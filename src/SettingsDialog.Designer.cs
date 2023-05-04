namespace UltiLaunch2
{
    partial class SettingsDialog
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
            label1 = new Label();
            tbHostName = new TextBox();
            bOk = new Button();
            bCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(192, 20);
            label1.TabIndex = 0;
            label1.Text = "Ultimate hostname/address";
            // 
            // tbHostName
            // 
            tbHostName.Location = new Point(210, 6);
            tbHostName.Name = "tbHostName";
            tbHostName.Size = new Size(217, 27);
            tbHostName.TabIndex = 1;
            // 
            // bOk
            // 
            bOk.DialogResult = DialogResult.OK;
            bOk.Location = new Point(333, 39);
            bOk.Name = "bOk";
            bOk.Size = new Size(94, 29);
            bOk.TabIndex = 2;
            bOk.Text = "OK";
            bOk.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            bCancel.DialogResult = DialogResult.Cancel;
            bCancel.Location = new Point(233, 39);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(94, 29);
            bCancel.TabIndex = 3;
            bCancel.Text = "Cancel";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            AcceptButton = bOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 79);
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Controls.Add(tbHostName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "SettingsDialog";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbHostName;
        private Button bOk;
        private Button bCancel;
    }
}