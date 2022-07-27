//Данный модуль предназначен для регистрации
//Исполнитель: Казарян Миран Размикович
//Дипломная работа 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;


namespace TV_and_MS
{

    public partial class Registration : Form
    {
        DateTime thisDay = DateTime.Today;
        string std_teach;
        public Registration()
        {
            InitializeComponent();
            accessBox.Visible = false;
            label8.Visible = false;
            accessButton.Visible = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
        }
        //регистрация нового пользователя
        private void button1_Click(object sender, EventArgs e)
        {
            //проверка валидность мейла
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Ошибка добавления данных,убедитесь,что все поля заполнены", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string pattern = null;
                pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (Regex.IsMatch(textBox6.Text, pattern))
                {

                
                if (teachradioButton.Checked == true)
                {
                    accessButton.Visible = true;
                    accessBox.Visible = true;
                    label8.Visible = true;
                    reg_button.Visible = false;
                    std_teach = "Преподаватель";
                }
                if (studentradioButton.Checked == true)
                {
                    std_teach = "Cтудент";
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                    {
                        try
                        {

                            //запрос , который добавляет нового пользователя в базу данных
                            SqlCommand cmd = new SqlCommand("INSERT INTO [TVMS].[dbo].[Service] ([Имя],[Фамилия],[Логин],[Пароль],[e-mail],[Группа],[Вид пользователя]) VALUES (" + "'" + textBox3.Text + "'" + "," + "'" + textBox4.Text + "'" + "," + "'" + textBox1.Text + "'" + "," + "'" + textBox2.Text + "'" + "," + "'" + textBox6.Text + "'" + "," + "'" + textBox5.Text + "'" + "," + "'" + std_teach + "'" + ")", Autorization.myConnection);
                            cmd.ExecuteNonQuery();
                            SqlCommand max = new SqlCommand("SELECT MAX ([TVMS].[dbo].[Service].[Код студента]) FROM [TVMS].[dbo].[Service]", Autorization.myConnection);
                            int maxid = Convert.ToInt32(max.ExecuteScalar().ToString());
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO [TVMS].[dbo].[Statistics] ([TVMS].[dbo].[Statistics].[Код студента],[TVMS].[dbo].[Statistics].[Всего заданий],[TVMS].[dbo].[Statistics].[Верных заданий],[TVMS].[dbo].[Statistics].[Процент правильных],[TVMS].[dbo].[Statistics].[Первая работа]) VALUES (" + maxid + ", 0,0,0,'"+(thisDay.ToString("d")) +"')", Autorization.myConnection);
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("Регистрация прошла успешно", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            data.login = textBox1.Text;
                            //data.pass = textBox2.Text;
                            Menu menu = new Menu();
                            menu.Show();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка добавления данных,убедитесь,что все поля заполнены", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                }
                else
                {
                    MessageBox.Show("Проверьте введенный e-mail ", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
     
        //проверяем, знает ли пользователь пароль для регистрации "Преподавателя"
        private void accessButton_Click(object sender, EventArgs e)
        {
            if (accessBox.Text != "0000")
            {
                MessageBox.Show("Неверный ключ доступа, попробуйте еще раз", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    try
                    {
                        //запрос , который добавляет нового пользователя в базу данных
                        SqlCommand cmd = new SqlCommand("INSERT INTO [TVMS].[dbo].[Service] ([Имя],[Фамилия],[Логин],[Пароль],[e-mail],[Группа],[Вид пользователя]) VALUES (" + "'" + textBox3.Text + "'" + "," + "'" + textBox4.Text + "'" + "," + "'" + textBox1.Text + "'" + "," + "'" + textBox2.Text + "'" + "," + "'" + textBox6.Text + "'" + "," + "'" + textBox5.Text + "'" + "," + "'" + std_teach + "'" + ")", Autorization.myConnection);
                        cmd.ExecuteNonQuery();
                        SqlCommand max = new SqlCommand("SELECT MAX ([TVMS].[dbo].[Service].[Код студента]) FROM [TVMS].[dbo].[Service]", Autorization.myConnection);
                        int maxid = Convert.ToInt32(max.ExecuteScalar().ToString());
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO [TVMS].[dbo].[Statistics] ([TVMS].[dbo].[Statistics].[Код студента],[TVMS].[dbo].[Statistics].[Всего заданий],[TVMS].[dbo].[Statistics].[Верных заданий],[TVMS].[dbo].[Statistics].[Процент правильных],[TVMS].[dbo].[Statistics].[Первая работа]) VALUES (" + maxid + ", 0,0,0,'"+(thisDay.ToString("d"))+"')", Autorization.myConnection);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Регистрация прошла успешно", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        data.login = textBox1.Text;
                        //data.pass = textBox2.Text;
                        Menu menu = new Menu();
                        menu.Show();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка добавления данных,убедитесь,что все поля заполнены", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        //имя(русский)
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }
        
        //фамилия(русский)
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }
       
        //логин(английский)
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && l != '\b')
            {
                e.Handled = true;
            }
        }
       
        //пароль(английский+цифры)
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && l != '\b' && !Char.IsDigit(l))
            {
                e.Handled = true;
            }
        }
       
        //e-mail (английский+цифры+.+@)
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && l != '\b' && !Char.IsDigit(l) && l != '.' && l != '@')
            {
                e.Handled = true;
            }
        }

        //при нажатии на textbox выделяем текст
        private void textBox1_Click(object sender, EventArgs e)
        {
            TextBox clicktb = sender as TextBox;
            clicktb.SelectAll();
        }

    }
}
