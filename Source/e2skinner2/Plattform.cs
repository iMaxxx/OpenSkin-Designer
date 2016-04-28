using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSkinDesigner
{
    public static class Platform
    {
        public enum ePlatform {WIN, MONO};

        public static ePlatform sysPlatform = ePlatform.WIN;

        public static void detectPlatform()
        {
            Type t = Type.GetType ("Mono.Runtime");
            if (t != null)
                sysPlatform = ePlatform.MONO;
            return;
        }      
    }
}
