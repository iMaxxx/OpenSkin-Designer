using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using OpenSkinDesigner.Logic;
using System.Drawing;
using System.ComponentModel;

namespace OpenSkinDesigner.Structures
{
    public class sAttributeScreen : sAttribute
    {
        private const String entryName = "2 Screen";

        public String pTitle;
        public float pTitleSize;
        public sFont pTitleFont;
        public Int32 pTitleXOff;
        public Int32 pTitleYOff;

        public sColor pBackgroundColor;
        public enum eFlags { wfBorder, wfNoBorder };
        public eFlags pFlags;
        private sWindowStyle pWindowStyle;

        public sColor pLabelForegroundColor;

        public Size pbpTopLeft;
        public Size pbpTop;
        public Size pbpTopRight;
        public Size pbpLeft;
        public Size pbpRight;
        public Size pbpBottomLeft;
        public Size pbpBottom;
        public Size pbpBottomRight;

        public String pbpTopLeftName;
        public String pbpTopName;
        public String pbpTopRightName;
        public String pbpLeftName;
        public String pbpRightName;
        public String pbpBottomLeftName;
        public String pbpBottomName;
        public String pbpBottomRightName;

        [CategoryAttribute("1 Global"),
       DefaultValueAttribute(""),
        ReadOnlyAttribute(true)]
        public new String Name
        {
            get { return pName; }
            set
            {
                pName = value;
                if (pName == null)
                    pName = "unknown";

                if (myNode.Attributes["title"] != null)
                    myNode.Attributes["title"].Value = pTitle;
                else
                {
                    myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("title"));
                    myNode.Attributes["title"].Value = pTitle;
                }
            }
        }

        [CategoryAttribute(entryName),
        DefaultValueAttribute("")]
        public String Title
        {
            get { return pTitle; }
            set
            {
                pTitle = value;
                if (pTitle != null && pTitle.Length > 0)
                {
                    if (myNode.Attributes["title"] != null)
                        myNode.Attributes["title"].Value = pTitle;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("title"));
                        myNode.Attributes["title"].Value = pTitle;
                    }
                }
                else
                    if (myNode.Attributes["title"] != null)
                        myNode.Attributes.RemoveNamedItem("title");
            }
        }

        [Editor(typeof(OpenSkinDesigner.Structures.cProperty.GradeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(OpenSkinDesigner.Structures.cProperty.sColorConverter)),
        CategoryAttribute(entryName)]
        public String BackgroundColor
        {
            get { return pBackgroundColor.pName; }
            set
            {
                if (value != null)
                    pBackgroundColor = (sColor)cDataBase.pColors.get(value);
                else
                    pBackgroundColor = null;

                if (pBackgroundColor != null && pBackgroundColor != (sColor)pWindowStyle.pColors["LabelBackground"])
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

        [TypeConverter(typeof(FlagsConverter)),
        CategoryAttribute(entryName)]
        public String Flags
        {
            get { return pFlags.ToString(); }
            set
            {
                if (value != null && value == eFlags.wfBorder.ToString()) pFlags = eFlags.wfBorder;
                else pFlags = eFlags.wfNoBorder;

                if (pFlags == eFlags.wfBorder)
                {
                    if (myNode.Attributes["flags"] != null)
                        myNode.Attributes["flags"].Value = "wfBorder";
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("flags"));
                        myNode.Attributes["flags"].Value = "wfBorder";
                    }
                }
                else
                {
                    if (myNode.Attributes["flags"] != null)
                        myNode.Attributes["flags"].Value = "wfNoBorder";
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("flags"));
                        myNode.Attributes["flags"].Value = "wfNoBorder";
                    }
                }
            }
        }

        public class FlagsConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(new string[]{eFlags.wfBorder.ToString(), 
                                                     eFlags.wfNoBorder.ToString()});
            }

            public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
            {
                return true;
            }
        }

        public sAttributeScreen(XmlNode node)
            : base(node)
        {
            if (node == null)
                return;


            pZPosition = -100;

            if (node.Attributes["title"] != null)
                pTitle = node.Attributes["title"].Value;

            if (node.Attributes["flags"] != null)
                switch (node.Attributes["flags"].Value)
                {
                    case "wfNoBorder":
                        pFlags = eFlags.wfNoBorder;
                        break;
                    case "wfBorder":
                    default:
                        pFlags = eFlags.wfBorder;
                        break;
                }

            pWindowStyle = (sWindowStyle)cDataBase.pWindowstyles.get();

            if (node.Attributes["backgroundColor"] != null)
                pBackgroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            else if (node.Name == "screen" && node.Attributes["position"] == null) 
                pBackgroundColor = (sColor)cDataBase.pColors.get("transparent");
             else
                pBackgroundColor = (sColor)pWindowStyle.pColors["Background"];

            if (node.Attributes["labelforeground"] != null)
                pTitle = node.Attributes["labelforeground"].Value;
            else
                pLabelForegroundColor = (sColor)pWindowStyle.pColors["LabelForeground"];

            pTitleFont = pWindowStyle.pFont;
            pTitleSize = pWindowStyle.pTitleSize * (((float)pTitleFont.Scale) / 100.0F);

            pTitleXOff = pWindowStyle.pXOff;
            pTitleYOff = pWindowStyle.pYOff;

            /*pbpTopLeft = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpTopLeft;
            pbpTop = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpTop;
            pbpTopRight = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpTopRight;
            pbpLeft = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpLeft;
            pbpRight = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpRight;
            pbpBottomLeft = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpBottomLeft;
            pbpBottom = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpBottom;
            pbpBottomRight = ((sWindowStyle.sBorderSet)pWindowStyle.pBorderSets["bsWindow"]).pbpBottomRight;*/

            sWindowStyle style = (sWindowStyle)cDataBase.pWindowstyles.get();
            sWindowStyle.sBorderSet borderset = (sWindowStyle.sBorderSet)style.pBorderSets["bsWindow"];

            if (borderset != null)
            {

                if (borderset.pbpTopLeftName.Length > 0)
                {
                    pbpTopLeftName = borderset.pbpTopLeftName;
                    pbpTopLeft = borderset.pbpTopLeft;
                }
                if (borderset.pbpTopName.Length > 0)
                {
                    pbpTopName = borderset.pbpTopName;
                    pbpTop = borderset.pbpTop;
                }
                if (borderset.pbpTopRightName.Length > 0)
                {
                    pbpTopRightName = borderset.pbpTopRightName;
                    pbpTopRight = borderset.pbpTopRight;
                }


                if (borderset.pbpLeftName.Length > 0)
                {
                    pbpLeftName = borderset.pbpLeftName;
                    pbpLeft = borderset.pbpLeft;
                }
                if (borderset.pbpRightName.Length > 0)
                {
                    pbpRightName = borderset.pbpRightName;
                    pbpRight = borderset.pbpRight;
                }


                if (borderset.pbpBottomLeftName.Length > 0)
                {
                    pbpBottomLeftName = borderset.pbpBottomLeftName;
                    pbpBottomLeft = borderset.pbpBottomLeft;
                }
                if (borderset.pbpBottomName.Length > 0)
                {
                    pbpBottomName = borderset.pbpBottomName;
                    pbpBottom = borderset.pbpBottom;
                }
                if (borderset.pbpBottomRightName.Length > 0)
                {
                    pbpBottomRightName = borderset.pbpBottomRightName;
                    pbpBottomRight = borderset.pbpBottomRight;
                }
            }
        }
    }
}