using JurDocs.WinForms.Model;

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
            dgvProjects = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            PrjectId = new DataGridViewTextBoxColumn();
            DocType = new DataGridViewTextBoxColumn();
            DocDate = new DataGridViewTextBoxColumn();
            FileName = new DataGridViewTextBoxColumn();
            Remark = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewButtonColumn();
            button6 = new Button();
            bindingSource1 = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tssCurrentProject = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            создатьПроектToolStripMenuItem = new ToolStripMenuItem();
            изменитьПроектToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            выходToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            создатьСправкуToolStripMenuItem = new ToolStripMenuItem();
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
            panelDragDrop = new Panel();
            panelSourceDocs = new Panel();
            label2 = new Label();
            panelDocs = new Panel();
            label1 = new Label();
            tbПисьмо = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cbProjectList = new ComboBox();
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            dgvProjectList = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            tabPage1 = new TabPage();
            comboBox2 = new ComboBox();
            label11 = new Label();
            textBox6 = new TextBox();
            label9 = new Label();
            label10 = new Label();
            textBox7 = new TextBox();
            tbИсх = new TextBox();
            tbОтпавитель = new TextBox();
            label7 = new Label();
            label8 = new Label();
            tbВх = new TextBox();
            label5 = new Label();
            label6 = new Label();
            tbПолучатель = new TextBox();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            a1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panelGrid = new Panel();
            tssCurrentPage = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panelDragDrop.SuspendLayout();
            panelSourceDocs.SuspendLayout();
            panelDocs.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjectList).BeginInit();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelGrid.SuspendLayout();
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
            // dgvProjects
            // 
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.AllowUserToDeleteRows = false;
            dgvProjects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Columns.AddRange(new DataGridViewColumn[] { id, PrjectId, DocType, DocDate, FileName, Remark, Column1 });
            dgvProjects.Location = new Point(3, 71);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.ReadOnly = true;
            dgvProjects.ShowCellToolTips = false;
            dgvProjects.Size = new Size(983, 327);
            dgvProjects.TabIndex = 5;
            dgvProjects.CellContentClick += dataGridView1_CellContentClick;
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
            // PrjectId
            // 
            PrjectId.HeaderText = "Проект";
            PrjectId.Name = "PrjectId";
            PrjectId.ReadOnly = true;
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tssCurrentProject, tssCurrentPage });
            statusStrip1.Location = new Point(0, 522);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1300, 22);
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
            // tssCurrentProject
            // 
            tssCurrentProject.Name = "tssCurrentProject";
            tssCurrentProject.Size = new Size(97, 17);
            tssCurrentProject.Text = "Текущий проект";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, toolStripMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1300, 24);
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
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { создатьСправкуToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(59, 20);
            toolStripMenuItem2.Text = "Проект";
            // 
            // создатьСправкуToolStripMenuItem
            // 
            создатьСправкуToolStripMenuItem.Name = "создатьСправкуToolStripMenuItem";
            создатьСправкуToolStripMenuItem.Size = new Size(164, 22);
            создатьСправкуToolStripMenuItem.Text = "Создать справку";
            // 
            // toolStrip2
            // 
            toolStrip2.Items.AddRange(new ToolStripItem[] { newDocButton, newToolStripButton, openToolStripButton, saveToolStripButton, printToolStripButton, toolStripSeparator, cutToolStripButton, copyToolStripButton, pasteToolStripButton, toolStripSeparator1, helpToolStripButton });
            toolStrip2.Location = new Point(0, 24);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.RenderMode = ToolStripRenderMode.System;
            toolStrip2.Size = new Size(1300, 25);
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
            newToolStripButton.Text = "Создать";
            newToolStripButton.Click += newToolStripButton_Click;
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(23, 22);
            openToolStripButton.Text = "&Open";
            openToolStripButton.Click += openToolStripButton_Click;
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
            cutToolStripButton.Click += cutToolStripButton_Click;
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
            // panelDragDrop
            // 
            panelDragDrop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelDragDrop.Controls.Add(panelSourceDocs);
            panelDragDrop.Controls.Add(panelDocs);
            panelDragDrop.Location = new Point(1015, 82);
            panelDragDrop.Name = "panelDragDrop";
            panelDragDrop.Size = new Size(273, 429);
            panelDragDrop.TabIndex = 13;
            // 
            // panelSourceDocs
            // 
            panelSourceDocs.BorderStyle = BorderStyle.FixedSingle;
            panelSourceDocs.Controls.Add(label2);
            panelSourceDocs.Location = new Point(20, 172);
            panelSourceDocs.Name = "panelSourceDocs";
            panelSourceDocs.Size = new Size(237, 112);
            panelSourceDocs.TabIndex = 1;
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
            // panelDocs
            // 
            panelDocs.BorderStyle = BorderStyle.FixedSingle;
            panelDocs.Controls.Add(label1);
            panelDocs.Location = new Point(20, 37);
            panelDocs.Name = "panelDocs";
            panelDocs.Size = new Size(237, 112);
            panelDocs.TabIndex = 0;
            panelDocs.Paint += panel2_Paint;
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
            // tbПисьмо
            // 
            tbПисьмо.Location = new Point(65, 42);
            tbПисьмо.Name = "tbПисьмо";
            tbПисьмо.Size = new Size(133, 23);
            tbПисьмо.TabIndex = 14;
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
            // cbProjectList
            // 
            cbProjectList.FormattingEnabled = true;
            cbProjectList.Location = new Point(65, 13);
            cbProjectList.Name = "cbProjectList";
            cbProjectList.Size = new Size(133, 23);
            cbProjectList.TabIndex = 17;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(997, 429);
            tabControl1.TabIndex = 18;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChangedAsync;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvProjectList);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(989, 401);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Проект";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvProjectList
            // 
            dgvProjectList.AllowUserToAddRows = false;
            dgvProjectList.AllowUserToDeleteRows = false;
            dgvProjectList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProjectList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjectList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjectList.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvProjectList.Location = new Point(3, 36);
            dgvProjectList.Name = "dgvProjectList";
            dgvProjectList.ReadOnly = true;
            dgvProjectList.Size = new Size(983, 358);
            dgvProjectList.TabIndex = 6;
            dgvProjectList.RowEnter += dgvProjectList_RowEnter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewTextBoxColumn1.HeaderText = "#";
            dataGridViewTextBoxColumn1.MinimumWidth = 50;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn2.DataPropertyName = "ProjectName";
            dataGridViewTextBoxColumn2.HeaderText = "Код проекта";
            dataGridViewTextBoxColumn2.MaxInputLength = 10;
            dataGridViewTextBoxColumn2.MinimumWidth = 100;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "ProjectFullName";
            dataGridViewTextBoxColumn3.HeaderText = "Наименование проекта";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.ToolTipText = "---";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn4.DataPropertyName = "Owner";
            dataGridViewTextBoxColumn4.HeaderText = "Владелец";
            dataGridViewTextBoxColumn4.MinimumWidth = 150;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 150;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(textBox6);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(textBox7);
            tabPage1.Controls.Add(tbИсх);
            tabPage1.Controls.Add(tbОтпавитель);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(tbВх);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(tbПолучатель);
            tabPage1.Controls.Add(dgvProjects);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(cbProjectList);
            tabPage1.Controls.Add(tbПисьмо);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(989, 401);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Письмо";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(837, 42);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(133, 23);
            comboBox2.TabIndex = 32;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(837, 16);
            label11.Name = "label11";
            label11.Size = new Size(81, 15);
            label11.TabIndex = 31;
            label11.Text = "Исполнитель";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(693, 13);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(133, 23);
            textBox6.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(642, 45);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 28;
            label9.Text = "Дата вх.";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(642, 16);
            label10.Name = "label10";
            label10.Size = new Size(57, 15);
            label10.TabIndex = 29;
            label10.Text = "Дата исх.";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(693, 42);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(133, 23);
            textBox7.TabIndex = 27;
            // 
            // tbИсх
            // 
            tbИсх.Location = new Point(502, 13);
            tbИсх.Name = "tbИсх";
            tbИсх.Size = new Size(133, 23);
            tbИсх.TabIndex = 26;
            // 
            // tbОтпавитель
            // 
            tbОтпавитель.Location = new Point(304, 13);
            tbОтпавитель.Name = "tbОтпавитель";
            tbОтпавитель.Size = new Size(133, 23);
            tbОтпавитель.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(451, 45);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 23;
            label7.Text = "№ вх.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(451, 16);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 24;
            label8.Text = "№ исх.";
            // 
            // tbВх
            // 
            tbВх.Location = new Point(502, 42);
            tbВх.Name = "tbВх";
            tbВх.Size = new Size(133, 23);
            tbВх.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(213, 45);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 19;
            label5.Text = "Получатель";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(217, 16);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 20;
            label6.Text = "Отправитель";
            // 
            // tbПолучатель
            // 
            tbПолучатель.Location = new Point(304, 42);
            tbПолучатель.Name = "tbПолучатель";
            tbПолучатель.Size = new Size(133, 23);
            tbПолучатель.TabIndex = 18;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(989, 401);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Договор";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { a1, Column2 });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(983, 395);
            dataGridView1.TabIndex = 0;
            // 
            // a1
            // 
            a1.HeaderText = "#";
            a1.Name = "a1";
            a1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // panelGrid
            // 
            panelGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelGrid.Controls.Add(tabControl1);
            panelGrid.Location = new Point(12, 82);
            panelGrid.Name = "panelGrid";
            panelGrid.Size = new Size(997, 429);
            panelGrid.TabIndex = 19;
            // 
            // tssCurrentPage
            // 
            tssCurrentPage.Name = "tssCurrentPage";
            tssCurrentPage.Size = new Size(118, 17);
            tssCurrentPage.Text = "toolStripStatusLabel3";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 544);
            Controls.Add(panelGrid);
            Controls.Add(panelDragDrop);
            Controls.Add(toolStrip2);
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
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panelDragDrop.ResumeLayout(false);
            panelSourceDocs.ResumeLayout(false);
            panelSourceDocs.PerformLayout();
            panelDocs.ResumeLayout(false);
            panelDocs.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProjectList).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelGrid.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dgvProjects;
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
#pragma warning disable CS0169 // The field 'MainForm.toolStrip1' is never used
        private ToolStrip toolStrip1;
