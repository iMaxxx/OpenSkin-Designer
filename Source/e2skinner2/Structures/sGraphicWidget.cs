using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using OpenSkinDesigner.Logic;
using System.Drawing;

namespace OpenSkinDesigner.Structures
{
    class sGraphicWidget : sGraphicElement
    {
        //protected sAttributeWidget pAttr;
        

        public sGraphicWidget(sAttributeWidget attr)
            : base(attr)
        {
            pAttr = attr;
        }

        public override void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
            if (cProperties.getPropertyBool("skinned_widget"))
            {
                new sGraphicRectangel(pAttr, false, (float)1.0, new sColor(Color.Yellow)).paint(sender, e);
            }
            
                //Unfortunatyl we have more tahn on instance of the base attributes,
                //so update all here
                if (((sAttributeWidget)pAttr).pRender.ToLower() == "label" || ((sAttributeWidget)pAttr).pRender.ToLower() == "fixedlabel")
                {
                    updateObject(pAttr, ((sAttributeWidget)pAttr).pLabel);
                    new sGraphicLabel((sAttributeLabel)((sAttributeWidget)pAttr).pLabel).paint(sender, e);
                }
                else if (((sAttributeWidget)pAttr).pRender.ToLower() == "pixmap")
                {
                    updateObject(pAttr, ((sAttributeWidget)pAttr).pPixmap);
                    new sGraphicPixmap((sAttributePixmap)((sAttributeWidget)pAttr).pPixmap).paint(sender, e);
                }
                else if (((sAttributeWidget)pAttr).pRender.ToLower() == "picon" || ((sAttributeWidget)pAttr).pRender.ToLower() == "xpicon")
                {
                    updateObject(pAttr, ((sAttributeWidget)pAttr).pPixmap);
                    new sGraphicPixmap((sAttributePixmap)((sAttributeWidget)pAttr).pPixmap).paint(sender, e);
                }
                else if (((sAttributeWidget)pAttr).pRender.ToLower() == "progress")
                {
                    updateObject(pAttr, ((sAttributeWidget)pAttr).pProgress);
                    new sGraphicProgress((sAttributeProgress)((sAttributeWidget)pAttr).pProgress).paint(sender, e);
                }
                else if (((sAttributeWidget)pAttr).pRender.ToLower() == "listbox")
                {
                    updateObject(pAttr, ((sAttributeWidget)pAttr).pListbox);
                    new sGraphicListbox((sAttributeListbox)((sAttributeWidget)pAttr).pListbox).paint(sender, e);
                }

                if (pAttr.pBorder)
                    new sGraphicRectangel(pAttr, false, (float)pAttr.pBorderWidth, pAttr.pBorderColor).paint(sender, e);
            
        }

        public void updateObject(sAttribute parent, sAttribute me)
        {
            me.pAbsolutX = parent.pAbsolutX;
            me.pAbsolutY = parent.pAbsolutY;
            me.pRelativX = parent.pRelativX;
            me.pRelativY = parent.pRelativY;
            me.pWidth = parent.pWidth;
            me.pHeight = parent.pHeight;
            me.pName = parent.pName;
            me.pZPosition = parent.pZPosition;
            me.pTransparent = parent.pTransparent;
            me.pBorder = parent.pBorder;
            me.pBorderColor = parent.pBorderColor;
            me.pBorderWidth = parent.pBorderWidth;
        }
    }
}
