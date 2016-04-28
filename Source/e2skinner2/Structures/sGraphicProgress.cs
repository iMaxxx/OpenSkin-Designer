using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using OpenSkinDesigner.Logic;
using System.Drawing;

namespace OpenSkinDesigner.Structures
{
    class sGraphicProgress : sGraphicElement
    {
        //protected sAttributeProgress pAttr;
        

        public sGraphicProgress(sAttributeProgress attr)
            : base(attr)
        {
            pAttr = attr;
        }

        public override void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!cProperties.getPropertyBool("skinned"))
            {
                new sGraphicRectangel(pAttr, false, (float)1.0, new sColor(Color.Green)).paint(sender, e);
            }
            else
            {
                if (pAttr.pTransparent)
                {
                    //new sGraphicRectangel().paint(sender, e);
                }
                else
                    new sGraphicRectangel(pAttr, true, 1.0F, ((sAttributeProgress)pAttr).pBackgroundColor).paint(sender, e);

                if(pAttr.pBorder)
                    new sGraphicRectangel(pAttr, false, (float)pAttr.pBorderWidth, pAttr.pBorderColor).paint(sender, e);

            }
        }
    }
}