#pragma warning restore CS0169 // The field 'MainForm.toolStrip1' is never used
#pragma warning disable CS0169 // The field 'MainForm.toolStripProgressBar1' is never used
        private ToolStripProgressBar toolStripProgressBar1;
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
        private Panel panelDragDrop;
        private Panel panelSourceDocs;
        private Panel panelDocs;
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
        private TextBox tbПисьмо;
        private Label label3;
        private Label label4;
        private ComboBox cbProjectList;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panelGrid;
        private ToolStripStatusLabel tssCurrentProject;
        private Label label7;
        private Label label8;
        private TextBox tbВх;
        private Label label5;
        private Label label6;
        private TextBox tbПолучатель;
        private ComboBox comboBox2;
        private Label label11;
        private TextBox textBox6;
        private Label label9;
        private Label label10;
        private TextBox textBox7;
        private TextBox tbИсх;
        private TextBox tbОтпавитель;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem создатьСправкуToolStripMenuItem;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn PrjectId;
        private DataGridViewTextBoxColumn DocType;
        private DataGridViewTextBoxColumn DocDate;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Remark;
        private DataGridViewButtonColumn Column1;
        private TabPage tabPage3;
        private DataGridView dgvProjectList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn a1;
        private DataGridViewTextBoxColumn Column2;
        private ToolStripStatusLabel tssCurrentPage;
    }
}
