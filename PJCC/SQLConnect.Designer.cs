namespace PJCC
{
    partial class SQLConnect
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
            this.DBname = new MetroFramework.Controls.MetroTextBox();
            this.useName = new MetroFramework.Controls.MetroTextBox();
            this.passWord = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.serverName = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // DBname
            // 
            // 
            // 
            // 
            this.DBname.CustomButton.Image = null;
            this.DBname.CustomButton.Location = new System.Drawing.Point(394, 2);
            this.DBname.CustomButton.Name = "";
            this.DBname.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.DBname.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DBname.CustomButton.TabIndex = 1;
            this.DBname.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DBname.CustomButton.UseSelectable = true;
            this.DBname.CustomButton.Visible = false;
            this.DBname.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.DBname.Lines = new string[0];
            this.DBname.Location = new System.Drawing.Point(27, 97);
            this.DBname.MaxLength = 32767;
            this.DBname.Multiline = true;
            this.DBname.Name = "DBname";
            this.DBname.PasswordChar = '\0';
            this.DBname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DBname.SelectedText = "";
            this.DBname.SelectionLength = 0;
            this.DBname.SelectionStart = 0;
            this.DBname.Size = new System.Drawing.Size(422, 30);
            this.DBname.TabIndex = 1;
            this.DBname.UseSelectable = true;
            this.DBname.WaterMark = "Database Name.";
            this.DBname.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.DBname.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // useName
            // 
            // 
            // 
            // 
            this.useName.CustomButton.Image = null;
            this.useName.CustomButton.Location = new System.Drawing.Point(394, 2);
            this.useName.CustomButton.Name = "";
            this.useName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.useName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.useName.CustomButton.TabIndex = 1;
            this.useName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.useName.CustomButton.UseSelectable = true;
            this.useName.CustomButton.Visible = false;
            this.useName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.useName.Lines = new string[0];
            this.useName.Location = new System.Drawing.Point(27, 133);
            this.useName.MaxLength = 32767;
            this.useName.Multiline = true;
            this.useName.Name = "useName";
            this.useName.PasswordChar = '\0';
            this.useName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.useName.SelectedText = "";
            this.useName.SelectionLength = 0;
            this.useName.SelectionStart = 0;
            this.useName.Size = new System.Drawing.Size(422, 30);
            this.useName.TabIndex = 2;
            this.useName.UseSelectable = true;
            this.useName.WaterMark = "User Name";
            this.useName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.useName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // passWord
            // 
            // 
            // 
            // 
            this.passWord.CustomButton.Image = null;
            this.passWord.CustomButton.Location = new System.Drawing.Point(394, 2);
            this.passWord.CustomButton.Name = "";
            this.passWord.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.passWord.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passWord.CustomButton.TabIndex = 1;
            this.passWord.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passWord.CustomButton.UseSelectable = true;
            this.passWord.CustomButton.Visible = false;
            this.passWord.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.passWord.Lines = new string[0];
            this.passWord.Location = new System.Drawing.Point(27, 169);
            this.passWord.MaxLength = 32767;
            this.passWord.Multiline = true;
            this.passWord.Name = "passWord";
            this.passWord.PasswordChar = '*';
            this.passWord.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passWord.SelectedText = "";
            this.passWord.SelectionLength = 0;
            this.passWord.SelectionStart = 0;
            this.passWord.Size = new System.Drawing.Size(422, 30);
            this.passWord.TabIndex = 3;
            this.passWord.UseSelectable = true;
            this.passWord.WaterMark = "Password";
            this.passWord.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passWord.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.Gainsboro;
            this.metroButton1.Location = new System.Drawing.Point(171, 205);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(135, 33);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "UPDATE";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // serverName
            // 
            // 
            // 
            // 
            this.serverName.CustomButton.Image = null;
            this.serverName.CustomButton.Location = new System.Drawing.Point(394, 2);
            this.serverName.CustomButton.Name = "";
            this.serverName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.serverName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.serverName.CustomButton.TabIndex = 1;
            this.serverName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.serverName.CustomButton.UseSelectable = true;
            this.serverName.CustomButton.Visible = false;
            this.serverName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.serverName.Lines = new string[0];
            this.serverName.Location = new System.Drawing.Point(27, 61);
            this.serverName.MaxLength = 32767;
            this.serverName.Multiline = true;
            this.serverName.Name = "serverName";
            this.serverName.PasswordChar = '\0';
            this.serverName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.serverName.SelectedText = "";
            this.serverName.SelectionLength = 0;
            this.serverName.SelectionStart = 0;
            this.serverName.Size = new System.Drawing.Size(422, 30);
            this.serverName.TabIndex = 0;
            this.serverName.UseSelectable = true;
            this.serverName.WaterMark = "Server Name";
            this.serverName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.serverName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // SQLConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(472, 252);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.passWord);
            this.Controls.Add(this.useName);
            this.Controls.Add(this.DBname);
            this.MaximizeBox = false;
            this.Name = "SQLConnect";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "SQL Connection";
            this.Load += new System.EventHandler(this.SQLConnect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox DBname;
        private MetroFramework.Controls.MetroTextBox useName;
        private MetroFramework.Controls.MetroTextBox passWord;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox serverName;
    }
}