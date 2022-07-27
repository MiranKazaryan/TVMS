//Данный модуль предназначен для восстановления пароля
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
//E-mail using
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;

namespace TV_and_MS
{

    public partial class Recovery_pass : Form
    {
        SqlDataReader reader;
        public Recovery_pass()
        {
            InitializeComponent();
        }
        //отправляем пароль на введенную пользователем почту
        private void button1_Click(object sender, EventArgs e)
        {
            string email = "tv_ms@mail.ru";
            string password = "butterfly28";
            string toEmail = mailBox.Text;
            try
            {
                //Указываем SMTP сервер и авторизуемся.
                SmtpClient Smtp_Client = new SmtpClient("smtp.mail.ru", 25);
                Smtp_Client.Credentials = new NetworkCredential(email, password);
                //Выключаем или включаем SSL - (например для гугла должен быть включен).
                Smtp_Client.EnableSsl = true;
                //Приступаем к формированию самого письма
                MailMessage Message = new MailMessage();
                Message.From = new MailAddress(email);// от кого
                Message.To.Add(new MailAddress(toEmail));// кому
                Message.Subject = "Ваш забытый пароль";
                //пишем запрос , который вытаскивает из базы пароль от данной почты
                SqlCommand pas = new SqlCommand("SELECT DISTINCT [TVMS].[dbo].[Service].[Пароль] FROM [TVMS].[dbo].[Service] where [TVMS].[dbo].[Service].[e-mail] = '" + mailBox.Text + "'", Autorization.myConnection);
                reader = pas.ExecuteReader();
                reader.Read();
                Message.Body = "Ваш утерянный пароль: "+reader["Пароль"].ToString().Trim();
                reader.Close();
               // Message.Body = "Само сообщение";
                Smtp_Client.Send(Message);//непосредственно само отправление...
                MessageBox.Show("Пароль отправлен на вашу почту", "Восстановление пароля", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                if (mailBox.Text == "")
                    MessageBox.Show("Введите e-mail", "Восстановление пароля", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("Проверьте введенный e-mail или свое подключение к интернету", "Восстановление пароля", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void mailBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && l != '\b' && !Char.IsDigit(l) && l != '.' && l != '@')
            {
                e.Handled = true;
            }
        }
    }
}
