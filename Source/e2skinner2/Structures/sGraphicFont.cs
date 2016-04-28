using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using OpenSkinDesigner.Logic;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace OpenSkinDesigner.Structures
{
    class sGraphicFont : sGraphicElement
    {
        protected String pText;
        protected float pSize;
        protected sFont pFont;
        protected sColor pColor;
        protected bool pTranparent;
        protected sColor pBackColor;
        protected cProperty.eHAlign pHAlignment;
        protected cProperty.eVAlign pVAlignment;

        //protected sAttribute pAttr;

        public sGraphicFont(sAttribute attr, Int32 x, Int32 y, String text, float size, sFont font, sColor color, cProperty.eHAlign hAlignment, cProperty.eVAlign vAlignment)
            : base(attr)
        {
            //pAttr = attr;

            pX = x;
            pY = y;

            pText = text;
            pSize = size;
            pFont = font;
            pColor = color;
            pHAlignment = hAlignment;
            pVAlignment = vAlignment;

            pTranparent = true;
        }

        public sGraphicFont(sAttribute attr, Int32 x, Int32 y, String text, float size, sFont font, sColor color, sColor backColor, cProperty.eHAlign hAlignment, cProperty.eVAlign vAlignment)
            : base(attr)
        {
            //pAttr = attr;

            pX = x;
            pY = y;

            pText = text;
            pSize = size;
            pFont = font;
            pColor = color;

            if (backColor != null)
            {
                pTranparent = false;
                pBackColor = backColor;
            }
            else pTranparent = true;

            pHAlignment = hAlignment;
            pVAlignment = vAlignment;
        }

        public override void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            System.Drawing.Font font = null;
            String name = "";
            try
            {
                if (pFont.FontFamily != null) //Only do this if the font is valid
                {
                    name = pFont.FontFamily.GetName(0);

                    font = new System.Drawing.Font(pFont.FontFamily, pSize, pFont.FontStyle, GraphicsUnit.Pixel);
                } else
                    Console.WriteLine("Font painting failed! (" + pFont.Name + ")");
            }
            catch (Exception error)
            {
                Console.WriteLine("Font painting failed! (" + pFont.Name + ")\n" + error);

                /*String errormessage = error.Message + ":\n\n";
                errormessage += error.StackTrace + "\n\n";
                errormessage += error.Source + "\n\n";
                errormessage += error.TargetSite + "\n\n";
                errormessage += name + "\n\n";

                //This message box is annoying
                MessageBox.Show(errormessage,
                    error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);*/

                return;
            }
        
            if (!pTranparent)
                new sGraphicRectangel(pAttr, true, 1.0F, pBackColor).paint(sender,e);

            StringFormat format = new StringFormat();
            
            // Horizontal
            if (pHAlignment == cProperty.eHAlign.Left)
                format.Alignment = StringAlignment.Near;
            else if (pHAlignment == cProperty.eHAlign.Center)
                format.Alignment = StringAlignment.Center;
            else
                format.Alignment = StringAlignment.Far;

            // Vertical
            //format.LineAlignment = StringAlignment.Center;

            if (pVAlignment == cProperty.eVAlign.Top)
                format.LineAlignment = StringAlignment.Near;
            else if (pVAlignment == cProperty.eVAlign.Center)
                format.LineAlignment = StringAlignment.Center;
            else
                format.LineAlignment = StringAlignment.Far;

            if (font != null)
            {
                SizeF StringSize = g.MeasureString(pText, font);

                Color penColor = pColor.Color;
                if (cProperties.getPropertyBool("enable_alpha"))
                    penColor = pColor.ColorAlpha;

                //int x = pX;
                int y = pY;

                float height = pHeight;

                if (pAttr != null && pAttr.GetType() == typeof(sAttributeLabel) && ((sAttributeLabel)pAttr).noWrap)
                {
                    height = StringSize.Height < pHeight ? StringSize.Height : pHeight;
                    if (pVAlignment == cProperty.eVAlign.Center)
                        y += (pHeight - (Int32)StringSize.Height) / 2;
                    else if (pVAlignment == cProperty.eVAlign.Bottom)
                        y += (pHeight - (Int32)StringSize.Height);
                }

                g.DrawString(pText, 
                    font, 
                    new SolidBrush(penColor),
                    new RectangleF(pX, y, pWidth, height), 
                    format);
            }
        }
    }
}
