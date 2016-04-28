using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel;
using OpenSkinDesigner.Logic;
using System.Drawing;
using System.IO;

namespace OpenSkinDesigner.Structures
{
    class sAttributeListbox : sAttribute
    {
        private const String entryName = "7 Listbox";

        //Listbox 20 regular http://ufs910.dontexist.com/trac/browser/cvs/apps/enigma2_01052009/lib/gui/elistboxcontent.cpp#L140
        //http://ufs910.dontexist.com/trac/browser/cvs/apps/enigma2_01052009/lib/gui/elistboxcontent.cpp#L273

        /*ListboxBackground" color="#450b1b1c"/>
		<color name="ListboxForeground" color="#ffffff"/>
		<color name="ListboxSelectedBackground" color="#25587b80"/>
		<color name="ListboxSelectedForeground" color="#ffffff"/>
		<color name="ListboxMarkedBackground" color="#ff0000"/>
		<color name="ListboxMarkedForeground" color="#ffffff"/>
		<color name="ListboxMarkedAndSelectedBackground" color="#800000"/>
		<color name="ListboxMarkedAndSelectedForeground" color="#ffffff"/>
         * backgroundPixmap //shown for the hole listbox
         selectionPixmap //shown under an selected entry
         ScrollbarMode
         * the following are only valid for the graphical multi epg
         EntryBorderColor="#071930" EntryBackgroundColor="#1f294b" EntryBackgroundColorSelected="#225b7395"
         * the following are only valid for the servicelist
         serviceInfoFont="Regular;22" serviceNameFont="Regular;24" serviceNumberFont="Regular;24"*/

        //note this are the pngs which will be shown around the complete list, not an entry
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

        public sColor pListboxBackgroundColor;
        public sColor pListboxForegroundColor;
        public sColor pListboxSelectedBackgroundColor;
        public sColor pListboxSelectedForegroundColor;
        public sColor pListboxMarkedBackgroundColor;
        public sColor pListboxMarkedForegroundColor;
        public sColor pListboxMarkedAndSelectedBackgroundColor;
        public sColor pListboxMarkedAndSelectedForegroundColor;

        public String pBackgroundPixmapName;
        public Image pBackgroundPixmap;
        public String pSelectionPixmapName;
        public Image pSelectionPixmap;

        public String[] pPreviewEntries = null;

        public cProperty.eScrollbarMode pScrollbarMode;

