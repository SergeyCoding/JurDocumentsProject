namespace JurDocsWinForms
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            dataGridView1 = new DataGridView();
            button6 = new Button();
            bindingSource1 = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            LoginText = new ComboBox();
            id = new DataGridViewTextBoxColumn();
            DocType = new DataGridViewTextBoxColumn();
            DocDate = new DataGridViewTextBoxColumn();
            FileName = new DataGridViewTextBoxColumn();
            Remark = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Выписки";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(93, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "Договоры";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(174, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Справки";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(713, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 3;
            button4.Text = "Выход";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(632, 12);
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
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(776, 376);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button6
            // 
            button6.Location = new Point(255, 12);
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
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
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
            LoginText.FormattingEnabled = true;
            LoginText.Items.AddRange(new object[] { "Иванов", "Петров", "Сидоров" });
            LoginText.Location = new Point(454, 11);
            LoginText.Name = "LoginText";
            LoginText.Size = new Size(172, 23);
            LoginText.TabIndex = 8;
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
            DocType.Width = 113;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoginText);
            Controls.Add(statusStrip1);
            Controls.Add(button6);
            Controls.Add(dataGridView1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Архив документов";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private DataGridViewTextBoxColumn myPropertyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn myProperty1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn myProperty2DataGridViewTextBoxColumn;
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
    }
}
