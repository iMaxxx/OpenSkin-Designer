namespace OpenSkinDesigner.Frames
{
    partial class fWindowstyle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fWindowstyle));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxStyles = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTable = new System.Windows.Forms.TabPage();
            this.propertyGridTable = new System.Windows.Forms.PropertyGrid();
            this.tabPageView = new System.Windows.Forms.TabPage();
            this.buttonBottomLeft = new System.Windows.Forms.Button();
            this.buttonBottom = new System.Windows.Forms.Button();
            this.buttonBottomRight = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonTopLeft = new System.Windows.Forms.Button();
            this.buttonTop = new System.Windows.Forms.Button();
            this.buttonTopRight = new System.Windows.Forms.Button();
            this.textBoxTopLeft = new System.Windows.Forms.TextBox();
            this.textBoxBottomLeft = new System.Windows.Forms.TextBox();
            this.textBoxBottomRight = new System.Windows.Forms.TextBox();
            this.textBoxBottom = new System.Windows.Forms.TextBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.textBoxTopRight = new System.Windows.Forms.TextBox();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.pictureBoxBottom = new System.Windows.Forms.PictureBox();
            this.pictureBoxBottomRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxBottomLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageTable.SuspendLayout();
            this.tabPageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(482, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Preview";
            // 
            // comboBoxStyles
            // 
            this.comboBoxStyles.FormattingEnabled = true;
            this.comboBoxStyles.Location = new System.Drawing.Point(78, 14);
            this.comboBoxStyles.Name = "comboBoxStyles";
            this.comboBoxStyles.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStyles.TabIndex = 26;
            this.comboBoxStyles.SelectedIndexChanged += new System.EventHandler(this.comboBoxStyles_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Style";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(487, 77);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPreview_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTable);
            this.tabControl1.Controls.Add(this.tabPageView);
            this.tabControl1.Location = new System.Drawing.Point(12, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(440, 334);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPageTable
            // 
            this.tabPageTable.Controls.Add(this.propertyGridTable);
            this.tabPageTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable.Name = "tabPageTable";
            this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable.Size = new System.Drawing.Size(432, 308);
            this.tabPageTable.TabIndex = 0;
            this.tabPageTable.Text = "Table";
            this.tabPageTable.UseVisualStyleBackColor = true;
            // 
            // propertyGridTable
            // 
            this.propertyGridTable.HelpVisible = false;
            this.propertyGridTable.Location = new System.Drawing.Point(0, 0);
            this.propertyGridTable.Name = "propertyGridTable";
            this.propertyGridTable.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridTable.Size = new System.Drawing.Size(432, 308);
            this.propertyGridTable.TabIndex = 0;
            // 
            // tabPageView
            // 
            this.tabPageView.Controls.Add(this.buttonBottomLeft);
            this.tabPageView.Controls.Add(this.buttonBottom);
            this.tabPageView.Controls.Add(this.buttonBottomRight);
            this.tabPageView.Controls.Add(this.buttonRight);
            this.tabPageView.Controls.Add(this.buttonLeft);
            this.tabPageView.Controls.Add(this.buttonTopLeft);
            this.tabPageView.Controls.Add(this.buttonTop);
            this.tabPageView.Controls.Add(this.buttonTopRight);
            this.tabPageView.Controls.Add(this.textBoxTopLeft);
            this.tabPageView.Controls.Add(this.textBoxBottomLeft);
            this.tabPageView.Controls.Add(this.textBoxBottomRight);
            this.tabPageView.Controls.Add(this.textBoxBottom);
            this.tabPageView.Controls.Add(this.textBoxLeft);
            this.tabPageView.Controls.Add(this.textBoxRight);
            this.tabPageView.Controls.Add(this.textBoxTopRight);
            this.tabPageView.Controls.Add(this.textBoxTop);
            this.tabPageView.Controls.Add(this.pictureBoxBottom);
            this.tabPageView.Controls.Add(this.pictureBoxBottomRight);
            this.tabPageView.Controls.Add(this.pictureBoxBottomLeft);
            this.tabPageView.Controls.Add(this.pictureBoxLeft);
            this.tabPageView.Controls.Add(this.pictureBoxRight);
            this.tabPageView.Controls.Add(this.pictureBoxTopLeft);
            this.tabPageView.Controls.Add(this.pictureBoxTopRight);
            this.tabPageView.Controls.Add(this.pictureBoxTop);
            this.tabPageView.Location = new System.Drawing.Point(4, 22);
            this.tabPageView.Name = "tabPageView";
            this.tabPageView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageView.Size = new System.Drawing.Size(432, 308);
            this.tabPageView.TabIndex = 1;
            this.tabPageView.Text = "View";
            this.tabPageView.UseVisualStyleBackColor = true;
            // 
            // buttonBottomLeft
            // 
            this.buttonBottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBottomLeft.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonBottomLeft.Location = new System.Drawing.Point(140, 250);
            this.buttonBottomLeft.Name = "buttonBottomLeft";
            this.buttonBottomLeft.Size = new System.Drawing.Size(20, 20);
            this.buttonBottomLeft.TabIndex = 59;
            this.buttonBottomLeft.UseMnemonic = false;
            this.buttonBottomLeft.UseVisualStyleBackColor = false;
            // 
            // buttonBottom
            // 
            this.buttonBottom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBottom.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonBottom.Location = new System.Drawing.Point(245, 250);
            this.buttonBottom.Name = "buttonBottom";
            this.buttonBottom.Size = new System.Drawing.Size(20, 20);
            this.buttonBottom.TabIndex = 58;
            this.buttonBottom.UseMnemonic = false;
            this.buttonBottom.UseVisualStyleBackColor = false;
            // 
            // buttonBottomRight
            // 
            this.buttonBottomRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBottomRight.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonBottomRight.Location = new System.Drawing.Point(350, 250);
            this.buttonBottomRight.Name = "buttonBottomRight";
            this.buttonBottomRight.Size = new System.Drawing.Size(20, 20);
            this.buttonBottomRight.TabIndex = 57;
            this.buttonBottomRight.UseMnemonic = false;
            this.buttonBottomRight.UseVisualStyleBackColor = false;
            // 
            // buttonRight
            // 
            this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRight.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonRight.Location = new System.Drawing.Point(405, 90);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(20, 20);
            this.buttonRight.TabIndex = 56;
            this.buttonRight.UseMnemonic = false;
            this.buttonRight.UseVisualStyleBackColor = false;
            // 
            // buttonLeft
            // 
            this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLeft.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonLeft.Location = new System.Drawing.Point(85, 90);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(20, 20);
            this.buttonLeft.TabIndex = 55;
            this.buttonLeft.UseMnemonic = false;
            this.buttonLeft.UseVisualStyleBackColor = false;
            // 
            // buttonTopLeft
            // 
            this.buttonTopLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTopLeft.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonTopLeft.Location = new System.Drawing.Point(140, 10);
            this.buttonTopLeft.Name = "buttonTopLeft";
            this.buttonTopLeft.Size = new System.Drawing.Size(20, 20);
            this.buttonTopLeft.TabIndex = 54;
            this.buttonTopLeft.UseMnemonic = false;
            this.buttonTopLeft.UseVisualStyleBackColor = false;
            // 
            // buttonTop
            // 
            this.buttonTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTop.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonTop.Location = new System.Drawing.Point(245, 10);
            this.buttonTop.Name = "buttonTop";
            this.buttonTop.Size = new System.Drawing.Size(20, 20);
            this.buttonTop.TabIndex = 53;
            this.buttonTop.UseMnemonic = false;
            this.buttonTop.UseVisualStyleBackColor = false;
            // 
            // buttonTopRight
            // 
            this.buttonTopRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTopRight.Image = global::OpenSkinDesigner.Properties.Resources.openfolderHS;
            this.buttonTopRight.Location = new System.Drawing.Point(350, 10);
            this.buttonTopRight.Name = "buttonTopRight";
            this.buttonTopRight.Size = new System.Drawing.Size(20, 20);
            this.buttonTopRight.TabIndex = 52;
            this.buttonTopRight.UseMnemonic = false;
            this.buttonTopRight.UseVisualStyleBackColor = false;
            // 
            // textBoxTopLeft
            // 
            this.textBoxTopLeft.Location = new System.Drawing.Point(60, 10);
            this.textBoxTopLeft.Name = "textBoxTopLeft";
            this.textBoxTopLeft.Size = new System.Drawing.Size(80, 20);
            this.textBoxTopLeft.TabIndex = 51;
            // 
            // textBoxBottomLeft
            // 
            this.textBoxBottomLeft.Location = new System.Drawing.Point(60, 250);
            this.textBoxBottomLeft.Name = "textBoxBottomLeft";
            this.textBoxBottomLeft.Size = new System.Drawing.Size(80, 20);
            this.textBoxBottomLeft.TabIndex = 50;
            // 
            // textBoxBottomRight
            // 
            this.textBoxBottomRight.Location = new System.Drawing.Point(270, 250);
            this.textBoxBottomRight.Name = "textBoxBottomRight";
            this.textBoxBottomRight.Size = new System.Drawing.Size(80, 20);
            this.textBoxBottomRight.TabIndex = 49;
            // 
            // textBoxBottom
            // 
            this.textBoxBottom.Location = new System.Drawing.Point(165, 250);
            this.textBoxBottom.Name = "textBoxBottom";
            this.textBoxBottom.Size = new System.Drawing.Size(80, 20);
            this.textBoxBottom.TabIndex = 48;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Location = new System.Drawing.Point(5, 90);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(80, 20);
            this.textBoxLeft.TabIndex = 47;
            // 
            // textBoxRight
            // 
            this.textBoxRight.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.textBoxRight.Location = new System.Drawing.Point(325, 90);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(80, 20);
            this.textBoxRight.TabIndex = 46;
            // 
            // textBoxTopRight
            // 
            this.textBoxTopRight.Location = new System.Drawing.Point(270, 10);
            this.textBoxTopRight.Name = "textBoxTopRight";
            this.textBoxTopRight.Size = new System.Drawing.Size(80, 20);
            this.textBoxTopRight.TabIndex = 45;
            // 
            // textBoxTop
            // 
            this.textBoxTop.Location = new System.Drawing.Point(165, 10);
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.Size = new System.Drawing.Size(80, 20);
            this.textBoxTop.TabIndex = 44;
            // 
            // pictureBoxBottom
            // 
            this.pictureBoxBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBottom.Location = new System.Drawing.Point(165, 195);
            this.pictureBoxBottom.Name = "pictureBoxBottom";
            this.pictureBoxBottom.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBottom.TabIndex = 43;
            this.pictureBoxBottom.TabStop = false;
            // 
            // pictureBoxBottomRight
            // 
            this.pictureBoxBottomRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxBottomRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBottomRight.Location = new System.Drawing.Point(270, 195);
            this.pictureBoxBottomRight.Name = "pictureBoxBottomRight";
            this.pictureBoxBottomRight.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxBottomRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBottomRight.TabIndex = 42;
            this.pictureBoxBottomRight.TabStop = false;
            // 
            // pictureBoxBottomLeft
            // 
            this.pictureBoxBottomLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBottomLeft.Location = new System.Drawing.Point(110, 195);
            this.pictureBoxBottomLeft.Name = "pictureBoxBottomLeft";
            this.pictureBoxBottomLeft.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxBottomLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBottomLeft.TabIndex = 41;
            this.pictureBoxBottomLeft.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLeft.Location = new System.Drawing.Point(110, 90);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(50, 100);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLeft.TabIndex = 40;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRight.Location = new System.Drawing.Point(270, 90);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(50, 100);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxRight.TabIndex = 39;
            this.pictureBoxRight.TabStop = false;
            // 
            // pictureBoxTopLeft
            // 
            this.pictureBoxTopLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTopLeft.Location = new System.Drawing.Point(110, 35);
            this.pictureBoxTopLeft.Name = "pictureBoxTopLeft";
            this.pictureBoxTopLeft.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxTopLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTopLeft.TabIndex = 38;
            this.pictureBoxTopLeft.TabStop = false;
            // 
            // pictureBoxTopRight
            // 
            this.pictureBoxTopRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxTopRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTopRight.Location = new System.Drawing.Point(270, 35);
            this.pictureBoxTopRight.Name = "pictureBoxTopRight";
            this.pictureBoxTopRight.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxTopRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTopRight.TabIndex = 37;
            this.pictureBoxTopRight.TabStop = false;
            // 
            // pictureBoxTop
            // 
            this.pictureBoxTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTop.Location = new System.Drawing.Point(165, 35);
            this.pictureBoxTop.Name = "pictureBoxTop";
            this.pictureBoxTop.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxTop.TabIndex = 36;
            this.pictureBoxTop.TabStop = false;
            // 
            // fWindowstyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 394);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxStyles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fWindowstyle";
            this.Text = "Window Style Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTable.ResumeLayout(false);
            this.tabPageView.ResumeLayout(false);
            this.tabPageView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxStyles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTable;
        private System.Windows.Forms.PropertyGrid propertyGridTable;
        private System.Windows.Forms.TabPage tabPageView;
        private System.Windows.Forms.Button buttonBottomLeft;
        private System.Windows.Forms.Button buttonBottom;
        private System.Windows.Forms.Button buttonBottomRight;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonTopLeft;
        private System.Windows.Forms.Button buttonTop;
        private System.Windows.Forms.Button buttonTopRight;
        private System.Windows.Forms.TextBox textBoxTopLeft;
        private System.Windows.Forms.TextBox textBoxBottomLeft;
        private System.Windows.Forms.TextBox textBoxBottomRight;
        private System.Windows.Forms.TextBox textBoxBottom;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.TextBox textBoxTopRight;
        private System.Windows.Forms.TextBox textBoxTop;
        private System.Windows.Forms.PictureBox pictureBoxBottom;
        private System.Windows.Forms.PictureBox pictureBoxBottomRight;
        private System.Windows.Forms.PictureBox pictureBoxBottomLeft;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxTopLeft;
        private System.Windows.Forms.PictureBox pictureBoxTopRight;
        private System.Windows.Forms.PictureBox pictureBoxTop;
    }
}