using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel;
using OpenSkinDesigner.Logic;

namespace OpenSkinDesigner.Structures
{
    class sAttributeProgress : sAttribute
    {
        private const String entryName = "Progress";

        public sColor pBackgroundColor;

        [Editor(typeof(OpenSkinDesigner.Structures.cProperty.GradeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(OpenSkinDesigner.Structures.cProperty.sColorConverter)),
        CategoryAttribute(entryName)]
        public String BackgroundColor
        {
            get { return pBackgroundColor.pName; }
            set {
                if (value != null)
                    pBackgroundColor = (sColor)cDataBase.pColors.get(value);
                else
                    pBackgroundColor = null;

                if (pBackgroundColor != null && pBackgroundColor != (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["Background"])
                {
                    if (myNode.Attributes["backgroundColor"] != null)
                        myNode.Attributes["backgroundColor"].Value = pBackgroundColor.pName;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("backgroundColor"));
                        myNode.Attributes["backgroundColor"].Value = pBackgroundColor.pName;
                    }
                }
                else
                    if (myNode.Attributes["backgroundColor"] != null)
                        myNode.Attributes.RemoveNamedItem("backgroundColor");
            }
        }

        public sAttributeProgress(sAttribute parent, XmlNode node)
            : base(parent, node)
        {

            if (node.Attributes["backgroundColor"] != null)
                pBackgroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            else
                pBackgroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["Background"];
        }
    }
}
