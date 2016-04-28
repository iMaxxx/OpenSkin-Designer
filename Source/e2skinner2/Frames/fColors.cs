using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using OpenSkinDesigner.Logic;
using OpenSkinDesigner.Structures;

namespace OpenSkinDesigner.Frames
{
    public partial class fColors : Form
    {
        const Int32 COL_NAME = 0;
        const Int32 COL_VALUE_AS_STRING = 1;
        const Int32 COL_VALUE = 2;

        private cXMLHandler pXmlHandler = null;

        public fColors()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            listView1.Items.Clear();

            sColor[] colors = (sColor[])cDataBase.pColors.getArray();

            foreach (sColor color in colors)
            {
                System.Windows.Forms.ListViewItem.ListViewSubItem[] subtitems = new System.Windows.Forms.ListViewItem.ListViewSubItem[3];

                subtitems[COL_NAME] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[COL_NAME].Text = color.pName;

                subtitems[COL_VALUE_AS_STRING] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                if (color.isNamedColor)
                    continue; //subtitems[COL_VALUE_AS_STRING].Text = color.pValueName;
                else
                    subtitems[COL_VALUE_AS_STRING].Text = "#" + Convert.ToString(color.pValue, 16);

                subtitems[COL_VALUE] = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                subtitems[COL_VALUE].BackColor = Color.FromArgb(255, color.Color);
                subtitems[COL_VALUE].Text = "    ";

                ListViewItem item = new ListViewItem(subtitems, 0);
                item.UseItemStyleForSubItems = false;
                listView1.Items.Add(item);
            }
            listView1.RedrawItems(0, listView1.Items.Count - 1, false);
        }

        public void setup(cXMLHandler xmlhandler)
        {
            pXmlHandler = xmlhandler;

            refresh();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBoxName.Text = listView1.SelectedItems[0].SubItems[COL_NAME].Text;
                Color color = listView1.SelectedItems[0].SubItems[COL_VALUE].BackColor;
                textBoxValue.Text = Convert.ToString(color.ToArgb(), 16);
                textBoxAlpha.Text = color.A.ToString();
                textBoxRed.Text = color.R.ToString();
                textBoxGreen.Text = color.G.ToString();
                textBoxBlue.Text = color.B.ToString();

                pictureBoxColor.BackColor = Color.FromArgb(255, color);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                String itmName = item.SubItems[COL_NAME].Text;
                String itmValueAsString = item.SubItems[COL_VALUE_AS_STRING].Text;
                if (itmValueAsString[0] == '#')
                    cDataBase.pColors.add((Object)new sColor(itmName, Convert.ToUInt32(itmValueAsString.Substring(1), 16)));
                else
                    cDataBase.pColors.add((Object)new sColor(itmName, itmValueAsString));
            }

            refresh();

