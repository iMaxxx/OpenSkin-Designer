using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using OpenSkinDesigner.Structures;
using System.Collections;

namespace OpenSkinDesigner.Logic
{
    public class cDesigner
    {
        protected ArrayList pDrawList = null;
        protected Graphics pGraph = null;

        protected float pScale = 1.0F;
        protected float pLevel = 1.1F;

        public cDesigner(Graphics graph)
        {
            pDrawList = new ArrayList();

            pGraph = graph;
        }

        public void zoomIn()
        {
            pScale *= pLevel;
            if (pScale < 0.4f) pScale = 0.4f;
            else if (pScale > 2.0f) pScale = 2.0f;
        }

        public void zoomOut()
        {
            pScale /= pLevel;
            if (pScale < 0.4f) pScale = 0.4f;
            else if (pScale > 2.0f) pScale = 2.0f;
        }

        public float zoomLevel()
        {
            return pScale;
        }

        public void setZoomLevel(float level)
        {
            pScale = level;
            if (pScale < 0.4f) pScale = 0.4f;
            else if (pScale > 2.0f) pScale = 2.0f;
        }

        public void sort()
        {
            pDrawList.Sort();
        }

        public void clear()
        {
            pDrawList.Clear();
        }

        public void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(pScale, pScale);
            //the array should be sorrted regarding zposition !!!
            foreach (sGraphicElement ele in pDrawList)
            {
                ele.paint(sender, e);
            }
        }

        public sGraphicElement getElement(uint x, uint y)
        {
            //x = (uint)((float)x * pScale);
            //y = (uint)((float)y * pScale);

            //the array should be sorrted regarding zposition !!!
            for (int i = 0; i < pDrawList.Count; i++)
            {
                sGraphicElement ele = (sGraphicElement)pDrawList[pDrawList.Count - 1 - i];

                if (ele.pX <= x && x < ele.pX + ele.pWidth &&
                    ele.pY <= y && y < ele.pY + ele.pHeight &&
                    ele.pZPosition != 1000)
                    return ele;
            }
            return null;
        }

        private sGraphicRectangel f1, f2, f3, f4;

        public void redrawFog(int x, int y, int w, int h)
        {
            pDrawList.Remove(f1);
            pDrawList.Remove(f2);
            pDrawList.Remove(f3);
            pDrawList.Remove(f4);
            drawFog(x, y, w, h);
        }

        public void drawFog(int x, int y, int w, int h)
        {
            sResolution res = cDataBase.pResolution.getResolution();

            int Xres = (int)res.Xres;
            int Yres = (int)res.Yres;

            f1 = new sGraphicRectangel(0, 0, (Int32)Xres, (Int32)y, true, (float)1.0, new sColor(200, Color.LightGray));
            f2 = new sGraphicRectangel(0, (Int32)y, (Int32)x, (Int32)h, true, (float)1.0, new sColor(200, Color.LightGray));
            f3 = new sGraphicRectangel((Int32)(x + w), (Int32)y, (Int32)((Xres - x - w) > 0 ? (Xres - x - w) : 0), (Int32)h, true, (float)1.0, new sColor(200, Color.LightGray));
            f4 = new sGraphicRectangel(0, (Int32)(y + h), (Int32)Xres, (Int32)((Yres - y - h) > 0 ? (Yres - y - h) : 0), true, (float)1.0, new sColor(200, Color.LightGray));
            pDrawList.Add(f1);
            pDrawList.Add(f2);
            pDrawList.Add(f3);
            pDrawList.Add(f4);
        }

        public void drawFrame()
        {
            sResolution res = cDataBase.pResolution.getResolution();
            pDrawList.Add(new sGraphicRectangel(0, 0, (Int32)res.Xres, (Int32)res.Yres, false, (float)1.0, new sColor(Color.Black)));
            pDrawList.Add(new sGraphicRectangel(0, 0, (Int32)res.Xres + 2, (Int32)res.Yres + 2, false, (float)1.0, new sColor(Color.Gray)));
            pDrawList.Add(new sGraphicRectangel(0, 0, (Int32)res.Xres + 4, (Int32)res.Yres + 4, false, (float)1.0, new sColor(Color.Black)));
        }

        public void drawBackground()
        {
            sResolution res = cDataBase.pResolution.getResolution();
            sAttribute attr = new sAttribute(0, 0, (Int32)res.Xres, (Int32)res.Yres, "Background");
            attr.pZPosition = -1000;
            pDrawList.Add(new sGraphicImage(attr, "background.jpg"));
        }

        public void draw(sAttribute attr)
        {
            sGraphicElement ele = null;

            Type type = attr.GetType();
            if (type == typeof(sAttributeScreen))
            {
                ele = new sGraphicScreen((sAttributeScreen)attr);
            }
            else if (type == typeof(sAttributeLabel))
            {
                ele = new sGraphicLabel((sAttributeLabel)attr);
            }
            else if (type == typeof(sAttributePixmap))
            {
                ele = new sGraphicPixmap((sAttributePixmap)attr);
            }
            else if (type == typeof(sAttributeWidget))
            {
                //ele = new sGraphicRectangel((sAttributeWidget)attr, false, 1.0F, Color.GreenYellow);
                ele = new sGraphicWidget((sAttributeWidget)attr);
            }

            pDrawList.Add(ele);
        }
    }
}
