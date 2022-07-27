//Данный модуль предназначен для вывода статистики
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
 
    public partial class Statistic : Form
    {
        SqlDataReader reader;
        public Statistic()
        {
            InitializeComponent();
        }

        //при загрузке формы
        private void Statistic_Load(object sender, EventArgs e)
        {
            int i = 1;
            //вывод служебной инфо 
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label1.Text = reader["Имя"].ToString().Trim();
            label2.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();
            //если студент-его личная статистика
            if (label4.Text.Contains("Студент"))
            {
                dataGridView2.Rows.Clear();

                //вывод статистики для обучающего тестирования
                SqlCommand cmd4 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Service].[Группа],[TVMS].[dbo].[Statistics].[Всего заданий],[TVMS].[dbo].[Statistics].[Процент правильных],[TVMS].[dbo].[Statistics].[Первая работа],[TVMS].[dbo].[Statistics].[Последняя работа] FROM [TVMS].[dbo].[Statistics],[TVMS].[dbo].[Service] WHERE [TVMS].[dbo].[Service].[Логин] = '" + data.login + "' AND [TVMS].[dbo].[Statistics].[Код студента]= (SELECT DISTINCT [TVMS].[dbo].[Service].[Код студента] FROM [TVMS].[dbo].[Service] where [TVMS].[dbo].[Service].[Логин] = '" + data.login + "')", Autorization.myConnection);
                reader = cmd4.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView2.Rows.Add("1", label1.Text + " " + label2.Text, reader["Группа"].ToString(), reader["Всего заданий"].ToString(), reader["Процент правильных"].ToString() + "%", reader["Первая работа"].ToString(), reader["Последняя работа"].ToString());
                }
                reader.Close();
            }
            //если преподаватель-общая статистика
            if (label4.Text.Contains("Преподаватель"))
            {

                dataGridView2.Rows.Clear();
                //вывод статистики для обучающего тестирования
                SqlCommand cmd_stat = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Service].[Фамилия],[TVMS].[dbo].[Service].[Имя],[TVMS].[dbo].[Service].[Группа],[TVMS].[dbo].[Statistics].[Всего заданий],[TVMS].[dbo].[Statistics].[Процент правильных],[TVMS].[dbo].[Statistics].[Первая работа],[TVMS].[dbo].[Statistics].[Последняя работа] FROM [TVMS].[dbo].[Statistics],[TVMS].[dbo].[Service]", Autorization.myConnection);
                reader = cmd_stat.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView2.Rows.Add(i, reader["Фамилия"].ToString().Trim() + " " + reader["Имя"].ToString().Trim(), reader["Группа"].ToString(), reader["Всего заданий"].ToString(), reader["Процент правильных"].ToString() + "%", reader["Первая работа"].ToString(), reader["Последняя работа"].ToString());
                    i++;
                }
                reader.Close();

            }
        }

        //открываем вкладку о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        //открываем основное меню
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        //выход к авторизации
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }

        //открываем справку
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }
    }
}
