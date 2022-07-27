//Данный модуль представляет класс, который является базовым и генерирует промежутки, в которых существуют генерируемые задания
//Исполнитель: Казарян Миран Размикович
//Дипломная работа 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators
{

    public class base_density
    {
        public int alpha1, beta1;//вероятность попадания данного промежутка
        public int alpha, beta;//промежуток, на котором плотность не равна нулю
        public Random rnd = new Random();
        public int gr_rand = 10;
        public base_density()
        {
            alpha = rnd.Next(-gr_rand, gr_rand);
            beta = rnd.Next(-gr_rand + 1, gr_rand + 1);
            //ограничим альфа и бета, альфа всегда меньше бета и альфа не равна нулю
            while (alpha == 0)
                alpha = rnd.Next(-gr_rand, gr_rand);
            while (beta <= alpha)
                beta = rnd.Next(-gr_rand + 1, gr_rand + 1);
            do
            {
                alpha1 = rnd.Next(-gr_rand - 10, gr_rand + 10);
                beta1 = rnd.Next(-gr_rand - 9, gr_rand + 11);
            }
            while (!(((alpha1 < alpha) && (beta1 > alpha) && (beta1 < beta) && (alpha1 < beta1)) || ((alpha1 == alpha) && (beta1 == beta)) || ((alpha1 > alpha) && (alpha1 < beta) && (beta1 > alpha1) && (beta1 < beta)) || ((beta1 > beta) && (alpha1 > alpha) && (alpha1 < beta) && (alpha1 < beta1))));
        }
        //функция для НОД
        public int sokr_dr(int i, int j)
        {
            int a, b, c;
            a = Math.Abs(i);
            b = Math.Abs(j); ;
            while (a != b)
            {
                if (a >= b) a -= b;
                else b -= a;
            }
            if (a > b) c = a;
            else c = b;
            return (c);
        }
    }
}
