//Данный модуль предназначен для запуска программы
//Исполнитель: Казарян Миран Размикович
//Дипломная работа
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TV_and_MS
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Autorization());
           // Application.Run(new Menu());
        }
    }
    static class data
    {
        public static string login = "%";
        public static string pass = "%";
        public static string value = "%";
        public static string qwe;
        public static string date_time;
    }

}
