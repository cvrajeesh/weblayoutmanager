using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.Design;

namespace PlugAI.Web.UI
{
    /// <summary>
    /// Designer class for extending the design time behaviour of the <see cref="LayoutManager">LayoutManager</see> control.
    /// </summary>
    public class LayoutManagerControlDesigner : ControlDesigner
    {
        
        #region Methods

        #region Overridden

        /// <summary>
        /// Gets the markup that is used to represent the <see cref="LayoutManager">LayoutManager</see> control at design time.
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            return "[LayoutManager Control]";
        }

        #endregion

        #endregion
    }
}
