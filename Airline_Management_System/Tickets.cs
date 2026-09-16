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

namespace Airline_Management_System
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rumman\Documents\AirplaneDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {

            if (Tid.Text == "" || TFcode.Text == "" || Tclass.Text == "" || TNation.Text == "" || amount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into TicketTbl (Tid,TFcode,Tclass,Tnation,Tamount,Tdate) values ('" + Tid.Text + "','" + TFcode.SelectedItem.ToString() + "','" + Tclass.SelectedItem.ToString() + "','" + TNation.Text + "','" + amount.Text + "','" + Date.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket details successfully recorded.");

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tid.Text = "";
            TFcode.Text = "";
            Tclass.Text = "";
            amount.Text = "";
            TNation.Text = "";
            Date.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }

        private void populate()
        {
            con.Open();
            string query = "select * from TicketTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TicketData.DataSource = ds.Tables[0];

            con.Close();
        }
        private void Tickets_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Tid.Text == "")
            {
                MessageBox.Show("Enter Flight to delete.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from TicketTbl where Tid='" + Tid.Text.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight information deleted successfully.");
                    con.Close();
                    populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Tid.Text == "" )
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update TicketTbl set TFcode='" + TFcode.SelectedItem.ToString() + "',Tnation='" + TNation.SelectedItem.ToString() + "',Tamount='" + amount.Text + "',Tclass='" + Tclass.Text + "',Tdate='" + Date.Value.Date.ToString() + "'where Tid='" + Tid.Text + "'  ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight information updated successfully.");
                    con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Missing Information");
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
