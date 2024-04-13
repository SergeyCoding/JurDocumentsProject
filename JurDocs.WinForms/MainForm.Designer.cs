namespace JurDocsWinForms
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            DocType = new DataGridViewTextBoxColumn();
            DocDate = new DataGridViewTextBoxColumn();
            FileName = new DataGridViewTextBoxColumn();
            Remark = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewButtonColumn();
            button6 = new Button();
            bindingSource1 = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            LoginText = new ComboBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            создатьПроектToolStripMenuItem = new ToolStripMenuItem();
            изменитьПроектToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            toolStrip2 = new ToolStrip();
            newDocButton = new ToolStripButton();
            newToolStripButton = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            printToolStripButton = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            cutToolStripButton = new ToolStripButton();
            copyToolStripButton = new ToolStripButton();
            pasteToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            helpToolStripButton = new ToolStripButton();
            panel1 = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            panel4 = new Panel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 53);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Выписки";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(93, 53);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Договоры";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(174, 53);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Справки";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(0, 0);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, DocType, DocDate, FileName, Remark, Column1 });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(681, 352);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            id.DataPropertyName = "Id";
            id.HeaderText = "#";
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.False;
            id.Width = 39;
            // 
            // DocType
            // 
            DocType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DocType.DataPropertyName = "DocType";
            DocType.HeaderText = "Вид документа";
            DocType.Name = "DocType";
            DocType.ReadOnly = true;
            DocType.Width = 104;
            // 
            // DocDate
            // 
            DocDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DocDate.HeaderText = "Дата документа";
            DocDate.Name = "DocDate";
            DocDate.ReadOnly = true;
            DocDate.Width = 108;
            // 
            // FileName
            // 
            FileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            FileName.DataPropertyName = "FileName";
            FileName.HeaderText = "Имя файла";
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            FileName.Width = 87;
            // 
            // Remark
            // 
            Remark.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Remark.HeaderText = "Описание";
            Remark.Name = "Remark";
            Remark.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Column1.DataPropertyName = "btnText";
            Column1.HeaderText = "Файл";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Text = "";
            Column1.Width = 42;
            // 
            // button6
            // 
            button6.Location = new Point(255, 53);
            button6.Name = "button6";
            button6.Size = new Size(112, 23);
            button6.TabIndex = 6;
            button6.Text = "Все документы";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(FileTableList);
            bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 547);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(998, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(23, 17);
            toolStripStatusLabel1.Text = "ОК";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // LoginText
            // 
            LoginText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoginText.FormattingEnabled = true;
            LoginText.Items.AddRange(new object[] { "Иванов", "Петров", "Сидоров" });
            LoginText.Location = new Point(733, 52);
            LoginText.Name = "LoginText";
            LoginText.Size = new Size(253, 23);
            LoginText.TabIndex = 8;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(998, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьПроектToolStripMenuItem, изменитьПроектToolStripMenuItem, toolStripMenuItem1, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьПроектToolStripMenuItem
            // 
            создатьПроектToolStripMenuItem.Name = "создатьПроектToolStripMenuItem";
            создатьПроектToolStripMenuItem.Size = new Size(169, 22);
            создатьПроектToolStripMenuItem.Text = "Создать проект";
            создатьПроектToolStripMenuItem.Click += создатьПроектToolStripMenuItem_Click;
            // 
            // изменитьПроектToolStripMenuItem
            // 
            изменитьПроектToolStripMenuItem.Name = "изменитьПроектToolStripMenuItem";
            изменитьПроектToolStripMenuItem.Size = new Size(169, 22);
            изменитьПроектToolStripMenuItem.Text = "Изменить проект";
            изменитьПроектToolStripMenuItem.Click += изменитьПроектToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(166, 6);
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(169, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { newDocButton, newToolStripButton, openToolStripButton, saveToolStripButton, printToolStripButton, toolStripSeparator, cutToolStripButton, copyToolStripButton, pasteToolStripButton, toolStripSeparator1, helpToolStripButton });
            toolStrip2.Location = new Point(0, 24);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.RenderMode = ToolStripRenderMode.System;
            toolStrip2.Size = new Size(998, 25);
            toolStrip2.TabIndex = 12;
            toolStrip2.Text = "toolStrip2";
            // 
            // newDocButton
            // 
            newDocButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newDocButton.Image = (Image)resources.GetObject("newDocButton.Image");
            newDocButton.ImageTransparentColor = Color.Magenta;
            newDocButton.Name = "newDocButton";
            newDocButton.Size = new Size(23, 22);
            newDocButton.Text = "Добавить документ";
            newDocButton.Click += toolStripButton3_Click;
            // 
            // newToolStripButton
            // 
            newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newToolStripButton.Image = (Image)resources.GetObject("newToolStripButton.Image");
            newToolStripButton.ImageTransparentColor = Color.Magenta;
            newToolStripButton.Name = "newToolStripButton";
            newToolStripButton.Size = new Size(23, 22);
            newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(23, 22);
            openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(23, 22);
            saveToolStripButton.Text = "&Save";
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = Color.Magenta;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new Size(23, 22);
            printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 25);
            // 
            // cutToolStripButton
            // 
            cutToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cutToolStripButton.Image = (Image)resources.GetObject("cutToolStripButton.Image");
            cutToolStripButton.ImageTransparentColor = Color.Magenta;
            cutToolStripButton.Name = "cutToolStripButton";
            cutToolStripButton.Size = new Size(23, 22);
            cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            copyToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyToolStripButton.Image = (Image)resources.GetObject("copyToolStripButton.Image");
            copyToolStripButton.ImageTransparentColor = Color.Magenta;
            copyToolStripButton.Name = "copyToolStripButton";
            copyToolStripButton.Size = new Size(23, 22);
            copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            pasteToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pasteToolStripButton.Image = (Image)resources.GetObject("pasteToolStripButton.Image");
            pasteToolStripButton.ImageTransparentColor = Color.Magenta;
            pasteToolStripButton.Name = "pasteToolStripButton";
            pasteToolStripButton.Size = new Size(23, 22);
            pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = Color.Magenta;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new Size(23, 22);
            helpToolStripButton.Text = "He&lp";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(713, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 454);
            panel1.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label2);
            panel3.Location = new Point(20, 172);
            panel3.Name = "panel3";
            panel3.Size = new Size(237, 112);
            panel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(80, 45);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 0;
            label2.Text = "Файл исходник";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(20, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 112);
            panel2.TabIndex = 0;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(69, 46);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Файлы документа";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(65, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(133, 23);
            textBox1.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 45);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 15;
            label3.Text = "Письмо";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 16);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 16;
            label4.Text = "Проект";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(65, 13);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 23);
            comboBox1.TabIndex = 17;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(695, 454);
            tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(687, 426);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Письмо";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(687, 426);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Договор";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(tabControl1);
            panel4.Location = new Point(12, 82);
            panel4.Name = "panel4";
            panel4.Size = new Size(695, 454);
            panel4.TabIndex = 19;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(97, 17);
            toolStripStatusLabel2.Text = "Текущий проект";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 569);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(toolStrip2);
            Controls.Add(LoginText);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Архив документов";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private Button button6;
