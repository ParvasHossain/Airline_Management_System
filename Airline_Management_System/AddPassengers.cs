using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Airline_Management_System
{
    public partial class AddPassengers : Form
    {
        public AddPassengers()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rumman\Documents\AirplaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if(PassId.Text==""||PassAddress.Text == "" ||PassName.Text == "" ||Passport.Text == "" ||Phone.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into PassengerTbl(PassId,PassName,Passport,PassAddress,PassNation,PassGender,PassPhone)values('"+PassId.Text+ "','"+PassName.Text+ "','"+Passport.Text+ "','"+PassAddress.Text+ "','"+Nationality.SelectedItem.ToString()+ "','"+Gender.SelectedItem.ToString()+ "','"+Phone.Text+"')";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Passenger details successfully recorded.");

                    con.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewPassengers viewpass= new ViewPassengers();
            viewpass.Show();    
            this.Hide();
        }

        private void PassId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu menu=new MainMenu();
            menu.Show();
            this.Hide();
        }

        private void AddPassengers_Load(object sender, EventArgs e)
        {

        }
    }
}
