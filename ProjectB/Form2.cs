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
    public partial class Form2 : Form
    {
        Graphics gr;
        Bitmap bit;

        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            picture.BackColor = Color.White;
            bit = new Bitmap(picture.Width, picture.Height);
            gr = Graphics.FromImage(bit);
            gr.ScaleTransform(1.0F, -1.0F);
            gr.TranslateTransform(1.0F, -(float)picture.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gr != null)
            {
                gr.Clear(Color.White);
                picture.Image = bit;
            }

            float yu, xy;

            if (!string.IsNullOrEmpty(textBox9.Text) && (float.TryParse(textBox9.Text, out yu)))
            {
                yu = (float)Convert.ToDouble(textBox9.Text);
            }
            else
            { return; }

            if (!string.IsNullOrEmpty(textBox1.Text) && (float.TryParse(textBox1.Text, out xy)))
            {
                label13.Visible = false;
                xy = (float)Convert.ToDouble(textBox1.Text);
            }
            else
            { return; }

            Pen pen = new Pen(Color.Black, 4);
            float mx = picture.Width / 20;
            float my = picture.Height / 100;

            PointF[] points =
            {
                new PointF(10, 30),
                new PointF(30.0F, 100.0F),
                new PointF(100.0F, 160.0F),
                new PointF(160.0F, 300.0F),
                new PointF(yu*mx, xy*my)
            };
     
            Pen pen1 = new Pen(Color.Crimson, 5);
            gr.DrawCurve(pen, points);
            picture.Image = bit;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserPC\Desktop\project\ProjectB11\ProjectB\Database.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserPC\Desktop\project\ProjectB11\ProjectB\Database.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            command.CommandText = "SELECT name, surname, patronymic FROM Name";
            command.Connection = sqlConnection;

            SqlDataReader reader = null;
            reader = command.ExecuteReader();

            string fio = "";
            while (reader.Read())
            {
                fio = reader["name"] + " " + reader["surname"] + " " + reader["patronymic"];
                comboBox1.Items.Add(fio);
            }


            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string[] snp = comboBox1.Text.Split(' ');
            //string surname = snp[0];
            //string name = snp[1];
            //string patronymic = snp[2];

            //SqlCommand command = new SqlCommand("SELECT * FROM [Name] ", sqlConnection);

            //SqlDataReader reader = command.ExecuteReader();


            //while (reader.HasRows)
            //{
            //    label5.Text = reader.GetName(0)+reader.GetName(1);
            //    //while (reader.Read())
            //    //{
            //    //    label5.Text = reader.GetString(0);
            //    //}
            //}


            double age = 0, weight = 0, growth = 0;

            //Для возраста
            if (!string.IsNullOrEmpty(textBox9.Text) && (Double.TryParse(textBox9.Text, out age)))
            {
                label17.Visible = false;
                age = Convert.ToDouble(textBox9.Text);

            }
            else
            {
                label17.Visible = true;
                label17.Text = "Ошибка ввода данных";
            }

            //Для массы
            if (!string.IsNullOrEmpty(textBox1.Text) && (Double.TryParse(textBox1.Text, out weight)))
            {
                label13.Visible = false;
                weight = Convert.ToDouble(textBox1.Text);

            }
            else
            {
                label13.Visible = true;
                label13.Text = "Ошибка ввода данных";
            }

            //Для роста
            if (!string.IsNullOrEmpty(textBox2.Text) && (Double.TryParse(textBox2.Text, out growth)))
            {
                label14.Visible = false;
                growth = Convert.ToDouble(textBox2.Text);

            }
            else
            {
                label14.Visible = true;
                label14.Text = "Ошибка ввода данных";
            }


            double caloriesOfHarris = 66.47 + (13.75 * weight) + (5.0 * growth) - (6.76 * age);
            string calculation1 = Convert.ToString(caloriesOfHarris);
            label4.Text = calculation1;

            double caloriesOfKrick = 66.0 + (14.0 * weight) + (5.0 * growth) - (6.9 * age);
            string calculation2 = Convert.ToString(caloriesOfKrick);
            label5.Text = calculation2;

            double caloriesOfEnergy = 66.9 + (14.5 * weight) + (5.9 * growth) - (7.2 * age);
            string calculation3 = Convert.ToString(caloriesOfEnergy);
            label9.Text = calculation3;
            //reader.Close();
            //sqlConnection.Close();


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
