using Project_6___People_App.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_6___People_App
{
    public partial class PeopleApp : Form
    {
        public PeopleApp()
        {
            InitializeComponent();
            LoadPanel(new Home(), MainPanel);
        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            LoadPanel(f, MainPanel);
        }

        private void LoadPanel(Form f, Panel p)
        {
            if (p.Controls.Count > 0)
            {
                p.Controls.RemoveAt(0);
            }
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            p.Controls.Add(f);
            f.Show();
        }

        private void HomePageBtn_Click(object sender, EventArgs e)
        {
            LoadPanel(new Home(), MainPanel);
        }
    }
}
