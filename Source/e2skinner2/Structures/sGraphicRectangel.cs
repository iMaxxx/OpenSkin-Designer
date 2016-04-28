using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;

namespace OpenSkinDesigner.Structures
{
    class sGraphicRectangel : sGraphicElement
    {
        protected bool pFilled;
        protected float pLineWidth;
        protected sColor pColor;

        public sGraphicRectangel(sAttribute attr, bool filled, float linewidth, sColor color)
            : base(attr)
        {
            pFilled = filled;
            pLineWidth = linewidth;
            pColor = color;
        }

        public sGraphicRectangel(Int32 x, Int32 y, Int32 width, Int32 height, bool filled, float linewidth, sColor color)
            : base(x, y, width, height)
        {
            //Console.WriteLine("sGraphicRectangel: " + x + ":" + y + " " + width + "x" + height);
            pFilled = filled;
            pLineWidth = linewidth;
            pColor = color;

            pZPosition = 1000;
        }

        public override void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            Color penColor = pColor.Color;
            if (Logic.cProperties.getPropertyBool("enable_alpha"))
                penColor = pColor.ColorAlpha;

            if (pFilled)
                g.FillRectangle(new SolidBrush(penColor), pX, pY, pWidth, pHeight);
            else
                g.DrawRectangle(new Pen(penColor, pLineWidth), pX, pY, pWidth, pHeight);
        }
    }
}
