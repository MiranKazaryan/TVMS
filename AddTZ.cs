//Данный модуль предназначен для добавления нового тестового задания в базу данных
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

    public partial class AddTZ : Form
    {
        SqlDataReader reader;
        int i = 0;
        int[] mass = new int[4];
        int[] masspar = new int[31];
        int tasknumber;

        public AddTZ()
        {
            InitializeComponent();
        }
        
        //при загрузке формы
        private void AddTZ_Load(object sender, EventArgs e)
        {
            //вывод служебной инфо 
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label1.Text = reader["Имя"].ToString().Trim();
            label2.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();
            //модули и параграфы
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

            label11.Visible = false;
            groupBox3.Visible = false;
            AnstextBox.Visible = false;
        }
        
        //выбор теоретических модулей
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (i = 0; i < 4; i++)
                mass[i] = 0;
            var list = sender as CheckedListBox;
            if (e.NewValue == CheckState.Checked)
                foreach (int index in list.CheckedIndices)
                    if (index != e.Index)
                        list.SetItemChecked(index, false);

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

        //выбор теоретических параграфов
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

       
        //добавление тестового задания
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (taskTextBox.Text != "")
                {
                    if (radioButton1.Checked == true && AnstextBox.Text == "")
                        MessageBox.Show("Заполните все поля");
                    if (radioButton2.Checked == true && (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""))
                        MessageBox.Show("Заполните все поля");
                    if (radioButton1.Checked == true && AnstextBox.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [TVMS].[dbo].[Task] ([Вопрос],[Уровень сложности],[Тип ТЗ]) VALUES (" + "'" + taskTextBox.Text + "'" + "," + "'" + Convert.ToInt32(rad_but1()) + "'" + "," + "'" + Convert.ToInt32(rad_but2()) + "')", Autorization.myConnection);
                        cmd.ExecuteNonQuery();

                        SqlCommand task = new SqlCommand("SELECT [TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + taskTextBox.Text + "'", Autorization.myConnection);
                        reader = task.ExecuteReader();
                        while (reader.Read())
                        {
                            tasknumber = Convert.ToInt32(reader["Код задания"]);
                        }
                        reader.Close();

                        SqlCommand cmd2 = new SqlCommand("INSERT INTO [TVMS].[dbo].[Answers] ([Ответ],[Правильность],[Код задания]) VALUES (" + "'" + AnstextBox.Text + "'" + ",'" + 1 + "','" + tasknumber + "')", Autorization.myConnection);
                        cmd2.ExecuteNonQuery();
                        for (i = 0; i < 31; i++)
                        {
                            if (masspar[i] != 0)
                            {
                                SqlCommand cmd1 = new SqlCommand("INSERT INTO [TVMS].[dbo].[in_par]([Код параграфа],[Код задания]) SELECT [TVMS].[dbo].[Paragraph].[Код параграфа],[TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Paragraph],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Paragraph].[Код параграфа]='" + masspar[i] + "'AND [TVMS].[dbo].[Task].[Вопрос]='" + taskTextBox.Text + "'", Autorization.myConnection);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Тестовое задание успешно добавлено", "Добавление тестового задания", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label11.Visible = false;
                        groupBox3.Visible = false;
                        AnstextBox.Visible = false;
                    }
                    else
                    {
                        // MessageBox.Show("Заполните все поля");
                    }

                    if (radioButton2.Checked == true && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO [TVMS].[dbo].[Task] ([Вопрос],[Уровень сложности],[Тип ТЗ]) VALUES (" + "'" + taskTextBox.Text + "'" + "," + "'" + Convert.ToInt32(rad_but1()) + "'" + "," + "'" + Convert.ToInt32(rad_but2()) + "')", Autorization.myConnection);
                        cmd.ExecuteNonQuery();

                        SqlCommand task = new SqlCommand("SELECT [TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + taskTextBox.Text + "'", Autorization.myConnection);
                        reader = task.ExecuteReader();
                        while (reader.Read())
                        {
                            tasknumber = Convert.ToInt32(reader["Код задания"]);
                        }
                        reader.Close();

                        SqlCommand cmd2 = new SqlCommand("INSERT INTO [TVMS].[dbo].[Answers] ([Ответ],[Правильность],[Код задания]) VALUES (" + "'" + textBox1.Text + "'" + ",'" + 0 + "','" + tasknumber + "')", Autorization.myConnection);
                        cmd2.ExecuteNonQuery();
                        SqlCommand cmd3 = new SqlCommand("INSERT INTO [TVMS].[dbo].[Answers] ([Ответ],[Правильность],[Код задания]) VALUES (" + "'" + textBox2.Text + "'" + ",'" + 0 + "','" + tasknumber + "')", Autorization.myConnection);
                        cmd3.ExecuteNonQuery();
                        SqlCommand cmd4 = new SqlCommand("INSERT INTO [TVMS].[dbo].[Answers] ([Ответ],[Правильность],[Код задания]) VALUES (" + "'" + textBox3.Text + "'" + ",'" + 0 + "','" + tasknumber + "')", Autorization.myConnection);
                        cmd4.ExecuteNonQuery();
                        SqlCommand right = new SqlCommand("INSERT INTO [TVMS].[dbo].[Answers] ([Ответ],[Правильность],[Код задания]) VALUES (" + "'" + textBox4.Text + "'" + ",'" + 1 + "','" + tasknumber + "')", Autorization.myConnection);
                        right.ExecuteNonQuery();
                        for (i = 0; i < 31; i++)
                        {
                            if (masspar[i] != 0)
                            {
                                SqlCommand cmd1 = new SqlCommand("INSERT INTO [TVMS].[dbo].[in_par]([Код параграфа],[Код задания]) SELECT [TVMS].[dbo].[Paragraph].[Код параграфа],[TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Paragraph],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Paragraph].[Код параграфа]='" + masspar[i] + "'AND [TVMS].[dbo].[Task].[Вопрос]='" + taskTextBox.Text + "'", Autorization.myConnection);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Тестовое задание успешно добавлено", "Добавление тестового задания", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label11.Visible = false;
                        groupBox3.Visible = false;
                        AnstextBox.Visible = false;
                        // this.Close();
                        //Menu m = new Menu();
                        // m.Show();
                    }
                    else
                    {
                        //MessageBox.Show("Заполните все поля");
                    }
                }
                else MessageBox.Show("Ошибка добавления данных,убедитесь,что все поля заполнены", "Добавление тестового задания", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                //удаление tasknumber
                SqlCommand del_task = new SqlCommand("DELETE FROM [TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                SqlCommand del_inpar = new SqlCommand("DELETE FROM [TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[in_par].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                SqlCommand del_ans = new SqlCommand("DELETE FROM [TVMS].[dbo].[Answers] WHERE [TVMS].[dbo].[Answers].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                SqlCommand del_dec = new SqlCommand("DELETE FROM [TVMS].[dbo].[Desicions] WHERE [TVMS].[dbo].[Desicions].[Код задания]='" + tasknumber + "'", Autorization.myConnection);
                del_inpar.ExecuteNonQuery();
                del_ans.ExecuteNonQuery();
                del_dec.ExecuteNonQuery();
                del_task.ExecuteNonQuery();
                MessageBox.Show("Ошибка добавления данных,убедитесь,что все поля заполнены", "Добавление тестового задания", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        //узнаем какой р/батон выбран для типа тз
        private int rad_but1()
        {
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

        // Какой р/батон выбран для сложности тз
        private int rad_but2()
        {
            
            foreach (Control item in groupBox2.Controls)
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

        //ограничение вводе в textbox
        private void AnstextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если это не цифра.
            if (!Char.IsDigit(e.KeyChar))
            {
                // Запрет на ввод более одной десятичной точки.
                if ((e.KeyChar != '.' || AnstextBox.Text.IndexOf(".") != -1) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }
        
        //если задание открытого типа
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                AnstextBox.Visible = true;
                label11.Text = "6.Ответ";
                groupBox3.Visible = false;
                label11.Visible = true;
                label11.Location = new Point(16, 603);
            }
        }
        
        //если задание закрытого типа
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                AnstextBox.Visible = false;
                label11.Text = "6.Введите 4 варианта ответа. Верный введите под 4 номером.";
                groupBox3.Visible = true;
                label11.Visible = true;
                label11.Location = new Point(16, 573);
            }
        }

        //выход к основному меню программы
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        //выход к авторизации в программном средстве
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }

        //открываем форму "О программе"
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        //ограничение вводе в textbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //item 
           // item.Focused
            //foreach (Control item in Controls)
           // {
            TextBox s=(TextBox)sender;
                    //Control item;
                    // Если это не цифра.
                    if (!Char.IsDigit(e.KeyChar))
                    {
                        // Запрет на ввод более одной десятичной точки.
                        if ((e.KeyChar != '.' || s.Text.IndexOf(".") != -1) && e.KeyChar != '\b')
                        {
                            e.Handled = true;
                        }
                    }
            //}
        }

        //открываем справку по программному средству
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }
    }
}
