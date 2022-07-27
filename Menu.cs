//Данный модуль предназначен для вывода всех модулей программного средства
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

    public partial class Menu : Form
    {
        SqlDataReader reader;
        public Menu()
        {
            InitializeComponent();
        }
        //открываем тестирование
        private void TestButton_Click(object sender, EventArgs e)
        {
            Select_test st = new Select_test();
            st.Show();
            this.Close();
        }
        //открываем добавление тестового набора
        private void AddButton_Click(object sender, EventArgs e)
        {
            Add_TestSet at = new Add_TestSet();
            at.Show();
            this.Close();
        }
        //открываем редактирование тестового задания
        private void EditButton_Click(object sender, EventArgs e)
        {
            EditTZ etz = new EditTZ();
            //Edit etz = new Edit();
            etz.Show();
            this.Close();
        }
        //при загрузке формы
        public void Menu_Load(object sender, EventArgs e)
        {
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label1.Text = reader["Имя"].ToString().Trim();
            label2.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();

            if (label4.Text.Trim() == "Студент")
            {
                pictureBox7.Visible = false;
                AddButton.Visible = false;
                pictureBox5.Visible = false;
                EditButton.Visible = false;
                pictureBox6.Location = new Point(478, 174);
                StatButton.Location = new Point(478, 338);
                TestButton.Location = new Point(241,338);
                pictureBox3.Location = new Point(241,174);
                this.Size = new Size(670, 462);
            }
        }

        

        //открываем статистику
        private void StatButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Statistic stat = new Statistic();
            stat.Show();
        }

        //Открываем лекционный материал
        private void EKL_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Lecture lect = new Lecture();
            lect.Show();
        }

        //открываем вкладку о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.Close();
            About ab = new About();
            ab.Show();
        }
        //выход из системы
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }
        //при наведении мыши на объект выдаем contextmenustrip
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            //contextMenuStrip1.Show(pictureBox5, e.X, e.Y);

        }
        private void EditButton_MouseMove(object sender, MouseEventArgs e)
        {
            //contextMenuStrip1.Show(EditButton, e.X, e.Y);
        }

        //открываем добавление ТЗ
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            AddTZ at = new AddTZ();
            at.Show();
        }

        //открываем удаление ТЗ
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
            DelTZ at = new DelTZ();
            at.Show();
        }

        //открываем изменение ТЗ
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
            ChangeTZ at = new ChangeTZ();
            at.Show();
        }

        //открываем справку
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            EditTZ etz = new EditTZ();
            //Edit etz = new Edit();
            etz.Show();
            this.Close();
        }
    }
}