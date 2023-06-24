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
    public partial class Home : Form
    {
        Point ImgPosition = new Point(257, 34);
        Point NameLPosition = new Point(313, 34);
        Point LastNameLPosition = new Point(435, 34);
        Point AgeLPosition = new Point(576, 34);
        string ImagePath = @"C:\Users\Saba\source\repos\Project 6 - People App\Project 6 - People App\Resources\icons8-user-50.png";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-PS7OKKF;Initial Catalog=PeopleApp_db;Integrated Security=True");
        public Home()
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            InitializeComponent();
            AutoScroll = true;
            Dock = DockStyle.Fill;
        }
        private void DynamicDBView(string id, string name, string lastname, string age, Point imgPos, Point NamePos, Point LastNamePos, Point AgePos)
        {
            Label NameL = new Label();
            Label LastNameL = new Label();
            Label AgeL = new Label();
            PictureBox pic = new PictureBox();

            pic.Location = imgPos;
            NameL.Location = NamePos;
            LastNameL.Location = LastNamePos;
            AgeL.Location = AgePos;

            NameL.Text = name;
            LastNameL.Text = lastname;
            AgeL.Text = age;

            NameL.Font = MainLabel.Font;
            LastNameL.Font = MainLabel.Font;
            AgeL.Font = MainLabel.Font;

            pic.Image = Image.FromFile(ImagePath);

            List<Control> cs = new List<Control>() { NameL, LastNameL, AgeL, pic };
            Controls.AddRange(cs.ToArray());

            ImgPosition.Y += 56;
            NameLPosition.Y += 56;
            LastNameLPosition.Y += 56;
            AgeLPosition.Y += 56;
        }
        private void Home_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Person_Tb",con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            PeopleDGV.Rows.Add(dt.Rows.Count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PeopleDGV.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                PeopleDGV.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                PeopleDGV.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                PeopleDGV.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                DynamicDBView(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), ImgPosition,NameLPosition,LastNameLPosition,AgeLPosition);
            }   
        }
    }
}