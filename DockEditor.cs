using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PlugAI.Web.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DockEditor : UserControl
    {

        #region Variables

        /// <summary>
        /// 
        /// </summary>
        private IWindowsFormsEditorService editorService = null;

        #endregion

        #region Constructor
       

        /// <summary>
        /// 
        /// </summary>
        public DockEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dock"></param>
        /// <param name="editorService"></param>
        public DockEditor(Dock dock, IWindowsFormsEditorService editorService)
            : this()
        {
            this.DockStyle = dock;
            this.editorService = editorService;
        }

        #endregion

        #region Properties

        private Dock dockStyle;

        /// <summary>
        /// 
        /// </summary>
        public Dock DockStyle
        {
            get { return dockStyle; }
            set 
            { 
                dockStyle = value;
                ChangeDock(value);
            }
        }
        

        #endregion

        #region Methods

        #region Private

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dock"></param>
        private void ChangeDock(PlugAI.Web.UI.Dock dock)
        {
            chbBottom.Checked = false;
            chbFill.Checked = false;
            chbLeft.Checked = false;
            chbNone.Checked = false;
            chbRight.Checked = false;
            chbTop.Checked = false;
            switch (dock)
            {
                case PlugAI.Web.UI.Dock.None:
                    chbNone.Checked = true;
                    break;
                case PlugAI.Web.UI.Dock.Top:
                    chbTop.Checked = true;
                    break;
                case PlugAI.Web.UI.Dock.Bottom:
                    chbBottom.Checked = true;
                    break;
                case PlugAI.Web.UI.Dock.Left:
                    chbLeft.Checked = true;
                    break;
                case PlugAI.Web.UI.Dock.Right:
                    chbRight.Checked = true;
                    break;
                case PlugAI.Web.UI.Dock.Fill:
                    chbFill.Checked = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void TearDown()
        {
            this.editorService.CloseDropDown();
        }
        
        #endregion

       

        #endregion

        #region Event Handlers


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chb_Click(object sender, EventArgs e)
        {
            this.DockStyle = (Dock)(sender as CheckBox).Dock;
            TearDown();
        }

        

        #endregion

        

    }
}