#pragma warning disable CS0169 // The field 'MainForm.myPropertyDataGridViewTextBoxColumn' is never used
        private DataGridViewTextBoxColumn myPropertyDataGridViewTextBoxColumn;
#pragma warning restore CS0169 // The field 'MainForm.myPropertyDataGridViewTextBoxColumn' is never used
#pragma warning disable CS0169 // The field 'MainForm.myProperty1DataGridViewTextBoxColumn' is never used
        private DataGridViewTextBoxColumn myProperty1DataGridViewTextBoxColumn;
#pragma warning restore CS0169 // The field 'MainForm.myProperty1DataGridViewTextBoxColumn' is never used
#pragma warning disable CS0169 // The field 'MainForm.myProperty2DataGridViewTextBoxColumn' is never used
        private DataGridViewTextBoxColumn myProperty2DataGridViewTextBoxColumn;
#pragma warning restore CS0169 // The field 'MainForm.myProperty2DataGridViewTextBoxColumn' is never used
        private BindingSource bindingSource1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ComboBox LoginText;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn DocType;
        private DataGridViewTextBoxColumn DocDate;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Remark;
        private DataGridViewButtonColumn Column1;
#pragma warning disable CS0169 // The field 'MainForm.toolStrip1' is never used
        private ToolStrip toolStrip1;
#pragma warning restore CS0169 // The field 'MainForm.toolStrip1' is never used
#pragma warning disable CS0169 // The field 'MainForm.toolStripProgressBar1' is never used
        private ToolStripProgressBar toolStripProgressBar1;
#pragma warning restore CS0169 // The field 'MainForm.toolStripProgressBar1' is never used
#pragma warning disable CS0169 // The field 'MainForm.toolStripButton1' is never used
        private ToolStripButton toolStripButton1;
#pragma warning restore CS0169 // The field 'MainForm.toolStripButton1' is never used
#pragma warning disable CS0169 // The field 'MainForm.toolStripButton2' is never used
        private ToolStripButton toolStripButton2;
#pragma warning restore CS0169 // The field 'MainForm.toolStripButton2' is never used
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStrip toolStrip2;
#pragma warning disable CS0169 // The field 'MainForm.toolStripButton3' is never used
        private ToolStripButton toolStripButton3;
#pragma warning restore CS0169 // The field 'MainForm.toolStripButton3' is never used
        private ToolStripButton newDocButton;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private ToolStripMenuItem создатьПроектToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private Label label2;
        private Label label1;
        private ToolStripMenuItem изменитьПроектToolStripMenuItem;
        private ToolStripButton newToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton printToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton cutToolStripButton;
        private ToolStripButton copyToolStripButton;
        private ToolStripButton pasteToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton helpToolStripButton;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel4;
        private ToolStripStatusLabel toolStripStatusLabel2;
    }
}
