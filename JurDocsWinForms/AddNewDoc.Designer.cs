namespace JurDocsWinForms
{
    partial class AddNewDoc
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
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            textBoxFileName = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(402, 27);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Открыть";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(352, 153);
            button2.Name = "button2";
            button2.Size = new Size(125, 23);
            button2.TabIndex = 2;
            button2.Text = "Добавить документ";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Выписки", "Справки", "Договора" });
            comboBox1.Location = new Point(106, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(290, 23);
            comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 4;
            label1.Text = "Вид документа";
            label1.Click += label1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Title = "Добавить документ";
            // 
            // textBoxFileName
            // 
            textBoxFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFileName.Location = new Point(106, 56);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(371, 23);
            textBoxFileName.TabIndex = 5;
            textBoxFileName.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 59);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 6;
            label2.Text = "Имя файла";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(106, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(371, 23);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(106, 114);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(371, 23);
            textBox3.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 88);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 9;
            label3.Text = "Реквизит1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 117);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 10;
            label4.Text = "Реквизит2";
            // 
            // AddNewDoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 188);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBoxFileName);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddNewDoc";
            Text = "Добавить документ";
            Load += AddNewDoc_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private Label label1;
        private OpenFileDialog openFileDialog1;
        private TextBox textBoxFileName;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
    }
}
