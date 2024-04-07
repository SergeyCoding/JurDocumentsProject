namespace JurDocsWinForms
{
    partial class CreateProjectForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            checkedListBox2 = new CheckedListBox();
            tabPage1 = new TabPage();
            checkedListBox1 = new CheckedListBox();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            checkedListBox3 = new CheckedListBox();
            label6 = new Label();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(159, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 1;
            label1.Text = "Идентификатор проекта";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(351, 15);
            label2.Name = "label2";
            label2.Size = new Size(409, 15);
            label2.TabIndex = 2;
            label2.Text = "(уникальный текст из цифр и букв, не более 10 символов без пробелов )";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(159, 41);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(601, 48);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 4;
            label3.Text = "Наименование проекта";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(159, 95);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(186, 23);
            comboBox1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 98);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 6;
            label4.Text = "Владелец";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(371, 116);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(389, 365);
            tabControl1.TabIndex = 7;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(checkedListBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(381, 337);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Справки";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkedListBox2
            // 
            checkedListBox2.Dock = DockStyle.Fill;
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { "111", "222", "333" });
            checkedListBox2.Location = new Point(3, 3);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(375, 331);
            checkedListBox2.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(checkedListBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(381, 337);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Выписки";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Dock = DockStyle.Fill;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "ффф", "иии", "ссс" });
            checkedListBox1.Location = new Point(3, 3);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(375, 331);
            checkedListBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(600, 487);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "ОК";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(681, 487);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(375, 98);
            label5.Name = "label5";
            label5.Size = new Size(201, 15);
            label5.TabIndex = 10;
            label5.Text = "Права доступа к разделам проекта:";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 522);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(771, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(23, 17);
            toolStripStatusLabel1.Text = "ОК";
            // 
            // checkedListBox3
            // 
            checkedListBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkedListBox3.FormattingEnabled = true;
            checkedListBox3.Items.AddRange(new object[] { "ййй", "ццц", "ууу" });
            checkedListBox3.Location = new Point(12, 146);
            checkedListBox3.Name = "checkedListBox3";
            checkedListBox3.Size = new Size(333, 328);
            checkedListBox3.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 121);
            label6.Name = "label6";
            label6.Size = new Size(146, 15);
            label6.TabIndex = 13;
            label6.Text = "Права доступа к проекту:";
            // 
            // CreateProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 544);
            Controls.Add(label6);
            Controls.Add(checkedListBox3);
            Controls.Add(statusStrip1);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateProjectForm";
            Text = "Создать проект";
            TopMost = true;
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private Button button2;
        private Label label5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private CheckedListBox checkedListBox3;
        private Label label6;
    }
}