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


namespace ProjectB
{
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
       
        public Form3()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            comboBox1.Items.AddRange(new string[] {"М",
                                                   "Ж" });
        }
        public string SensText
        {
            get { return textBox9.Text; }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }
        private  void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserPC\Desktop\project\ProjectB11\ProjectB\Database.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserPC\Desktop\project\ProjectB11\ProjectB\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

        }

        private  void button2_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.Text;
            command1.CommandText = "INSERT INTO [Name] (surname, name, patronymic, sex)VALUES(@surname, @name, @patronymic, @sex)";
            command1.Connection = sqlConnection;
            //Для фамилии

            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
                {

                string surname = Convert.ToString(textBox6.Text);
                command1.Parameters.AddWithValue("@surname", surname);
                
                }
            else
            {
                label17.Visible = true;
                label17.Text = "Ошибка ввода данных";
            }

            //Для имени
            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {

                string name = Convert.ToString(textBox7.Text);
                command1.Parameters.AddWithValue("@name", name);

            }
            else
            {
                label18.Visible = true;
                label18.Text = "Ошибка ввода данных";
            }

            //Для отчества
            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                string patronymic = Convert.ToString(textBox8.Text);
                command1.Parameters.AddWithValue("@patronymic", patronymic);

            }
            else
            {
                label19.Visible = true;
                label19.Text = "Ошибка ввода данных";
            }

            //Пол
            string sex = Convert.ToString(comboBox1.Text);
            command1.Parameters.AddWithValue("@sex", sex);


            //закрыли комманд
            command1.ExecuteNonQuery();
            //закрыли поток
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserPC\Desktop\project\ProjectB11\ProjectB\Database.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserPC\Desktop\project\ProjectB11\ProjectB\Database.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();


            SqlCommand command2 = new SqlCommand();

            command2.CommandText = "SELECT Id FROM Name"; ;
            command2.Connection = sqlConnection;

            int id_name = 0;

            SqlDataReader reader = null;
            reader = command2.ExecuteReader();

            while (reader.Read())
            {
                id_name = (int)reader["Id"];

            }

            
            reader.Close();


            command2.CommandType = CommandType.Text;
            command2.CommandText = "INSERT INTO [Parametrs] (id_name, weight, growth, GMFCS_1, GMFCS_2, GMFCS_3, GMFCS_4, GMFCS_5, tone_down, tone, tone_up, FA_l, FA_in, FA_mob, FA_am)VALUES(@id_name, @weight, @growth, @GMFCS_1, @GMFCS_2, @GMFCS_3, @GMFCS_4, @GMFCS_5, @tone_down, @tone, @tone_up, @FA_l, @FA_in, @FA_mob, @FA_am)";
            command2.Connection = sqlConnection;

            command2.Parameters.AddWithValue("@id_name", id_name);

            //Для массы
            int weight;

            if (!string.IsNullOrEmpty(textBox9.Text) && (Int32.TryParse(textBox9.Text, out weight)))
            {
                weight = Convert.ToInt32(textBox9.Text);
                command2.Parameters.AddWithValue("@weight", weight);

            }
            else
            {
                label20.Visible = true;
                label20.Text = "Ошибка ввода данных";
            }

            //Для роста
            int growth;

            if (!string.IsNullOrEmpty(textBox10.Text) && (Int32.TryParse(textBox10.Text, out growth)))
            {

                growth = Convert.ToInt32(textBox10.Text);
                command2.Parameters.AddWithValue("@growth", growth);


            }
            else
            {
                label21.Visible = true;
                label21.Text = "Ошибка ввода данных";
            }


            ////На GMFCS
            var GMFCS_1 = radioButton1.Checked;
            command2.Parameters.AddWithValue("@GMFCS_1", GMFCS_1);

            var GMFCS_2 = radioButton2.Checked;
            command2.Parameters.AddWithValue("@GMFCS_2", GMFCS_2);

            var GMFCS_3 = radioButton3.Checked;
            command2.Parameters.AddWithValue("@GMFCS_3", GMFCS_3);

            var GMFCS_4 = radioButton4.Checked;
            command2.Parameters.AddWithValue("@GMFCS_4", GMFCS_4);

            var GMFCS_5 = radioButton5.Checked;
            command2.Parameters.AddWithValue("@GMFCS_5", GMFCS_5);


            ////Мышечный тонус
            var tone_down = radioButton8.Checked;
            command2.Parameters.AddWithValue("@tone_down", tone_down);

            var tone = radioButton9.Checked;
            command2.Parameters.AddWithValue("@tone", tone);

            var tone_up = radioButton10.Checked;
            command2.Parameters.AddWithValue("@tone_up", tone_up);


            ////Состояние
            var FA_l = radioButton15.Checked;
            command2.Parameters.AddWithValue("@FA_l", FA_l);

            var FA_in = radioButton14.Checked;
            command2.Parameters.AddWithValue("@FA_in", FA_in);

            var FA_mob = radioButton13.Checked;
            command2.Parameters.AddWithValue("@FA_mob", FA_mob);

            var FA_am = radioButton12.Checked;
            command2.Parameters.AddWithValue("@FA_am", FA_am);


            
            command2.ExecuteNonQuery();
            

            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

            string[] fullname = new string[3];
            
            String.Join(" ", fullname);

            Form f2 = new Form2();
            f2.Show();
            this.Hide();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
