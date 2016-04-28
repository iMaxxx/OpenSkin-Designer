using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenSkinDesigner.Logic;
using OpenSkinDesigner.Structures;
using System.Drawing.Text;
using System.IO;

namespace OpenSkinDesigner.Frames
{
    public partial class fFonts : Form
    {
        private cXMLHandler pXmlHandler = null;

        public fFonts()
        {
            InitializeComponent();
        }

        public void setup(cXMLHandler xmlhandler)
        {
            pXmlHandler = xmlhandler;

            sFont[] fonts = cDataBase.getFonts();

            //listView1.Clear();
            foreach (sFont font in fonts)
            {
                System.Windows.Forms.ListViewItem.ListViewSubItem[] subtitems = new System.Windows.Forms.ListViewItem.ListViewSubItem[6];

                subtitems[0] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[0].Text = font.Name;
                subtitems[1] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[1].Text = font.Filename;
                subtitems[2] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[2].Text = font.Path;
                subtitems[3] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[3].Text = Convert.ToString(font.Scale);
                subtitems[4] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[4].Text = Convert.ToString(font.Replacement);
                subtitems[5] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[5].Text = "0";
                ListViewItem item = new ListViewItem(subtitems, 0);
                listView1.Items.Add(item);
            }
            listView1.RedrawItems(0, listView1.Items.Count - 1, false);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBoxName.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBoxPath.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBoxScale.Text = listView1.SelectedItems[0].SubItems[3].Text;
                checkBoxReplacement.Checked = Convert.ToBoolean(listView1.SelectedItems[0].SubItems[4].Text);

                float pSize = 20.25F;
                sFont pFont = cDataBase.getFont(textBoxName.Text);

                System.Drawing.Font font = null;
                String name = "";
                try
                {
                    if (pFont.FontFamily != null) //Only do this if the font is valid
                    {
                        name = pFont.FontFamily.GetName(0);

                        font = new System.Drawing.Font(pFont.FontFamily, pSize, pFont.FontStyle, GraphicsUnit.Pixel);
                        textBoxPreview.Font = font;
                        textBoxPreview.Text = "Test String 1234567890 !#?";
                    } else
                    {
                        Console.WriteLine("Font painting failed! (" + pFont.Name + ")");
                        textBoxPreview.Text ="Font failed !";
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Font painting failed! (" + pFont.Name + ")\n" + error);
                    textBoxPreview.Text = "Font failed !";
                    return;
                }

                
            }
        }
    }
}
