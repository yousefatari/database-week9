using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace database
{
    public partial class Form1 : Form
    {

       private string connectstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"week9.accdb\"";
        private OleDbConnection con;
        public Form1()
        {
            con = new OleDbConnection(connectstring);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateStudentsGird();

        }

        private void btnstudentadd_Click(object sender, EventArgs e)

        {
            InsertStudent(txtstudentNo.Text, txtstudentfirstname.Text, txtStudentlastname.Text);

            ClearForm();

            UpdateStudentsGird();
        }
        private void UpdateStudentsGird()
        {
            OleDbCommand command = new OleDbCommand("Select * from Table1", con);

            OleDbDataAdapter da = new OleDbDataAdapter(command);

            //  data base � applcation ���� ���� 
            DataTable dt = new DataTable();

            da.Fill(dt);
            //  command��������� ��� ���� �� database  ����� 

            dataGridView1.DataSource = dt;


        }


        private void InsertStudent( string StudentNo,string Studentfirstname,string Studentlastname)
        
        {
            //command��� ��  
            string insertCommand = $"Insert Into Table1([StudentNo],[Student first Name],[Student last Name]) " +
                $"values('{StudentNo}', '{Studentfirstname}', '{Studentlastname}')";//$  ' � ����  string ������� ��� 

            OleDbCommand command = new OleDbCommand(insertCommand, con);
            //insertCommand name command

            con.Open();

            command.ExecuteNonQuery();
            //to inspent ,uptate,delete

            con.Close();

        }
      private void ClearForm()
        {
            txtstudentNo.Text = "";
            txtstudentfirstname.Text = "";
            txtStudentlastname.Text = "";

            txtstudentNo.Focus();


        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}