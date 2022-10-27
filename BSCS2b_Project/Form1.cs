using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace BSCS2b_Project
{
    public partial class Form1 : Form
    {
        DatabaseConnect dbConnect = new DatabaseConnect();

        public Form1()
        {
            InitializeComponent();
            if (!this.dbConnect.Connect())
            {
                MessageBox.Show("Not Connected to the Database!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.ToString();
            string password = tbPassword.Text.ToString();

            try
            {
                dbConnect.Connect();
                dbConnect.Cmd.CommandText = $"SELECT * FROM USERS WHERE " +
                    $"USERNAME = '{userName}' and PASSWORD ='{password}'";
                SqlDataReader result = dbConnect.Cmd.ExecuteReader();
                
                if(result.Read())
                {
                    MessageBox.Show("Login Successful!");
                }
                else
                {
                    MessageBox.Show("Either username or password is incorrect!");
                }
            
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}