using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_6___People_App.Forms
{
    public partial class AddForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PS7OKKF;Initial Catalog=PeopleApp_db;Integrated Security=True");
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text.Length != 0 && LastNameTb.Text.Length != 0 && AgeNUAD.Value != 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"Insert Into Person_Tb (Name, LastName, Age) VALUES ('{NameTb.Text}','{LastNameTb.Text}', {AgeNUAD.Value})", con);
                cmd.ExecuteNonQuery();
                con.Close();
                NameTb.Text = "";
                LastNameTb.Text = "";
                AgeNUAD.BackColor = Color.White;
                AgeNUAD.Value = 0;
                MessageBox.Show("Added Person", "Success.");
            }
            else if (NameTb.Text.Length == 0)
            {
                NameTb.BackColor = Color.Red;
            }
            else if (LastNameTb.Text.Length == 0)
            {
                LastNameTb.BackColor = Color.Red;
            }
            else
            {
                AgeNUAD.BackColor = Color.Red;
            }
            
        }
        private void NameTb_TextChanged(object sender, EventArgs e)
        {
            NameTb.BackColor = Color.White;
        }

        private void LastNameTb_TextChanged(object sender, EventArgs e)
        {
            LastNameTb.BackColor = Color.White;
        }

        private void AgeNUAD_ValueChanged(object sender, EventArgs e)
        {
            AgeNUAD.BackColor = Color.White;
        }
    }
}
