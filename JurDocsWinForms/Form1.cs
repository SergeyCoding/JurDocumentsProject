using System.Diagnostics;

namespace JurDocsWinForms
{
    public partial class Form1 : Form
    {
        private const string _noLoginStripStatus = "Выберите пользователя, и нажмите логин...";
        private bool _isLogin = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = _noLoginStripStatus;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                MessageBox.Show("Click by " + e.RowIndex);
                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginText.Text))
            {
                toolStripStatusLabel1.Text = _noLoginStripStatus;
                _isLogin = false;
                return;
            }

            toolStripStatusLabel1.Text = "OK";
            _isLogin = true;
        }


        private void testDataGrid()
        {
            var z = new List<FileTableList>();

            for (int i = 0; i < 10; i++)
                z.Add(new FileTableList { Id = i, DocType = "d1" + i, BtnText = "btn" + i });

            this.dataGridView1.DataSource = z;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileTableListBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!_isLogin)
                return;

            testDataGrid();

            //Process.Start("explorer.exe", @"C:\Work\TFS\JurDocumentsProject\Temp1");
        }
    }
}
