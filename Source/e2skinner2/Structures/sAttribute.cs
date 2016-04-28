using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using OpenSkinDesigner.Logic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace OpenSkinDesigner.Structures
{
    public class sAttribute
    {
        public class PositionConverter : TypeConverter
        {
            public PositionConverter() { }

            public override bool CanConvertFrom(  ITypeDescriptorContext context,
                                                Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;

                return base.CanConvertTo(context, sourceType);
            }

            public override bool CanConvertTo(   ITypeDescriptorContext context,
                                                Type destinationType)
            {
                if (destinationType == typeof(string))
                    return true;

                if (destinationType == typeof(InstanceDescriptor))
                    return true;

                return (bool)base.ConvertTo(context, destinationType);
            }

            

            public override object ConvertFrom(ITypeDescriptorContext context,
                              CultureInfo culture, 
                              object value) 
            {
                if (value is string) {
                    try {
                        string s = (string) value;
                        int comma = s.IndexOf(',');
                        if (comma != -1) {
                            string X = s.Substring(0, comma);
                            string Y = s.Substring(comma + 1).Trim();

                            //Test if valid input
                            if (!X.Equals("center"))
                                Int32.Parse(X);
                            if (!Y.Equals("center"))
                                Int32.Parse(Y);

                            Position po = new Position();
                            po.X = X;
                            po.Y = Y;
                            return po;
                        }
                    }
                    catch {
                        throw new ArgumentException(
                            " '" + (string)value + " is not valid input!");
                    }
                }  
                return base.ConvertFrom(context, culture, value);
            }

            public override object ConvertTo(ITypeDescriptorContext context,
                          CultureInfo culture,
                          object value,
                          Type destinationType)
            {
                if (culture == null)
                    culture = CultureInfo.CurrentCulture;
                // LAMESPEC: "The default implementation calls the object's
                // ToString method if the object is valid and if the destination
                // type is string." MS does not behave as per the specs.
                // Oh well, we have to be compatible with MS.
                if (value is Point)
                {
                    Position point = (Position)value;
                    if (destinationType == typeof(string))
                    {
                        return point.X.ToString(culture) + culture.TextInfo.ListSeparator
                            + " " + point.Y.ToString(culture);
                    }
                    else if (destinationType == typeof(InstanceDescriptor))
                    {
                        ConstructorInfo ctor = typeof(Position).GetConstructor(new Type[] { typeof(int), typeof(int) });
                        return new InstanceDescriptor(ctor, new object[] { point.X, point.Y });
                    }
                }

                return base.ConvertTo(context, culture, value, destinationType);
            }

            public override object CreateInstance(ITypeDescriptorContext context,
                               IDictionary propertyValues)
            {
                Object _x = propertyValues["X"];
                Object _y = propertyValues["Y"];
                String X = _x.ToString();
                String Y = _y.ToString();

                try
                {
                    //Test if valid input
                    if (!X.Equals("center"))
                        Int32.Parse(X);
                    if (!Y.Equals("center"))
                        Int32.Parse(Y);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Position po = new Position();
                po.X = X;
                po.Y = Y;
                return po;
            }

            public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override PropertyDescriptorCollection GetProperties(
                                ITypeDescriptorContext context,
                                object value, Attribute[] attributes)
            {
                if (value is Position)
                    return TypeDescriptor.GetProperties(value, attributes);

                return base.GetProperties(context, value, attributes);
            }

            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

        }

        [TypeConverterAttribute(typeof(PositionConverter/*ExpandableObjectConverter*/))]
        public class Position
        {
            public Position() { X = "0"; Y = "0"; }
            public Position(Size sz) { X = sz.Width.ToString(); Y = sz.Height.ToString(); }
            public Position(int x, int y) { X = x.ToString(); Y = y.ToString(); }
            public Position(String x, String y) { X = x; Y = y; }

            public String X { get; set; }
            public String Y { get; set; }

            public Int32 iX() { return Int32.Parse(X); }
            public Int32 iY() { return Int32.Parse(Y); }

            public override string ToString() { return X + "," + Y; }
        }

        private const String entryName = "1 Global";

        private sAttribute _pParent = null;
        private Int32 _pAbsolutX;
        private Int32 _pAbsolutY;

        [BrowsableAttribute(false)]
        public sAttribute Parent
        {
            get { return _pParent; }
        }

        [BrowsableAttribute(false)]
        public Int32 pAbsolutX
        {
            get { return pRelativX + (_pParent != null ? _pParent.pAbsolutX : 0); }
            set { _pAbsolutX = value; }
        }

        [BrowsableAttribute(false)]
        public Int32 pAbsolutY
        {
            get { return pRelativY + (_pParent != null ? _pParent.pAbsolutY : 0); }
            set { _pAbsolutY = value; }
        }
        public Int32 pRelativX;
        public Int32 pRelativY;
        public Int32 pWidth;
        public Int32 pHeight;

        public String pName;

        public Int32 pZPosition;
        public bool pTransparent;

        //Border around Element, is this allowed for every element ?
        public bool pBorder;
        public UInt32 pBorderWidth;
        public sColor pBorderColor;

        [CategoryAttribute(entryName),
        DefaultValueAttribute("")]
        public String Name
        {
            get { return pName; }
            set { 
                pName = value;
                if (pName != null && pName.Length > 0)
                {
                    if (myNode.Attributes["name"] != null)
                        myNode.Attributes["name"].Value = pName;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("name"));
                        myNode.Attributes["name"].Value = pName;
                    }
                }
                else
                    if (myNode.Attributes["name"] != null)
                        myNode.Attributes.RemoveNamedItem("name");
            }
        }

        [CategoryAttribute(entryName)]
        public Position Relativ
        {
            get
            {
                String x = pRelativX.ToString(), y = pRelativY.ToString();
                //if (pRelativX == (cDataBase.pResolution.getResolution().Xres - pWidth) >> 1 /*1/2*/)
                  //  x = "center";
                //if (pRelativY == (cDataBase.pResolution.getResolution().Yres - pHeight) >> 1 /*1/2*/)
                  //  y = "center";
                return new Position(x, y); }
            set {

                Int32 vX = 0;
                Int32 vY = 0;
                if (value.X.Equals("center"))
                    vX = (Int32)(cDataBase.pResolution.getResolution().Xres - pWidth) >> 1 /*1/2*/;
                else
                    vX = (Int32)value.iX();
                if (value.Y.Equals("center"))
                    vY = (Int32)(cDataBase.pResolution.getResolution().Yres - pHeight) >> 1 /*1/2*/;
                else
                    vY = (Int32)value.iY();

                pAbsolutX = pAbsolutX + ((Int32)vX - pRelativX);
                pRelativX = (Int32)vX;
                pAbsolutY = pAbsolutY + ((Int32)vY - pRelativY);
                pRelativY = (Int32)vY;



                if (myNode.Attributes["position"] != null)
                    myNode.Attributes["position"].Value = value.X + "," + value.Y;
                else
                {
                    myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("position"));
                    myNode.Attributes["position"].Value = pRelativX + "," + pRelativY;
                }
            }
        }

        [CategoryAttribute(entryName),
        ReadOnlyAttribute(true)]
        public Point Absolut
        {
            get { return new Point((int)pAbsolutX, (int)pAbsolutY); }
            //set { pAbsolutX = (UInt32)value.X; pAbsolutY = (UInt32)value.Y; }
        }

        [CategoryAttribute(entryName),
        ReadOnlyAttribute(true)]
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)pAbsolutX, (int)pAbsolutY, pWidth, pHeight); }
            //set { pAbsolutX = (UInt32)value.X; pAbsolutY = (UInt32)value.Y; }
        }

        [CategoryAttribute(entryName)]
        public Size Size
        {
            get { return new Size((int)pWidth, (int)pHeight); }
            set { 
                pWidth = (Int32)value.Width; 
                pHeight = (Int32)value.Height;

                if (myNode.Attributes["size"] != null)
                    myNode.Attributes["size"].Value = pWidth + "," + pHeight;
                else
                {
                    myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("size"));
                    myNode.Attributes["size"].Value = pWidth + "," + pHeight;
                }
            }
        }

        [CategoryAttribute(entryName)]
        public Int32 zPosition
        {
            get { return pZPosition; }
            set { 
                pZPosition = value;

                if (myNode.Attributes["zPosition"] != null)
                    myNode.Attributes["zPosition"].Value = pZPosition.ToString();
                else
                {
                    myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("zPosition"));
                    myNode.Attributes["zPosition"].Value = pZPosition.ToString();
                }
            }
        }

        [CategoryAttribute(entryName)]
        public bool Transparent
        {
            get { return pTransparent; }
            set { 
                pTransparent = value;

                if (myNode.Attributes["transparent"] != null)
                    myNode.Attributes["transparent"].Value = pTransparent?"1":"0";
                else
                {
                    myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("transparent"));
                    myNode.Attributes["transparent"].Value = pTransparent ? "1" : "0";
                }
            }
        }

        [CategoryAttribute(entryName)]
        public UInt32 BorderWidth
        {
            get { return pBorderWidth; }
            set {   
                pBorderWidth = value;
                if (pBorderWidth > 0 && pBorderColor != null)
                    pBorder = true;
                else
                    pBorder = false;

                if (pBorder)
                {
                    if (myNode.Attributes["borderWidth"] != null)
                        myNode.Attributes["borderWidth"].Value = pBorderWidth.ToString();
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("borderWidth"));
                        myNode.Attributes["borderWidth"].Value = pBorderWidth.ToString();
                    }

                    if (myNode.Attributes["borderColor"] != null)
                        myNode.Attributes["borderColor"].Value = pBorderColor.pName;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("borderColor"));
                        myNode.Attributes["borderColor"].Value = pBorderColor.pName;
                    }
                }
                else
                {
                    if (myNode.Attributes["borderWidth"] != null)
                        myNode.Attributes.RemoveNamedItem("borderWidth");
                    if (myNode.Attributes["borderColor"] != null)
                        myNode.Attributes.RemoveNamedItem("borderColor");
                }
            }
        }

        [Editor(typeof(OpenSkinDesigner.Structures.cProperty.GradeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(OpenSkinDesigner.Structures.cProperty.sColorConverter)),
        CategoryAttribute(entryName)]
        public String BorderColor
        {
            get
            {
                if (pBorderColor != null) return pBorderColor.pName;
                else return "(none)";
            }
            set {
                if (value != null && value != "(none)")
                {
                    pBorderColor = (sColor)cDataBase.pColors.get(value);
                    if (/*pBorderWidth > 0 && */pBorderColor != null) //First set the color, asecond set the width
                        pBorder = true;
                    else
                        pBorder = false;
                }
                else
                {
                    pBorderColor = null;
                    pBorder = false;
                }

                if (pBorder)
                {
                    if (myNode.Attributes["borderWidth"] != null)
                        myNode.Attributes["borderWidth"].Value = pBorderWidth.ToString();
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("borderWidth"));
                        myNode.Attributes["borderWidth"].Value = pBorderWidth.ToString();
                    }

                    if (myNode.Attributes["borderColor"] != null)
                        myNode.Attributes["borderColor"].Value = pBorderColor.pName;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("borderColor"));
                        myNode.Attributes["borderColor"].Value = pBorderColor.pName;
                    }
                }
                else
                {
                    if (myNode.Attributes["borderWidth"] != null)
                        myNode.Attributes.RemoveNamedItem("borderWidth");
                    if (myNode.Attributes["borderColor"] != null)
                        myNode.Attributes.RemoveNamedItem("borderColor");
                }
            }
        }

        public XmlNode myNode;

        public sAttribute( sAttribute parent, XmlNode node)
        {
            if (node == null)
                return;

            myNode = node;

            _pParent = parent;

            try
            {
                pWidth = Convert.ToInt32(node.Attributes["size"].Value.Substring(0, node.Attributes["size"].Value.IndexOf(',')).Trim());
                pHeight = Convert.ToInt32(node.Attributes["size"].Value.Substring(node.Attributes["size"].Value.IndexOf(',') + 1).Trim());
            }
            catch
            {
                pWidth = (int)cDataBase.pResolution.getResolution().Xres;
                pHeight = (int)cDataBase.pResolution.getResolution().Yres;
            }
            

            try
            {
                String sRelativeX = node.Attributes["position"].Value.Substring(0, node.Attributes["position"].Value.IndexOf(',')).Trim();
                if (sRelativeX.Equals("center"))
                    pRelativX = (Int32)(cDataBase.pResolution.getResolution().Xres - pWidth) >> 1 /*1/2*/;
                else
                    pRelativX = Convert.ToInt32(sRelativeX);
            } catch
            {
                pRelativX = 0;
            }
            pAbsolutX = parent.pAbsolutX + pRelativX;

            try
            {
                String sRelativeY = node.Attributes["position"].Value.Substring(node.Attributes["position"].Value.IndexOf(',') + 1).Trim();
                if (sRelativeY.Equals("center"))
                    pRelativY = (Int32)(cDataBase.pResolution.getResolution().Yres - pHeight) >> 1 /*1/2*/;
                else
                    pRelativY = Convert.ToInt32(sRelativeY);
            }
            catch
            {
                pRelativY = 0;
            }
            pAbsolutY = parent.pAbsolutY + pRelativY;


            if (node.Attributes["name"] != null)
                pName = node.Attributes["name"].Value.Trim();
            else
                pName = "";

            if (node.Attributes["zPosition"] != null)
                pZPosition = Convert.ToInt32(node.Attributes["zPosition"].Value.Trim());
            else
                pZPosition = 0;

            if (node.Attributes["transparent"] != null)
                pTransparent = Convert.ToUInt32(node.Attributes["transparent"].Value.Trim()) != 0;
            else
                pTransparent = false;

            if (node.Attributes["borderWidth"] != null)
                pBorderWidth = Convert.ToUInt32(node.Attributes["borderWidth"].Value.Trim());
            else
                pBorderWidth = 0;

            if (node.Attributes["borderColor"] != null)
                pBorderColor = (sColor)cDataBase.pColors.get(node.Attributes["borderColor"].Value.Trim());
            else
                pBorderColor = null;

            if (pBorderWidth > 0 && pBorderColor != null)
                pBorder = true;
            else
                pBorder = false;
        }

        public sAttribute(XmlNode node)
        {
            if (node == null)
                return;

            myNode = node;
            if (node.Attributes["size"]!=null)
            {
                pWidth = Convert.ToInt32(node.Attributes["size"].Value.Substring(0, node.Attributes["size"].Value.IndexOf(',')).Trim());
                pHeight = Convert.ToInt32(node.Attributes["size"].Value.Substring(node.Attributes["size"].Value.IndexOf(',') + 1).Trim());
            }
            else
            {
                pWidth = (Int32)(cDataBase.pResolution.getResolution().Xres);
                pHeight = (Int32)(cDataBase.pResolution.getResolution().Yres);
            }
            if (node.Attributes["position"]!=null)
            {
                String sRelativeX = node.Attributes["position"].Value.Substring(0, node.Attributes["position"].Value.IndexOf(',')).Trim();
                if (sRelativeX.Equals("center"))
                    pRelativX = (Int32)(cDataBase.pResolution.getResolution().Xres - pWidth) >> 1 /*1/2*/;
                else
                    pRelativX = Convert.ToInt32(sRelativeX);
            }
            else//To display panels
            {
                pRelativX = 0;
            }
            pAbsolutX = pRelativX;

            if (node.Attributes["position"]!=null)
            {
                String sRelativeY = node.Attributes["position"].Value.Substring(node.Attributes["position"].Value.IndexOf(',') + 1).Trim();
                if (sRelativeY.Equals("center"))
                    pRelativY = (Int32)(cDataBase.pResolution.getResolution().Yres - pHeight) >> 1 /*1/2*/;
                else
                    pRelativY = Convert.ToInt32(sRelativeY);
            }
            else// To display panels
            {
                pRelativY = 0;
            }
            pAbsolutY = pRelativY;
                      

            if (node.Attributes["name"] != null)
                pName = node.Attributes["name"].Value.Trim();

            if (node.Attributes["zPosition"] != null)
                pZPosition = Convert.ToInt32(node.Attributes["zPosition"].Value.Trim());
            else
                pZPosition = 0;

            if (node.Attributes["transparent"] != null)
                pTransparent = Convert.ToUInt32(node.Attributes["transparent"].Value.Trim()) != 0;
            else
                pTransparent = false;

            if (node.Attributes["borderWidth"] != null)
                pBorderWidth = Convert.ToUInt32(node.Attributes["borderWidth"].Value.Trim());
            else
                pBorderWidth = 0;

            if (node.Attributes["borderColor"] != null)
                pBorderColor = (sColor)cDataBase.pColors.get(node.Attributes["borderColor"].Value.Trim());
            else
                pBorderColor = (sColor)cDataBase.pColors.get("transparent");

            if (pBorderWidth > 0 && pBorderColor != null)
                pBorder = true;
            else
                pBorder = false;

            if (node.Attributes["name"] != null && node.Attributes["position"] == null && node.Attributes["size"] == null && node.Name == "screen")
            {
                pTransparent = false;
            }
        }

        public sAttribute(Int32 x, Int32 y, Int32 width, Int32 height, String name)
        {
            pAbsolutX = x;
            pAbsolutY = y;
            pRelativX = x;
            pRelativY = y;
            pWidth = width;
            pHeight = height;

            pName = name;
        }
    }
}
