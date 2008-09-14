using System;


namespace PlugAI.Web.UI
{
    /// <summary>
    /// Species the Docking attribute of a <see cref="DockableItem">DockableItem</see>.
    /// </summary>
    /// 
    public enum Dock
    {   
        /// <summary>
        /// None Dock
        /// </summary>
        [EnumDescription("$.layoutEngine.DOCK.NONE")]
        None = 0,
        /// <summary>
        /// Top Dock
        /// </summary>
        [EnumDescription("$.layoutEngine.DOCK.TOP")]
        Top,
        /// <summary>
        /// Bottom Dock
        /// </summary>
        [EnumDescription("$.layoutEngine.DOCK.BOTTOM")]
        Bottom,
        /// <summary>
        /// Left Dock
        /// </summary>
        [EnumDescription("$.layoutEngine.DOCK.LEFT")]
        Left,        
        /// <summary>
        /// Right Dock
        /// </summary>
        [EnumDescription("$.layoutEngine.DOCK.RIGHT")]
        Right,       
        /// <summary>
        /// Fill Dock
        /// </summary>
        [EnumDescription("$.layoutEngine.DOCK.FILL")]
        Fill
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    public enum VerticalAlign
    {
        /// <summary>
        /// Top Align
        /// </summary>
        [EnumDescription("$.layoutEngine.VALIGN.TOP")]
        Top = 0,
        /// <summary>
        /// Align Middle
        /// </summary>
        [EnumDescription("$.layoutEngine.VALIGN.MIDDLE")]
        Middle,
        /// <summary>
        /// Align Bottom
        /// </summary>
        [EnumDescription("$.layoutEngine.VALIGN.BOTTOM")]
        Bottom
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    public enum HorizontalAlign
    {
        /// <summary>
        /// Align Left
        /// </summary>
        [EnumDescription("$.layoutEngine.HALIGN.LEFT")]
        Left = 0,
        /// <summary>
        /// Align Center
        /// </summary>
        [EnumDescription("$.layoutEngine.HALIGN.CENTER")]
        Center,
        /// <summary>
        /// Align Right
        /// </summary>
        [EnumDescription("$.layoutEngine.HALIGN.RIGHT")]
        Right
    }


    /// <summary>
    /// Describes the enum.
    /// </summary>
    public class EnumDescription : Attribute
    {
        private string text;
        /// <summary>
        /// Gets Text property/
        /// </summary>
        public string Text 
        {
            get
            {
                return this.text;
            }
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text"></param>
        public EnumDescription(string text)
        {
            this.text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.text;
        }
    }

    /// <summary>
    /// Enumeration helper with extension method
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Extension method which return Enumeration description attribute value.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Description(this Enum val)
        {
            EnumDescription[] attributes = (EnumDescription[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(EnumDescription), false);
            return attributes.Length > 0 ? attributes[0].ToString() : string.Empty;
        }   
    }

}
