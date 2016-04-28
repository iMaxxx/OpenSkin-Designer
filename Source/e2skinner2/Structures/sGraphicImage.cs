using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using OpenSkinDesigner.Logic;
using System.Drawing.Imaging;
using System.IO;

namespace OpenSkinDesigner.Structures
{
    class sGraphicImage : sGraphicElement
    {
        protected Image pImage;

        //protected sAttribute pAttr;

        public sGraphicImage(sAttribute attr, String image, Int32 x, Int32 y, Int32 w, Int32 h)
            : base(attr)
        {
            //Console.WriteLine("sGraphicImage: " + x + ":" + y + " " + w + "x" + h);

            try
            {
                pImage = Image.FromFile(cDataBase.getPath(image));
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found! (" + cDataBase.getPath(image) + ")\n" + ex);
                return;
            }
            pX = x;
            pY = y;


            pWidth = w < (Int32)pImage.Width ? w : (Int32)pImage.Width;
            pHeight = h < (Int32)pImage.Height ? h : (Int32)pImage.Height; ;
        }

        public sGraphicImage(sAttribute attr, String image, Int32 x, Int32 y)
            : base(attr)
        {
            //Console.WriteLine("sGraphicImage: " + x + ":" + y);

            //pAttr = attr;
            if (image == null || image.Length == 0)
                return;
            try
            {
                pImage = Image.FromFile(cDataBase.getPath(image));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found! (" + cDataBase.getPath(image) + ")");
                return;
            }
            
            pX = x;
            pY = y;

            pWidth = (Int32)pImage.Width;
            pHeight = (Int32)pImage.Height;
        }

        public sGraphicImage(sAttribute attr, String image)
            : base(attr)
        {
            //Console.WriteLine("sGraphicImage: ");

            //pAttr = attr;
            if (image == null || image.Length == 0)
                return;
            try
            {
                pImage = Image.FromFile(cDataBase.getPath(image));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found! (" + cDataBase.getPath(image) + ")");
                return;
            }
        }


        public override void paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //if (!cProperties.getPropertyBool("skinned"))
            //{
            //    new sGraphicRectangel(pAttr, false, (float)1.0, Color.Red).paint(sender, e);
            //}
            //else
            if(pImage != null)
            {
                Graphics g = e.Graphics;
                g.DrawImageUnscaledAndClipped(pImage, new Rectangle((int)pX, (int)pY, pWidth < pImage.Width ? (int)pWidth : pImage.Width, pHeight < pImage.Height ? (int)pHeight : pImage.Height));
            }
        }
    }
}
