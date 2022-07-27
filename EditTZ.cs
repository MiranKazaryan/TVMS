//Данный модуль предназначен для выбора способа редактирования тестовых заданий в базе данных
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

    public partial class EditTZ : Form
    {
        SqlDataReader reader;
        public EditTZ()
        {
            InitializeComponent();
        }
        //приступаем к редакции тестового задания по выбранному р/баттону
        private void button1_Click(object sender, EventArgs e)
        {
           /* if (AddradioButton.Checked == false && ChangeradioButton.Checked == false && DeleteradioButton.Checked == false)
                MessageBox.Show("Выберите режим редактирования тестового задания", "Редактирование тестового задания", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    if (AddradioButton.Checked == true)
                    {
                        this.Close();
                        AddTZ atz = new AddTZ();
                        atz.Show();
                    }
                    if (ChangeradioButton.Checked == true)
                    {
                        this.Close();
                        ChangeTZ ctz = new ChangeTZ();
                        ctz.Show();
                    }
                    if (DeleteradioButton.Checked == true)
                    {
                        this.Close();
                        DelTZ dtz = new DelTZ();
                        dtz.Show();
                    }
                }
                catch
                {
                    //MessageBox.Show("Error", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        }

        //при загрузке формы
        private void EditTZ_Load(object sender, EventArgs e)
        {
            //вывод служебной инфо 
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label1.Text = reader["Имя"].ToString().Trim();
            label2.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();

            SqlCommand cmd4 = new SqlCommand("SELECT DISTINCT [Вопрос] FROM [TVMS].[dbo].[Task]", Autorization.myConnection);
            reader = cmd4.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["Вопрос"].ToString());
            }
            reader.Close();
        }

        //Открываем вкладку "О программе"
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        //Открываем основное меню программы
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        //Осуществляем выход из системы
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }

        //Открываем справку по программе
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void ChangeBut_Click(object sender, EventArgs e)
        {
            this.Close();
            ChangeTZ ctz = new ChangeTZ();
            ctz.Show();
        }

        private void DelBut_Click(object sender, EventArgs e)
        {
            this.Close();
            DelTZ dtz = new DelTZ();
            dtz.Show();
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            this.Close();
            AddTZ atz = new AddTZ();
            atz.Show();
        }
    }
}
