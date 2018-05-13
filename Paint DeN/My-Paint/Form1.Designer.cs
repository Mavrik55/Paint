namespace My_Paint
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйРисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чистыйПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скопироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слоиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСлойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСлойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.карандашToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кистьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стеркаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прямаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.Слои = new System.Windows.Forms.CheckedListBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.color1 = new System.Windows.Forms.Panel();
            this.color2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.changeColor = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Вернуть = new System.Windows.Forms.PictureBox();
            this.Отменить = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Вернуть)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Отменить)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.слоиToolStripMenuItem,
            this.рисованиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйРисунокToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйРисунокToolStripMenuItem
            // 
            this.новыйРисунокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.чистыйПроектToolStripMenuItem,
            this.изФайлаToolStripMenuItem});
            this.новыйРисунокToolStripMenuItem.Name = "новыйРисунокToolStripMenuItem";
            this.новыйРисунокToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.новыйРисунокToolStripMenuItem.Text = "Новый рисунок";
            // 
            // чистыйПроектToolStripMenuItem
            // 
            this.чистыйПроектToolStripMenuItem.Name = "чистыйПроектToolStripMenuItem";
            this.чистыйПроектToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.чистыйПроектToolStripMenuItem.Text = "Читсый проект";
            this.чистыйПроектToolStripMenuItem.Click += new System.EventHandler(this.читсыйПроектToolStripMenuItem_Click);
            // 
            // изФайлаToolStripMenuItem
            // 
            this.изФайлаToolStripMenuItem.Name = "изФайлаToolStripMenuItem";
            this.изФайлаToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.изФайлаToolStripMenuItem.Text = "Из  файла";
            this.изФайлаToolStripMenuItem.Click += new System.EventHandler(this.изФайлаToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьToolStripMenuItem,
            this.вернутьToolStripMenuItem,
            this.скопироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            // 
            // вернутьToolStripMenuItem
            // 
            this.вернутьToolStripMenuItem.Name = "вернутьToolStripMenuItem";
            this.вернутьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.вернутьToolStripMenuItem.Text = "Вернуть";
            // 
            // скопироватьToolStripMenuItem
            // 
            this.скопироватьToolStripMenuItem.Name = "скопироватьToolStripMenuItem";
            this.скопироватьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.скопироватьToolStripMenuItem.Text = "Скопировать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // слоиToolStripMenuItem
            // 
            this.слоиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСлойToolStripMenuItem,
            this.удалитьСлойToolStripMenuItem});
            this.слоиToolStripMenuItem.Name = "слоиToolStripMenuItem";
            this.слоиToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.слоиToolStripMenuItem.Text = "Слои";
            // 
            // добавитьСлойToolStripMenuItem
            // 
            this.добавитьСлойToolStripMenuItem.Name = "добавитьСлойToolStripMenuItem";
            this.добавитьСлойToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.добавитьСлойToolStripMenuItem.Text = "Добавить слой";
            this.добавитьСлойToolStripMenuItem.Click += new System.EventHandler(this.добавитьСлойToolStripMenuItem_Click);
            // 
            // удалитьСлойToolStripMenuItem
            // 
            this.удалитьСлойToolStripMenuItem.Name = "удалитьСлойToolStripMenuItem";
            this.удалитьСлойToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.удалитьСлойToolStripMenuItem.Text = "Удалить слой";
            this.удалитьСлойToolStripMenuItem.Click += new System.EventHandler(this.удалитьСлойToolStripMenuItem_Click);
            // 
            // рисованиеToolStripMenuItem
            // 
            this.рисованиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.карандашToolStripMenuItem,
            this.кистьToolStripMenuItem,
            this.стеркаToolStripMenuItem,
            this.текстToolStripMenuItem,
            this.прямаяToolStripMenuItem});
            this.рисованиеToolStripMenuItem.Name = "рисованиеToolStripMenuItem";
            this.рисованиеToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.рисованиеToolStripMenuItem.Text = "Рисование";
            this.рисованиеToolStripMenuItem.Click += new System.EventHandler(this.рисованиеToolStripMenuItem_Click);
            // 
            // карандашToolStripMenuItem
            // 
            this.карандашToolStripMenuItem.Name = "карандашToolStripMenuItem";
            this.карандашToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.карандашToolStripMenuItem.Text = "Карандаш";
            this.карандашToolStripMenuItem.Click += new System.EventHandler(this.карандашToolStripMenuItem_Click);
            // 
            // кистьToolStripMenuItem
            // 
            this.кистьToolStripMenuItem.Name = "кистьToolStripMenuItem";
            this.кистьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.кистьToolStripMenuItem.Text = "Кисть";
            this.кистьToolStripMenuItem.Click += new System.EventHandler(this.кистьToolStripMenuItem_Click);
            // 
            // стеркаToolStripMenuItem
            // 
            this.стеркаToolStripMenuItem.Name = "стеркаToolStripMenuItem";
            this.стеркаToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.стеркаToolStripMenuItem.Text = "Стерка";
            this.стеркаToolStripMenuItem.Click += new System.EventHandler(this.стеркаToolStripMenuItem_Click);
            // 
            // текстToolStripMenuItem
            // 
            this.текстToolStripMenuItem.Name = "текстToolStripMenuItem";
            this.текстToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.текстToolStripMenuItem.Text = "Текст";
            // 
            // прямаяToolStripMenuItem
            // 
            this.прямаяToolStripMenuItem.Name = "прямаяToolStripMenuItem";
            this.прямаяToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.прямаяToolStripMenuItem.Text = "Прямая";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(239, 49);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton1.Text = "Стандартная кисть";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton2.Text = "Перекрещенная кисть";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton3.Text = "Кисть из bmp файла";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton6.Text = "Стерка";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 46);
            this.toolStripButton7.Text = "Заливка";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 46);
            this.toolStripButton8.Text = "Спрей";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(0, 85);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(890, 475);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 2;
            this.AnT.Load += new System.EventHandler(this.AnT_Load);
            this.AnT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseMove);
            this.AnT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseUp);
            // 
            // Слои
            // 
            this.Слои.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Слои.ForeColor = System.Drawing.Color.DarkRed;
            this.Слои.FormattingEnabled = true;
            this.Слои.HorizontalScrollbar = true;
            this.Слои.Location = new System.Drawing.Point(896, 30);
            this.Слои.Name = "Слои";
            this.Слои.Size = new System.Drawing.Size(86, 274);
            this.Слои.TabIndex = 3;
            this.Слои.SelectedIndexChanged += new System.EventHandler(this.LayersControl_SelectedIndexChanged);
            this.Слои.SelectedValueChanged += new System.EventHandler(this.LayersControl_SelectedValueChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip2.Location = new System.Drawing.Point(239, 26);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(112, 47);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(42, 42);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // RenderTimer
            // 
            this.RenderTimer.Interval = 20;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // color1
            // 
            this.color1.BackColor = System.Drawing.Color.Black;
            this.color1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.color1.Location = new System.Drawing.Point(525, 40);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(31, 30);
            this.color1.TabIndex = 9;
            this.color1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.color1_MouseClick);
            // 
            // color2
            // 
            this.color2.BackColor = System.Drawing.Color.Ivory;
            this.color2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.color2.Location = new System.Drawing.Point(536, 49);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(31, 30);
            this.color2.TabIndex = 10;
            this.color2.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Текущий цвет";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(572, 66);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(83, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Заменить цвет";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPEG files|*.jpeg|All files|*.*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPEG files|*.jpg|All files|*.*";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(896, 381);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Coming soon";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Вернуть
            // 
            this.Вернуть.Image = ((System.Drawing.Image)(resources.GetObject("Вернуть.Image")));
            this.Вернуть.Location = new System.Drawing.Point(354, 24);
            this.Вернуть.Name = "Вернуть";
            this.Вернуть.Size = new System.Drawing.Size(50, 49);
            this.Вернуть.TabIndex = 15;
            this.Вернуть.TabStop = false;
            this.Вернуть.Click += new System.EventHandler(this.Вернуть_Click);
            // 
            // Отменить
            // 
            this.Отменить.Image = ((System.Drawing.Image)(resources.GetObject("Отменить.Image")));
            this.Отменить.Location = new System.Drawing.Point(410, 24);
            this.Отменить.Name = "Отменить";
            this.Отменить.Size = new System.Drawing.Size(50, 49);
            this.Отменить.TabIndex = 16;
            this.Отменить.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(466, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 49);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(963, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 24);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(931, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 24);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 572);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Отменить);
            this.Controls.Add(this.Вернуть);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.color1);
            this.Controls.Add(this.color2);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.Слои);
            this.Controls.Add(this.AnT);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mini-paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Вернуть)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Отменить)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.CheckedListBox Слои;
        private System.Windows.Forms.ToolStripMenuItem рисованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem карандашToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кистьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стеркаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слоиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСлойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСлойToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйРисунокToolStripMenuItem;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.Panel color1;
        private System.Windows.Forms.Panel color2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ColorDialog changeColor;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem чистыйПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьToolStripMenuItem;
        private System.Windows.Forms.PictureBox Вернуть;
        private System.Windows.Forms.PictureBox Отменить;
        private System.Windows.Forms.ToolStripMenuItem скопироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прямаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

