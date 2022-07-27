//Данный модуль предназначен для авторизации пользователя
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
using System.Data.SqlClient;

namespace TV_and_MS
{

    public partial class Autorization : Form
    {
        public static SqlConnection myConnection;
        string name = "";
        string rename = "";
        string login = "";
        SqlDataReader reader;
        public Autorization()
        {
            InitializeComponent();
        }
        
        //открываем вкладку "Регистрация"
        private void registrate_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }
        
        //открываем вкладку "Восстановление пароля"
        private void pass_Label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Recovery_pass rp = new Recovery_pass();
            rp.Show();
        }
       
        //при загрузке формы
        private void Autorization_Load(object sender, EventArgs e)
        {
            
                //myConnection = new SqlConnection("Data Source=localhost;User ID=sa;Password=butterfly28");
            //myConnection = new SqlConnection("Data Source=localhost");
            myConnection = new SqlConnection("Database=TVMS;Server=localhost;Integrated Security=True;connect timeout = 30");
                //  connetionString = "Data Source=asus;Initial Catalog=tv_ms;User ID=UserName;Password=Password";
                //cnn = new SqlConnection(connetionString);
                try
                {
                    myConnection.Open();
                   // MessageBox.Show("Connection Open ! ");
                }
                catch 
                {
                    MessageBox.Show("Проверьте подключение! ", "Подключение к серверу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    // MessageBox.Show("Не удалось подключиться к базе ! ");
                }
        }
       
        //пытаемся авторизоваться
        private void autorization_button_Click(object sender, EventArgs e)
        {
            
            login = "";
            name = "";
            rename = "";
            try
            {
                SqlCommand logcmd = new SqlCommand("SELECT DISTINCT [Логин] FROM [TVMS].[dbo].[Service] where [Логин] = '" + login_box.Text + "'", myConnection);
                reader = logcmd.ExecuteReader();
                reader.Read();
                login = reader["Логин"].ToString();
                reader.Close();    
                SqlCommand pascmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия] FROM [TVMS].[dbo].[Service] where [Пароль] = '" + password_box.Text + "' AND [Логин]='" + login + "'", myConnection);
                reader=pascmd.ExecuteReader();
                reader.Read();
                name = reader["Имя"].ToString();
                rename = reader["Фамилия"].ToString();
                reader.Close();
                data.login = login_box.Text;
                //data.pass = password_box.Text;
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            catch
            {
                if (login_box.Text == "" || password_box.Text == "")
                    MessageBox.Show("Введите логин и пароль", "Авторизация пользователя", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                MessageBox.Show("Убедитесь в правильности введенных данных, можете воспользоваться средством восстановления пароля или пройти регистрацию", "Авторизация пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
            }
        }
    }
}
