using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using OpenSkinDesigner.Logic;

namespace OpenSkinDesigner.Structures
{
    public class sWindowStyle
    {
        public class sBorderSet
        {
            public String pName;

            public enum ePosition
            {
                bpTopLeft, bpTop, bpTopRight,
                bpLeft, bpRight,
                bpBottomLeft, bpBottom, bpBottomRight
            };

            public String pbpTopLeftName;
            public String pbpTopName;
            public String pbpTopRightName;
            public String pbpLeftName;
            public String pbpRightName;
            public String pbpBottomLeftName;
            public String pbpBottomName;
            public String pbpBottomRightName;

            public Size pbpTopLeft;
            public Size pbpTop;
            public Size pbpTopRight;
            public Size pbpLeft;
            public Size pbpRight;
            public Size pbpBottomLeft;
            public Size pbpBottom;
            public Size pbpBottomRight;

            public sBorderSet(String name,
                                String bpTopLeftName,
                                String bpTopName,
                                String bpTopRightName,
                                String bpLeftName,
                                String bpRightName,
                                String bpBottomLeftName,
                                String bpBottomName,
                                String bpBottomRightName)
            {
                pName = name;

                pbpTopLeftName = bpTopLeftName;
                pbpTopName = bpTopName;
                pbpTopRightName = bpTopRightName;
                pbpLeftName = bpLeftName;
                pbpRightName = bpRightName;
                pbpBottomLeftName = bpBottomLeftName;
                pbpBottomName = bpBottomName;
                pbpBottomRightName = bpBottomRightName;

                if (pbpTopLeftName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpTopLeftName));
                    pbpTopLeft = pixmap.Size;
                    pixmap.Dispose();
                }
                if (pbpTopName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpTopName));
                    pbpTop = pixmap.Size;
                    pixmap.Dispose();
                }
                if (pbpTopRightName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpTopRightName));
                    pbpTopRight = pixmap.Size;
                    pixmap.Dispose();
                }


                if (pbpLeftName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpLeftName));
                    pbpLeft = pixmap.Size;
                    pixmap.Dispose();
                }
                if (pbpRightName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpRightName));
                    pbpRight = pixmap.Size;
                    pixmap.Dispose();
                }


                if (pbpBottomLeftName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpBottomLeftName));
                    pbpBottomLeft = pixmap.Size;
                    pixmap.Dispose();
                }
                if (pbpBottomName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpBottomName));
                    pbpBottom = pixmap.Size;
                    pixmap.Dispose();
                }
                if (pbpBottomRightName.Length > 0)
                {
                    Image pixmap = Image.FromFile(cDataBase.getPath(pbpBottomRightName));
                    pbpBottomRight = pixmap.Size;
                    pixmap.Dispose();
                }
            }
        }

        public sFont pFont;
        public float pTitleSize;
        public Int32 pXOff;
        public Int32 pYOff;
        public Hashtable pColors;
        public Hashtable pBorderSets;

        public sWindowStyle(sFont font, float titlesize, Int32 xOff, Int32 yOff, Hashtable colors, sBorderSet[] bordersets)
        {
            pFont = font;
            pTitleSize = titlesize;
            pXOff = xOff;
            pYOff = yOff;

            pColors = colors;/*new Hashtable();
            foreach (sColor color in colors)
                pColors.Add(color.pName, color);*/

            pBorderSets = new Hashtable();
            foreach (sBorderSet borderset in bordersets)
                pBorderSets.Add(borderset.pName, borderset);
        }
    }
}