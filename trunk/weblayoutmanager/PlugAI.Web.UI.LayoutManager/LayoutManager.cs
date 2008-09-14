using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Drawing;

#region Assembly

[assembly: TagPrefix("PlugAI.Web.UI", "PlugAI")]

#if DEBUG
[assembly: WebResource("PlugAI.Web.UI.scripts.jquery-1.2.6.js", "text/Javascript")]
[assembly: WebResource("PlugAI.Web.UI.scripts.jquery.layoutengine.js", "text/Javascript")]
#else
[assembly: WebResource("PlugAI.Web.UI.scripts.jquery-1.2.6.pack.js", "text/Javascript")]
[assembly: WebResource("PlugAI.Web.UI.scripts.jquery.layoutengine.min.js", "text/Javascript")]
#endif

#endregion

namespace PlugAI.Web.UI
{
    
    /// <summary>
    /// A control that helps you to manage the layout of a web form, similar to windows forms.
    /// </summary>
    [   
    ToolboxData("<{0}:LayoutManager runat=server></{0}:LayoutManager>"),
    ToolboxBitmap(typeof(Button), "PlugAI.Web.UI.LayoutManager.bmp"),
    Designer(typeof(LayoutManagerControlDesigner)),    
    DefaultProperty("Items"),
    ParseChildren(true,"Items")
    ]
    public class LayoutManager : WebControl
    {
        #region Constants

#if DEBUG

        private const string JQUERYSCRIPT = "PlugAI.Web.UI.scripts.jquery-1.2.6.js";
        private const string LAYOUTEXTSCRIPT = "PlugAI.Web.UI.scripts.jquery.layoutengine.js";
    
#else
        private const string JQUERYSCRIPT = "PlugAI.Web.UI.scripts.jquery-1.2.6.pack.js";
        private const string LAYOUTEXTSCRIPT = "PlugAI.Web.UI.scripts.jquery.layoutengine.min.js";

#endif



        #endregion


        #region Properties

        private DockableItemCollection items;

        /// <summary>
        /// Gets the Items.
        /// </summary>
        ///
        [
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),        
        PersistenceMode(PersistenceMode.InnerProperty),
        RefreshProperties(RefreshProperties.All)
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

        /// <summary>
        /// Gets or Sets whether the JQuery is already linked or not.
        /// </summary>
        /// 
        [DefaultValue(false)]
        public bool JQueryAlreadyAdded { get; set; }

        #region Overridden

        /// <summary>
        /// Gets the HTML tag for the <see cref="LayoutManager">LayoutManager</see> control
        /// </summary>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Script;
            }
        }

        #endregion

        #endregion


        #region Methods

        #region Overridden

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

          

            if (!JQueryAlreadyAdded)
            {
                string jqueryUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), JQUERYSCRIPT);
                this.Page.ClientScript.RegisterClientScriptInclude("JQuery-1-2-6", jqueryUrl);
            }
            string layoutExtUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), LAYOUTEXTSCRIPT);           
            this.Page.ClientScript.RegisterClientScriptInclude("Layoyt-ext", layoutExtUrl);

        }


        /// <summary>
        /// Renders the script attributes to opening tag of the <see cref="LayoutManager">LayoutManager</see> control to the specified <see cref="HtmlTextWriter">HtmlTextWriter</see>.
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.AddAttribute("language", "javascript");
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            base.RenderBeginTag(writer);
        }

        /// <summary>
        /// Render the javascript required for the layout into the specified <see cref="HtmlTextWriter">HtmlTextWriter</see>.
        /// </summary>
        /// <param name="output"></param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.Append("var layoutSettings = " + Items[0].Serialize() + ";");
            scriptBuilder.Append(@"$(document).ready(function(){");
            scriptBuilder.Append(@" $.layoutEngine(layoutSettings);");
            scriptBuilder.Append(@"});");

            output.Write(scriptBuilder.ToString());

        }

        

        #endregion

        #endregion

       
    }
}