        [CategoryAttribute(entryName)]
        public String BackgroundPixmap
        {
            get { return pBackgroundPixmapName; }
            set {
                pBackgroundPixmapName = value;

                if (pBackgroundPixmapName != null && pBackgroundPixmapName.Length > 0)
                {
                    if (myNode.Attributes["backgroundPixmap"] != null)
                        myNode.Attributes["backgroundPixmap"].Value = pBackgroundPixmapName;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("backgroundPixmap"));
                        myNode.Attributes["backgroundPixmap"].Value = pBackgroundPixmapName;
                    }
                }
                else
                    if (myNode.Attributes["backgroundPixmap"] != null)
                        myNode.Attributes.RemoveNamedItem("backgroundPixmap");              
                }
        }

        [CategoryAttribute(entryName)]
        public String SelectionPixmap
        {
            get { return pSelectionPixmapName; }
            set { 
                pSelectionPixmapName = value;

                if (pSelectionPixmapName != null && pSelectionPixmapName.Length > 0)
                {
                    if (myNode.Attributes["selectionPixmap"] != null)
                        myNode.Attributes["selectionPixmap"].Value = pSelectionPixmapName;
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("selectionPixmap"));
                        myNode.Attributes["selectionPixmap"].Value = pSelectionPixmapName;
                    }
                }
                else
                    if (myNode.Attributes["selectionPixmap"] != null)
                        myNode.Attributes.RemoveNamedItem("selectionPixmap");
                
                }
        }

        [TypeConverter(typeof(cProperty.ScrollbarModeConverter)),
        CategoryAttribute(entryName)]
        public String ScrollbarMode
        {
            get { return pScrollbarMode.ToString(); }
            set
            {
                if (value != null && value == cProperty.eScrollbarMode.showAlways.ToString()) pScrollbarMode = cProperty.eScrollbarMode.showAlways;
                else if (value != null && value == cProperty.eScrollbarMode.showOnDemand.ToString()) pScrollbarMode = cProperty.eScrollbarMode.showOnDemand;
                else pScrollbarMode = cProperty.eScrollbarMode.showNever;

                if (pScrollbarMode == cProperty.eScrollbarMode.showAlways) myNode.Attributes["scrollbarMode"].Value = "showAlways";
                else if (pScrollbarMode == cProperty.eScrollbarMode.showOnDemand) myNode.Attributes["scrollbarMode"].Value = "showOnDemand";
                else myNode.Attributes["scrollbarMode"].Value = "showNever";
            }
        }


        public Int32 pItemHeight;

        [CategoryAttribute(entryName)]
        public Int32 ItemHeight
        {
            get { return pItemHeight; }
            set
            {
                pItemHeight = value;

                //if (pItemHeight != null)
                {
                    if (myNode.Attributes["itemHeight"] != null)
                        myNode.Attributes["itemHeight"].Value = pItemHeight.ToString();
                    else
                    {
                        myNode.Attributes.Append(myNode.OwnerDocument.CreateAttribute("itemHeight"));
                        myNode.Attributes["itemHeight"].Value = pItemHeight.ToString();
                    }
                }
                //else
                //    if (myNode.Attributes["itemHeight"] != null)
                //        myNode.Attributes.RemoveNamedItem("itemHeight");
                
            }
        }
        

        public sAttributeListbox(sAttribute parent, XmlNode node)
            : base(parent, node)
        {

            if (node.Attributes["backgroundColor"] != null)
                pListboxBackgroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            else
                pListboxBackgroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxBackground"];

            if (node.Attributes["foregroundColor"] != null)
                pListboxForegroundColor = (sColor)cDataBase.pColors.get(node.Attributes["foregroundColor"].Value);
            else
                pListboxForegroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxForeground"];


            //if (node.Attributes["backgroundColor"] != null)
            //    pListboxSelectedBackgroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            //else
            pListboxSelectedBackgroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxSelectedBackground"];

            //if (node.Attributes["backgroundColor"] != null)
            //    pListboxSelectedForegroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            //else
            pListboxSelectedForegroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxSelectedForeground"];


            //if (node.Attributes["backgroundColor"] != null)
            //    pListboxMarkedBackgroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            //else
            pListboxMarkedBackgroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxMarkedBackground"];

            //if (node.Attributes["backgroundColor"] != null)
            //    pListboxMarkedForegroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            //else
            pListboxMarkedForegroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxMarkedForeground"];


            //if (node.Attributes["backgroundColor"] != null)
            //    pListboxMarkedAndSelectedBackgroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            //else
            pListboxMarkedAndSelectedBackgroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxMarkedAndSelectedBackground"];

            //if (node.Attributes["backgroundColor"] != null)
            //    pListboxMarkedAndSelectedForegroundColor = (sColor)cDataBase.pColors.get(node.Attributes["backgroundColor"].Value);
            //else
            pListboxMarkedAndSelectedForegroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["ListboxMarkedAndSelectedForeground"];


            if (node.Attributes["backgroundPixmap"] != null)
            {
                pBackgroundPixmapName = node.Attributes["backgroundPixmap"].Value;
                try
                {
                    pBackgroundPixmap = Image.FromFile(cDataBase.getPath(pBackgroundPixmapName));
                }
                catch (FileNotFoundException)
                {
                    pBackgroundPixmap = null;
                }
            }
            if (node.Attributes["selectionPixmap"] != null)
            {
                pSelectionPixmapName = node.Attributes["selectionPixmap"].Value;
                try
                {
                    pSelectionPixmap = Image.FromFile(cDataBase.getPath(pSelectionPixmapName));
                }
                catch (FileNotFoundException)
                {
                    pSelectionPixmap = null;
                }
            }

            if (myNode.Attributes["scrollbarMode"] != null)
                pScrollbarMode = myNode.Attributes["scrollbarMode"].Value.ToLower() == "showAlways".ToLower() ? cProperty.eScrollbarMode.showAlways :
                    myNode.Attributes["scrollbarMode"].Value.ToLower() == "showOnDemand".ToLower() ? cProperty.eScrollbarMode.showOnDemand :
                    cProperty.eScrollbarMode.showNever;

            sWindowStyle style = (sWindowStyle)cDataBase.pWindowstyles.get();
            sWindowStyle.sBorderSet borderset = (sWindowStyle.sBorderSet)style.pBorderSets["bsListboxEntry"];

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


            if (node.Attributes["itemHeight"] != null)
                pItemHeight = Convert.ToInt32(node.Attributes["itemHeight"].Value.Trim());
            else
                pItemHeight = 20;


            String entries = cPreviewText.getText(parent.Name, Name);
            if(entries.Length > 0)
                pPreviewEntries = entries.Split('|');
        }
    }
}
