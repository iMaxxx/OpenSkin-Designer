using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using OpenSkinDesigner.Logic;
using System.Drawing;
using System.Windows.Forms;

namespace OpenSkinDesigner.Structures
{
    class sGraphicPixmap : sGraphicElement
    {
        //protected sAttributePixmap pAttr;
        
        public sGraphicPixmap(sAttributePixmap attr)
            : base(attr)
        {
            pAttr = attr;
        }

        public override void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
            if (cProperties.getPropertyBool("skinned_pixmap"))
            {
                if (!((sAttributePixmap)pAttr).pHide) 
                    new sGraphicRectangel(pAttr, false, (float)1.0, new sColor(Color.Blue)).paint(sender, e);
            }

            if (((sAttributePixmap)pAttr).pPixmapName != null)
            {
                if (!((sAttributePixmap)pAttr).pHide)
                    new sGraphicImage(pAttr, ((sAttributePixmap)pAttr).pPixmapName).paint(sender, e);
            }

                if (pAttr.pBorder)
                    new sGraphicRectangel(pAttr, false, (float)pAttr.pBorderWidth, pAttr.pBorderColor).paint(sender, e);

                /*else
                 * 
                 * Show missing icon ?
                 */
            
        }
    }
}
