using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel;
using System.Drawing;
using OpenSkinDesigner.Logic;
using System.Diagnostics;
using System.Windows.Forms;

namespace OpenSkinDesigner.Structures
{
    class sAttributeWidget : sAttribute
    {
        private const String entryName = "2 Widget";

        public String pSource;
        public String pRender;

        public sAttributeLabel pLabel;
        public sAttributePixmap pPixmap;
        public sAttributeProgress pProgress;
        public sAttributeListbox pListbox;

        /*//Pixmap
        public String pPixmapPath;

        //Label
        public String pText;
        public sFont pFont;
        public float pFontSize;
        public sColor pBackgroundColor; //background is used for the shadow if wanted, or posily if not transparent is selected !!!!
        public sColor pForegroundColor;
        public enum eVAlign { Top, Center, Bottom };
        public enum eHAlign { Left, Center, Right };
        public eVAlign pValign = eVAlign.Center;
        public eHAlign pHalign = eHAlign.Left;
        public bool pNoWrap = true;*/

        [CategoryAttribute(entryName),
        DefaultValue("(none)")]
        public String Source
        {
            get { return pSource; }
            set { 
                pSource = value;
                if (pSource != null && pSource.Length > 0)
                {
                    if (myNode.Attributes["source"] != null)
                        myNode.Attributes["source"].Value = pSource;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("source"));
                        myNode.Attributes["source"].Value = pSource;
                    }
                }
                else
                    if (myNode.Attributes["source"] != null)
                        myNode.Attributes.RemoveNamedItem("source");
            }
        }

        [TypeConverter(typeof(RenderConverter)),
        CategoryAttribute(entryName)]
        public String Render
        {
            get { return pRender; }
            set { 
                pRender = value;
                if (pRender != null && pRender.Length > 0)
                {
                    if (myNode.Attributes["render"] != null)
                        myNode.Attributes["render"].Value = pRender;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("render"));
                        myNode.Attributes["render"].Value = pRender;
                    }
                }
                else
                    if (myNode.Attributes["render"] != null)
                        myNode.Attributes.RemoveNamedItem("render");
            }
        }

        //#####################################################################
        //################# LABEL #############################################
        private const String entryNameLabel = "3 Label";
        [CategoryAttribute(entryNameLabel)]
        public String Text
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.Text;
                else return "(none)";
            }
            set
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel")
                {
                    pLabel.Text = value;
                }
            }
        }

        [CategoryAttribute(entryNameLabel),
        ReadOnlyAttribute(true)]
        public String PreviewText
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.pPreviewText;
                else return "(none)";
            }
        }

        //[CategoryAttribute(entryName),
        //ReadOnlyAttribute(true)]

        [TypeConverter(typeof(OpenSkinDesigner.Structures.cProperty.sFontConverter)),
        CategoryAttribute(entryNameLabel)]
        public String Font
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.Font;
                else return "(none)";
            }
            set
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel")
                {
                    pLabel.Font = value;
                }
            }
        }

        [CategoryAttribute(entryNameLabel)]
        public float FontSize
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.FontSize;
                else return 0;
            }
            set
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel")
                {
                    pLabel.FontSize = value;
                }
            }
        }

        [Editor(typeof(OpenSkinDesigner.Structures.cProperty.GradeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(OpenSkinDesigner.Structures.cProperty.sColorConverter)),
        CategoryAttribute(entryNameLabel)]
        public String ForegroundColor
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.ForegroundColor;
                else return "(none)";
            }
            set
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel")
                {
                    pLabel.ForegroundColor = value;
                }
            }
        }

        [Editor(typeof(OpenSkinDesigner.Structures.cProperty.GradeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(OpenSkinDesigner.Structures.cProperty.sColorConverter)),
        CategoryAttribute(entryNameLabel)]
        public String BackgroundColor
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.BackgroundColor;
                else return "(none)";
            }
            set
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel")
                {
                    pLabel.BackgroundColor = value;
                }
            }
        }


        [TypeConverter(typeof(cProperty.VAlignConverter)),
        CategoryAttribute(entryNameLabel)]
        public String Valign
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.Valign;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") pLabel.Valign = value; }
        }

        [TypeConverter(typeof(cProperty.HAlignConverter)),
        CategoryAttribute(entryNameLabel)]
        public String Halign
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.Halign;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") pLabel.Halign = value; }
        }

        [CategoryAttribute(entryNameLabel)]
        public bool noWrap
        {
            get
            {
                if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") return pLabel.pNoWrap;
                else return false;
            }
            set { if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel") pLabel.noWrap = value; }
        }

        //######################################################################
        //################# PIXMAP #############################################
        private const String entryNamePixmap = "4 Pixmap";
        [CategoryAttribute(entryNamePixmap)]
        public String Path
        {
            get
            {
                if (pRender.ToLower() == "pixmap") return pPixmap.Path;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "pixmap") pPixmap.Path = value; }
        }

        [CategoryAttribute(entryNamePixmap),
        ReadOnlyAttribute(true)]
        public Size Resolution
        {
            get
            {
                if (pRender.ToLower() == "pixmap") return pPixmap.Resolution;
                else return new Size();
            }
        }

        [TypeConverter(typeof(cProperty.AlphatestConverter)),
        CategoryAttribute(entryNamePixmap)]
        public String Alphatest
        {
            get
            {
                if (pRender.ToLower() == "pixmap") return pPixmap.Alphatest;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "pixmap") pPixmap.Alphatest = value; }
        }

        //######################################################################
        //################# PROGRESS ###########################################
        private const String entryNameProgress = "6 Progress";

        [Editor(typeof(OpenSkinDesigner.Structures.cProperty.GradeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(OpenSkinDesigner.Structures.cProperty.sColorConverter)),
        CategoryAttribute(entryNameProgress)]
        public String ProgressColor
        {
            get
            {
                if (pRender.ToLower() == "progress") return pProgress.BackgroundColor;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "progress") pProgress.BackgroundColor = value; }
        }

        //######################################################################
        //################# LISTBOX ############################################
        private const String entryNameListbox = "7 Listbox";

        [TypeConverter(typeof(cProperty.ScrollbarModeConverter)),
        CategoryAttribute(entryNameListbox)]
        public String ScrollbarMode
        {
            get
            {
                if (pRender.ToLower() == "listbox") return pListbox.ScrollbarMode;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "listbox") pListbox.ScrollbarMode = value; }
        }

        [CategoryAttribute(entryNameListbox)]
        public String BackgroundPixmap
        {
            get
            {
                if (pRender.ToLower() == "listbox") return pListbox.BackgroundPixmap;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "listbox") pListbox.BackgroundPixmap = value; }
        }

        [CategoryAttribute(entryNameListbox)]
        public String SelectionPixmap
        {
            get
            {
                if (pRender.ToLower() == "listbox") return pListbox.SelectionPixmap;
                else return "(none)";
            }
            set { if (pRender.ToLower() == "listbox") pListbox.SelectionPixmap = value; }
        }

        [CategoryAttribute(entryNameListbox)]
        public Int32 ItemHeight
        {
            get
            {
                if (pRender.ToLower() == "listbox") return pListbox.ItemHeight;
                else return 0;
            }
            set { if (pRender.ToLower() == "listbox") pListbox.ItemHeight = value; }
        }

        //######################################################################
        //################# WIDGET #############################################

        public class RenderConverter : StringConverter
        {
            public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context)
            {
                return true;
            }

            public override StandardValuesCollection
                     GetStandardValues(ITypeDescriptorContext context)
            {
                return new StandardValuesCollection(new string[]{   "Canvas",
                                                                    "FixedLabel",
                                                                    "Label",
                                                                    "Listbox",
                                                                    "Picon",
                                                                    "XPicon",
                                                                    "Pixmap",
                                                                    "PositionGauge",
                                                                    "Progress"});
            }

            public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context)
            {
                return true;
            }
        }

        public sAttributeWidget(sAttribute parent, XmlNode node)
            : base(parent, node)
        {
            if (node.Attributes["source"] != null)
                pSource = node.Attributes["source"].Value;

            if (node.Attributes["render"] != null)
                pRender = node.Attributes["render"].Value;

            if (pRender == null)
            {
                if (node.Attributes["pixmap"] != null)
                    pRender = "Pixmap";
                else if (pName == "menu" || pName == "list" || pName.EndsWith("list")) //depreceated
                    pRender = "Listbox";
                else if (pName == "PositionGauge") //depreceated
                    pRender = "PositionGauge";
                else if (node.Attributes["pointer"] != null)
                    pRender = "PositionGauge";
                else
                    pRender = "Label";
            }

            if (pRender.ToLower() == "label" || pRender.ToLower() == "fixedlabel")
            {
                pLabel = new sAttributeLabel(parent, node);
            }
            else if (pRender.ToLower() == "pixmap")
            {
                pPixmap = new sAttributePixmap(parent, node);
            }
            else if (pRender.ToLower() == "picon")
            {
                pPixmap = new sAttributePixmap(parent, node);
            }
            else if (pRender.ToLower() == "xpicon")
            {
                pPixmap = new sAttributePixmap(parent, node);
            }
            else if (pRender.ToLower() == "progress")
            {
                pProgress = new sAttributeProgress(parent, node);
            }
            else if (pRender.ToLower() == "listbox")
            {
                pListbox = new sAttributeListbox(parent, node);
            }

            if (pSource != null && pSource.Length > 0)
            {
                String text = cPreviewText.getText(parent.Name, pSource);
                if (text.Length > 0)
                {
                    if (pLabel != null && (pLabel.pText == null || pLabel.pText.Length == 0))
                        pLabel.pPreviewText = text;
                    if (pListbox != null)
                        pListbox.pPreviewEntries = text.Split('|');
                }
            }

            if (node.HasChildNodes)
            {
                foreach (XmlNode nodeConverter in node.ChildNodes)
                {
                    if (nodeConverter.Attributes != null)
                    {
                        String type = nodeConverter.Attributes["type"].Value;
                        String parameter = nodeConverter.InnerText;

                        String text = cConverter.getText(pSource, type, parameter);
                        if (text != null)
                        {
                            if (pLabel != null)
                            {
                                if (text.Length > 0 && (pLabel.pText == null || pLabel.pText.Length <= 0))
                                    pLabel.pPreviewText = text;

                                if (text == "MAGIC#TRUE")
                                {
                                    //pLabel.pText = "";
                                }
                                else if (text == "MAGIC#FALSE")
                                {
                                    pLabel.pPreviewText = "";
                                }
                            }
                            else if (pPixmap != null)
                            {
                                if (text == "MAGIC#TRUE")
                                {
                                    //pLabel.pText = "";
                                }
                                else if (text == "MAGIC#FALSE")
                                {
                                    pPixmap.pPixmap = new Size(0, 0);
                                    pPixmap.pHide = true;
                                }
                            }
                        }
                    }
                }
                
                cConverter.reset();
            }
            else
            {
                if (pSource != null)
                {
                    if (pSource.ToLower() == "title")
                    {
                        if (parent is sAttributeScreen)
                        {
                            if (pLabel != null)
                                pLabel.pPreviewText = ((sAttributeScreen)parent).pTitle;
                        }
                    }
                }
            }
        }
    }
}
