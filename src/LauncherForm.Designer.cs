namespace UltiLaunch2
{
    partial class LauncherForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            bSelectDir = new Button();
            lDirectory = new Label();
            tbDirectory = new TextBox();
            lbFiles = new ListBox();
            bMount = new Button();
            bRun = new Button();
            lHostname = new Label();
            bConfig = new Button();
            SuspendLayout();
            // 
            // bSelectDir
            // 
            bSelectDir.Location = new Point(360, 6);
            bSelectDir.Name = "bSelectDir";
            bSelectDir.Size = new Size(36, 27);
            bSelectDir.TabIndex = 0;
            bSelectDir.Text = "...";
            bSelectDir.UseVisualStyleBackColor = true;
            bSelectDir.Click += bSelectDir_Click;
            // 
            // lDirectory
            // 
            lDirectory.AutoSize = true;
            lDirectory.Location = new Point(12, 9);
            lDirectory.Name = "lDirectory";
            lDirectory.Size = new Size(70, 20);
            lDirectory.TabIndex = 1;
            lDirectory.Text = "Directory";
            // 
            // tbDirectory
            // 
            tbDirectory.Location = new Point(88, 6);
            tbDirectory.Name = "tbDirectory";
            tbDirectory.Size = new Size(266, 27);
            tbDirectory.TabIndex = 2;
            tbDirectory.TextChanged += tbDirectory_TextChanged;
            // 
            // lbFiles
            // 
            lbFiles.FormattingEnabled = true;
            lbFiles.ItemHeight = 20;
            lbFiles.Location = new Point(12, 39);
            lbFiles.Name = "lbFiles";
            lbFiles.Size = new Size(284, 304);
            lbFiles.TabIndex = 3;
            lbFiles.SelectedIndexChanged += lbFiles_SelectedIndexChanged;
            lbFiles.DoubleClick += bMount_Click;
            // 
            // bMount
            // 
            bMount.Location = new Point(302, 39);
            bMount.Name = "bMount";
            bMount.Size = new Size(94, 29);
            bMount.TabIndex = 4;
            bMount.Text = "Mount";
            bMount.UseVisualStyleBackColor = true;
            bMount.Click += bMount_Click;
            // 
            // bRun
            // 
            bRun.Location = new Point(302, 74);
            bRun.Name = "bRun";
            bRun.Size = new Size(94, 29);
            bRun.TabIndex = 5;
            bRun.Text = "Run";
            bRun.UseVisualStyleBackColor = true;
            bRun.Click += bRun_Click;
            // 
            // lHostname
            // 
            lHostname.AutoSize = true;
            lHostname.Location = new Point(12, 350);
            lHostname.Name = "lHostname";
            lHostname.Size = new Size(87, 20);
            lHostname.TabIndex = 6;
            lHostname.Text = "IP Adddress";
            // 
            // bConfig
            // 
            bConfig.Location = new Point(360, 346);
            bConfig.Name = "bConfig";
            bConfig.Size = new Size(36, 29);
            bConfig.TabIndex = 7;
            bConfig.Text = "⚙";
            bConfig.UseVisualStyleBackColor = true;
            bConfig.Click += bConfig_Click;
            // 
            // LauncherForm
            // 
            AcceptButton = bMount;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 383);
            Controls.Add(bConfig);
            Controls.Add(lHostname);
            Controls.Add(bRun);
            Controls.Add(bMount);
            Controls.Add(lbFiles);
            Controls.Add(tbDirectory);
            Controls.Add(lDirectory);
            Controls.Add(bSelectDir);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LauncherForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Ultimate Launcher";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bSelectDir;
        private Label lDirectory;
        private TextBox tbDirectory;
        private ListBox lbFiles;
        private Button bMount;
        private Button bRun;
        private Label lHostname;
        private Button bConfig;
    }
}