namespace TV_and_MS
{
    partial class Autorization
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autorization));
            this.autorization_button = new System.Windows.Forms.Button();
            this.login_box = new System.Windows.Forms.TextBox();
            this.password_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.registrate_link = new System.Windows.Forms.LinkLabel();
            this.pass_Label = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // autorization_button
            // 
            this.autorization_button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autorization_button.Location = new System.Drawing.Point(183, 109);
            this.autorization_button.Name = "autorization_button";
            this.autorization_button.Size = new System.Drawing.Size(52, 30);
            this.autorization_button.TabIndex = 0;
            this.autorization_button.Text = "Вход";
            this.autorization_button.UseVisualStyleBackColor = true;
            this.autorization_button.Click += new System.EventHandler(this.autorization_button_Click);
            // 
            // login_box
            // 
            this.login_box.Location = new System.Drawing.Point(86, 18);
            this.login_box.Name = "login_box";
            this.login_box.Size = new System.Drawing.Size(149, 20);
            this.login_box.TabIndex = 1;
            this.login_box.Text = "mir";
            // 
            // password_box
            // 
            this.password_box.Location = new System.Drawing.Point(86, 52);
            this.password_box.Name = "password_box";
            this.password_box.PasswordChar = '*';
            this.password_box.Size = new System.Drawing.Size(149, 20);
            this.password_box.TabIndex = 2;
            this.password_box.Text = "butterfly28";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // registrate_link
            // 
            this.registrate_link.AutoSize = true;
            this.registrate_link.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registrate_link.LinkColor = System.Drawing.Color.OrangeRed;
            this.registrate_link.Location = new System.Drawing.Point(28, 78);
            this.registrate_link.Name = "registrate_link";
            this.registrate_link.Size = new System.Drawing.Size(94, 19);
            this.registrate_link.TabIndex = 5;
            this.registrate_link.TabStop = true;
            this.registrate_link.Text = "Регистрация";
            this.registrate_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registrate_link_LinkClicked);
            // 
            // pass_Label
            // 
            this.pass_Label.AutoSize = true;
            this.pass_Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_Label.LinkColor = System.Drawing.Color.OrangeRed;
            this.pass_Label.Location = new System.Drawing.Point(141, 78);
            this.pass_Label.Name = "pass_Label";
            this.pass_Label.Size = new System.Drawing.Size(118, 19);
            this.pass_Label.TabIndex = 6;
            this.pass_Label.TabStop = true;
            this.pass_Label.Text = "Забыли пароль?";
            this.pass_Label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pass_Label_LinkClicked);
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 155);
            this.Controls.Add(this.pass_Label);
            this.Controls.Add(this.registrate_link);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.login_box);
            this.Controls.Add(this.autorization_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Autorization";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Autorization_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button autorization_button;
        private System.Windows.Forms.TextBox login_box;
        private System.Windows.Forms.TextBox password_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel registrate_link;
        private System.Windows.Forms.LinkLabel pass_Label;
    }
}

