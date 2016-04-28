using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenSkinDesigner.Logic;
using System.Collections;

namespace OpenSkinDesigner.Frames
{
    public partial class fPreferences : Form
    {
        public fPreferences()
        {
            InitializeComponent();

            foreach (DictionaryEntry key in cProperties.getProperties())
            {
                ListViewItem item = new ListViewItem(new String[] { key.Key.ToString(), key.Value.ToString() });
                listView1.Items.Add(item);
            }

            if(listView1.Items.Count > 0)
                listView1.RedrawItems(0, listView1.Items.Count - 1, false);
        }

    }
}
