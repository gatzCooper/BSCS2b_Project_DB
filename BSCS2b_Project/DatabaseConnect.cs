using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCS2b_Project
{
    public class DatabaseConnect
    {
        //connection string
        private const string serverName = "localhost\\SQLEXPRESS";
        private const string dataBaseName = "BSCS4A_DB";
        private const bool integratedSecurity = true;

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;

        #region Encapsulation
        public SqlConnection Con { get => con; set => con = value; }
        public SqlCommand Cmd { get => cmd; set => cmd = value; }
        public SqlDataReader Dr { get => dr; set => dr = value; }
        #endregion Encapsulation

        // Constructor
        public DatabaseConnect()
        {
            this.con = new SqlConnection("Data Source = " + serverName + ";"
                            + "Integrated Security = " + integratedSecurity + ";" +
                            "Initial Catalog = " + dataBaseName + ""
                        );
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.con;
        }
        public bool Connect()
        {
            if (this.con.State == ConnectionState.Closed || this.con.State == ConnectionState.Broken)
            {
                try { this.con.Open(); }
                catch { return false; }
            }
            return true;
        }

        // Method to close the connection to the database
        public void Disconnect()
        {
            if (this.con.State == ConnectionState.Open)
            {
                this.con.Close();
            }
        }


    }
}
