using System;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Web.UI;
using System.ComponentModel.Design;
using System.Collections;
using System.Text;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace PlugAI.Web.UI
{
    /// <summary>
    /// Class that represents a Dockable Item.
    /// </summary>
    ///
    [
    DefaultProperty("Items"),
    ParseChildren(true, "Items"),
    Serializable,
    TypeConverter(typeof(ExpandableObjectConverter))
    ]
    public class DockableItem :  IJSONSerialize
    {

        #region Private Variables
      

        #endregion

        #region Properties


        private string name;

        /// <summary>
        /// Gets or Sets the Name property.
        /// </summary>
        [
        NotifyParentProperty(true),
        Description("Indicate the name used in code to indentify the object.")
        ]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string elementID;
        /// <summary>
        /// 
        /// </summary>
        [NotifyParentProperty(true)]
        public string ElementID
        {
            get { return elementID; }
            set { elementID = value; }
        }


        private Dock dock = Dock.None;
        /// <summary>
        /// Gets or Sets the Dock.
        /// </summary>
        ///         
        [
        Editor(typeof(DockUITypeEditor),typeof(UITypeEditor)),
        NotifyParentProperty(true),
        DefaultValue(Dock.None)
        ]
        public Dock Dock 
        {
            get
            {
                return this.dock;
            }
            set
            {
                this.dock = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Width.
        /// </summary>
        /// 
        [
        NotifyParentProperty(true),
        DefaultValue(0)
        ]
        public int Width { get; set; }

        /// <summary>
        /// Gets or Sets the Height.
        /// </summary>
        /// 
        [
        NotifyParentProperty(true),
        DefaultValue(0)
        ]
        public int Height { get; set; }

        private DockableItemCollection items;

        /// <summary>
        /// Gets the Items.
        /// </summary>
        ///
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),        
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
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
        }


        private Margin margin;

        /// <summary>
        /// Gets or Sets Margin
        /// </summary>
        ///         
        public Margin Margin
        {
            get { return margin; }
            set { margin = value; }
        }
        

        private string heading;

        /// <summary>
        /// Gets or Sets the heading
        /// </summary>
        ///         
        public string Heading
        {
            get { return heading; }
            set { heading = value; }
        }

        private HorizontalAlign align;

        /// <summary>
        /// Gets or Sets the horizontal align.
        /// </summary>
        /// 
        [
        DefaultValue(HorizontalAlign.Left)
        ]
        public HorizontalAlign Align
        {
            get { return align; }
            set { align = value; }
        }

        private VerticalAlign vAlign;

        /// <summary>
        /// Gets or Sets the vertical align.
        /// </summary>
        /// 
        [
        DefaultValue(VerticalAlign.Top)
        ]
        public VerticalAlign VAlign
        {
            get { return vAlign; }
            set { vAlign = value; }
        }
        
        
        

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public DockableItem()
        {
            
           
        }

        #endregion

        #region Overridden

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(this.Name) ?
                (string.IsNullOrEmpty(this.ElementID) ? base.ToString() : this.ElementID) : this.Name;
        }

        #endregion

        #region IJSONSerialize Members
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            StringBuilder json = new StringBuilder();

            json.Append("{");
            
            json.Append(string.Format("Name:\"{0}\"", this.Name));

            if (!string.IsNullOrEmpty(this.Heading))
            {
                json.Append(string.Format(",Heading:\"{0}\"", HttpUtility.HtmlEncode(this.Heading)));
            }

            if (Dock == Dock.None)
            {
                json.Append(string.Format(",Align:{0}", this.Align.Description()));
                json.Append(string.Format(",VAlign:{0}", this.VAlign.Description()));
            }

            json.Append(string.Format(",EleID:\"{0}\"", this.ElementID));

            // Set margin
            if (this.Margin.AllSame)
            {
                if (this.Margin.Any != 0)
                {
                    json.Append(string.Format(",Margin:{0}", this.Margin.Any.ToString()));
                }
            }
            else
            {
                if (this.Margin.Left != 0)
                {
                    json.Append(string.Format(",MarginLeft:{0}", this.Margin.Left.ToString()));
                }
                if (this.Margin.Top != 0)
                {
                    json.Append(string.Format(",MarginTop:{0}", this.Margin.Top.ToString()));
                }
                if (this.Margin.Right != 0)
                {
                    json.Append(string.Format(",MarginRight:{0}", this.Margin.Right.ToString()));
                }
                if (this.Margin.Bottom != 0)
                {
                    json.Append(string.Format(",MarginBottom:{0}", this.Margin.Bottom.ToString()));
                }
            }

            json.Append(string.Format(",Dock:{0}", this.Dock.Description()));
            if (this.Width > 0)
            {
                json.Append(string.Format(",Width:{0}", this.Width.ToString()));
            }
            if (this.Height > 0)
            {
                json.Append(string.Format(",Height:{0}", this.Height.ToString()));
            }

            if (items != null && items.Count > 0)
            {
                json.Append(string.Format(",Children:{0}", items.Serialize()));
            }

            json.Append("}");

            return json.ToString();

        }

        #endregion

        
    }
}
