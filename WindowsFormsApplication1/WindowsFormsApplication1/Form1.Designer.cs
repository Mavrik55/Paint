namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WinL = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйРисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ывывToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ывывыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кистьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ластикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слоиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСлойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСлойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(12, 88);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(748, 473);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            this.AnT.Load += new System.EventHandler(this.AnT_Load);
            // 
            // WinL
            // 
            this.WinL.FormattingEnabled = true;
            this.WinL.Location = new System.Drawing.Point(766, 86);
            this.WinL.Name = "WinL";
            this.WinL.Size = new System.Drawing.Size(120, 469);
            this.WinL.TabIndex = 1;
            this.WinL.SelectedIndexChanged += new System.EventHandler(this.WinL_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.ывывToolStripMenuItem,
            this.слоиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(926, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйРисунокToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйРисунокToolStripMenuItem
            // 
            this.новыйРисунокToolStripMenuItem.Name = "новыйРисунокToolStripMenuItem";
            this.новыйРисунокToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.новыйРисунокToolStripMenuItem.Text = "Новый рисунок";
            // 
            // ывывToolStripMenuItem
            // 
            this.ывывToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ывывыToolStripMenuItem,
            this.кистьToolStripMenuItem,
            this.ластикToolStripMenuItem});
            this.ывывToolStripMenuItem.Name = "ывывToolStripMenuItem";
            this.ывывToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.ывывToolStripMenuItem.Text = "Рисование";
            this.ывывToolStripMenuItem.Click += new System.EventHandler(this.ывывToolStripMenuItem_Click);
            // 
            // ывывыToolStripMenuItem
            // 
            this.ывывыToolStripMenuItem.Name = "ывывыToolStripMenuItem";
            this.ывывыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ывывыToolStripMenuItem.Text = "Карандаш";
            // 
            // кистьToolStripMenuItem
            // 
            this.кистьToolStripMenuItem.Name = "кистьToolStripMenuItem";
            this.кистьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.кистьToolStripMenuItem.Text = "Кисть";
            // 
            // ластикToolStripMenuItem
            // 
            this.ластикToolStripMenuItem.Name = "ластикToolStripMenuItem";
            this.ластикToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ластикToolStripMenuItem.Text = "Ластик";
            // 
            // слоиToolStripMenuItem
            // 
            this.слоиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСлойToolStripMenuItem,
            this.удалитьСлойToolStripMenuItem});
            this.слоиToolStripMenuItem.Name = "слоиToolStripMenuItem";
            this.слоиToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.слоиToolStripMenuItem.Text = "Слои";
            this.слоиToolStripMenuItem.Click += new System.EventHandler(this.слоиToolStripMenuItem_Click);
            // 
            // добавитьСлойToolStripMenuItem
            // 
            this.добавитьСлойToolStripMenuItem.Name = "добавитьСлойToolStripMenuItem";
            this.добавитьСлойToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.добавитьСлойToolStripMenuItem.Text = "Добавить слой";
            // 
            // удалитьСлойToolStripMenuItem
            // 
            this.удалитьСлойToolStripMenuItem.Name = "удалитьСлойToolStripMenuItem";
            this.удалитьСлойToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.удалитьСлойToolStripMenuItem.Text = "Удалить слой";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 573);
            this.Controls.Add(this.WinL);
            this.Controls.Add(this.AnT);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckedListBox WinL;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйРисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ывывToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ывывыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кистьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ластикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слоиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСлойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСлойToolStripMenuItem;
    }
}

