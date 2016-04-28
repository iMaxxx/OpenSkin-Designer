using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace OpenSkinDesigner.Structures
{
    public class sResolution
    {
        public UInt32 Xres = 0;
        public UInt32 Yres = 0;
        public UInt32 Bpp = 0;

        public sResolution(UInt32 xres, UInt32 yres, UInt32 bpp)
        {
            Xres = xres;
            Yres = yres;
            Bpp = bpp;
        }
    }
}
