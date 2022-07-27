namespace TV_and_MS
{
    partial class Lecture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lecture));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.webB = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основноеМенюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзСистемыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.listBox1.Items.AddRange(new object[] {
            "",
            "§1. Испытания и события",
            "§2. Относительная частота случайного события. Статистическая вероятность",
            "§3. Классическое определение вероятности",
            "§4. Геометрические вероятности",
            "§5. Основные формулы комбинаторики",
            "§6. Основные теоремы о вероятности",
            "§7. Формула полной вероятности. Формулы Байесса",
            "§8. Схема повторения независимых испытаний. Формула Бернулли. Производящая функци" +
                "я.",
            "§9. Локальная и интегральная теоремы Лапласа. Формула Пуассона"});
            this.listBox1.Location = new System.Drawing.Point(0, 62);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(729, 143);
            this.listBox1.TabIndex = 40;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // webB
            // 
            this.webB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webB.Location = new System.Drawing.Point(0, 62);
            this.webB.MinimumSize = new System.Drawing.Size(20, 20);
            this.webB.Name = "webB";
            this.webB.Size = new System.Drawing.Size(729, 608);
            this.webB.TabIndex = 39;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.основноеМенюToolStripMenuItem,
            this.выходИзСистемыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 24);
            this.menuStrip1.TabIndex = 114;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // основноеМенюToolStripMenuItem
            // 
            this.основноеМенюToolStripMenuItem.Name = "основноеМенюToolStripMenuItem";
            this.основноеМенюToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.основноеМенюToolStripMenuItem.Text = "Основное меню";
            this.основноеМенюToolStripMenuItem.Click += new System.EventHandler(this.основноеМенюToolStripMenuItem_Click);
            // 
            // выходИзСистемыToolStripMenuItem
            // 
            this.выходИзСистемыToolStripMenuItem.Name = "выходИзСистемыToolStripMenuItem";
            this.выходИзСистемыToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.выходИзСистемыToolStripMenuItem.Text = "Выход из системы";
            this.выходИзСистемыToolStripMenuItem.Click += new System.EventHandler(this.выходИзСистемыToolStripMenuItem_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(12, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(105, 20);
            this.linkLabel1.TabIndex = 43;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Содержание";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Lecture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(729, 669);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.webB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Lecture";
            this.Text = "Теоретический материал";
            this.Load += new System.EventHandler(this.Lecture_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.WebBrowser webB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основноеМенюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзСистемыToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}