//Данный модуль предназначен для добавления нового тестового набора для контрольного тестирования
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

    public partial class Add_TestSet : Form
    {
        SqlDataReader reader;
        int i = 0;
        int[] mass = new int[4];
        int[] masspar = new int[31];
        public Add_TestSet()
        {
            InitializeComponent();
        }
        //узнаем какой р/батон выбран
        private int rad_but()
        {
            // Какой р/батон выбран
            foreach (Control item in groupBox1.Controls)
            {
                if (item is RadioButton)
                {
                    if (((RadioButton)item).Checked)
                    {
                        return int.Parse(item.Tag.ToString());
                    }
                }
            }
            return -1;
        }
        //при загрузке формы
        private void Add_TestSet_Load(object sender, EventArgs e)
        {
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label1.Text = reader["Имя"].ToString().Trim();
            label2.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();

            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT [Код модуля],[Название] FROM [TVMS].[dbo].[Modul]", Autorization.myConnection);
            reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                checkedListBox1.Items.Add(reader["Название"]);
            }
            reader.Close();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [Название] FROM [TVMS].[dbo].[Paragraph] ", Autorization.myConnection);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                checkedListBox2.Items.Add(reader["Название"]);
            }
            reader.Close();
        }
        //выбор модулей 
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex) == true)
                mass[checkedListBox1.SelectedIndex] = 0;
            else
            {
                SqlCommand cmd1 = new SqlCommand("SELECT [Код модуля] FROM [TVMS].[dbo].[Modul] WHERE [Название]='" + checkedListBox1.SelectedItem.ToString() + "'", Autorization.myConnection);
                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    mass[Convert.ToInt32(reader["Код модуля"]) - 1] = Convert.ToInt32(reader["Код модуля"]);
                }
                reader.Close();
                //обновляем параграфы
                checkedListBox2.Items.Clear();
                for (i = 0; i < 4; i++)
                {
                    if (mass[i] != 0)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT DISTINCT [Название] FROM [TVMS].[dbo].[Paragraph] WHERE [Код модуля]=" + (i + 1) + "", Autorization.myConnection);

                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            checkedListBox2.Items.Add(reader["Название"]);
                        }
                        reader.Close();
                    }
                }
            }
        }


        //добавление тестового набора
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [TVMS].[dbo].[Test_Set] ([Сложность набора],[Заданий],[Название]) VALUES (" + "'" + Convert.ToInt32(rad_but()) + "'" + "," + "'" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'" + "," + "'" + textBox2.Text + "')", Autorization.myConnection);
                    cmd.ExecuteNonQuery();
                    for (i = 0; i < 31; i++)
                    {
                        if (masspar[i] != 0)
                        {
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO [TVMS].[dbo].[par_set]([Код параграфа],[Код набора]) SELECT [TVMS].[dbo].[Paragraph].[Код параграфа],[TVMS].[dbo].[Test_Set].[Код набора] FROM [TVMS].[dbo].[Paragraph],[TVMS].[dbo].[Test_Set] WHERE [TVMS].[dbo].[Paragraph].[Код параграфа]='" + masspar[i] + "'AND [TVMS].[dbo].[Test_Set].[Название]='" + textBox2.Text + "'", Autorization.myConnection);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    for (i = 0; i < 4; i++)
                    {
                        if (mass[i] != 0)
                        {
                            SqlCommand cmd2 = new SqlCommand("INSERT INTO [TVMS].[dbo].[mod_set]([Код модуля],[Код набора]) SELECT [TVMS].[dbo].[Modul].[Код модуля],[TVMS].[dbo].[Test_Set].[Код набора] FROM [TVMS].[dbo].[Modul],[TVMS].[dbo].[Test_Set] WHERE [TVMS].[dbo].[Modul].[Код модуля]='" + mass[i] + "'AND [TVMS].[dbo].[Test_Set].[Название]='" + textBox2.Text + "'", Autorization.myConnection);
                            cmd2.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Тестовый набор успешно добавлен", "Добавление набора", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                    Menu m = new Menu();
                    m.Show();
                }
                else MessageBox.Show("Ошибка добавления данных,убедитесь,что все поля заполнены", "Добавление набора", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Ошибка добавления данных,убедитесь,что все поля заполнены", "Добавление набора", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //выбор параграфов
        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox2.GetItemChecked(checkedListBox2.SelectedIndex) == true)
                masspar[checkedListBox2.SelectedIndex] = 0;
            else
            {
                SqlCommand cmd1 = new SqlCommand("SELECT [Код параграфа] FROM [TVMS].[dbo].[Paragraph] WHERE [Название]='" + checkedListBox2.SelectedItem.ToString() + "'", Autorization.myConnection);
                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    masspar[Convert.ToInt32(reader["Код параграфа"]) - 1] = Convert.ToInt32(reader["Код параграфа"]);
                }
                reader.Close();
            }
        }
        //выход из программы к авторизации
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }
        //переход к основному меню программы
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu m = new Menu();
            m.Show();
        }
        //переход к форме "О программе"
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        //Переход к Справочной информации по программе
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }
    }
}
