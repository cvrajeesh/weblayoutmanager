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
    public class DockableCollectionUITypeEditor : UITypeEditor
    {

        private IWindowsFormsEditorService editorService = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
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
                DockableItemCollection items = value as DockableItemCollection;
                if (items == null)
                {
                    items = new DockableItemCollection();
                }
                DockableCollectionEditor itemEditor = new DockableCollectionEditor(items, editorService);
                editorService.ShowDialog(itemEditor);
                value = itemEditor.Items;
                context.OnComponentChanged();
            }

            return value;
        }

    }
}
