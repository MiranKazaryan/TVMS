namespace TV_and_MS
{
    partial class Recovery_pass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recovery_pass));
            this.recovery_button = new System.Windows.Forms.Button();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recovery_button
            // 
            this.recovery_button.Location = new System.Drawing.Point(222, 85);
            this.recovery_button.Name = "recovery_button";
            this.recovery_button.Size = new System.Drawing.Size(75, 23);
            this.recovery_button.TabIndex = 0;
            this.recovery_button.Text = "Отправить";
            this.recovery_button.UseVisualStyleBackColor = true;
            this.recovery_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(15, 44);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(100, 20);
            this.mailBox.TabIndex = 1;
            this.mailBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mailBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите e-mail, на который отправится ваш пароль:";
            // 
            // Recovery_pass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 123);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.recovery_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Recovery_pass";
            this.Text = "Восстановление пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button recovery_button;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.Label label1;
    }
}