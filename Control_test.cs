//Данный модуль предназначен для генерации контрольного тестирования из тестового набора
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

    public partial class Control_test : Form
    {
        SqlDataReader reader;
        int id_task1;
        int id = 0;
        //int minT, maxT;
        int  par, test_set,quest_task;
        string TYPE;//ТИП ТЗ
        string task1;
        int repeat=0;
        List<int> partask = new List<int>();
        List<int> idtask = new List<int>();
        //RichTextBox item;
        public Control_test()
        {
            InitializeComponent();
        }

        // Какой р/батон выбран в tabpage
        private Control rad_but(TabPage.ControlCollection t)
        {
            //foreach (Control item in tabPage1.Controls)
            foreach (Control item in t)
            {
                if (item is RadioButton)
                {
                    if (((RadioButton)item).Checked)
                    {
                        return item;
                    }
                }
            }
            return textBox1;
        }

        //функция формирование тестового задания
        private void testquest()
        {
            Random r = new Random();
            int i = 1;
            do
            {
                //добавление параграфов заданий в список, из которого надо будет генерировать задания    
                do
                {
                    try
                    {
                        id = idtask.Count;
                        par = partask.Count;
                        id_task1 = r.Next(0, id);
                        par = r.Next(0, par);
                        repeat++;
                        if (repeat > 200)
                        {
                            this.Close();
                            MessageBox.Show("В базе нет заданий удовлетворяющих выбранному тестовому набора, выберите другой тестовый набор.","Контрольное тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            task1 = "exit";
                            i = quest_task + 1;
                            Select_test ed = new Select_test();
                            ed.Show();
                        }
                        SqlCommand questioncmd = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Task].[Вопрос],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[Test_Set],[TVMS].[dbo].[par_set],[TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[Test_Set].[Название]='" + data.value + "' AND [TVMS].[dbo].[Task].[Код задания]='" + id_task1 + "' AND [TVMS].[dbo].[Task].[Уровень сложности]=[TVMS].[dbo].[Test_Set].[Сложность набора] AND TVMS.dbo.in_par.[Код параграфа]='" + partask[par] + "' AND TVMS.dbo.Task.[Код задания]=TVMS.dbo.in_par.[Код задания]", Autorization.myConnection);
                        reader = questioncmd.ExecuteReader();
                        reader.Read();
                        task1 = reader["Вопрос"].ToString();
                        TYPE = reader["Тип ТЗ"].ToString();
                        reader.Close();


                        switch (i)
                        {
                            case 1:
                                {
                                    webBrowser1.DocumentText = task1;
                                    //richTextBox1.Text = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox1.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton1.Visible = false;
                                        radioButton2.Visible = false;
                                        radioButton3.Visible = false;
                                        radioButton4.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox1.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton1.Visible = true;
                                        radioButton2.Visible = true;
                                        radioButton3.Visible = true;
                                        radioButton4.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton1.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton2.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton3.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton4.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }

                                    break;
                                }
                            case 2:
                                {
                                    webBrowser2.DocumentText = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox2.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton9.Visible = false;
                                        radioButton10.Visible = false;
                                        radioButton11.Visible = false;
                                        radioButton12.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox2.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton9.Visible = true;
                                        radioButton10.Visible = true;
                                        radioButton11.Visible = true;
                                        radioButton12.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton9.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton10.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton11.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton12.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    webBrowser3.DocumentText = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox3.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton13.Visible = false;
                                        radioButton14.Visible = false;
                                        radioButton15.Visible = false;
                                        radioButton16.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox3.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton13.Visible = true;
                                        radioButton14.Visible = true;
                                        radioButton15.Visible = true;
                                        radioButton16.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton13.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton14.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton15.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton16.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    webBrowser4.DocumentText = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox4.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton17.Visible = false;
                                        radioButton18.Visible = false;
                                        radioButton19.Visible = false;
                                        radioButton20.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox4.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton17.Visible = true;
                                        radioButton18.Visible = true;
                                        radioButton19.Visible = true;
                                        radioButton20.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton17.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton18.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton19.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton20.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    webBrowser5.DocumentText = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox5.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton21.Visible = false;
                                        radioButton22.Visible = false;
                                        radioButton23.Visible = false;
                                        radioButton24.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox5.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton21.Visible = true;
                                        radioButton22.Visible = true;
                                        radioButton23.Visible = true;
                                        radioButton24.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton21.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton22.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton23.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton24.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    webBrowser6.DocumentText = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox6.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton25.Visible = false;
                                        radioButton26.Visible = false;
                                        radioButton27.Visible = false;
                                        radioButton28.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox6.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton25.Visible = true;
                                        radioButton26.Visible = true;
                                        radioButton27.Visible = true;
                                        radioButton28.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton25.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton26.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton27.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton28.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }
                                    break;
                                }
                            case 7:
                                {
                                    webBrowser7.DocumentText = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox7.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton29.Visible = false;
                                        radioButton30.Visible = false;
                                        radioButton31.Visible = false;
                                        radioButton32.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox1.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton29.Visible = true;
                                        radioButton30.Visible = true;
                                        radioButton31.Visible = true;
                                        radioButton32.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton29.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton30.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton31.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton32.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }
                                    break;
                                }
                            case 8:
                                {
                                    webBrowser8.DocumentText = task1;
                                    if (TYPE == "1")
                                    {
                                        label2.Text = "Ответ";
                                        textBox8.Visible = true;
                                        //groupBox1.Visible = false;
                                        radioButton33.Visible = false;
                                        radioButton34.Visible = false;
                                        radioButton35.Visible = false;
                                        radioButton36.Visible = false;
                                    }
                                    if (TYPE == "2")
                                    {
                                        textBox8.Visible = false;
                                        label2.Text = "Выберите один из вариантов";

                                        radioButton33.Visible = true;
                                        radioButton34.Visible = true;
                                        radioButton35.Visible = true;
                                        radioButton36.Visible = true;
                                        //выдача 4 вариантов ответа к тестовому заданию
                                        int rad_i = 1;
                                        SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
                                        //в зависимости от типа задания выдаются элементы управления
                                        reader = responsecmd.ExecuteReader();
                                        while (reader.Read())
                                        {
                                            switch (rad_i)
                                            {
                                                case 1:
                                                    radioButton33.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 2:
                                                    radioButton34.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 3:
                                                    radioButton35.Text = reader["Ответ"].ToString();
                                                    break;
                                                case 4:
                                                    radioButton36.Text = reader["Ответ"].ToString();
                                                    break;

                                            }
                                            rad_i++;
                                        }
                                        reader.Close();
                                    }
                                    break;
                                }
                        }
                            i++;
                    }
                    catch
                    {
                        reader.Close();
                    }
                }
                while (task1 == null);
            }
            while (i != quest_task+1);
        }
       
        //при загрузке формы
        private void Control_test_Load(object sender, EventArgs e)
        {
            label8.Text = "";
            string testset = data.value;

            Random r = new Random();
            //выбор границ кода задания
           /* SqlCommand max = new SqlCommand("SELECT MAX ([TVMS].[dbo].[Task].[Код задания]) FROM [TVMS].[dbo].[Task]", Autorization.myConnection);
            SqlCommand min = new SqlCommand("SELECT MIN ([TVMS].[dbo].[Task].[Код задания]) FROM [TVMS].[dbo].[Task]", Autorization.myConnection);
            maxT = Convert.ToInt32(max.ExecuteScalar().ToString());
            minT = Convert.ToInt32(min.ExecuteScalar().ToString());
            */
            SqlCommand cod_id = new SqlCommand("SELECT DISTINCT[TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Task]", Autorization.myConnection);
            reader = cod_id.ExecuteReader();
            while (reader.Read())
            {
                idtask.Add(Convert.ToInt32(reader["Код задания"]));
            }
            reader.Close();
            //запросы тестовых заданий
            //ответ на первое задание
            SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
            //выводим служебную информацию на форму
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label7.Text = reader["Имя"].ToString().Trim();
            label6.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();

            //узнаем какой тестовый набор выбран
            SqlCommand cmdset = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Test_Set].[Код набора] FROM [TVMS].[dbo].[Test_Set] WHERE [TVMS].[dbo].[Test_Set].[Название]='" + data.value + "'", Autorization.myConnection);
            reader = cmdset.ExecuteReader();
            reader.Read();
            test_set = Convert.ToInt32(reader["Код набора"].ToString());
            reader.Close();
            SqlCommand difset = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Test_Set].[Сложность набора] FROM [TVMS].[dbo].[Test_Set] WHERE [TVMS].[dbo].[Test_Set].[Код набора]='" + test_set + "'", Autorization.myConnection);
            //узнаем количество заданий в тестовом наборе и определяем количество вкладок
            SqlCommand tasks = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Test_Set].[Заданий] FROM [TVMS].[dbo].[Test_Set] WHERE [TVMS].[dbo].[Test_Set].[Код набора]='" + test_set + "'", Autorization.myConnection);
            quest_task = Convert.ToInt32(tasks.ExecuteScalar().ToString());
            if (quest_task == 6)
            {
                tabControl1.TabPages.Remove(tabPage7);
                tabControl1.TabPages.Remove(tabPage8);
            }
            if(quest_task==7)
                tabControl1.TabPages.Remove(tabPage8);
            label8.Text = "Задания тестового набора (уровень сложности -" + Convert.ToInt32(difset.ExecuteScalar().ToString()) + ")";

            //узнаем из каких параграфов генерировать тестовый набор
            SqlCommand cmdpar = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Paragraph].[Код параграфа] FROM [TVMS].[dbo].[Paragraph],[TVMS].[dbo].[par_set] WHERE [TVMS].[dbo].[par_set].[Код набора]=" + test_set + " AND [TVMS].[dbo].[par_set].[Код параграфа]=[TVMS].[dbo].[Paragraph].[Код параграфа]", Autorization.myConnection);
            reader = cmdpar.ExecuteReader();
            while (reader.Read())
            {
                partask.Add(Convert.ToInt32(reader["Код параграфа"]));
            }
            reader.Close();
            testquest();
        }
        
        //служебная кнопка
        private void button10_Click(object sender, EventArgs e)
        {
            string ans;
            SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task1, Autorization.myConnection);
            //в зависимости от типа задания выдаются элементы управления
            reader = cmd9.ExecuteReader();
            reader.Read();
            ans = reader["Ответ"].ToString();
            //TYPE = reader["Тип ТЗ"].ToString();
            if (textBox1.Text == ans)
                MessageBox.Show("great");
            reader.Close();
        }
        
        //выделение текста из textbox
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
            textBox2.SelectAll();
            textBox3.SelectAll();
            textBox4.SelectAll();
            textBox5.SelectAll();
            textBox6.SelectAll();
            textBox7.SelectAll();
            textBox8.SelectAll();
        }
       
        //ограничени ввода ответа в textbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если это не цифра.
            if (!Char.IsDigit(e.KeyChar))
            {
                // Запрет на ввод более одной десятичной точки.
                if (textBox1.Focused)
                {
                    if ((e.KeyChar != ',' || textBox1.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                if (textBox2.Focused)
                {
                    if ((e.KeyChar != ',' || textBox2.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                if (textBox3.Focused)
                {
                    if ((e.KeyChar != ',' || textBox3.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                if (textBox4.Focused)
                {
                    if ((e.KeyChar != ',' || textBox4.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                if (textBox5.Focused)
                {
                    if ((e.KeyChar != ',' || textBox5.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                if (textBox6.Focused)
                {
                    if ((e.KeyChar != ',' || textBox6.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                if (textBox7.Focused)
                {
                    if ((e.KeyChar != ',' || textBox7.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                if (textBox8.Focused)
                {
                    if ((e.KeyChar != ',' || textBox8.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        //завершение тестирования
        private void button9_Click(object sender, EventArgs e)
        {
                    //tabControl1_Selecting(sender, e);
            DateTime thisDay = DateTime.Today;
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Код студента] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            int id = Convert.ToInt32(reader["Код студента"].ToString());
            reader.Close();
            SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Statistics].[Всего заданий],[TVMS].[dbo].[Statistics].[Верных заданий],[TVMS].[dbo].[Statistics].[Процент правильных] FROM [TVMS].[dbo].[Statistics] WHERE [TVMS].[dbo].[Statistics].[Код студента]=" + id + "", Autorization.myConnection);
            reader = cmd1.ExecuteReader();
            reader.Read();
            int tasks = Convert.ToInt32(reader["Всего заданий"].ToString());
            int truetasks = Convert.ToInt32(reader["Верных заданий"].ToString());
            //int percent = Convert.ToInt32(reader["Процент правильных"].ToString());
            reader.Close();
            string ans;
            double answer;
            int rightquest=0;
           /* richTextBox1.Text = task1;
            SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + richTextBox1.Text + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания]", Autorization.myConnection);
            //в зависимости от типа задания выдаются элементы управления
            reader = cmd9.ExecuteReader();
            reader.Read();
            ans = reader["Ответ"].ToString();
            //TYPE = reader["Тип ТЗ"].ToString();
            if (textBox1.Text == ans)
                MessageBox.Show("great");
            reader.Close();
            */
            for(int i=1;i<quest_task+1;i++)
            {
            switch (i)
            {
                case 1:
                    {
                        //richTextBox1.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser1.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox1.Text == Convert.ToString(answer))
                            {
                                rightquest++;
                                //tabPage1.BackColor = System.Drawing.Color.SeaGreen;
                                tabPage1.Text += "+";
                            }
                            else tabPage1.Text += "–";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage1.Text = "1 +";

                            }
                            else
                            {
                                tabPage1.Text = "1 –";

                            }

                        }

                        reader.Close();    
                        break;
                    }
                case 2:
                    {
                        //richTextBox2.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser2.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox2.Text == Convert.ToString(answer))
                            {
                                rightquest++;

                                tabPage2.Text = "2 +";
                            }
                            else tabPage2.Text = "2 –";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage2.Text = "2 +";

                            }
                            else
                            {
                                tabPage2.Text = "2 –";

                            }

                        }
                        reader.Close();
                        break;
                    }
                case 3:
                    {
                        //richTextBox3.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser3.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox3.Text == Convert.ToString(answer))
                            {
                                rightquest++;
                                tabPage3.Text = "3 +";
                            }
                            else tabPage3.Text = "3 –";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage3.Text = "3 +";

                            }
                            else
                            {
                                tabPage3.Text = "3 –";

                            }

                        }
                        reader.Close();
                        break;
                    }
                case 4:
                    {
                        //richTextBox4.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser4.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox4.Text == Convert.ToString(answer))
                            {
                                rightquest++;
                                tabPage4.Text = "4 +";
                            }
                            else tabPage4.Text = "4 –";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage4.Text = "4 +";

                            }
                            else
                            {
                                tabPage4.Text = "4 –";

                            }

                        }
                        reader.Close();
                        break;
                    }
                case 5:
                    {
                        //richTextBox5.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser5.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox5.Text == Convert.ToString(answer))
                            {
                                rightquest++;
                                tabPage5.Text = "5 +";
                            }
                            else tabPage5.Text = "5 –";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage5.Text = "5 +";

                            }
                            else
                            {
                                tabPage5.Text = "5 –";

                            }

                        }
                        reader.Close();
                        break;
                    }
                case 6:
                    {
                        //richTextBox6.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser6.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox6.Text == Convert.ToString(answer))
                            {
                                rightquest++;
                                tabPage6.Text = "6 +";
                            }
                            else tabPage6.Text = "6 –";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage6.Text = "6 +";

                            }
                            else
                            {
                                tabPage6.Text = "6 –";

                            }

                        }
                        reader.Close();
                        break;
                    }
                case 7:
                    {
                        //richTextBox7.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser7.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox7.Text == Convert.ToString(answer))
                            {
                                rightquest++;
                                tabPage7.Text = "7 +";
                            }
                            else tabPage7.Text = "7 –";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage7.Text = "7 +";

                            }
                            else
                            {
                                tabPage7.Text = "7 –";

                            }

                        }
                        reader.Close();
                        break;
                    }
                case 8:
                    {
                        //richTextBox8.Text = task1;
                        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Answers].[Ответ],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Answers],[TVMS].[dbo].[Task] WHERE [TVMS].[dbo].[Task].[Вопрос]='" + webBrowser8.DocumentText + "' AND [TVMS].[dbo].[Task].[Код задания]=[TVMS].[dbo].[Answers].[Код задания] AND [TVMS].[dbo].[Answers].[Правильность]='" + 1 + "'", Autorization.myConnection);
                        //в зависимости от типа задания выдаются элементы управления
                        reader = cmd9.ExecuteReader();
                        reader.Read();
                        ans = reader["Ответ"].ToString();
                        
                        TYPE = reader["Тип ТЗ"].ToString();
                        if (TYPE == "1")
                        {
                            answer = Math.Round(Convert.ToDouble(ans), 3);
                            if (textBox8.Text == Convert.ToString(answer))
                            {
                                rightquest++;
                                tabPage8.Text = "8 +";
                            }
                            else tabPage8.Text = "8 –";//tabPage1.BackColor = System.Drawing.Color.Red;
                        }
                        if (TYPE == "2")
                        {
                            if (rad_but(tabPage1.Controls).Text == ans)
                            {
                                rightquest++;
                                tabPage8.Text = "8 +";

                            }
                            else
                            {
                                tabPage8.Text = "8 –";

                            }

                        }
                        reader.Close();

                        break;
                    }
                    
            }
        }
            Ans_button.Enabled = false;
            SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + quest_task) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + rightquest) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + rightquest) / (double)(tasks + quest_task)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "',[TVMS].[dbo].[Statistics].[Код набора]='" + test_set + "' WHERE [TVMS].[dbo].[Statistics].[Код студента]='" + id + "'", Autorization.myConnection);
                      updstat.ExecuteNonQuery();
            MessageBox.Show("В ходе контрольного тестирования верно было решено " + rightquest.ToString() + " заданий,можете просмотреть их", "Контрольное тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //MessageBox.Show("В ходе контрольного тестирования верно было решено "+ rightquest.ToString() + " заданий");








            /*
SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Код студента] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            int id =Convert.ToInt32(reader["Код студента"].ToString());
            reader.Close();
            SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Statistics].[Всего заданий],[TVMS].[dbo].[Statistics].[Верных заданий],[TVMS].[dbo].[Statistics].[Процент правильных] FROM [TVMS].[dbo].[Statistics] WHERE [TVMS].[dbo].[Statistics].[Код студента]="+id+"", Autorization.myConnection);
            reader = cmd1.ExecuteReader();
            reader.Read();
            int tasks = Convert.ToInt32(reader["Всего заданий"].ToString());
            int truetasks = Convert.ToInt32(reader["Верных заданий"].ToString());
            //int percent = Convert.ToInt32(reader["Процент правильных"].ToString());
            reader.Close();
            //math.round(ответ,3)
            string ans;
            double answer;
            if (TYPE == "1")
            {
                SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task, Autorization.myConnection);
                //в зависимости от типа задания выдаются элементы управления
                reader = responsecmd.ExecuteReader();
                reader.Read();
                ans = reader["Ответ"].ToString();
                reader.Close();
                answer = Math.Round(Convert.ToDouble(ans), 3);
                if (textBox1.Text == Convert.ToString(answer))
                {
                    SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                    updstat.ExecuteNonQuery();
                    MessageBox.Show("great");
                    textBox1.Enabled = false;
                }
                else
                {
                    SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" +Math.Round((((double)(truetasks) / (double)(tasks + 1)) * 100),0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                    updstat.ExecuteNonQuery();
                    MessageBox.Show("mistake");
                }
                //reader.Close();
            }
            if (TYPE == "2")
            {
                SqlCommand rightcmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + id_task + "AND [Правильность]='" + 1 + "'", Autorization.myConnection);
                reader = rightcmd.ExecuteReader();
                reader.Read();
                ans = reader["Ответ"].ToString();
                reader.Close();
                if (rad_but().Text == ans)
                {
                    SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                    updstat.ExecuteNonQuery();
                    MessageBox.Show("great");
                }
                else
                {
                    SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                    updstat.ExecuteNonQuery();
                    MessageBox.Show("mistake");
                }
            }*/
        }
      
        //открываем вкладку "О программе"
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
        
        //возврат к основному меню программы
        private void основноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }
      
        //выход из системы
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }

        //Открываем вкладку статистика
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Statistic stat = new Statistic();
            stat.Show();
        }

        //Открываем вкладку справка
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        }

    }
