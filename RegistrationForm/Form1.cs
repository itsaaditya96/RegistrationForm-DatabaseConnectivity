using System;
using MySql.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class Form1 : Form
    {
     
        String myconnection = "SERVER=127.0.0.1;DATABASE=dotnet;UID=root;PASSWORD=aaditya", inquery,outquery;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String gender;

            if (radioButton1.Checked)
                gender = radioButton1.Text;
            else if (radioButton2.Checked)
                gender = radioButton2.Text;
            else
                gender = radioButton1.Text;
            try
            {
                
                inquery = "insert into details(Name,FatherName,MotherName,Address,PhoneNo,Gender,Marks10,Marks12,Branch) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "','" + gender + "'," + Convert.ToDouble(textBox5.Text) + "," + Convert.ToDecimal(textBox6.Text) + ",'" + comboBox1.Text + "')";
                MySqlConnection connection = new MySqlConnection(myconnection);
                MySqlCommand command = new MySqlCommand(inquery, connection);
                MySqlDataReader myReader;
                connection.Open();
                myReader = command.ExecuteReader();
                MessageBox.Show("Save Data");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            outquery = "SELECT * FROM details";
            MySqlConnection connection = new MySqlConnection(myconnection);
            MySqlCommand command = new MySqlCommand(outquery, connection);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable("My Table");
            myAdapter.Fill(table);
            foreach (DataRow row in table.Rows) {
                for (int i = 0; i < row.ItemArray.Length/9; i++) {
                    comboBox2.Items.Add(row.ItemArray[0].ToString());
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name_fetched = comboBox2.Text;

            String fetched_query = "SELECT * FROM details WHERE name = '"+name_fetched+"'";
            MySqlConnection connection = new MySqlConnection(myconnection);
            MySqlCommand command = new MySqlCommand(fetched_query, connection);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable("My Table");
            myAdapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                textBox1.Text = row.ItemArray[0].ToString();
                textBox2.Text = row.ItemArray[1].ToString();
                textBox3.Text = row.ItemArray[2].ToString();
                richTextBox1.Text = row.ItemArray[3].ToString();
                textBox4.Text = row.ItemArray[4].ToString();
                textBox5.Text = row.ItemArray[6].ToString();
                textBox6.Text = row.ItemArray[7].ToString();
                comboBox1.Text = row.ItemArray[8].ToString();

                if (row.ItemArray[5].ToString() == "Male")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
                


            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
