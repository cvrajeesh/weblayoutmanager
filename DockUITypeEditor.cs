using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace PlugAI.Web.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class DockUITypeEditor : UITypeEditor
    {

        private IWindowsFormsEditorService editorService = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="provider"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            }

            if (editorService != null)
            {
                Dock dock = (Dock)value;                
                DockEditor itemEditor = new DockEditor(dock, editorService);
                editorService.DropDownControl(itemEditor);
                value = itemEditor.DockStyle;
                context.OnComponentChanged();
            }

            return value;
        }

    }
}
