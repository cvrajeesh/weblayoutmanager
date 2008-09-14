using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing.Design;

namespace PlugAI.Web.UI
{
    /// <summary>
    /// Class that represents a collection of Dockable Items
    /// </summary>
    ///     
    [
    Editor(typeof(DockableCollectionUITypeEditor),typeof(UITypeEditor)),
    Serializable
    ]
    public class DockableItemCollection : List<DockableItem>, IJSONSerialize
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DockableItemCollection()
        {

        }

        #region IJSONSerialize Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            StringBuilder collectionString = new StringBuilder();
            if (this.Count > 0)
            {
                collectionString.Append("[");                
                for (int i = 0; i < this.Count - 1; i++)
                {
                    collectionString.Append(string.Format("{0},", this[i].Serialize()));
                }
                collectionString.Append(string.Format("{0}", this[this.Count-1].Serialize()));
                collectionString.Append("]");
            }

            return collectionString.ToString();
        }

        #endregion
    }
}
