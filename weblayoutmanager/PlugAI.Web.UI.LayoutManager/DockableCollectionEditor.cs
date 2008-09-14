using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PlugAI.Web.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DockableCollectionEditor : Form
    {
        #region Constants

        /// <summary>
        /// 
        /// </summary>
        private const int IMAGEINDEXNONE = 4;

        /// <summary>
        /// 
        /// </summary>
        private const int IMAGEINDEXLEFT = 5;

        /// <summary>
        /// 
        /// </summary>
        private const int IMAGEINDEXRIGHT = 6;

        /// <summary>
        /// 
        /// </summary>
        private const int IMAGEINDEXTOP = 7;

        /// <summary>
        /// 
        /// </summary>
        private const int IMAGEINDEXBOTTOM = 8;

        /// <summary>
        /// 
        /// </summary>
        private const int IMAGEINDEXFILL = 9;

        #endregion

        #region Variables

        /// <summary>
        /// 
        /// </summary>
        private IWindowsFormsEditorService editorService = null;

        /// <summary>
        /// 
        /// </summary>
        private enum Move
        {
            /// <summary>
            /// 
            /// </summary>
            Up = 0,
            /// <summary>
            /// 
            /// </summary>
            Down,
            /// <summary>
            /// 
            /// </summary>
            Left,
            /// <summary>
            /// 
            /// </summary>
            Right
        }

        #endregion

        #region Constructor


        /// <summary>
        /// 
        /// </summary>
        public DockableCollectionEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="editorService"></param>
        public DockableCollectionEditor(DockableItemCollection items, IWindowsFormsEditorService editorService):this()
        {
            this.items = items;
            this.editorService = editorService;
        }


        #endregion

        #region Properties

        private DockableItemCollection items = null;
        /// <summary>
        /// 
        /// </summary>
        public DockableItemCollection Items 
        {
            get
            {
                if (items == null)
                {
                    items = new DockableItemCollection();
                }
                return items;
            }
            set
            {
                items = value;
            }
        }

        #endregion        

        #region Methods

        #region Private

        /// <summary>
        /// 
        /// </summary>
        private void LoadItems()
        {            
            foreach (DockableItem item in this.Items)
            {
                AddDockableItem(item, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parent"></param>
        private void AddDockableItem(DockableItem item, TreeNode parent)
        {
            TreeNode node = new TreeNode(item.ToString());
            node.Tag = item;

            ChangeNodeIcon(node, item.Dock);

            // First node
            if (parent == null)
            {
                trvDockableItems.Nodes.Add(node);
            }
            else
            {
                parent.Nodes.Add(node);
            }

            

            foreach (DockableItem childItem in item.Items)
            {
                AddDockableItem(childItem, node);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedNode"></param>
        private void UpdateViewAfterSelectionChange(TreeNode selectedNode)
        {
            prgDockableItemProperties.SelectedObject = selectedNode.Tag;
            lblGridLabel.Text = selectedNode.Tag.ToString() + " properties :";
            
            bool canMoveRight = (selectedNode.Index != 0);
            bool canMoveLeft = (selectedNode.Parent != null);
            bool canMoveTop = (selectedNode.Index > 0);
            bool canMoveBottom = (selectedNode.NextNode != null);

            btnUp.Enabled = canMoveTop;
            btnDown.Enabled = canMoveBottom;
            btnLeft.Enabled = canMoveLeft;
            btnRight.Enabled = canMoveRight;
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddNewDockableItem()
        {
            DockableItem dockableItem = new DockableItem();

            TreeNode node = new TreeNode(dockableItem.ToString(), IMAGEINDEXNONE, IMAGEINDEXNONE);
            node.Tag = dockableItem;

            if (trvDockableItems.SelectedNode != null)
            {
                (trvDockableItems.SelectedNode.Tag as DockableItem).Items.Add(dockableItem);
                trvDockableItems.SelectedNode.Nodes.Add(node);
            }
            else
            {
                this.items.Add(dockableItem);
                trvDockableItems.Nodes.Add(node);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="move"></param>
        private void MoveItem(TreeNode node, Move move)
        {

            trvDockableItems.BeginUpdate();
            
            switch (move)
            {
                case Move.Up:
                    SwapNodes(node, node.PrevNode,true);                    
                    break;
                case Move.Down:
                    SwapNodes(node.NextNode, node, false);
                    break;
                case Move.Left:
                    MoveNodeLeft(node);
                    break;
                case Move.Right:
                    MoveNodeRight(node);
                    break;
                default:
                    break;
            }

         
            trvDockableItems.EndUpdate();


           
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private void SwapNodes(TreeNode first, TreeNode second)
        {
            // First index will always greater than the second index.
            // So when removing we remove the item at first index then second index,
            // but when inserting just do the reverse.

            int firstIndex = first.Index;
            int secondIndex = second.Index;
            DockableItem firstItem = (first.Tag as DockableItem);
            DockableItem secondItem = (second.Tag as DockableItem);

           

            // assumes both are in same level
            if (first.Parent != null)
            {
                TreeNode parentNode = first.Parent;
                DockableItemCollection itemCollection = (parentNode.Tag as DockableItem).Items;

                itemCollection.RemoveAt(firstIndex);
                itemCollection.RemoveAt(secondIndex);

                itemCollection.Insert(secondIndex, firstItem);
                itemCollection.Insert(firstIndex, secondItem);

                parentNode.Nodes.RemoveAt(firstIndex);
                parentNode.Nodes.RemoveAt(secondIndex);

                parentNode.Nodes.Insert(secondIndex, first);
                parentNode.Nodes.Insert(firstIndex, second);                     
               
                
            }
            else
            {
                this.Items.RemoveAt(firstIndex);
                this.Items.RemoveAt(secondIndex);

                this.Items.Insert(secondIndex, firstItem);
                this.Items.Insert(firstIndex, secondItem);
                

                trvDockableItems.Nodes.RemoveAt(firstIndex);
                trvDockableItems.Nodes.RemoveAt(secondIndex);

                trvDockableItems.Nodes.Insert(secondIndex, first);
                trvDockableItems.Nodes.Insert(firstIndex, second);
                
            }

          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="selectFirst"></param>
        private void SwapNodes(TreeNode first, TreeNode second, bool selectFirst)
        {
            SwapNodes(first, second);
            if (selectFirst)
            {
                trvDockableItems.SelectedNode = first;
            }
            else
            {
                trvDockableItems.SelectedNode = second;
            }
            trvDockableItems.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        private void MoveNodeRight(TreeNode node)
        {
            int nodeIndex = node.Index;
            DockableItem nodeItem = (node.Tag as DockableItem);
            TreeNode prevNode = node.PrevNode;

            if (node.Parent != null)
            {
                (node.Parent.Tag as DockableItem).Items.RemoveAt(nodeIndex);
                node.Parent.Nodes.RemoveAt(nodeIndex);
            }
            else
            {
                this.Items.RemoveAt(nodeIndex);
                trvDockableItems.Nodes.RemoveAt(nodeIndex);
            }
            (prevNode.Tag as DockableItem).Items.Add(nodeItem);
            prevNode.Nodes.Add(node);


            trvDockableItems.SelectedNode = node;
            trvDockableItems.Focus();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        private void MoveNodeLeft(TreeNode node)
        {
            int nodeIndex = node.Index;
            DockableItem nodeItem = (node.Tag as DockableItem);
            TreeNode parentNode = node.Parent;

            (node.Parent.Tag as DockableItem).Items.RemoveAt(nodeIndex);
            node.Parent.Nodes.RemoveAt(nodeIndex);

            if (parentNode.Parent != null)
            {
                TreeNode grandParent = parentNode.Parent;
                (grandParent.Tag as DockableItem).Items.Add(nodeItem);
                grandParent.Nodes.Add(node);
            }
            else
            {
                this.Items.Add(nodeItem);
                trvDockableItems.Nodes.Add(node);
            }

            trvDockableItems.SelectedNode = node;
            trvDockableItems.Focus();
        }


        /// <summary>
        /// 
        /// </summary>
        private void RemoveDockableItem()
        {
            if (trvDockableItems.SelectedNode != null)
            {
                DockableItem dockableItem = trvDockableItems.SelectedNode.Tag as DockableItem;
                if (trvDockableItems.SelectedNode.Parent != null)
                {
                    (trvDockableItems.SelectedNode.Parent.Tag as DockableItem).Items.Remove(dockableItem);
                }
                else
                {
                    this.Items.Remove(dockableItem);
                }
                trvDockableItems.SelectedNode.Remove();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        private void ChangeNodeIcon(TreeNode node, PlugAI.Web.UI.Dock newDockVal)
        {
            int imageIndex = IMAGEINDEXNONE;
            switch (newDockVal)
            {
                case PlugAI.Web.UI.Dock.None:
                    imageIndex = IMAGEINDEXNONE;
                    break;
                case PlugAI.Web.UI.Dock.Top:
                    imageIndex = IMAGEINDEXTOP;
                    break;
                case PlugAI.Web.UI.Dock.Bottom:
                    imageIndex = IMAGEINDEXBOTTOM;
                    break;
                case PlugAI.Web.UI.Dock.Left:
                    imageIndex = IMAGEINDEXLEFT;
                    break;
                case PlugAI.Web.UI.Dock.Right:
                    imageIndex = IMAGEINDEXRIGHT;
                    break;
                case PlugAI.Web.UI.Dock.Fill:
                    imageIndex = IMAGEINDEXFILL;
                    break;
                default:
                    throw new ArgumentException("Invalid argument");
                    break;
            }
            node.SelectedImageIndex = imageIndex;
            node.ImageIndex = imageIndex;
            
        }

        #endregion

       

        #endregion

        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockableCollectionEditor_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDockableItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateViewAfterSelectionChange(e.Node);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewDockableItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveDockableItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void prgDockableItemProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            trvDockableItems.BeginUpdate();

            if (trvDockableItems.SelectedNode != null)
            {
                trvDockableItems.SelectedNode.Text = trvDockableItems.SelectedNode.Tag.ToString();
                if (e.ChangedItem.Value is PlugAI.Web.UI.Dock)
                {
                    ChangeNodeIcon(trvDockableItems.SelectedNode, (PlugAI.Web.UI.Dock)e.ChangedItem.Value);
                }
            }

            trvDockableItems.EndUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveItem(trvDockableItems.SelectedNode, Move.Up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveItem(trvDockableItems.SelectedNode, Move.Left);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveItem(trvDockableItems.SelectedNode, Move.Right);
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveItem(trvDockableItems.SelectedNode, Move.Down);
        }

        #endregion

       

        

        

    }
}