            cDataBase.pColors.sync(pXmlHandler);
            Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length > 0 && textBoxValue.Text.Length > 0)
            {
                String itmName = textBoxName.Text;
                UInt32 itmColor = Convert.ToUInt32(textBoxValue.Text, 16);

                cDataBase.pColors.add((Object)new sColor(itmName, itmColor));
            }
            refresh();
        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            String colorString = "0";
            UInt32 color = 0;
            try
            {
                colorString = textBoxValue.Text.Length > 0 ? textBoxValue.Text.Replace(" ", "") : "0";
                if (colorString.Length > 8)
                    colorString = colorString.Substring(0, 8);
                color = Convert.ToUInt32(colorString, 16);
            }
            catch (Exception error)
            {
                String errormessage = error.Message + ":\n\n";
                errormessage += "Invalid format for value hexadecimal value!" + "\n";
                errormessage += error.Message;

                MessageBox.Show(errormessage,
                    error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                return;
            }
            int alpha = (int)(color >> 24) & 0xff;
            textBoxAlpha.Text = alpha.ToString();
            int red = (int)(color >> 16) & 0xff;
            textBoxRed.Text = red.ToString();
            int green = (int)(color >> 8) & 0xff;
            textBoxGreen.Text = green.ToString();
            int blue = (int)color & 0xff;
            textBoxBlue.Text = blue.ToString();
            pictureBoxColor.BackColor = Color.FromArgb(/*alpha, */(int)red, (int)green, (int)blue);

            listView1.SelectedItems[0].SubItems[COL_VALUE_AS_STRING].Text = "#" + textBoxValue.Text;
            listView1.SelectedItems[0].SubItems[COL_VALUE].BackColor = pictureBoxColor.BackColor;
        }

        private void textBoxAlpha_TextChanged(object sender, EventArgs e)
        {
            UInt32 alpha = 0;
            UInt32 red = 0;
            UInt32 green = 0;
            UInt32 blue = 0;

            try
            {
                String alphaString = textBoxAlpha.Text.Length > 0 ? textBoxAlpha.Text.Trim() : "0";
                alpha = Convert.ToUInt32(alphaString);
                alpha &= 0xFF;
            }
            catch (Exception error)
            {
                String errormessage = error.Message + ":\n\n";
                errormessage += "Invalid format for value alpha!" + "\n";
                errormessage += error.Message;

                MessageBox.Show(errormessage,
                    error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                String redString = textBoxRed.Text.Length > 0 ? textBoxRed.Text.Trim() : "0";
                red = Convert.ToUInt32(redString);
                red &= 0xFF;
            }
            catch (Exception error)
            {
                String errormessage = error.Message + ":\n\n";
                errormessage += "Invalid format for value red!" + "\n";
                errormessage += error.Message;

                MessageBox.Show(errormessage,
                    error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                String greenString = textBoxGreen.Text.Length > 0 ? textBoxGreen.Text.Trim() : "0";
                green = Convert.ToUInt32(greenString);
                green &= 0xFF;
            }
            catch (Exception error)
            {
                String errormessage = error.Message + ":\n\n";
                errormessage += "Invalid format for value green!" + "\n";
                errormessage += error.Message;

                MessageBox.Show(errormessage,
                    error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            try
            {
                String blueString = textBoxBlue.Text.Length > 0 ? textBoxBlue.Text.Trim() : "0";
                blue = Convert.ToUInt32(blueString);
                blue &= 0xFF;
            }
            catch (Exception error)
            {
                String errormessage = error.Message + ":\n\n";
                errormessage += "Invalid format for value blue!" + "\n";
                errormessage += error.Message;

                MessageBox.Show(errormessage,
                    error.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            UInt32 value = /*Convert.ToUInt32*/((alpha * 0x01000000) + (red * 0x00010000) + (green * 0x00000100) + blue);
            textBoxValue.Text = Convert.ToString(value, 16);

            pictureBoxColor.BackColor = Color.FromArgb(/*alpha, */(int)red, (int)green, (int)blue);
        }

        private void buttonPallete_Click(object sender, EventArgs e)
        {
            colorDialog.AllowFullOpen = true;
            colorDialog.AnyColor = true;
            colorDialog.FullOpen = true;
            UInt32 color = (Convert.ToUInt32(textBoxValue.Text,16)&0x00FFFFFF);
            UInt32 colorSwap = color;
            colorSwap |= (((colorSwap >> 16) & 0xFF) << 24);
            colorSwap &= 0xFF00FFFF;
            colorSwap |= (((colorSwap >> 0) & 0xFF) << 16);
            colorSwap &= 0xFFFFFF00;
            colorSwap |= (((colorSwap >> 24) & 0xFF) << 0);
            colorSwap &= 0x00FFFFFF;
            colorDialog.CustomColors = new int[] { (Int32)colorSwap, };
            colorDialog.Color = Color.FromArgb((Int32)color );
            DialogResult rst = colorDialog.ShowDialog();
            if (rst == DialogResult.OK)
            {
                textBoxRed.Text = Convert.ToString(colorDialog.Color.R);
                textBoxGreen.Text = Convert.ToString(colorDialog.Color.G);
                textBoxBlue.Text = Convert.ToString(colorDialog.Color.B);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unused colors are removed automatically.");
        }


        private void buttonRename_Click(object sender, EventArgs e)
        {
            cDataBase.pColors.rename(pXmlHandler, listView1.SelectedItems[0].SubItems[COL_NAME].Text, textBoxName.Text);
            listView1.SelectedItems[0].SubItems[COL_NAME].Text = textBoxName.Text;
            Refresh();
        }

    }
}
