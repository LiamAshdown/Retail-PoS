namespace Client
{
    partial class Login
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
            this.Login_Box_Username = new System.Windows.Forms.TextBox();
            this.Login_Box_Password = new System.Windows.Forms.TextBox();
            this.Login_Label_Username = new System.Windows.Forms.Label();
            this.Login_Label_Password = new System.Windows.Forms.Label();
            this.Login_Button_Login = new System.Windows.Forms.Button();
            this.Login_Label_Logo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login_Box_Username
            // 
            this.Login_Box_Username.Location = new System.Drawing.Point(335, 181);
            this.Login_Box_Username.Name = "Login_Box_Username";
            this.Login_Box_Username.Size = new System.Drawing.Size(100, 20);
            this.Login_Box_Username.TabIndex = 0;
            // 
            // Login_Box_Password
            // 
            this.Login_Box_Password.Location = new System.Drawing.Point(335, 225);
            this.Login_Box_Password.Name = "Login_Box_Password";
            this.Login_Box_Password.Size = new System.Drawing.Size(100, 20);
            this.Login_Box_Password.TabIndex = 1;
            this.Login_Box_Password.UseSystemPasswordChar = true;
            // 
            // Login_Label_Username
            // 
            this.Login_Label_Username.AutoSize = true;
            this.Login_Label_Username.Location = new System.Drawing.Point(358, 165);
            this.Login_Label_Username.Name = "Login_Label_Username";
            this.Login_Label_Username.Size = new System.Drawing.Size(55, 13);
            this.Login_Label_Username.TabIndex = 2;
            this.Login_Label_Username.Text = "Username";
            // 
            // Login_Label_Password
            // 
            this.Login_Label_Password.AutoSize = true;
            this.Login_Label_Password.Location = new System.Drawing.Point(358, 209);
            this.Login_Label_Password.Name = "Login_Label_Password";
            this.Login_Label_Password.Size = new System.Drawing.Size(53, 13);
            this.Login_Label_Password.TabIndex = 3;
            this.Login_Label_Password.Text = "Password";
            // 
            // Login_Button_Login
            // 
            this.Login_Button_Login.Location = new System.Drawing.Point(348, 251);
            this.Login_Button_Login.Name = "Login_Button_Login";
            this.Login_Button_Login.Size = new System.Drawing.Size(75, 23);
            this.Login_Button_Login.TabIndex = 4;
            this.Login_Button_Login.Text = "Login";
            this.Login_Button_Login.UseVisualStyleBackColor = true;
            this.Login_Button_Login.Click += new System.EventHandler(this.Login_Button_Login_Click);
            // 
            // Login_Label_Logo
            // 
            this.Login_Label_Logo.AutoSize = true;
            this.Login_Label_Logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Label_Logo.Location = new System.Drawing.Point(111, 57);
            this.Login_Label_Logo.Name = "Login_Label_Logo";
            this.Login_Label_Logo.Size = new System.Drawing.Size(602, 73);
            this.Login_Label_Logo.TabIndex = 5;
            this.Login_Label_Logo.Text = "TILE POS SYSTEM";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Login_Label_Logo);
            this.Controls.Add(this.Login_Button_Login);
            this.Controls.Add(this.Login_Label_Password);
            this.Controls.Add(this.Login_Label_Username);
            this.Controls.Add(this.Login_Box_Password);
            this.Controls.Add(this.Login_Box_Username);
            this.Name = "Login";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Login_Box_Username;
        private System.Windows.Forms.TextBox Login_Box_Password;
        private System.Windows.Forms.Label Login_Label_Username;
        private System.Windows.Forms.Label Login_Label_Password;
        private System.Windows.Forms.Button Login_Button_Login;
        private System.Windows.Forms.Label Login_Label_Logo;
    }
}

