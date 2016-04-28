using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;

using OpenSkinDesigner.Structures;
using System.Xml;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace OpenSkinDesigner.Logic
{
    static public class cDataBase
    {
        static private Hashtable pFonts = null;
        
        

        static public cDataBaseColor pColors;
        static public cDataBaseWindowstyle pWindowstyles;
        static public cDataBaseImage pImage;
        static public cDataBaseResolution pResolution;

        static public void init(cXMLHandler XmlHandler)
        {
            pColors = new cDataBaseColor(XmlHandler);
            initFonts(XmlHandler);
            pResolution = new cDataBaseResolution(XmlHandler);
            pImage = new cDataBaseImage(XmlHandler);
            pWindowstyles = new cDataBaseWindowstyle(XmlHandler);
        }

        static public void clear()
        {
            pColors = null;
            pFonts = null;
            pResolution = null;
            pImage = null;
            pWindowstyles = null;
        }

        //#################################################################

        public abstract class cDataBaseElement
        {
            public abstract Object[] getArray();
            public abstract Object get(String name);
            public abstract String add(Object element);
            public abstract bool remove(Object element);
            public abstract bool sync(cXMLHandler XmlHandler);
        }

        //#################################################################

        public class cDataBaseWindowstyle : cDataBaseElement
        {
            private sWindowStyle pWindowStyle = null;

            public cDataBaseWindowstyle(cXMLHandler XmlHandler)
            {
                Hashtable colors = new Hashtable();
                sFont titlefont = null;
                float titlesize = (float)0.0;
                Int32 xOff = 0, yOff = 0;
                ArrayList bordersets = new ArrayList();

                string[] path = { /*"skin", */"windowstyle" };
                XmlNode styleNode = XmlHandler.XmlGetRootNodeElement(path);
                if (styleNode == null)
                {
                    //<font filename= name= scale="90" />
                    sFont font = new sFont(
                        "Regular",
                        "nmsbd.ttf",
                        90,
                        false
                    );
                    pFonts.Add(font.Name, font);

                    colors.Add("Background", pColors.get("#25062748"));
                    colors.Add("LabelForeground", pColors.get("#ffffff"));
                    colors.Add("ListboxBackground", pColors.get("#25062748"));
                    colors.Add("ListboxForeground", pColors.get("#ffffff"));
                    colors.Add("ListboxSelectedBackground", pColors.get("#254f7497"));
                    colors.Add("ListboxSelectedForeground", pColors.get("#ffffff"));
                    colors.Add("ListboxMarkedBackground", pColors.get("#ff0000"));
                    colors.Add("ListboxMarkedForeground", pColors.get("#ffffff"));
                    colors.Add("ListboxMarkedAndSelectedBackground", pColors.get("#800000"));
                    colors.Add("ListboxMarkedAndSelectedForeground", pColors.get("#ffffff"));
                    colors.Add("WindowTitleForeground", pColors.get("#ffffff"));
                    colors.Add("WindowTitleBackground", pColors.get("#25062748"));

                    sWindowStyle.sBorderSet borderset = new sWindowStyle.sBorderSet(
                                "bsWindow",
                                "skin_default/b_tl.png",
                                "skin_default/b_t.png",
                                "skin_default/b_tr.png",
                                "skin_default/b_l.png",
                                "skin_default/b_r.png",
                                "skin_default/b_bl.png",
                                "skin_default/b_b.png",
                                "skin_default/b_br.png");
                    bordersets.Add(borderset);

                    pWindowStyle = new sWindowStyle(getFont("Regular"), 20.0f, 33, 14, colors, (sWindowStyle.sBorderSet[])bordersets.ToArray(typeof(sWindowStyle.sBorderSet)));
                }
                else
                {
                    foreach (XmlNode myXmlNode in styleNode.ChildNodes)
                    {
                        if (myXmlNode.Name == "color")
                        {
                            if (colors[myXmlNode.Attributes["color"].Value] == null)
                                colors.Add(myXmlNode.Attributes["name"].Value, pColors.get(myXmlNode.Attributes["color"].Value));
                        }
                        else if (myXmlNode.Name == "title")
                        {
                            String font = myXmlNode.Attributes["font"].Value;
                            titlesize = Convert.ToSingle(font.Substring(font.IndexOf(';') + 1));
                            font = font.Substring(0, font.IndexOf(';'));
                            titlefont = getFont(font);
                            xOff = Convert.ToInt32(myXmlNode.Attributes["offset"].Value.Substring(0, myXmlNode.Attributes["offset"].Value.IndexOf(',')));
                            yOff = Convert.ToInt32(myXmlNode.Attributes["offset"].Value.Substring(myXmlNode.Attributes["offset"].Value.IndexOf(',') + 1));
                        }
                        else if (myXmlNode.Name == "borderset")
                        {
                            String pbpTopLeftName = "";
                            String pbpTopName = "";
                            String pbpTopRightName = "";
                            String pbpLeftName = "";
                            String pbpRightName = "";
                            String pbpBottomLeftName = "";
                            String pbpBottomName = "";
                            String pbpBottomRightName = "";

                            //string[] path2 = { "skin", "windowstyle", "borderset" };
                            //XmlNode fontNode2 = XmlHandler.XmlGetRootNodeElement(path2);
                            foreach (XmlNode myXmlNode2 in /*fontNode2*/myXmlNode.ChildNodes)
                            {
                                if (myXmlNode2.Attributes["pos"].Value == "bpTopLeft")
                                {
                                    pbpTopLeftName = myXmlNode2.Attributes["filename"].Value;
                                }
                                else if (myXmlNode2.Attributes["pos"].Value == "bpTop")
                                {
                                    pbpTopName = myXmlNode2.Attributes["filename"].Value;
                                }
                                else if (myXmlNode2.Attributes["pos"].Value == "bpTopRight")
                                {
                                    pbpTopRightName = myXmlNode2.Attributes["filename"].Value;
                                }
                                else if (myXmlNode2.Attributes["pos"].Value == "bpLeft")
                                {
                                    pbpLeftName = myXmlNode2.Attributes["filename"].Value;
                                }
                                else if (myXmlNode2.Attributes["pos"].Value == "bpRight")
                                {
                                    pbpRightName = myXmlNode2.Attributes["filename"].Value;
                                }
                                else if (myXmlNode2.Attributes["pos"].Value == "bpBottomLeft")
                                {
                                    pbpBottomLeftName = myXmlNode2.Attributes["filename"].Value;
                                }
                                else if (myXmlNode2.Attributes["pos"].Value == "bpBottom")
                                {
                                    pbpBottomName = myXmlNode2.Attributes["filename"].Value;
                                }
                                else if (myXmlNode2.Attributes["pos"].Value == "bpBottomRight")
                                {
                                    pbpBottomRightName = myXmlNode2.Attributes["filename"].Value;
                                }
                            }

                            sWindowStyle.sBorderSet borderset = new sWindowStyle.sBorderSet(
                                myXmlNode.Attributes["name"].Value,
                                pbpTopLeftName,
                                pbpTopName,
                                pbpTopRightName,
                                pbpLeftName,
                                pbpRightName,
                                pbpBottomLeftName,
                                pbpBottomName,
                                pbpBottomRightName);
                            bordersets.Add(borderset);
                        }
                    }

                    pWindowStyle = new sWindowStyle(titlefont, titlesize, xOff, yOff, colors, (sWindowStyle.sBorderSet[])bordersets.ToArray(typeof(sWindowStyle.sBorderSet)));
                }
            }

            public Object get()
            {
                // Valerie workaround till font loading is supported by skins
                // At this point the font should be loaded
                if (pWindowStyle.pFont == null) pWindowStyle.pFont = getFont("Regular");
                return (Object)pWindowStyle;
            }

            public override Object get(String name)
            {
                return (Object)pWindowStyle;
            }

            public override Object[] getArray() { return null; }
            public override String add(Object element) { return null; }

            public override bool remove(Object element) { return false; }
            public override bool sync(cXMLHandler XmlHandler) { return false; }
        }

        //#################################################################

        public class cDataBaseImage
        {
            private ArrayList pImages = null;

            public cDataBaseImage(cXMLHandler XmlHandler)
            {
                string[] path2 = { "skin" };
                XmlNode Node = XmlHandler.XmlGetRootNodeElement(null/*path2*/);

                pImages = new ArrayList();

                if (Node.HasChildNodes)
                    checkImages(Node.ChildNodes);
            }

            private void checkImages(XmlNodeList nodes)
            {
                foreach (XmlNode myXmlNode in nodes)
                {
                    if (myXmlNode.HasChildNodes)
                        checkImages(myXmlNode.ChildNodes);

                    if (myXmlNode.Attributes != null)
                    {
                        if (myXmlNode.Attributes["pixmap"] != null)
                        {
                            if (!pImages.Contains(myXmlNode.Attributes["pixmap"].Value))
                                pImages.Add(myXmlNode.Attributes["pixmap"].Value);
                        }
                        //if (myXmlNode.Attributes["filename"] != null)
                        //{
                        //    if (!pImages.Contains(myXmlNode.Attributes["filename"].Value))
                        //        pImages.Add(myXmlNode.Attributes["filename"].Value);
                        //}
                    }
                }
            }

            public void rescale(int o_x, int o_y, int x, int y)
            {
                double scale_x = (x*1.0) / o_x;
                double scale_y = (y * 1.0) / o_y;

                foreach (String image in pImages)
                {
                     Image pixmap;
                     try
                     {
                         pixmap = Image.FromFile(cDataBase.getPath(image));
                     }
                     catch (FileNotFoundException error)
                     {
                         String errormessage = "PNG not found " + image + "!";
                         errormessage += cDataBase.getPath(image) + "\n\n";
                         errormessage += "Error:\n";
                         errormessage += error.Message;

                         MessageBox.Show(errormessage,
                             error.Message,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1);
                         continue;
                     }
                    Image scaled = pixmap.GetThumbnailImage(Convert.ToInt32(pixmap.Width * scale_x), Convert.ToInt32(pixmap.Height * scale_y), null, IntPtr.Zero);
                    pixmap.Dispose();
                    pixmap = null;
                    String path = cDataBase.getPath(image);
                    scaled.Save(path);
                    scaled.Dispose();
                    pixmap = null;
                }

            }
        }

        //#################################################################

        public class cDataBaseColor : cDataBaseElement
        {
            private Hashtable pColors = null;

            public cDataBaseColor(cXMLHandler XmlHandler)
            {
                pColors = new Hashtable();

                string[] path = { /*"skin", */"colors" };
                XmlNode colorNode = XmlHandler.XmlGetRootNodeElement(path);
                foreach (XmlNode myXmlNode in colorNode.ChildNodes)
                {
                    if (myXmlNode.NodeType != XmlNodeType.Element)
                        continue;
                    String colorString = myXmlNode.Attributes["value"].Value;
                    sColor color;
                    if (colorString[0] == '#')
                    {
                        UInt32 colorValue = Convert.ToUInt32(colorString.Substring(1), 16);
                        color = new sColor(myXmlNode.Attributes["name"].Value, colorValue);
                    }
                    else
                        color = new sColor(myXmlNode.Attributes["name"].Value, colorString);
                    
                    if (pColors[color.pName] == null)
                        pColors.Add(color.pName, color);
                    else
                    {
                        String errormessage = "More than one color defined with name " + color.pName;
                        errormessage += "\n\n" + ((sColor)pColors[color.pName]).pName + "\t#" + Convert.ToString(((sColor)pColors[color.pName]).pValue, 16); ;
                        errormessage += "\n" + color.pName + "\t#" + Convert.ToString(color.pValue, 16);

                        errormessage += "\n";
                        errormessage += "\n" + "The second definition will be deleted!";

                        MessageBox.Show(errormessage,
                            "Error while parsing color table",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                    }
                }

                string[] path2 = { "skin" };
                XmlNode Node = XmlHandler.XmlGetRootNodeElement(null/*path2*/);
                checkColor(Node.ChildNodes);

                sync(XmlHandler);
            }

            private void checkColor(XmlNodeList nodes)
            {
                foreach (XmlNode myXmlNode in nodes)
                {
                    if (myXmlNode.NodeType != XmlNodeType.Element)
                        continue;

                    if (myXmlNode.HasChildNodes)
                        checkColor(myXmlNode.ChildNodes);

                    if (myXmlNode.Attributes != null)
                    {
                        if (myXmlNode.Attributes["color"] != null)
                        {
                            if (myXmlNode.Attributes["color"].Value[0] == '#')
                            {
                                String colorString = myXmlNode.Attributes["color"].Value.Substring(1);
                                try
                                {
                                    uint colorValue = Convert.ToUInt32(colorString, 16);
                                    myXmlNode.Attributes["color"].Value = get(colorValue);
                                }
                                catch (Exception)
                                {
                                    myXmlNode.Attributes["color"].Value = colorString;
                                }
                            }
                        }
                        if (myXmlNode.Attributes["foregroundColor"] != null)
                        {
                            if (myXmlNode.Attributes["foregroundColor"].Value[0] == '#')
                            {
                                String colorString = myXmlNode.Attributes["foregroundColor"].Value.Substring(1);
                                try
                                {
                                    uint colorValue = Convert.ToUInt32(colorString, 16);
                                    myXmlNode.Attributes["foregroundColor"].Value = get(colorValue);
                                }
                                catch (Exception ex)
                                {
                                    myXmlNode.Attributes["foregroundColor"].Value = colorString;
                                }
                            }
                        }
                        if (myXmlNode.Attributes["backgroundColor"] != null)
                        {
                            if (myXmlNode.Attributes["backgroundColor"].Value[0] == '#')
                            {
                                String colorString = myXmlNode.Attributes["backgroundColor"].Value.Substring(1);
                                try
                                {
                                    uint colorValue = Convert.ToUInt32(colorString, 16);
                                    myXmlNode.Attributes["backgroundColor"].Value = get(colorValue);
                                }
                                catch (Exception ex)
                                {
                                    myXmlNode.Attributes["backgroundColor"].Value = colorString;
                                }
                            }
                        }
                        if (myXmlNode.Attributes["borderColor"] != null)
                        {
                            if (myXmlNode.Attributes["borderColor"].Value[0] == '#')
                            {
                                String colorString = myXmlNode.Attributes["borderColor"].Value.Substring(1);
                                try
                                {
                                    uint colorValue = Convert.ToUInt32(colorString, 16);
                                    myXmlNode.Attributes["borderColor"].Value = get(colorValue);
                                }
                                catch (Exception ex)
                                {
                                    myXmlNode.Attributes["borderColor"].Value = colorString;
                                }
                            }
                        }
                    }
                }
            }

            public void rename(cXMLHandler XmlHandler, String name, String to)
            {
                sColor color = (sColor)pColors[name];
                remove(color);
                color.pName = to;
                add(color);

                string[] path = { /*"skin", */"colors" };
                XmlNode Node = XmlHandler.XmlGetRootNodeElement(path);

                renameColor(Node.ChildNodes, name, to);
            }

            private void renameColor(XmlNodeList nodes, String name, String to)
            {
                foreach (XmlNode myXmlNode in nodes)
                {
                    if (myXmlNode.NodeType != XmlNodeType.Element)
                        continue;

                    if (myXmlNode.HasChildNodes)
                        renameColor(myXmlNode.ChildNodes, name, to);

                    if (myXmlNode.Attributes != null)
                    {
                        if (myXmlNode.Attributes["color"] != null)
                        {
                            if (myXmlNode.Attributes["color"].Value == name)
                            {
                                myXmlNode.Attributes["color"].Value = to;
                            }
                        }
                        if (myXmlNode.Attributes["foregroundColor"] != null)
                        {
                            if (myXmlNode.Attributes["foregroundColor"].Value == name)
                            {
                                myXmlNode.Attributes["foregroundColor"].Value = to;
                            }
                        }
                        if (myXmlNode.Attributes["backgroundColor"] != null)
                        {
                            if (myXmlNode.Attributes["backgroundColor"].Value == name)
                            {
                                myXmlNode.Attributes["backgroundColor"].Value = to;
                            }
                        }
                        if (myXmlNode.Attributes["borderColor"] != null)
                        {
                            if (myXmlNode.Attributes["borderColor"].Value == name)
                            {
                                myXmlNode.Attributes["borderColor"].Value = to;
                            }
                        }
                    }
                }
            }

            public override Object[] getArray()
            {
                ArrayList colors = new ArrayList();
                colors.AddRange(pColors.Values);
                colors.Sort();
                Object[] Aobjects = (Object[])colors.ToArray();
                sColor[] Acolors = new sColor[Aobjects.Length];
                Aobjects.CopyTo(Acolors, 0);
                return (Object[])Acolors;
            }

            public override Object get(String name)
            {
                if (name[0] == '#')
                {
                    return new sColor("undefined", Convert.ToUInt32(name.Substring(1), 16));
                }
                return (Object)pColors[name];
            }

            public String get(UInt32 value)
            {
                foreach (sColor color in pColors.Values)
                {
                    if (color.pValue == value)
                        return color.pName;
                }

                return add(new sColor("un" + Convert.ToString(value, 16), value));
            }

            public override String add(Object element)
            {
                sColor color = (sColor)element;
                foreach (sColor tmpcolor in pColors.Values)
                {
                    if (tmpcolor.pName == color.pName)
                    {
                        tmpcolor.pValue = color.pValue;
                        return color.pName;
                    }
                }

                pColors.Add(color.pName, color);
                return color.pName;
            }

            public override bool remove(Object element)
            {
                sColor color = (sColor)element;
                foreach (sColor tmpcolor in pColors.Values)
                {
                    if (tmpcolor.pName == color.pName)
                    {
                        pColors.Remove(tmpcolor.pName);
                        return true;
                    }
                }
                return false;
            }

            public override bool sync(cXMLHandler XmlHandler)
            {
                string[] path = { /*"skin", */"colors" };
                XmlNode colorNode = XmlHandler.XmlGetRootNodeElement(path);

                colorNode.RemoveAll();

                //Sort Names: an hashtable is not sortable, so convert it to an arraylist

                ArrayList sorter = new ArrayList();
                sorter.AddRange(pColors.Values);
                sorter.Sort();

                foreach (sColor color in sorter)
                {
                    if (color.isNamedColor)
                    {
                        String[] attributes = { "color",
                                            "name",  color.pName, 
                                            "value", color.pValueName };
                        XmlHandler.XmlAppendNode(colorNode, attributes);
                    }
                    else
                    {
                        String value = Convert.ToString(color.pValue, 16);
                        while (value.Length < 8)
                            value = "0" + value;

                        String[] attributes = { "color",
                                            "name",  color.pName, 
                                            "value", "#" + value };
                        XmlHandler.XmlAppendNode(colorNode, attributes);
                    }
                }

                return true;
            }
        }

        //#################################################################

        public class cDataBaseResolution
        {
            private sResolution pResolution = null;
            private XmlNode resolutionNode = null;

            public cDataBaseResolution(cXMLHandler XmlHandler)
            {
                string[] path = { /*"skin", */"output" };
                resolutionNode = XmlHandler.XmlGetRootNodeElement(path);
                foreach (XmlNode myXmlNode in resolutionNode.ChildNodes)
                {
                    if (myXmlNode.NodeType != XmlNodeType.Element)
                        continue;

                    pResolution = new sResolution(
                        Convert.ToUInt32(myXmlNode.Attributes["xres"].Value),
                        Convert.ToUInt32(myXmlNode.Attributes["yres"].Value),
                        Convert.ToUInt32(myXmlNode.Attributes["bpp"].Value)
                    );
                }
            }

            public sResolution getResolution()
            {
                return pResolution;
            }

            public void setResolution(uint x, uint y)
            {
                pResolution.Xres = x;
                pResolution.Yres = y;

                string[] path = { /*"skin", */"output" };
                foreach (XmlNode myXmlNode in resolutionNode.ChildNodes)
                {
                    if (myXmlNode.NodeType != XmlNodeType.Element)
                        continue;

                    myXmlNode.Attributes["xres"].Value = x.ToString();
                    myXmlNode.Attributes["yres"].Value = y.ToString();
                    //myXmlNode.Attributes["bpp"].Value = bpp.ToString();
                }
            }
        }

        //#################################################################

        static private void initFonts(cXMLHandler XmlHandler)
        {
            pFonts = new Hashtable();

            string[] path = { /*"skin", */"fonts" };
            XmlNode fontNode = XmlHandler.XmlGetRootNodeElement(path);
            if (fontNode == null)
            {
                //PVMC Workaround till proper fonts for plugins is implemented in enigma2
                //We expect that the fontloader pseudo screen is the first screen in the skin
                path[0] = "screen";
                fontNode = XmlHandler.XmlGetRootNodeElement(path);
                if (fontNode.Attributes["name"].Value == "PVMC_FontLoader")
                {
                    Hashtable elements = new Hashtable();
                    foreach (XmlNode myXmlNode in fontNode.ChildNodes)
                    {
                        if (myXmlNode.NodeType != XmlNodeType.Element)
                            continue;
                        elements.Add(myXmlNode.Attributes["name"].Value, myXmlNode.Attributes["text"].Value);
                    }

                    Int32 api = Convert.ToInt32(elements["API"] != null ? elements["API"] : "1");
                    if (api >= 2)
                    {
                        Int32 count = Convert.ToInt32(elements["COUNT"] != null ? elements["COUNT"] : "0");
                        for (int i = 0; i < count; i++)
                        {
                            string[] fontString = ((string)elements["FONT" + i.ToString()]).Split('|');

                            sFont font = new sFont(
                                fontString[1],
                                fontString[0],
                                Convert.ToInt32(fontString[2]),
                                fontString[3] != "False"
                            );
                            pFonts.Add(font.Name, font);
                        }
                    }
                }

            }
            else
            {
                foreach (XmlNode myXmlNode in fontNode.ChildNodes)
                {
                    if (myXmlNode.NodeType != XmlNodeType.Element)
                        continue;

                    sFont font = new sFont(
                        myXmlNode.Attributes["name"].Value,
                        myXmlNode.Attributes["filename"].Value,
                        Convert.ToInt32(myXmlNode.Attributes["scale"] != null ? myXmlNode.Attributes["scale"].Value : "100"),
                        Convert.ToInt32(myXmlNode.Attributes["replacement"] != null ? myXmlNode.Attributes["replacement"].Value : "0") != 0
                    );
                    pFonts.Add(font.Name, font);
                }
            }
        }

        static public sFont getFont(String name)
        {
            return (sFont)pFonts[name];
        }

        static public sFont[] getFonts()
        {
            sFont[] fonts = new sFont[pFonts.Count];
            pFonts.Values.CopyTo(fonts, 0);
            return fonts;
        }

        //#################################################################

        static public String getPath(String path)
        {
            if (path[0] == '~')
                return cProperties.getProperty("path_skin") + path.Substring(1);
            else if (path[0] == '@')
                return cProperties.getProperty("path_skins") + path.Substring(1); 
            else
                return cProperties.getProperty("path") + "/" + path; 
        }

        //#################################################################
        //#################################################################
        //#################################################################

        private static double scale_x = 1;
        private static double scale_y = 1;

        public static void rescaleLocations(cXMLHandler XmlHandler, int o_x, int o_y, int x, int y)
            {
                scale_x = (x * 1.0) / o_x;
                scale_y = (y * 1.0) / o_y;

                string[] path2 = { "skin" };
                XmlNode Node = XmlHandler.XmlGetRootNodeElement(path2);

                if (Node.HasChildNodes)
                    checkLocations(Node.ChildNodes);
            }

        private static void checkLocations(XmlNodeList nodes)
            {
                foreach (XmlNode node in nodes)
                {
                    if (node.NodeType != XmlNodeType.Element)
                        continue;

                    if (node.HasChildNodes)
                        checkLocations(node.ChildNodes);

                    if (node.Attributes != null)
                    {
                        int w = 0;
                        int h = 0;
                        if (node.Attributes["size"] != null)
                        {
                            {
                                double dw, dh;
                                try
                                {
                                    dw = Convert.ToInt32(node.Attributes["size"].Value.Substring(0, node.Attributes["size"].Value.IndexOf(',')));
                                }
                                catch (OverflowException e)
                                {
                                    dw = 0;
                                }
                                dw *= scale_x;
                                try
                                {
                                    dh = Convert.ToInt32(node.Attributes["size"].Value.Substring(node.Attributes["size"].Value.IndexOf(',') + 1));
                                }
                                catch (OverflowException e)
                                {
                                    dh = 0;
                                }
                                dh *= scale_y;

                                w = (int)dw;
                                h = (int)dh;

                                node.Attributes["size"].Value = w.ToString() + "," + h.ToString();
                            }
                        }
                        if (node.Attributes["position"] != null)
                        {
                            {
                                double dx, dy;
                                 try
                                {
                                    String sRelativeX = node.Attributes["position"].Value.Substring(0, node.Attributes["position"].Value.IndexOf(',')).Trim();
                                    if (sRelativeX.Equals("center"))
                                        dx = (cDataBase.pResolution.getResolution().Xres - w) >> 1 /*1/2*/;
                                    else
                                        dx = Convert.ToUInt32(sRelativeX);
                                }
                                catch (OverflowException e)
                                {
                                    dx = 0;
                                }
                                 dx *= scale_x;
                                try
                                {
                                    String sRelativeY = node.Attributes["position"].Value.Substring(node.Attributes["position"].Value.IndexOf(',') + 1).Trim();
                                    if (sRelativeY.Equals("center"))
                                        dy = (cDataBase.pResolution.getResolution().Yres - h) >> 1 /*1/2*/;
                                    else
                                        dy = Convert.ToUInt32(sRelativeY);
                                }
                                catch (OverflowException e)
                                {
                                    dy = 0;
                                }
                                dy *= scale_y;

                                int x = (int)dx;
                                int y = (int)dy;

                                node.Attributes["position"].Value = x.ToString() + "," + y.ToString();
                            }
                        }
                        
                        if (node.Attributes["font"] != null)
                        { //font="Regular;20"
                            String tmpfont = node.Attributes["font"].Value;
                            double size = Convert.ToDouble(tmpfont.Substring(tmpfont.IndexOf(';') + 1));
                            String fontname = tmpfont.Substring(0, tmpfont.IndexOf(';'));

                            size *= scale_x;

                            node.Attributes["font"].Value = fontname + "; " + Convert.ToInt32(size);
                        }
                    }
                }
            }
    }
}
