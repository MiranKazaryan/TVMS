//Данный  модуль предназначен для выбора режима тестирования
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

    public partial class Select_test : Form
    {
        SqlDataReader reader;
        public Select_test()
        {
            InitializeComponent();
        }
        //выбор режима тестирования
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlradioButton.Checked == true)
                {
                    //setcomboBox.Visible = true;
                    //формирует выбранный тестовый набор
                    data.value = setcomboBox.SelectedItem.ToString();
                    Control_test ct = new Control_test();
                    ct.Show();
                    this.Close();
                }
                if (EducradioButton.Checked == true)
                {
                    eduTest et = new eduTest();
                    et.Show();
                    this.Close();
                }
            }
            catch {
                MessageBox.Show("Выберите тестовый набор", "Режим тестирования", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //выбор тестового набора для контрольного тестирования
        private void ControlradioButton_Click(object sender, EventArgs e)
        {
            if (ControlradioButton.Checked == true)
            {
                label7.Visible = true;
                setcomboBox.Visible = true;

            }
        }
        //при загрузке формы
        private void Select_test_Load(object sender, EventArgs e)
        {
            //вывод служебной инфо 
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label1.Text = reader["Имя"].ToString().Trim();
            label2.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();
            //вывод тестовых наборов в combobox 
            SqlCommand cont_test = new SqlCommand("SELECT DISTINCT [Код набора],[Название] FROM [TVMS].[dbo].[Test_Set]", Autorization.myConnection);
            reader = cont_test.ExecuteReader();
            while (reader.Read())
                setcomboBox.Items.Add(reader["Название"].ToString());
            reader.Close();
        }

        //выбор параметров для обучающего тестирования
        private void EducradioButton_Click(object sender, EventArgs e)
        {
            if (ControlradioButton.Checked == false)
            {
                label7.Visible = false;
                setcomboBox.Visible = false;

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
        //выходим из системы
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
