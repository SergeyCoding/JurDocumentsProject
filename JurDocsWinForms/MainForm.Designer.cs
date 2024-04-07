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
            button5 = new Button();
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
            выходToolStripMenuItem = new ToolStripMenuItem();
            toolStrip2 = new ToolStrip();
            newDocButton = new ToolStripButton();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            создатьПроектToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel1.SuspendLayout();
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
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(911, 52);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 4;
            button5.Text = "Логин";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Login_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, DocType, DocDate, FileName, Remark, Column1 });
            dataGridView1.Location = new Point(12, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(695, 454);
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
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
            LoginText.Size = new Size(172, 23);
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
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { создатьПроектToolStripMenuItem, toolStripMenuItem1, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(180, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { newDocButton });
            toolStrip2.Location = new Point(0, 24);
            toolStrip2.Name = "toolStrip2";
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
            panel3.Location = new Point(20, 172);
            panel3.Name = "panel3";
            panel3.Size = new Size(237, 112);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(20, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(237, 112);
            panel2.TabIndex = 0;
            panel2.Paint += panel2_Paint;
            // 
            // создатьПроектToolStripMenuItem
            // 
            создатьПроектToolStripMenuItem.Name = "создатьПроектToolStripMenuItem";
            создатьПроектToolStripMenuItem.Size = new Size(180, 22);
            создатьПроектToolStripMenuItem.Text = "Создать проект";
            создатьПроектToolStripMenuItem.Click += создатьПроектToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 569);
            Controls.Add(panel1);
            Controls.Add(toolStrip2);
            Controls.Add(LoginText);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(button6);
            Controls.Add(dataGridView1);
            Controls.Add(button5);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
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
    }
}
