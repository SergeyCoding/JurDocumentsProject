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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewDoc));
            openFileDialog1 = new OpenFileDialog();
            splitDocForm = new SplitContainer();
            dtpDateIn = new DateTimePicker();
            cbProjectName = new ComboBox();
            cbDocType = new ComboBox();
            tbCaption = new TextBox();
            tbNumberOut = new TextBox();
            tbNumberIn = new TextBox();
            label31 = new Label();
            label29 = new Label();
            label27 = new Label();
            label28 = new Label();
            cbRecipient9 = new ComboBox();
            label21 = new Label();
            label22 = new Label();
            cbRecipient8 = new ComboBox();
            label23 = new Label();
            label24 = new Label();
            cbRecipient7 = new ComboBox();
            label25 = new Label();
            label26 = new Label();
            cbRecipient6 = new ComboBox();
            label15 = new Label();
            label16 = new Label();
            cbRecipient5 = new ComboBox();
            label17 = new Label();
            cbSender0 = new ComboBox();
            cbSender1 = new ComboBox();
            cbSender2 = new ComboBox();
            cbSender3 = new ComboBox();
            cbSender4 = new ComboBox();
            cbSender5 = new ComboBox();
            cbSender6 = new ComboBox();
            cbSender7 = new ComboBox();
            cbSender8 = new ComboBox();
            cbSender9 = new ComboBox();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            cbRecipient0 = new ComboBox();
            cbRecipient1 = new ComboBox();
            cbRecipient2 = new ComboBox();
            cbRecipient3 = new ComboBox();
            cbRecipient4 = new ComboBox();
            label11 = new Label();
            cbExecutors = new ComboBox();
            btnOk = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtpDateOut = new DateTimePicker();
            label32 = new Label();
            label30 = new Label();
            tbFileName = new TextBox();
            pbViewer = new PictureBox();
            tbSorceFileName = new TextBox();
            panel1 = new Panel();
            btnPageNext = new Button();
            btnPageBack = new Button();
            ssDocEdit = new StatusStrip();
            statusOk = new ToolStripStatusLabel();
            statusPageCountText = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitDocForm).BeginInit();
            splitDocForm.Panel1.SuspendLayout();
            splitDocForm.Panel2.SuspendLayout();
            splitDocForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbViewer).BeginInit();
            panel1.SuspendLayout();
            ssDocEdit.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.Title = "Добавить документ";
            // 
            // splitDocForm
            // 
            splitDocForm.AllowDrop = true;
            splitDocForm.BorderStyle = BorderStyle.FixedSingle;
            splitDocForm.Dock = DockStyle.Fill;
            splitDocForm.IsSplitterFixed = true;
            splitDocForm.Location = new Point(0, 0);
            splitDocForm.Name = "splitDocForm";
            // 
            // splitDocForm.Panel1
            // 
            splitDocForm.Panel1.Controls.Add(dtpDateIn);
            splitDocForm.Panel1.Controls.Add(cbProjectName);
            splitDocForm.Panel1.Controls.Add(cbDocType);
            splitDocForm.Panel1.Controls.Add(tbCaption);
            splitDocForm.Panel1.Controls.Add(tbNumberOut);
            splitDocForm.Panel1.Controls.Add(tbNumberIn);
            splitDocForm.Panel1.Controls.Add(label31);
            splitDocForm.Panel1.Controls.Add(label29);
            splitDocForm.Panel1.Controls.Add(label27);
            splitDocForm.Panel1.Controls.Add(label28);
            splitDocForm.Panel1.Controls.Add(cbRecipient9);
            splitDocForm.Panel1.Controls.Add(label21);
            splitDocForm.Panel1.Controls.Add(label22);
            splitDocForm.Panel1.Controls.Add(cbRecipient8);
            splitDocForm.Panel1.Controls.Add(label23);
            splitDocForm.Panel1.Controls.Add(label24);
            splitDocForm.Panel1.Controls.Add(cbRecipient7);
            splitDocForm.Panel1.Controls.Add(label25);
            splitDocForm.Panel1.Controls.Add(label26);
            splitDocForm.Panel1.Controls.Add(cbRecipient6);
            splitDocForm.Panel1.Controls.Add(label15);
            splitDocForm.Panel1.Controls.Add(label16);
            splitDocForm.Panel1.Controls.Add(cbRecipient5);
            splitDocForm.Panel1.Controls.Add(label17);
            splitDocForm.Panel1.Controls.Add(cbSender0);
            splitDocForm.Panel1.Controls.Add(cbSender1);
            splitDocForm.Panel1.Controls.Add(cbSender2);
            splitDocForm.Panel1.Controls.Add(cbSender3);
            splitDocForm.Panel1.Controls.Add(cbSender4);
            splitDocForm.Panel1.Controls.Add(cbSender5);
            splitDocForm.Panel1.Controls.Add(cbSender6);
            splitDocForm.Panel1.Controls.Add(cbSender7);
            splitDocForm.Panel1.Controls.Add(cbSender8);
            splitDocForm.Panel1.Controls.Add(cbSender9);
            splitDocForm.Panel1.Controls.Add(label18);
            splitDocForm.Panel1.Controls.Add(label19);
            splitDocForm.Panel1.Controls.Add(label20);
            splitDocForm.Panel1.Controls.Add(cbRecipient0);
            splitDocForm.Panel1.Controls.Add(cbRecipient1);
            splitDocForm.Panel1.Controls.Add(cbRecipient2);
            splitDocForm.Panel1.Controls.Add(cbRecipient3);
            splitDocForm.Panel1.Controls.Add(cbRecipient4);
            splitDocForm.Panel1.Controls.Add(label11);
            splitDocForm.Panel1.Controls.Add(cbExecutors);
            splitDocForm.Panel1.Controls.Add(btnOk);
            splitDocForm.Panel1.Controls.Add(btnDelete);
            splitDocForm.Panel1.Controls.Add(btnCancel);
            splitDocForm.Panel1.Controls.Add(label12);
            splitDocForm.Panel1.Controls.Add(label13);
            splitDocForm.Panel1.Controls.Add(label14);
            splitDocForm.Panel1.Controls.Add(label10);
            splitDocForm.Panel1.Controls.Add(label9);
            splitDocForm.Panel1.Controls.Add(label8);
            splitDocForm.Panel1.Controls.Add(label7);
            splitDocForm.Panel1.Controls.Add(label6);
            splitDocForm.Panel1.Controls.Add(label5);
            splitDocForm.Panel1.Controls.Add(label4);
            splitDocForm.Panel1.Controls.Add(label3);
            splitDocForm.Panel1.Controls.Add(label2);
            splitDocForm.Panel1.Controls.Add(label1);
            splitDocForm.Panel1.Controls.Add(dtpDateOut);
            splitDocForm.Panel1MinSize = 750;
            // 
            // splitDocForm.Panel2
            // 
            splitDocForm.Panel2.AllowDrop = true;
            splitDocForm.Panel2.Controls.Add(label32);
            splitDocForm.Panel2.Controls.Add(label30);
            splitDocForm.Panel2.Controls.Add(tbFileName);
            splitDocForm.Panel2.Controls.Add(pbViewer);
            splitDocForm.Panel2.Controls.Add(tbSorceFileName);
            splitDocForm.Panel2.Controls.Add(panel1);
            splitDocForm.Panel2.DragDrop += SplitDocForm_Panel2_DragDrop;
            splitDocForm.Panel2.DragOver += SplitDocForm_Panel2_DragOver;
            splitDocForm.Size = new Size(1192, 747);
            splitDocForm.SplitterDistance = 750;
            splitDocForm.TabIndex = 13;
            // 
            // dtpDateIn
            // 
            dtpDateIn.Location = new Point(89, 158);
            dtpDateIn.Name = "dtpDateIn";
            dtpDateIn.ShowCheckBox = true;
            dtpDateIn.Size = new Size(166, 23);
            dtpDateIn.TabIndex = 73;
            // 
            // cbProjectName
            // 
            cbProjectName.FormattingEnabled = true;
            cbProjectName.Location = new Point(152, 13);
            cbProjectName.Name = "cbProjectName";
            cbProjectName.Size = new Size(147, 23);
            cbProjectName.TabIndex = 0;
            // 
            // cbDocType
            // 
            cbDocType.FormattingEnabled = true;
            cbDocType.Location = new Point(457, 13);
            cbDocType.Name = "cbDocType";
            cbDocType.Size = new Size(153, 23);
            cbDocType.TabIndex = 1;
            // 
            // tbCaption
            // 
            tbCaption.Location = new Point(152, 55);
            tbCaption.Multiline = true;
            tbCaption.Name = "tbCaption";
            tbCaption.Size = new Size(582, 55);
            tbCaption.TabIndex = 2;
            // 
            // tbNumberOut
            // 
            tbNumberOut.Location = new Point(312, 132);
            tbNumberOut.Name = "tbNumberOut";
            tbNumberOut.Size = new Size(113, 23);
            tbNumberOut.TabIndex = 5;
            // 
            // tbNumberIn
            // 
            tbNumberIn.Location = new Point(312, 161);
            tbNumberIn.Name = "tbNumberIn";
            tbNumberIn.Size = new Size(113, 23);
            tbNumberIn.TabIndex = 6;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(337, 16);
            label31.Name = "label31";
            label31.Size = new Size(88, 15);
            label31.TabIndex = 71;
            label31.Text = "Тип документа";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(26, 14);
            label29.Name = "label29";
            label29.Size = new Size(74, 15);
            label29.TabIndex = 67;
            label29.Text = "Код проекта";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label27.Location = new Point(408, 491);
            label27.Name = "label27";
            label27.Size = new Size(24, 15);
            label27.TabIndex = 65;
            label27.Text = "10.";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label28.Location = new Point(26, 491);
            label28.Name = "label28";
            label28.Size = new Size(24, 15);
            label28.TabIndex = 64;
            label28.Text = "10.";
            // 
            // cbRecipient9
            // 
            cbRecipient9.FormattingEnabled = true;
            cbRecipient9.Location = new Point(436, 488);
            cbRecipient9.Name = "cbRecipient9";
            cbRecipient9.Size = new Size(299, 23);
            cbRecipient9.TabIndex = 26;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label21.Location = new Point(408, 462);
            label21.Name = "label21";
            label21.Size = new Size(17, 15);
            label21.TabIndex = 57;
            label21.Text = "9.";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label22.Location = new Point(26, 462);
            label22.Name = "label22";
            label22.Size = new Size(17, 15);
            label22.TabIndex = 56;
            label22.Text = "9.";
            // 
            // cbRecipient8
            // 
            cbRecipient8.FormattingEnabled = true;
            cbRecipient8.Location = new Point(436, 459);
            cbRecipient8.Name = "cbRecipient8";
            cbRecipient8.Size = new Size(299, 23);
            cbRecipient8.TabIndex = 25;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label23.Location = new Point(408, 433);
            label23.Name = "label23";
            label23.Size = new Size(17, 15);
            label23.TabIndex = 61;
            label23.Text = "8.";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label24.Location = new Point(26, 433);
            label24.Name = "label24";
            label24.Size = new Size(17, 15);
            label24.TabIndex = 60;
            label24.Text = "8.";
            // 
            // cbRecipient7
            // 
            cbRecipient7.FormattingEnabled = true;
            cbRecipient7.Location = new Point(436, 430);
            cbRecipient7.Name = "cbRecipient7";
            cbRecipient7.Size = new Size(299, 23);
            cbRecipient7.TabIndex = 24;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label25.Location = new Point(408, 404);
            label25.Name = "label25";
            label25.Size = new Size(17, 15);
            label25.TabIndex = 53;
            label25.Text = "7.";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label26.Location = new Point(26, 404);
            label26.Name = "label26";
            label26.Size = new Size(17, 15);
            label26.TabIndex = 52;
            label26.Text = "7.";
            // 
            // cbRecipient6
            // 
            cbRecipient6.FormattingEnabled = true;
            cbRecipient6.Location = new Point(436, 401);
            cbRecipient6.Name = "cbRecipient6";
            cbRecipient6.Size = new Size(299, 23);
            cbRecipient6.TabIndex = 23;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.Location = new Point(408, 376);
            label15.Name = "label15";
            label15.Size = new Size(17, 15);
            label15.TabIndex = 45;
            label15.Text = "6.";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label16.Location = new Point(26, 376);
            label16.Name = "label16";
            label16.Size = new Size(17, 15);
            label16.TabIndex = 44;
            label16.Text = "6.";
            // 
            // cbRecipient5
            // 
            cbRecipient5.FormattingEnabled = true;
            cbRecipient5.Location = new Point(436, 373);
            cbRecipient5.Name = "cbRecipient5";
            cbRecipient5.Size = new Size(299, 23);
            cbRecipient5.TabIndex = 22;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label17.Location = new Point(408, 347);
            label17.Name = "label17";
            label17.Size = new Size(17, 15);
            label17.TabIndex = 49;
            label17.Text = "5.";
            // 
            // cbSender0
            // 
            cbSender0.FormattingEnabled = true;
            cbSender0.Location = new Point(59, 227);
            cbSender0.Name = "cbSender0";
            cbSender0.Size = new Size(297, 23);
            cbSender0.TabIndex = 7;
            // 
            // cbSender1
            // 
            cbSender1.FormattingEnabled = true;
            cbSender1.Location = new Point(59, 256);
            cbSender1.Name = "cbSender1";
            cbSender1.Size = new Size(297, 23);
            cbSender1.TabIndex = 8;
            // 
            // cbSender2
            // 
            cbSender2.FormattingEnabled = true;
            cbSender2.Location = new Point(59, 285);
            cbSender2.Name = "cbSender2";
            cbSender2.Size = new Size(297, 23);
            cbSender2.TabIndex = 9;
            // 
            // cbSender3
            // 
            cbSender3.FormattingEnabled = true;
            cbSender3.Location = new Point(59, 315);
            cbSender3.Name = "cbSender3";
            cbSender3.Size = new Size(297, 23);
            cbSender3.TabIndex = 10;
            // 
            // cbSender4
            // 
            cbSender4.FormattingEnabled = true;
            cbSender4.Location = new Point(59, 344);
            cbSender4.Name = "cbSender4";
            cbSender4.Size = new Size(297, 23);
            cbSender4.TabIndex = 11;
            // 
            // cbSender5
            // 
            cbSender5.FormattingEnabled = true;
            cbSender5.Location = new Point(59, 373);
            cbSender5.Name = "cbSender5";
            cbSender5.Size = new Size(297, 23);
            cbSender5.TabIndex = 12;
            // 
            // cbSender6
            // 
            cbSender6.FormattingEnabled = true;
            cbSender6.Location = new Point(59, 401);
            cbSender6.Name = "cbSender6";
            cbSender6.Size = new Size(297, 23);
            cbSender6.TabIndex = 13;
            // 
            // cbSender7
            // 
            cbSender7.FormattingEnabled = true;
            cbSender7.Location = new Point(59, 430);
            cbSender7.Name = "cbSender7";
            cbSender7.Size = new Size(297, 23);
            cbSender7.TabIndex = 14;
            // 
            // cbSender8
            // 
            cbSender8.FormattingEnabled = true;
            cbSender8.Location = new Point(59, 459);
            cbSender8.Name = "cbSender8";
            cbSender8.Size = new Size(297, 23);
            cbSender8.TabIndex = 15;
            // 
            // cbSender9
            // 
            cbSender9.FormattingEnabled = true;
            cbSender9.Location = new Point(59, 488);
            cbSender9.Name = "cbSender9";
            cbSender9.Size = new Size(297, 23);
            cbSender9.TabIndex = 16;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label18.Location = new Point(26, 347);
            label18.Name = "label18";
            label18.Size = new Size(17, 15);
            label18.TabIndex = 48;
            label18.Text = "5.";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label19.Location = new Point(408, 318);
            label19.Name = "label19";
            label19.Size = new Size(17, 15);
            label19.TabIndex = 41;
            label19.Text = "4.";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label20.Location = new Point(26, 318);
            label20.Name = "label20";
            label20.Size = new Size(17, 15);
            label20.TabIndex = 40;
            label20.Text = "4.";
            // 
            // cbRecipient0
            // 
            cbRecipient0.FormattingEnabled = true;
            cbRecipient0.Location = new Point(436, 227);
            cbRecipient0.Name = "cbRecipient0";
            cbRecipient0.Size = new Size(299, 23);
            cbRecipient0.TabIndex = 17;
            // 
            // cbRecipient1
            // 
            cbRecipient1.FormattingEnabled = true;
            cbRecipient1.Location = new Point(436, 256);
            cbRecipient1.Name = "cbRecipient1";
            cbRecipient1.Size = new Size(299, 23);
            cbRecipient1.TabIndex = 18;
            // 
            // cbRecipient2
            // 
            cbRecipient2.FormattingEnabled = true;
            cbRecipient2.Location = new Point(436, 285);
            cbRecipient2.Name = "cbRecipient2";
            cbRecipient2.Size = new Size(299, 23);
            cbRecipient2.TabIndex = 19;
            // 
            // cbRecipient3
            // 
            cbRecipient3.FormattingEnabled = true;
            cbRecipient3.Location = new Point(436, 315);
            cbRecipient3.Name = "cbRecipient3";
            cbRecipient3.Size = new Size(299, 23);
            cbRecipient3.TabIndex = 20;
            // 
            // cbRecipient4
            // 
            cbRecipient4.FormattingEnabled = true;
            cbRecipient4.Location = new Point(436, 344);
            cbRecipient4.Name = "cbRecipient4";
            cbRecipient4.Size = new Size(299, 23);
            cbRecipient4.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(408, 288);
            label11.Name = "label11";
            label11.Size = new Size(17, 15);
            label11.TabIndex = 33;
            label11.Text = "3.";
            // 
            // cbExecutors
            // 
            cbExecutors.FormattingEnabled = true;
            cbExecutors.Items.AddRange(new object[] { "Выписки", "Справки", "Договора" });
            cbExecutors.Location = new Point(134, 538);
            cbExecutors.Name = "cbExecutors";
            cbExecutors.Size = new Size(321, 23);
            cbExecutors.TabIndex = 27;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(422, 705);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 25);
            btnOk.TabIndex = 28;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.Location = new Point(528, 705);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 25);
            btnDelete.TabIndex = 29;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDeleteClick;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(634, 705);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 25);
            btnCancel.TabIndex = 30;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancelClick;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(26, 288);
            label12.Name = "label12";
            label12.Size = new Size(17, 15);
            label12.TabIndex = 32;
            label12.Text = "3.";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(408, 259);
            label13.Name = "label13";
            label13.Size = new Size(17, 15);
            label13.TabIndex = 37;
            label13.Text = "2.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label14.Location = new Point(26, 259);
            label14.Name = "label14";
            label14.Size = new Size(17, 15);
            label14.TabIndex = 36;
            label14.Text = "2.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(408, 230);
            label10.Name = "label10";
            label10.Size = new Size(17, 15);
            label10.TabIndex = 29;
            label10.Text = "1.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(26, 230);
            label9.Name = "label9";
            label9.Size = new Size(17, 15);
            label9.TabIndex = 28;
            label9.Text = "1.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(436, 209);
            label8.Name = "label8";
            label8.Size = new Size(73, 15);
            label8.TabIndex = 25;
            label8.Text = "Получатель";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(261, 164);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 23;
            label7.Text = "№ вх.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(261, 135);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 22;
            label6.Text = "№ исх.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 164);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 21;
            label5.Text = "Дата вх.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 209);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 19;
            label4.Text = "Отправитель";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 541);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 18;
            label3.Text = "Документ внесен";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 135);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 15;
            label2.Text = "Дата исх.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 58);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 13;
            label1.Text = "Название документа";
            // 
            // dtpDateOut
            // 
            dtpDateOut.CustomFormat = " \"\"";
            dtpDateOut.Location = new Point(89, 129);
            dtpDateOut.Name = "dtpDateOut";
            dtpDateOut.ShowCheckBox = true;
            dtpDateOut.Size = new Size(166, 23);
            dtpDateOut.TabIndex = 72;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(3, 42);
            label32.Name = "label32";
            label32.Size = new Size(61, 15);
            label32.TabIndex = 77;
            label32.Text = "Исходник";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(3, 16);
            label30.Name = "label30";
            label30.Size = new Size(95, 15);
            label30.TabIndex = 76;
            label30.Text = "Скан документа";
            // 
            // tbFileName
            // 
            tbFileName.Location = new Point(104, 11);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new Size(321, 23);
            tbFileName.TabIndex = 72;
            // 
            // pbViewer
            // 
            pbViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbViewer.Image = (Image)resources.GetObject("pbViewer.Image");
            pbViewer.Location = new Point(3, 71);
            pbViewer.Name = "pbViewer";
            pbViewer.Size = new Size(422, 579);
            pbViewer.SizeMode = PictureBoxSizeMode.CenterImage;
            pbViewer.TabIndex = 1;
            pbViewer.TabStop = false;
            // 
            // tbSorceFileName
            // 
            tbSorceFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSorceFileName.Location = new Point(104, 39);
            tbSorceFileName.Multiline = true;
            tbSorceFileName.Name = "tbSorceFileName";
            tbSorceFileName.Size = new Size(321, 23);
            tbSorceFileName.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnPageNext);
            panel1.Controls.Add(btnPageBack);
            panel1.Location = new Point(3, 656);
            panel1.Name = "panel1";
            panel1.Size = new Size(422, 86);
            panel1.TabIndex = 75;
            // 
            // btnPageNext
            // 
            btnPageNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPageNext.Location = new Point(208, 32);
            btnPageNext.Name = "btnPageNext";
            btnPageNext.Size = new Size(75, 23);
            btnPageNext.TabIndex = 74;
            btnPageNext.Text = ">";
            btnPageNext.UseVisualStyleBackColor = true;
            btnPageNext.Click += BtnPageNext_Click;
            // 
            // btnPageBack
            // 
            btnPageBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPageBack.Location = new Point(127, 32);
            btnPageBack.Name = "btnPageBack";
            btnPageBack.Size = new Size(75, 23);
            btnPageBack.TabIndex = 73;
            btnPageBack.Text = "<";
            btnPageBack.UseVisualStyleBackColor = true;
            btnPageBack.Click += BtnPageBack_Click;
            // 
            // ssDocEdit
            // 
            ssDocEdit.Items.AddRange(new ToolStripItem[] { statusOk, statusPageCountText });
            ssDocEdit.Location = new Point(0, 747);
            ssDocEdit.Name = "ssDocEdit";
            ssDocEdit.Size = new Size(1192, 22);
            ssDocEdit.TabIndex = 14;
            ssDocEdit.Text = "statusStrip1";
            // 
            // statusOk
            // 
            statusOk.Name = "statusOk";
            statusOk.Size = new Size(23, 17);
            statusOk.Text = "OK";
            // 
            // statusPageCountText
            // 
            statusPageCountText.Name = "statusPageCountText";
            statusPageCountText.Size = new Size(99, 17);
            statusPageCountText.Text = "Страница: X/XXX";
            // 
            // AddNewDoc
            // 
            AcceptButton = btnOk;
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 769);
            Controls.Add(splitDocForm);
            Controls.Add(ssDocEdit);
            MinimumSize = new Size(1200, 800);
            Name = "AddNewDoc";
            Text = "Внесение документа в архив";
            FormClosing += AddNewDoc_FormClosing;
            Load += AddNewDoc_Load;
            ResizeEnd += AddNewDoc_ResizeEnd;
            Resize += AddNewDoc_Resize;
            splitDocForm.Panel1.ResumeLayout(false);
            splitDocForm.Panel1.PerformLayout();
            splitDocForm.Panel2.ResumeLayout(false);
            splitDocForm.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitDocForm).EndInit();
            splitDocForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbViewer).EndInit();
            panel1.ResumeLayout(false);
            ssDocEdit.ResumeLayout(false);
            ssDocEdit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private OpenFileDialog openFileDialog1;
        private SplitContainer splitDocForm;
        private Button btnDelete;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbNumberOut;
        private ComboBox cbExecutors;
        private TextBox tbCaption;
        private Label label5;
        private PictureBox pbViewer;
        private TextBox tbSorceFileName;
        private TextBox tbNumberIn;
        private Label label7;
        private Label label6;
        private Label label15;
        private Label label16;
        private ComboBox cbRecipient5;
        private ComboBox cbSender5;
        private Label label17;
        private Label label18;
        private ComboBox cbRecipient4;
        private ComboBox cbSender4;
        private Label label19;
        private Label label20;
        private ComboBox cbRecipient3;
        private ComboBox cbSender3;
        private Label label11;
        private Label label12;
        private ComboBox cbRecipient2;
        private ComboBox cbSender2;
        private Label label13;
        private Label label14;
        private ComboBox cbRecipient1;
        private ComboBox cbSender1;
        private Label label10;
        private Label label9;
        private ComboBox cbRecipient0;
        private ComboBox cbSender0;
        private Label label8;
        private Label label27;
        private Label label28;
        private ComboBox cbRecipient9;
        private ComboBox cbSender9;
        private Label label21;
        private Label label22;
        private ComboBox cbRecipient8;
        private ComboBox cbSender8;
        private Label label23;
        private Label label24;
        private ComboBox cbRecipient7;
        private ComboBox cbSender7;
        private Label label25;
        private Label label26;
        private ComboBox cbRecipient6;
        private ComboBox cbSender6;
        private Label label29;
        private ComboBox cbDocType;
        private Label label31;
        private ComboBox cbProjectName;
        private Button btnPageNext;
        private Button btnPageBack;
        private StatusStrip ssDocEdit;
        private ToolStripStatusLabel statusOk;
        private ToolStripStatusLabel statusPageCountText;
        private Panel panel1;
        private Button btnCancel;
        private Button btnOk;
        private TextBox tbFileName;
        private Label label32;
        private Label label30;
        private DateTimePicker dtpDateOut;
        private DateTimePicker dtpDateIn;
    }
}
