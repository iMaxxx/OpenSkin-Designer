using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.IO;
using OpenSkinDesigner.Logic;
using System.Windows.Forms;

namespace OpenSkinDesigner.Structures
{
    public class sFont
    {
        public const int DEFAULT_SCALE = 100;
        public const bool DEFAULT_REPLACEMENT = false;

        public String Name = "";
        public String Filename = "";
        public String Path = "";
        public System.Drawing.FontFamily FontFamily;
        public System.Drawing.FontStyle FontStyle;

        //if this isnt defined as global public, mono will lose the reference and crash!!!
        public PrivateFontCollection pfc;

        public System.Drawing.Font Font;
        public int Scale = 0;
        public bool Replacement = false;

        public sFont(String name, String path, int scale, bool replacement)
        {
            String fontPath = cProperties.getProperty("path_fonts");
            String skinPath = cProperties.getProperty("path_skin");
            String skinsPath = cProperties.getProperty("path");

            pfc = new PrivateFontCollection();

            Name = name; 
            Path = path;

            Scale = scale;
            Replacement = replacement;

            //This way we have only the file name, but what happens if the fonts are in the skin directory ?
            //Lets check all posibilities
            Filename = Path.Substring(Path.LastIndexOf('/')>0?Path.LastIndexOf('/')+1:0);
            String AbsolutPathFont = fontPath + "/" + Filename;
            String AbsolutPathSkinPathFont = skinsPath + "/" + skinPath + "/" + Filename;
            String RelativPathFont = Path;
            String RelativPathSkinPathFont = skinsPath + "/" + skinPath + "/" + Path;
            RelativPathFont = Path;
            RelativPathFont = RelativPathFont.Replace("enigma2", "");
            RelativPathFont = RelativPathFont.Replace("usr", "");
            RelativPathFont = RelativPathFont.Replace("local", "");
            RelativPathFont = RelativPathFont.Replace("share", "");
            RelativPathFont = RelativPathFont.Replace("var", "");
            RelativPathFont = skinsPath + "/" + RelativPathFont;

            AbsolutPathFont = AbsolutPathFont.Replace("\\", "/");
            AbsolutPathSkinPathFont = AbsolutPathSkinPathFont.Replace("\\", "/");
            RelativPathFont = RelativPathFont.Replace("\\", "/");
            RelativPathSkinPathFont = RelativPathSkinPathFont.Replace("\\", "/");


            //RelativPathFont = fontPath.Replace("fonts", "") + RelativPathFont;

            String lookupPath = "";
            if (File.Exists(AbsolutPathFont))
                lookupPath = new FileInfo(AbsolutPathFont).FullName;
            else if (File.Exists(AbsolutPathSkinPathFont))
                lookupPath = new FileInfo(AbsolutPathSkinPathFont).FullName;
            else if (File.Exists(RelativPathFont))
                lookupPath = new FileInfo(RelativPathFont).FullName;
            else if (File.Exists(RelativPathSkinPathFont))
                lookupPath = new FileInfo(RelativPathSkinPathFont).FullName;
            else
            {
                String errorMessage = "";
                errorMessage += "OpenSkinDesigner has searched in several places for the font \"" + Filename + ".\"\n";
                errorMessage += "Unfortunatly the search was not successful.\n";
                errorMessage += "\n";
                errorMessage += "Search Locations:\n";
                errorMessage += "\t" + new FileInfo(AbsolutPathFont).FullName + "\n";
                errorMessage += "\t" + new FileInfo(AbsolutPathSkinPathFont).FullName + "\n";
                errorMessage += "\t" + new FileInfo(RelativPathFont).FullName + "\n";
                errorMessage += "\t" + new FileInfo(RelativPathSkinPathFont).FullName + "\n";

                MessageBox.Show(errorMessage,
                    "Error while loading fonts",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                pfc.AddFontFile(lookupPath);
            }
            catch (FileNotFoundException error)
            {
                String errorMessage = "";
                errorMessage += "OpenSkinDesigner has tried to open the font \"" + Filename + "\".\n";
                errorMessage += "Unfortunatly this was not successful.\n";
                errorMessage += "Either the font type is not supported by e2kinner2,\n";
                errorMessage += "or it is not a vaild font.\n";
                errorMessage += "\n";
                errorMessage += "Location:\n";
                errorMessage += "\t" + new FileInfo(lookupPath).FullName + "\n" + error + "\n";

                MessageBox.Show(errorMessage,
                    "Error while loading fonts",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            FontFamily = pfc.Families[0];
            String name2 = FontFamily.GetName(0);
            FontStyle = System.Drawing.FontStyle.Regular;
            if (FontFamily.IsStyleAvailable(System.Drawing.FontStyle.Regular))
                FontStyle = System.Drawing.FontStyle.Regular;
            else
                FontStyle = System.Drawing.FontStyle.Bold;

            int t1 = FontFamily.GetCellAscent(FontStyle);
            int t2 = FontFamily.GetCellDescent(FontStyle);
            int t3 = FontFamily.GetEmHeight(FontStyle);
            int t4 = FontFamily.GetLineSpacing(FontStyle);
        }
    }
}
