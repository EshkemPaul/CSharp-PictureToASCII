namespace PictureASCII
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.labelFileLoaded = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelMadeBy = new System.Windows.Forms.Label();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.buttonURL = new System.Windows.Forms.Button();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.labelPixels = new System.Windows.Forms.Label();
            this.buttonDeleteLocal = new System.Windows.Forms.Button();
            this.buttonDeleteURL = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLoad.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonLoad.Location = new System.Drawing.Point(430, 9);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(148, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load the local picture";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Enabled = false;
            this.buttonConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonConvert.Location = new System.Drawing.Point(12, 133);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(590, 22);
            this.buttonConvert.TabIndex = 1;
            this.buttonConvert.Text = "Convert to ASCII Art";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // labelFileLoaded
            // 
            this.labelFileLoaded.AutoSize = true;
            this.labelFileLoaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFileLoaded.ForeColor = System.Drawing.Color.Red;
            this.labelFileLoaded.Location = new System.Drawing.Point(206, 59);
            this.labelFileLoaded.Name = "labelFileLoaded";
            this.labelFileLoaded.Size = new System.Drawing.Size(99, 13);
            this.labelFileLoaded.TabIndex = 2;
            this.labelFileLoaded.Text = "[File not loaded]";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pixels: \"@%#*+=-:. \"",
            "Pixels: \"$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\" + \"\\\\|()1{}[]?-_+~<>i!lI;:,\" " +
                "+ \"\\\" ^`\'. \"",
            "Pixels: \"█▓▒░ \""});
            this.comboBox1.Location = new System.Drawing.Point(62, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(540, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(331, 107);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(271, 20);
            this.textBoxSize.TabIndex = 4;
            this.textBoxSize.Text = "80";
            this.textBoxSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSize_KeyPress);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSize.Location = new System.Drawing.Point(12, 110);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(313, 13);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = "Size (depends on your resolution screen or font size): ";
            // 
            // labelMadeBy
            // 
            this.labelMadeBy.AutoSize = true;
            this.labelMadeBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMadeBy.Location = new System.Drawing.Point(402, 165);
            this.labelMadeBy.Name = "labelMadeBy";
            this.labelMadeBy.Size = new System.Drawing.Size(200, 13);
            this.labelMadeBy.TabIndex = 6;
            this.labelMadeBy.Text = "Application made by Kamil Utratny";
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Enabled = false;
            this.textBoxLocal.Location = new System.Drawing.Point(12, 10);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(412, 20);
            this.textBoxLocal.TabIndex = 7;
            // 
            // buttonURL
            // 
            this.buttonURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonURL.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonURL.Location = new System.Drawing.Point(430, 34);
            this.buttonURL.Name = "buttonURL";
            this.buttonURL.Size = new System.Drawing.Size(148, 23);
            this.buttonURL.TabIndex = 8;
            this.buttonURL.Text = "Load picture from URL";
            this.buttonURL.UseVisualStyleBackColor = true;
            this.buttonURL.Click += new System.EventHandler(this.buttonURL_Click);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(12, 36);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(412, 20);
            this.textBoxURL.TabIndex = 9;
            // 
            // labelPixels
            // 
            this.labelPixels.AutoSize = true;
            this.labelPixels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPixels.Location = new System.Drawing.Point(12, 83);
            this.labelPixels.Name = "labelPixels";
            this.labelPixels.Size = new System.Drawing.Size(44, 13);
            this.labelPixels.TabIndex = 10;
            this.labelPixels.Text = "Pixels:";
            // 
            // buttonDeleteLocal
            // 
            this.buttonDeleteLocal.Enabled = false;
            this.buttonDeleteLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteLocal.ForeColor = System.Drawing.Color.Red;
            this.buttonDeleteLocal.Location = new System.Drawing.Point(579, 9);
            this.buttonDeleteLocal.Name = "buttonDeleteLocal";
            this.buttonDeleteLocal.Size = new System.Drawing.Size(23, 23);
            this.buttonDeleteLocal.TabIndex = 11;
            this.buttonDeleteLocal.Text = "X";
            this.buttonDeleteLocal.UseVisualStyleBackColor = true;
            this.buttonDeleteLocal.Click += new System.EventHandler(this.buttonDeleteLocal_Click);
            // 
            // buttonDeleteURL
            // 
            this.buttonDeleteURL.Enabled = false;
            this.buttonDeleteURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteURL.ForeColor = System.Drawing.Color.Red;
            this.buttonDeleteURL.Location = new System.Drawing.Point(579, 34);
            this.buttonDeleteURL.Name = "buttonDeleteURL";
            this.buttonDeleteURL.Size = new System.Drawing.Size(23, 23);
            this.buttonDeleteURL.TabIndex = 12;
            this.buttonDeleteURL.Text = "X";
            this.buttonDeleteURL.UseVisualStyleBackColor = true;
            this.buttonDeleteURL.Click += new System.EventHandler(this.buttonDeleteURL_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "English",
            "Deutsch",
            "Español",
            "Français",
            "Italiano",
            "Polski",
            "Português"});
            this.comboBox2.Location = new System.Drawing.Point(12, 159);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 185);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.buttonDeleteURL);
            this.Controls.Add(this.buttonDeleteLocal);
            this.Controls.Add(this.labelPixels);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.buttonURL);
            this.Controls.Add(this.textBoxLocal);
            this.Controls.Add(this.labelMadeBy);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelFileLoaded);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picture to ASCII Art";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label labelFileLoaded;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Label labelMadeBy;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.Button buttonURL;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label labelPixels;
        private System.Windows.Forms.Button buttonDeleteLocal;
        private System.Windows.Forms.Button buttonDeleteURL;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

