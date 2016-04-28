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

namespace OpenSkinDesigner.Frames
{
    public partial class fWindowstyle : Form
    {
        private cXMLHandler pXmlHandler = null;
        private cDesigner pDesigner = null;


        public fWindowstyle()
        {
            InitializeComponent();
            pDesigner = new cDesigner(pictureBoxPreview.CreateGraphics());
        }

        public void setup(cXMLHandler xmlhandler)
        {
            pXmlHandler = xmlhandler;
            
            refresh();
        }

        private void refresh()
        {
            sWindowStyle style = (sWindowStyle)cDataBase.pWindowstyles.get();
            foreach (sWindowStyle.sBorderSet borderset in style.pBorderSets.Values)
            {
                comboBoxStyles.Items.Add(borderset.pName);
            }

            comboBoxStyles.SelectedIndex = 0;

            //refreshStyle();
        }

        private void refreshStyle()
        {
            sWindowStyle style = (sWindowStyle)cDataBase.pWindowstyles.get();
            sWindowStyle.sBorderSet borderset = (sWindowStyle.sBorderSet)style.pBorderSets[comboBoxStyles.SelectedItem.ToString()];

            propertyGridTable.SelectedObject = borderset;

            if (borderset.pbpTopLeftName.Length > 0)
            {
                textBoxTopLeft.Text = borderset.pbpTopLeftName;
                pictureBoxTopLeft.Image = Image.FromFile(cDataBase.getPath(borderset.pbpTopLeftName));
            }
            if (borderset.pbpTopName.Length > 0)
            {
                textBoxTop.Text = borderset.pbpTopName;
                pictureBoxTop.Image = Image.FromFile(cDataBase.getPath(borderset.pbpTopName));
            }
            if (borderset.pbpTopRightName.Length > 0)
            {
                textBoxTopRight.Text = borderset.pbpTopRightName;
                pictureBoxTopRight.Image = Image.FromFile(cDataBase.getPath(borderset.pbpTopRightName));
            }


            if (borderset.pbpLeftName.Length > 0)
            {
                textBoxLeft.Text = borderset.pbpLeftName;
                pictureBoxLeft.Image = Image.FromFile(cDataBase.getPath(borderset.pbpLeftName));
            }
            if (borderset.pbpRightName.Length > 0)
            {
                textBoxRight.Text = borderset.pbpRightName;
                pictureBoxRight.Image = Image.FromFile(cDataBase.getPath(borderset.pbpRightName));
            }


            if (borderset.pbpBottomLeftName.Length > 0)
            {
                textBoxBottomLeft.Text = borderset.pbpBottomLeftName;
                pictureBoxBottomLeft.Image = Image.FromFile(cDataBase.getPath(borderset.pbpBottomLeftName));
            }
            if (borderset.pbpBottomName.Length > 0)
            {
                textBoxBottom.Text = borderset.pbpBottomName;
                pictureBoxBottom.Image = Image.FromFile(cDataBase.getPath(borderset.pbpBottomName));
            }
            if (borderset.pbpBottomRightName.Length > 0)
            {
                textBoxBottomRight.Text = borderset.pbpBottomRightName;
                pictureBoxBottomRight.Image = Image.FromFile(cDataBase.getPath(borderset.pbpBottomRightName));
            }


            sAttributeScreen attr = new sAttributeScreen(null);
            attr.pZPosition = -100;

            attr.pAbsolutX = attr.pRelativX = 50;
            attr.pAbsolutY = attr.pRelativY = 50;

            attr.pWidth = 200;
            attr.pHeight = 200;

            attr.pBackgroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["Background"];

            attr.pLabelForegroundColor = (sColor)((sWindowStyle)cDataBase.pWindowstyles.get()).pColors["LabelForeground"];

            attr.pTitle = "Title";

            attr.pTitleFont = ((sWindowStyle)cDataBase.pWindowstyles.get()).pFont;
            attr.pTitleSize = ((sWindowStyle)cDataBase.pWindowstyles.get()).pTitleSize * (((float)attr.pTitleFont.Scale) / 100.0F);

            attr.pTitleXOff = ((sWindowStyle)cDataBase.pWindowstyles.get()).pXOff;
            attr.pTitleYOff = ((sWindowStyle)cDataBase.pWindowstyles.get()).pYOff;

            attr.pbpTopLeft = borderset.pbpTopLeft;
            attr.pbpTop = borderset.pbpTop;
            attr.pbpTopRight = borderset.pbpTopRight;

            attr.pbpLeft = borderset.pbpLeft;
            attr.pbpRight = borderset.pbpRight;

            attr.pbpBottomLeft = borderset.pbpBottomLeft;
            attr.pbpBottom = borderset.pbpBottom;
            attr.pbpBottomRight = borderset.pbpBottomRight;

            //attr.Flags = "wfBorder";

            pDesigner.clear();
            pDesigner.draw(attr);
        }





        //########################################################################

        private void comboBoxStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStyle();
            pictureBoxPreview.Invalidate();
        }

        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            pDesigner.paint(sender, e);
        }
    }
}
