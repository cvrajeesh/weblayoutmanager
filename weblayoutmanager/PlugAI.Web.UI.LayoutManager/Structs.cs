using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.Design.Serialization;

namespace PlugAI.Web.UI
{
    /// <summary>
    /// 
    /// </summary>
    [
    TypeConverter(typeof(MarginTypeConvert)),
    Serializable
    ]
    public struct Margin
    {
        private int left;

        /// <summary>
        /// 
        /// </summary>
        /// 
        [DefaultValue(0)]
        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        private int right;

        /// <summary>
        /// 
        /// </summary>
        /// 
        [DefaultValue(0)]
        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        private int bottom;

        /// <summary>
        /// 
        /// </summary>
        /// 
        [DefaultValue(0)]
        public int Bottom
        {
            get { return bottom; }
            set { bottom = value; }
        }

        private int top;

        /// <summary>
        /// 
        /// </summary>
        /// 
        [DefaultValue(0)]
        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        /// <summary>
        /// Gets a margin. Use only when AllSame property is true.
        /// </summary>
        [
        Browsable(false),
        DefaultValue(0)
        ]
        public int Any
        {
            get
            {
                return this.Left;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [
        Browsable(false),
        DefaultValue(false)
        ]
        public bool AllSame
        {
            get
            {
                if ((Left == Right) && (Left == Top) && (Left == Bottom))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="all"></param>
        public Margin(int all)
        {
            this.top = this.left = this.right = this.bottom = all;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public Margin(int left, int top, int right, int bottom)
        {
            this.top = top;
            this.left = left;
            this.bottom = bottom;
            this.right = right;
        }

        /// <summary>
        /// Returns comma separated values of Top, Left, Bottom, Right
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", Left, Top, Right, Bottom);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MarginTypeConvert : ExpandableObjectConverter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            string actualValue = value as string;
            if (actualValue == null)
            {
                return base.ConvertFrom(context, culture, value);
            }

            string[] values = actualValue.Trim().Split(new char[] { ',' });
            int[] propValues = new int[values.Length];
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            if (values.Length == 1)
            {
                int val = (int)converter.ConvertFromString(context, culture, values[0]);
                return new Margin(val, val, val, val);
            }
            else
            {
                for (int i = 0; i < values.Length; i++)
                {
                    propValues[i] = (int)converter.ConvertFromString(context, culture, values[i]);
                }

                return new Margin(propValues[0], propValues[1], propValues[2], propValues[3]);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {

            if (value is Margin)
            {
                if (destinationType == typeof(string))
                {
                    Margin margin = (Margin)value;
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                    string[] str = new string[4];
                    int index = 0;
                    str[index++] = converter.ConvertToString(context, culture, margin.Left);
                    str[index++] = converter.ConvertToString(context, culture, margin.Top);
                    str[index++] = converter.ConvertToString(context, culture, margin.Right);
                    str[index++] = converter.ConvertToString(context, culture, margin.Bottom);
                    return string.Join(",", str);
                }
                else if (destinationType == typeof(InstanceDescriptor))
                {
                    Margin margin = (Margin)value;
                    return new InstanceDescriptor(
                        typeof(Margin).GetConstructor(
                        new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) }),
                        new object[] { margin.Left, margin.Top, margin.Right, margin.Bottom });
                }
                else
                {
                    // Nothing
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="propertyValues"></param>
        /// <returns></returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            return
                new Margin(
                    (int)propertyValues["Top"],
                    (int)propertyValues["Left"],
                    (int)propertyValues["Bottom"],
                    (int)propertyValues["Right"]
                    );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(Margin), attributes).Sort(new string[] { "Left", "Top", "Right", "Bottom" });
        }

    }
}
