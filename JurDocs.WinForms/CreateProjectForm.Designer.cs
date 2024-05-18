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
            tbProjectName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbProjectFullName = new TextBox();
            label3 = new Label();
            cbProjectOwner = new ComboBox();
            label4 = new Label();
            tabControl_Rights = new TabControl();
            tabPage_Письма = new TabPage();
            clbProjectRights_Письма = new CheckedListBox();
            tabPage_Справки = new TabPage();
            clbProjectRights_Справки = new CheckedListBox();
            tabPage_Выписки = new TabPage();
            clbProjectRights_Выписки = new CheckedListBox();
            btnOk = new Button();
            btnCancel = new Button();
            label5 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            clbProjectRights = new CheckedListBox();
            label6 = new Label();
            tabControl_Rights.SuspendLayout();
            tabPage_Письма.SuspendLayout();
            tabPage_Справки.SuspendLayout();
            tabPage_Выписки.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tbProjectName
            // 
            tbProjectName.Location = new Point(159, 12);
            tbProjectName.MaxLength = 10;
            tbProjectName.Name = "tbProjectName";
            tbProjectName.Size = new Size(186, 23);
            tbProjectName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 1;
            label1.Text = "Идентификатор проекта";
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
            // tbProjectFullName
            // 
            tbProjectFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbProjectFullName.Location = new Point(159, 41);
            tbProjectFullName.Multiline = true;
            tbProjectFullName.Name = "tbProjectFullName";
            tbProjectFullName.Size = new Size(601, 48);
            tbProjectFullName.TabIndex = 3;
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
            // cbProjectOwner
            // 
            cbProjectOwner.FormattingEnabled = true;
            cbProjectOwner.Location = new Point(159, 95);
            cbProjectOwner.Name = "cbProjectOwner";
            cbProjectOwner.Size = new Size(186, 23);
            cbProjectOwner.TabIndex = 5;
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
            // tabControl_Rights
            // 
            tabControl_Rights.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl_Rights.Controls.Add(tabPage_Письма);
            tabControl_Rights.Controls.Add(tabPage_Справки);
            tabControl_Rights.Controls.Add(tabPage_Выписки);
            tabControl_Rights.Location = new Point(371, 116);
            tabControl_Rights.Name = "tabControl_Rights";
            tabControl_Rights.SelectedIndex = 0;
            tabControl_Rights.Size = new Size(389, 365);
            tabControl_Rights.TabIndex = 7;
            // 
            // tabPage_Письма
            // 
            tabPage_Письма.Controls.Add(clbProjectRights_Письма);
            tabPage_Письма.Location = new Point(4, 24);
            tabPage_Письма.Name = "tabPage_Письма";
            tabPage_Письма.Padding = new Padding(3);
            tabPage_Письма.Size = new Size(381, 337);
            tabPage_Письма.TabIndex = 2;
            tabPage_Письма.Text = "Письма";
            tabPage_Письма.UseVisualStyleBackColor = true;
            // 
            // clbProjectRights_Письма
            // 
            clbProjectRights_Письма.Dock = DockStyle.Fill;
            clbProjectRights_Письма.Items.AddRange(new object[] { "1", "2", "3" });
            clbProjectRights_Письма.Location = new Point(3, 3);
            clbProjectRights_Письма.Name = "clbProjectRights_Письма";
            clbProjectRights_Письма.Size = new Size(375, 331);
            clbProjectRights_Письма.TabIndex = 0;
            // 
            // tabPage_Справки
            // 
            tabPage_Справки.Controls.Add(clbProjectRights_Справки);
            tabPage_Справки.Location = new Point(4, 24);
            tabPage_Справки.Name = "tabPage_Справки";
            tabPage_Справки.Padding = new Padding(3);
            tabPage_Справки.Size = new Size(381, 337);
            tabPage_Справки.TabIndex = 1;
            tabPage_Справки.Text = "Справки";
            tabPage_Справки.UseVisualStyleBackColor = true;
            // 
            // clbProjectRights_Справки
            // 
            clbProjectRights_Справки.Dock = DockStyle.Fill;
            clbProjectRights_Справки.FormattingEnabled = true;
            clbProjectRights_Справки.Items.AddRange(new object[] { "111", "222", "333" });
            clbProjectRights_Справки.Location = new Point(3, 3);
            clbProjectRights_Справки.Name = "clbProjectRights_Справки";
            clbProjectRights_Справки.Size = new Size(375, 331);
            clbProjectRights_Справки.TabIndex = 0;
            // 
            // tabPage_Выписки
            // 
            tabPage_Выписки.Controls.Add(clbProjectRights_Выписки);
            tabPage_Выписки.Location = new Point(4, 24);
            tabPage_Выписки.Name = "tabPage_Выписки";
            tabPage_Выписки.Padding = new Padding(3);
            tabPage_Выписки.Size = new Size(381, 337);
            tabPage_Выписки.TabIndex = 0;
            tabPage_Выписки.Text = "Выписки";
            tabPage_Выписки.UseVisualStyleBackColor = true;
            // 
            // clbProjectRights_Выписки
            // 
            clbProjectRights_Выписки.Dock = DockStyle.Fill;
            clbProjectRights_Выписки.FormattingEnabled = true;
            clbProjectRights_Выписки.Items.AddRange(new object[] { "ффф", "иии", "ссс" });
            clbProjectRights_Выписки.Location = new Point(3, 3);
            clbProjectRights_Выписки.Name = "clbProjectRights_Выписки";
            clbProjectRights_Выписки.Size = new Size(375, 331);
            clbProjectRights_Выписки.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(600, 487);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 8;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(681, 487);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
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
            // clbProjectRights
            // 
            clbProjectRights.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            clbProjectRights.FormattingEnabled = true;
            clbProjectRights.Items.AddRange(new object[] { "ййй", "ццц", "ууу" });
            clbProjectRights.Location = new Point(12, 146);
            clbProjectRights.Name = "clbProjectRights";
            clbProjectRights.Size = new Size(333, 328);
            clbProjectRights.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 127);
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
            Controls.Add(clbProjectRights);
            Controls.Add(statusStrip1);
            Controls.Add(label5);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(tabControl_Rights);
            Controls.Add(label4);
            Controls.Add(cbProjectOwner);
            Controls.Add(label3);
            Controls.Add(tbProjectFullName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbProjectName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateProjectForm";
            Text = "Создать проект";
            TopMost = true;
            tabControl_Rights.ResumeLayout(false);
            tabPage_Письма.ResumeLayout(false);
            tabPage_Справки.ResumeLayout(false);
            tabPage_Выписки.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbProjectName;
        private Label label1;
        private Label label2;
        private TextBox tbProjectFullName;
        private Label label3;
        private ComboBox cbProjectOwner;
        private Label label4;
        private TabControl tabControl_Rights;
        private TabPage tabPage_Выписки;
        private TabPage tabPage_Справки;
        private Button btnOk;
        private Button btnCancel;
        private Label label5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private CheckedListBox clbProjectRights_Выписки;
        private CheckedListBox clbProjectRights_Справки;
        private CheckedListBox clbProjectRights_Письма;
        private CheckedListBox clbProjectRights;
        private Label label6;
        private TabPage tabPage_Письма;
    }
}