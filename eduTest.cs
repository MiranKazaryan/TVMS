//Данный модуль предназначен для генерации обучающего тестирования
//Исполнитель: Казарян Миран Размикович
//Дипломная работа 
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace TV_and_MS
{

   
    
    public partial class eduTest : Form
    {
        SqlDataReader reader;
        int id_task;
        //char zamena;
        //Parser p = new Parser();
        //ExpressionParser parser = new ExpressionParser();
        string task;
        int rad_i;
        double x;
        int repeat;
        int pars = 0;//если задание решается еще раз
        //int minT, maxT;
        int i = 0;
        int par = 0;
        int id = 0;
        //int repeat = 0;//количество попыток вытащить задание
        int[] mass = new int[4];
        int[] masspar = new int[31];
        List<int> partask = new List<int>();
        List<int> idtask = new List<int>();
        int generate = 0;
        string TYPE;//ТИП ТЗ

        public eduTest()
        {
            InitializeComponent();
        }

        // Какой р/батон выбран из вариантов ответа
        private Control rad_but()
        {
            foreach (Control item in groupBox1.Controls)
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

        //узнаем какой уровень сложности выбра
        private int rad_but1()
        {
            // Какой р/батон выбран
            foreach (Control item in groupBox3.Controls)
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

        //функция формирование тестового задания
        private void testquest()
        {
            button1.Enabled = true;
            task = "";
            Random r = new Random();
            int rand = r.Next(0, 3);
            //repeat = 0;
            generate = 0;
            i = 0;
            groupBox2.Visible = false;
            label14.Visible = false;
            textBox5.Visible = false;
            label15.Visible = false;
            textBox6.Visible = false;
            do
            {
                try
                {
                    //int counter = 0;
                    par = partask.Count;
                    par = r.Next(0, par);
                    
                    //если сгенерировался параграф из второго модуля, по параграфам плотности,фунцкии распределения или числовым характеристикам , то воспользуемся автогенерацией
                    if (partask[par] > 10 && partask[par] <= 13)
                    {
                        generate = 1;
                        //int setgen = r.Next(0, 3);
                        //if (setgen == 0)
                        //{
                            Generators.density1.Instance.obnul();
                            //узнаем сложность, если сложность 1 то
                            webBrowser1.DocumentText = Generators.density1.Instance.task(Convert.ToInt32(rad_but1()));
                            if (Convert.ToInt32(rad_but1()) == 1)
                            {
                                if (Generators.density1.Instance.x1 == 0)
                                {
                                    webBrowser1.DocumentText = Generators.density1.Instance.task(Convert.ToInt32(rad_but1()));
                                    //groupBox4.Visible = true;
                                    
                                    //textBox1.Visible = false;
                                }
                                else
                                {
                                    groupBox4.Visible = false;
                                    textBox1.Visible = true;
                                }
                                webBrowser1.Visible = true;
                                label2.Text = "Ответ";
                                groupBox1.Visible = false;
                                radioButton1.Visible = false;
                                radioButton2.Visible = false;
                                radioButton3.Visible = false;
                                radioButton4.Visible = false;
                                //repeat = 0;
                                task = webBrowser1.DocumentText;
                            }
                            //при уровне сложности 2
                            if (Convert.ToInt32(rad_but1()) == 2)
                            {
                                if (Generators.density1.Instance.x1 == 0)
                                {
                                    webBrowser1.DocumentText = Generators.density1.Instance.task(Convert.ToInt32(rad_but1()));
                                    //groupBox4.Visible = true;
                                    //textBox1.Visible = false;
                                }
                                else
                                {
                                    groupBox4.Visible = false;
                                    textBox1.Visible = true;
                                }
                                webBrowser1.Visible = true;
                                //поработать над локацией label2.Text , textbox5,groupbox4
                                label2.Text = "Ответ на первое задание";
                                //label2.Location = new Point(182,348);
                                textBox1.Location = new Point(294, 461);
                                label14.Visible = true;
                                textBox5.Visible = true;
                                groupBox1.Visible = false;
                                radioButton1.Visible = false;
                                radioButton2.Visible = false;
                                radioButton3.Visible = false;
                                radioButton4.Visible = false;
                                //repeat = 0;
                                task = webBrowser1.DocumentText;
                            }
                            //при уровне сложности 3
                            if (Convert.ToInt32(rad_but1()) == 3)
                            {
                                if (Generators.density1.Instance.x1 == 0)
                                {
                                    webBrowser1.DocumentText = Generators.density1.Instance.task(Convert.ToInt32(rad_but1()));
                                    //groupBox4.Visible = true;
                                    //textBox1.Visible = false;
                                }
                                else
                                {
                                    groupBox4.Visible = false;
                                    textBox1.Visible = true;
                                }
                                webBrowser1.Visible = true;
                                label2.Text = "Ответ на первое задание";
                                textBox1.Location = new Point(294, 461);
                                label14.Visible = true;
                                textBox5.Visible = true;
                                label15.Visible = true;
                                textBox6.Visible = true;
                                groupBox1.Visible = false;
                                radioButton1.Visible = false;
                                radioButton2.Visible = false;
                                radioButton3.Visible = false;
                                radioButton4.Visible = false;
                                //repeat = 0;
                                task = webBrowser1.DocumentText;
                            }
                        //}
                    }


                        //если сгенерировался параграф не из второго модуля, по параграфам плотности,фунцкии распределения или числовым характеристикам 
                    else
                    {
                        idtask.Clear();
                        repeat++;
                        //генерируем задание
                        //do
                        //{
                        // try
                        //{
                        //counter++;
                        par = partask.Count;
                        par = r.Next(0, par);
                        //сделать генерацию заданий при вызове формы по параметрам, далее из них уже генерировать задания
                        //заполнить в базе задания по каждому параграфу из первых двух модулей
                        //запретить удаление из базы последнего задания по параграфу.
                        SqlCommand cod_id = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[in_par].[Код задания]=[TVMS].[dbo].[Task].[Код задания] AND [TVMS].[dbo].[in_par].[Код параграфа] ='" + partask[par] + "' AND [TVMS].[dbo].[Task].[Уровень сложности]='" + Convert.ToInt32(rad_but1()) + "'", Autorization.myConnection);
                        reader = cod_id.ExecuteReader();
                       /* while (reader.Read() == false || repeat < 100)
                        {
                            par = r.Next(0, partask.Count);
                            SqlCommand id = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Task].[Код задания] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[in_par].[Код задания]=[TVMS].[dbo].[Task].[Код задания] AND [TVMS].[dbo].[in_par].[Код параграфа] ='" + partask[par] + "' AND [TVMS].[dbo].[Task].[Уровень сложности]='" + Convert.ToInt32(rad_but1()) + "'", Autorization.myConnection);
                            reader = id.ExecuteReader();
                            repeat++;
                            if (repeat >= 100)
                                idtask.Clear();
                        }*/
                        while (reader.Read())
                        {
                            idtask.Add(Convert.ToInt32(reader["Код задания"]));
                        }
                        reader.Close();
                        //if (counter > 100)
                        // {

                        // }
                        // }
                        // catch
                        // {
                        // }
                        //}
                        // while (idtask.Count == 0);
                        // id = idtask.Count;
                        //id_task = r.Next(0, id);


                        //если заданий по выбранным параметрам нет
                     if (repeat==100)
                        {
                            this.Close();
                            //MessageBox.Show("Проверьте введенный e-mail ", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("В базе нет заданий удовлетворяющих выбранным параметрам, или же в базе нету новых заданий этого вида, выберите иные параметры.","Выберите иные параметры" ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                            task = "exit";
                            eduTest ed = new eduTest();
                            ed.Show();
                        }
                        //если по выбранным параметрам есть задания
                        else
                        {
                            id = idtask.Count;
                            id_task = r.Next(0, id);
                            //SqlCommand questioncmd = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Task].[Вопрос],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[Task].[Код задания]=" + id_task + "AND [TVMS].[dbo].[Task].[Уровень сложности]=" + Convert.ToInt32(rad_but1()) + "AND [TVMS].[dbo].[in_par].[Код параграфа]='" + partask[par] + "'", Autorization.myConnection);
                            SqlCommand questioncmd = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Task].[Вопрос],[TVMS].[dbo].[Task].[Тип ТЗ] FROM [TVMS].[dbo].[Task],[TVMS].[dbo].[in_par] WHERE [TVMS].[dbo].[Task].[Код задания]=" + idtask[id_task] + " AND TVMS.dbo.Task.[Код задания]=TVMS.dbo.in_par.[Код задания] AND [TVMS].[dbo].[Task].[Уровень сложности]=" + Convert.ToInt32(rad_but1()) + " AND TVMS.dbo.in_par.[Код параграфа]='" + partask[par] + "'", Autorization.myConnection);
                            reader = questioncmd.ExecuteReader();
                            reader.Read();
                            task = reader["Вопрос"].ToString();
                            TYPE = reader["Тип ТЗ"].ToString();
                            reader.Close();
                            //если задания первого типа
                            if (TYPE == "1")
                            {
                                label2.Text = "Ответ";
                                textBox1.Visible = true;
                                groupBox1.Visible = false;
                                groupBox4.Visible = false;
                                radioButton1.Visible = false;
                                radioButton2.Visible = false;
                                radioButton3.Visible = false;
                                radioButton4.Visible = false;
                            }
                            //если задания второго типа
                            if (TYPE == "2")
                            {
                                textBox1.Visible = false;
                                label2.Text = "Выберите один из вариантов";
                                groupBox1.Visible = true;
                                groupBox4.Visible = false;
                                radioButton1.Visible = true;
                                radioButton2.Visible = true;
                                radioButton3.Visible = true;
                                radioButton4.Visible = true;
                                //выдача 4 вариантов ответа к тестовому заданию
                                rad_i = 1;
                                SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + idtask[id_task], Autorization.myConnection);
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
                            webBrowser1.DocumentText = task;
                            i++;
                        }
                    }
                }

                catch
                {
                    //if (reader.Read() == true)
                        reader.Close();
                    //else { }
                    
                }
            }
            while (task == "");
        }

        //при загрузке формы
        private void eduTest_Load(object sender, EventArgs e)
        {
            label8.Text = "";
            //вывод служебной инфо 
            SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Имя],[Фамилия],[Вид пользователя] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
            reader = name_surnamecmd.ExecuteReader();
            reader.Read();
            label6.Text = reader["Имя"].ToString().Trim();
            label7.Text = reader["Фамилия"].ToString().Trim();
            label4.Text = reader["Вид пользователя"].ToString().Trim();
            reader.Close();
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            //запрос на названия модулей
            SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT [Код модуля],[Название] FROM [TVMS].[dbo].[Modul]", Autorization.myConnection);
            reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                checkedListBox1.Items.Add(reader["Название"]);
            }
            reader.Close();
            //запрос на названия параграфов
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [Название] FROM [TVMS].[dbo].[Paragraph] ", Autorization.myConnection);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                checkedListBox2.Items.Add(reader["Название"]);
            }
            reader.Close();
            textBox1.Enabled = true;
        }

        //проверка ответа на задание
        private void button1_Click(object sender, EventArgs e)
        {
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
            //math.round(ответ,3)
            string ans;
            double answer;
            #region
            if (generate == 0)
            {
                /*SqlCommand name_surnamecmd = new SqlCommand("SELECT DISTINCT [Код студента] FROM [TVMS].[dbo].[Service] where [Логин] = '" + data.login + "'", Autorization.myConnection);
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
                //math.round(ответ,3)
                string ans;
                double answer;*/
                
                if (TYPE == "1")
                {
                    SqlCommand responsecmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + idtask[id_task], Autorization.myConnection);
                    //в зависимости от типа задания выдаются элементы управления
                    reader = responsecmd.ExecuteReader();
                    reader.Read();
                    ans = reader["Ответ"].ToString();
                    reader.Close();
                    answer = Math.Round(Convert.ToDouble(ans), 3);
                    if (textBox1.Text == Convert.ToString(answer))
                    {
                        
                        // Display the date in the default (general) format.

                        // Display the date in a variety of formats.
                       // (thisDay.ToString("d"));//5/3/2012
                        SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        updstat.ExecuteNonQuery();
                        MessageBox.Show("Задание решено верно", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("great");
                        textBox1.Enabled = false;
                        button1.Enabled = false;
                    }
                    else
                    {
                        SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        updstat.ExecuteNonQuery();
                        MessageBox.Show("Задание решено неверно, попробуйте решить его еще раз или перейдите к новому заданию", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("mistake");
                    }
                    //reader.Close();
                }
                if (TYPE == "2")
                {
                    SqlCommand rightcmd = new SqlCommand("SELECT DISTINCT [Ответ] FROM [TVMS].[dbo].[Answers] WHERE [Код задания]=" + idtask[id_task] + "AND [Правильность]='" + 1 + "'", Autorization.myConnection);
                    reader = rightcmd.ExecuteReader();
                    reader.Read();
                    ans = reader["Ответ"].ToString();
                    reader.Close();
                    if (rad_but().Text == ans)
                    {
                        SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        updstat.ExecuteNonQuery();
                        MessageBox.Show("Задание решено верно", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Enabled = false;
                    }
                    else
                    {
                        SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        updstat.ExecuteNonQuery();
                        MessageBox.Show("Задание решено неверно, попробуйте решить его еще раз или перейдите к новому заданию", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            #endregion
            else
            {
               int difzad=Convert.ToInt32(rad_but1());
                if (difzad == 1)
                {
                    //если задание на нахождение функции распределения воспользуемся алгоритмом поточечного сравнения функций
                   /* if (Generators.density1.Instance.x1 == 0)
                    {
                        try
                        {
                            pars++;
                            double result;
                            x = Generators.density1.Instance.alpha;
                            //zamena = Convert.ToChar(x.ToString());
                            //str = Convert.ToString(x).Substring(0, 1);
                            //if (str=="-")
                            if (textBox4.Text == "")
                                data.qwe = (textBox2.Text + label12.Text + textBox3.Text).Trim();
                            else
                                data.qwe = (textBox2.Text + label12.Text + textBox3.Text + label13.Text + textBox4.Text).Trim();
                            //data.qwe = textBox1.Text.Trim();


                            //  string str = "aabccdeefgghiijkklmm";
                            string pattern = "[x]";
                            string replacement = x.ToString();
                            if (x < 0)
                                replacement = "(" + x.ToString() + ")";
                            Regex rgx = new Regex(pattern);

                            data.qwe = rgx.Replace(data.qwe, replacement);
                            MathParser.Parser p = new MathParser.Parser();
                            p.Evaluate(data.qwe);
                            result = Math.Round(p.Result, 3);
                            double genans = Math.Abs(Generators.density1.Instance.answer1(x));
                            double usans = Math.Abs(result);
                            //webBrowser1.DocumentText += Generators.density1.Instance.ans(Convert.ToInt32(rad_but1()));
                            //while (x < Math.Abs(Generators.density1.Instance.beta))
                            while (x < (Generators.density1.Instance.beta))
                            {
                                if (Math.Abs(genans - usans) < 0.05)
                                {
                                    x += 0.5;
                                    data.qwe = (textBox2.Text + label12.Text + textBox3.Text + label13.Text + textBox4.Text).Trim();
                                    // data.qwe = textBox1.Text.Trim();
                                    replacement = x.ToString();
                                    if (x < 0)
                                        replacement = "(" + x.ToString() + ")";
                                    data.qwe = rgx.Replace(data.qwe, replacement);
                                    //data.qwe = data.qwe.Replace('x', zamena);
                                    p.Evaluate(data.qwe);
                                    result = Math.Round(p.Result, 3);
                                    genans = Math.Abs(Generators.density1.Instance.answer1(x));
                                    usans = Math.Abs(result);
                                    if (x == Generators.density1.Instance.beta)
                                        MessageBox.Show("great");
                                }
                                else
                                {
                                    MessageBox.Show("mistake");
                                    x = Math.Abs(Generators.density1.Instance.beta);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("проверьте правильность ввода");
                        }
                        // }
                        //else MessageBox.Show("Проверьте правильность ввода");
                        //добавляем ошибку в задание
                    }
                    else
                    {*/
                        if (textBox1.Text == Generators.density1.Instance.ans(difzad))
                        {
                            //SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            //updstat.ExecuteNonQuery();
                            SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            updstat.ExecuteNonQuery();
                            textBox1.Enabled = false;
                            button1.Enabled = false;
                            MessageBox.Show("Задание решено верно", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Enabled = false;
                        }
                        else
                        {
                            //SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            //updstat.ExecuteNonQuery();
                            SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            updstat.ExecuteNonQuery();
                            MessageBox.Show("Задание решено неверно, попробуйте решить его еще раз или перейдите к новому заданию", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    //}
                }
                
                //при уровне сложности 2
                if (Convert.ToInt32(rad_but1()) == 2)
                {
                    string t1, t2, t3;
                    t3 = Generators.density1.Instance.ans(difzad);
                    t1 = Generators.density1.Instance.ans(difzad).Substring(0, Generators.density1.Instance.ans(difzad).LastIndexOf(";"));
                    t2 = Generators.density1.Instance.ans(difzad).Substring(Generators.density1.Instance.ans(difzad).IndexOf(";") + 1);
                   // string str = @"4145223 102596 102F6154 FB25EAF5 lirrium\x\wx_gg_03.dat";
                    //string result = Generators.density1.Instance.ans(difzad).Substring(Generators.density1.Instance.ans(difzad).IndexOf(";", 0));
                    //если задание на нахождение функции распределения воспользуемся алгоритмом поточечного сравнения функций
                    /*if (Generators.density1.Instance.x1 == 0 && textBox5.Text == t2)
                    {
                        try
                        {
                            pars++;
                            double result;
                            x = Generators.density1.Instance.alpha;
                            //zamena = Convert.ToChar(x.ToString());
                            //str = Convert.ToString(x).Substring(0, 1);
                            //if (str=="-")
                            if (textBox4.Text == "")
                                data.qwe = (textBox2.Text + label12.Text + textBox3.Text + label13.Text).Trim();
                            else
                                data.qwe = (textBox2.Text + label12.Text + textBox3.Text + label13.Text + textBox4.Text).Trim();
                            //data.qwe = textBox1.Text.Trim();


                            //  string str = "aabccdeefgghiijkklmm";
                            string pattern = "[x]";
                            string replacement = x.ToString();
                            //if (x < 0)
                                replacement = "(" + x.ToString() + ")";
                            Regex rgx = new Regex(pattern);

                            data.qwe = rgx.Replace(data.qwe, replacement);
                            MathParser.Parser p = new MathParser.Parser();
                            p.Evaluate(data.qwe);
                            result = Math.Round(p.Result, 3);
                            double genans = Math.Abs(Generators.density1.Instance.answer1(x));
                            double usans = Math.Abs(result);
                            //webBrowser1.DocumentText += Generators.density1.Instance.ans(Convert.ToInt32(rad_but1()));
                            //while (x < Math.Abs(Generators.density1.Instance.beta))
                            while (x < (Generators.density1.Instance.beta))
                            {
                                if (Math.Abs(genans - usans) < 0.05)
                                {
                                    x += 0.5;
                                    data.qwe = (textBox2.Text + label12.Text + textBox3.Text + label13.Text + textBox4.Text).Trim();
                                    // data.qwe = textBox1.Text.Trim();
                                    replacement = x.ToString();
                                    //if (x < 0)
                                        replacement = "(" + x.ToString() + ")";
                                    data.qwe = rgx.Replace(data.qwe, replacement);
                                    //data.qwe = data.qwe.Replace('x', zamena);
                                    p.Evaluate(data.qwe);
                                    result = Math.Round(p.Result, 3);
                                    genans = Math.Abs(Generators.density1.Instance.answer1(x));
                                    usans = Math.Abs(result);
                                    if (x == Generators.density1.Instance.beta)
                                        MessageBox.Show("great");
                                }
                                else
                                {
                                    MessageBox.Show("mistake");
                                    x = Math.Abs(Generators.density1.Instance.beta);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("проверьте правильность ввода");
                        }
                        // }
                        //else MessageBox.Show("Проверьте правильность ввода");
                        //добавляем ошибку в задание
                    }
                    else
                    {
                      */ 
                        if (textBox1.Text == t1 && textBox5.Text == t2)
                        {
                            //SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            //updstat.ExecuteNonQuery();
                            SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            updstat.ExecuteNonQuery();
                            textBox1.Enabled = false;
                            button1.Enabled = false;
                            MessageBox.Show("Задание решено верно", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Enabled = false;
                            textBox5.Enabled = false;

                        }
                        else
                        {
                            //SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            //updstat.ExecuteNonQuery();
                            SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                            updstat.ExecuteNonQuery();
                            MessageBox.Show("Задание решено неверно, попробуйте решить его еще раз или перейдите к новому заданию", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    //}

                }
                //при уровне сложности 3
                if (difzad == 3)
                {
                    string t1, t2, t3;
                    t3 = Generators.density1.Instance.ans(difzad);
                    t1 =Generators.density1.Instance.ans(difzad).Substring(0,Generators.density1.Instance.ans(difzad).Substring(0, Generators.density1.Instance.ans(difzad).LastIndexOf(";")).LastIndexOf(";"));
                    t2 =Generators.density1.Instance.ans(difzad).Substring(Generators.density1.Instance.ans(difzad).IndexOf(";") + 1);
                    t3 = t2.Substring(t2.IndexOf(";") + 1);
                    t2=t2.Substring(0,t2.LastIndexOf(";"));
                    
                    if (textBox1.Text == t1 && textBox5.Text == t2 && textBox6.Text==t3)
                    {
                        //SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        //updstat.ExecuteNonQuery();
                        SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        updstat.ExecuteNonQuery();
                        textBox1.Enabled = false;
                        button1.Enabled = false;
                        MessageBox.Show("Задание решено верно", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Enabled = false;
                        textBox5.Enabled = false;
                        textBox6.Enabled = false;
                    }
                    else
                    {
                        //SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET[TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks) / (double)(tasks + 1)) * 100), 0) + "WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        //updstat.ExecuteNonQuery();
                        SqlCommand updstat = new SqlCommand("UPDATE [TVMS].[dbo].[Statistics] SET [TVMS].[dbo].[Statistics].[Всего заданий]=" + (tasks + 1) + ",[TVMS].[dbo].[Statistics].[Верных заданий]=" + (truetasks + 1) + ",[TVMS].[dbo].[Statistics].[Процент правильных]=" + Math.Round((((double)(truetasks + 1) / (double)(tasks + 1)) * 100), 0) + ",[TVMS].[dbo].[Statistics].[Последняя работа]='" + (thisDay.ToString("d")) + "' WHERE [Код студента]=" + id + "", Autorization.myConnection);
                        updstat.ExecuteNonQuery();
                        MessageBox.Show("Задание решено неверно, попробуйте решить его еще раз или перейдите к новому заданию", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        //генерация нового задания
        private void button9_Click(object sender, EventArgs e)
        {
            testquest();
            textBox1.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox1.Text = "Введите ответ с точностью до 0.001";
        }
     
        //выделение текста при нажатии на textbox
        private void textBox1_Click(object sender, EventArgs e)
        {
            TextBox s = (TextBox)sender;
            s.SelectAll();
            //textBox1.SelectAll();
        }

        //приступить к тестированию по заданным параметрам
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox2.CheckedIndices.Count != 0 && rad_but1() != -1)
            {

                //добавление параграфов заданий в список, из которого надо будет генерировать задания    
                for (i = 0; i < 31; i++)
                {
                    if (masspar[i] != 0)
                        partask.Add(masspar[i]);
                }
                par = partask.Count;
                if (rad_but1() == -1 || par == 0)
                    MessageBox.Show("Выберите все параметры тестирования", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    testquest();
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    label8.Text = "Задания тестового набора (уровень сложности -" + Convert.ToInt32(rad_but1()) + ")";
                }
            }
            else
            {
                MessageBox.Show("Выберите все параметры тестирования", "Обучающее тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //выборка модулей, для определения параметров тестирования 
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
            }
            //вывод параграфов
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


        //выборка параграфов, для определения параметров тестирования 
        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox2.GetItemChecked(checkedListBox2.SelectedIndex) == true)
            { 
                //masspar[checkedListBox2.SelectedIndex] = 0; 
                SqlCommand cmd1 = new SqlCommand("SELECT [Код параграфа] FROM [TVMS].[dbo].[Paragraph] WHERE [Название]='" + checkedListBox2.SelectedItem.ToString() + "'", Autorization.myConnection);
                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    masspar[Convert.ToInt32(reader["Код параграфа"]) - 1] = 0;
                }
                reader.Close();
            }
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

        //ввод в поле ответов только десятичных чисел через запятую
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Generators.density1.Instance.x1 == 0 && generate == 1)
            {
                // Если это не цифра.
                if (textBox2.Focused == true)
                {
                    if (!Char.IsDigit(e.KeyChar))
                    {
                        // Запрет на ввод более одной десятичной точки.
                        if ((e.KeyChar != '-' || textBox2.Text.IndexOf("-") != -1) && (e.KeyChar != ',' || textBox2.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                        {
                            e.Handled = true;
                        }
                    }
                }
                if (textBox3.Focused == true)
                {
                    if (!Char.IsDigit(e.KeyChar))
                    {
                        // Запрет на ввод более одной десятичной точки.
                        if ((e.KeyChar != '-' || textBox3.Text.IndexOf("-") != -1) && (e.KeyChar != ',' || textBox3.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                        {
                            e.Handled = true;
                        }
                    }
                }
                if (textBox4.Focused == true)
                {
                    if (!Char.IsDigit(e.KeyChar))
                    {
                        // Запрет на ввод более одной десятичной точки.
                        if ((e.KeyChar != '-' || textBox4.Text.IndexOf("-") != -1) && (e.KeyChar != ',' || textBox4.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            else
            {
                // Если это не цифра.
                if (!Char.IsDigit(e.KeyChar))
                {
                    // Запрет на ввод более одной десятичной точки.
                    if ((e.KeyChar != ',' || textBox1.Text.IndexOf(",") != -1) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        //вывод вкладки о программе
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
        
        //выход из системы
        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Autorization auth = new Autorization();
            auth.Show();
        }
        
        //задаем иные параметры для тестирования
        private void другиеПараметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            eduTest et = new eduTest();
            et.Show();
        }
        
        //ограничение на ввод
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox s = (TextBox)sender;
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
        }
        
        //открываем статистику
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Statistic stat = new Statistic();
            stat.Show();
        }
        
        //открываем справку
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }
       
        //завершение тестирования
        private void завершениеТестированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Statistic stat = new Statistic();
            stat.Show();
        }
    }
}
