//Данный моудль представляет дочерний класс, генерирует задание по линейной плотности распределения
//Исполнитель: Казарян Миран Размикович
//Дипломная работа 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators
{

    public class density1:base_density
    {
        private static density1 instance;
        public double k1;
        public double k2;
        public double b1;
        public double b2;
        public double k;
        public double b;
        public int x1 = 0;
        public int x2 = 0;
        public int x3 = 0;
        public double P1, P2, P3, P4, Mx, Dx, sco;

        public density1():base() {
            this.alpha1 = alpha1;
            this.beta1 = beta1;
            this.alpha = alpha;
            this.beta = beta;
            this.rnd = rnd;
            this.gr_rand = gr_rand;
            //while (x1 == x2 || x1 == x3 || x3 == x2 )
            while (x1 == x2 || x1 == x3 || x3 == x2 || x2==0 ||x3 == 0)
            {
                x1 = rnd.Next(0, 5);
                x2 = rnd.Next(0, 5);
                x3 = rnd.Next(0, 5);
            }
            k1 = 2; 
            k2 = (Math.Pow((double)(beta - alpha), 2));
            b1 = -2 * alpha; 
            b2 = k2;
          //Расчет коэффициентов k,b для плотности распределения
           k = Math.Round((2 / (Math.Pow((double)(beta - alpha), 2))), 3);
           b = Math.Round(((-2 * alpha) / (Math.Pow((double)(beta - alpha), 2))), 3);

        }

        public static density1 Instance
         {
            get {
                if (instance == null)
                {
                    instance = new density1();
                }
                return instance;
            }
         }

        public void obnul()
        {
            instance = new density1();
        }

        //аргумент подаем, чтобы задать уровень сложности,генерируем задания по уровню сложности
        public string task(int i)
        {
            string Head = "<html xmlns:m='xmltemplates/pmathml.sxl'>" +
            "<font style = \"font-weight: normal;fons-size: 12pt; color: black; font-style: normal; font-family: 'Times NEw Roman'; font variatn: normal; text-decoration: none\">" +
            "<body><object id = 'math1' classid='clsid:32F66A20-7614-11D4-BD11-00104BD3F987'></object>" +
            "<?import namespace= 'm' implementation='#math1' ?>";
            string task = "<p>Функция <m:math display='inline'><m:mi>f</m:mi><m:mo>(</m:mo><m:mi>x</m:mi><m:mo>)</m:mo></m:math>";
            task += " является плотностью распределения вероятностей некоторой случайной величины <m:math display='inline'><m:mi>X</m:mi></m:math>.</p>";
            string task1 = "<br> <p> Восстановить функцию распределения <m:math display='inline'><m:mi>F</m:mi><m:mo>(</m:mo><m:mi>x</m:mi><m:mo>)</m:mo></m:math>";
            task1 += "этой СВ <m:math display='inline'><m:mi>X</m:mi></m:math>?</p>";
            string task2 = "<br><p>Вычислить вероятность попадания СВ <m:math display='inline'><m:mi>X</m:mi></m:math> в промежуток (" + alpha1 + ";" + beta1 + ")? </p>";
          //string task3 = "<br><p>3.Построить графики для плотности <m:math display='inline'><m:mi>f</m:mi><m:mo>(</m:mo><m:mi>x</m:mi><m:mo>)</m:mo></m:math> и функции распределения <m:math display='inline'><m:mi>F</m:mi><m:mo>(</m:mo><m:mi>x</m:mi><m:mo>)</m:mo></m:math> этой СВ <m:math display='inline'><m:mi>X</m:mi></m:math>.</p>";
            string task3 = "<br><p>Вычислить с.к.о. <m:math display='inline'><m:mi>&#963;</m:mi><m:mo>(</m:mo><m:mi>x</m:mi><m:mo>)</m:mo></m:math>? </p>";
            string task4 = "<br><p>Вычислить математическое ожидание <m:math display='inline'><m:mi>M</m:mi><m:mo>(</m:mo><m:mi>x</m:mi><m:mo>)</m:mo></m:math>? </p>";
            string task5 = "<br><p>Вычислить дисперсию <m:math display='inline'><m:mi>D</m:mi><m:mo>(</m:mo><m:mi>x</m:mi><m:mo>)</m:mo></m:math>? </p>";
            string s ="<m:math display='inline'>";
            //f(x)=
            s += "<m:mi>f</m:mi>";
            s += "<m:mo>(</m:mo>";
            s += "<m:mi>x</m:mi>";
            s += "<m:mo>)</m:mo>";
            s += "<m:mo>=</m:mo></m:math>";
            s += "<m:math display='inline'><m:mfenced open='{' close=''>";
            s += "<m:mtable columnalign='left'>";
            s += "<m:mtr>";
            s += "<m:mtd>";
            //находим наибольший общий делитель
           
            k1 = k1 / sokr_dr((int)k1, (int)k2);
            k2 = k2 / sokr_dr((int)k1, (int)k2);
            if (k2 == 1)
                s += "<m:mn>" + k1 + "</m:mn>";
            else
                s += "<m:mfrac><m:mn>" + k1 + "</m:mn><m:mn>" + k2 + "</m:mn></m:mfrac>";
            s += "<m:mi>x</m:mi>";
            b1 = b1 / sokr_dr((int)b1, (int)b2);
            b2 = b2 / sokr_dr((int)b1, (int)b2);
            if (b2 == 1)
            {
                if (b1 < 0)
                    s += "<m:mn>" + b1 + "</m:mn>";
                else s += "<m:mo>+</m:mo><m:mn>" + b1 + "</m:mn>";
            }
            else
                s += "<m:mo>+</m:mo><m:mfrac><m:mn>" + b1 + "</m:mn><m:mn>" + b2 + "</m:mn></m:mfrac>";
            s += "<m:mo>,</m:mo>";
            s += "<m:mi>x</m:mi>";
            s += "<m:mo>&#8712;</m:mo>";
            s += "<m:mo>(</m:mo>";
            s+="<m:mn>" + alpha + "</m:mn>";
            s += "<m:mo>;</m:mo>";
            s += "<m:mn>" + beta + "</m:mn>";
            s += "<m:mo>)</m:mo>";
            s += "</m:mtd>";
            s += "</m:mtr>";
            //0,x(a,b)
            s += " <m:mtr>";
            s += " <m:mtd>";
            s += " <m:mn>0</m:mn>";
            s += " <m:mo>,</m:mo>";
            s += "<m:mi>x</m:mi>";
            s += "<m:mo>&#8713;</m:mo>";
            s += "<m:mo>(</m:mo>";
            s += "<m:mn>" + alpha + "</m:mn>";
            s += "<m:mo>;</m:mo>";
            s += "<m:mn>" + beta + "</m:mn>";
            s += "<m:mo>)</m:mo>";
            s += "</m:mtd>";
            s += "</m:mtr>";
            s += "</m:mtable>";
            s += "</m:mfenced>";
            s += "</m:math>";

            //string[] MasTask= { Head, s ,task1,task2,task3,task4,task5};
            string[] MasTask = { task1, task2, task3, task4, task5, Head, s };
           // return (Head+s+task);
            if(i==1)
                return MasTask[5]+MasTask[6]+task+MasTask[x1];
            if (i == 2)
                return MasTask[5] + MasTask[6] + task  + MasTask[x1]  + MasTask[x2];
            if (i == 3)
                return MasTask[5] + MasTask[6] + task + MasTask[x1] +  MasTask[x2] + MasTask[x3];
            return MasTask[5] + MasTask[6] + task;
        }
        //функция распределения
        public double answer1(double x)
        {
            double ans1 = Math.Round(k / 2, 3);
            double ans2 = Math.Round(Math.Pow(x, 2), 3);
            double ans3 = Math.Round(b * x, 3);
            double ans4 = Math.Round(Math.Pow(alpha, 2), 3);
            double ans5 = Math.Round(b * alpha, 3);
            //double ans = (k / 2) * (Math.Pow(x, 2)) + b * x - (((k / 2) * Math.Pow(alpha, 2)) + b * alpha);
            double ans = Math.Round(ans1 * ans2 + ans3 - (ans1 * ans4 + ans5));
            return Math.Round(ans,3);
           // double ans = (k/2)*Math.Pow(x, 2)+b*x-((k*Math.Pow(alpha,2)/2)+b*alpha);
           //return ans;
            // return Math.Round(k1 / (2 * k2), 3) + Math.Pow(x, 2) + Math.Round(b1 / b2, 3) + x + Math.Round(((k1 * Math.Pow(alpha, 2)) / (2 * k2)) + Math.Round(b1 * alpha / b2, 3), 3);
        }
        //вероятность попадания в промежуток
        public double answer2()
        {
            P1 = (Math.Round((beta1 - alpha1) * (b + k * ((double)(beta1 + alpha1) / 2)), 3));
            P2 = (Math.Round((beta1 - alpha) * (b + k * ((double)(beta1 + alpha) / 2)), 3));
            P3 = (Math.Round((beta - alpha1) * (b + k * ((double)(beta + alpha1) / 2)), 3));
            P4 = (Math.Round((beta - alpha) * (b + k * ((double)(beta + alpha) / 2)), 3));
            if (alpha1 >= alpha && beta1 <= beta)
            {
                return Math.Round(P1, 3);
            }
            if (alpha1 < alpha && beta1 <= beta)
            {
                return Math.Round(P2, 3);
            }
            if (alpha1 >= alpha && beta1 > beta)
            {
                return Math.Round(P3, 3);
            }
            if (alpha1 < alpha && beta1 > beta)
            {
                return Math.Round(P4, 3);
            }
            return -1;

        }
        //матожидание
        public double answer4()
        {
            Mx = (Math.Round(((k / 3) * (beta * beta * beta - alpha * alpha * alpha) + (b / 2) * (beta * beta - alpha * alpha)), 3));
            return Mx;
        }
        //Дисперсия
        public double answer5()
        {
            Dx = (Math.Round(((k / 4) * (beta * beta * beta - alpha * alpha * alpha) + (b / 2) * (beta * beta - alpha * alpha) - Math.Pow((k / 3) * (beta * beta * beta * beta - alpha * alpha * alpha * alpha) + (b / 3) * (beta * beta * beta - alpha * alpha * alpha), 2)), 3));
            return Dx;
        }
        //ответы на задания в зависимости от уровня сложности
        public string ans(int i)
        {
            string Head = "<html xmlns:m='xmltemplates/pmathml.sxl'>" +
            "<font style = \"font-weight: normal;fons-size: 12pt; color: black; font-style: normal; font-family: 'Times NEw Roman'; font variatn: normal; text-decoration: none\">" +
            "<body><object id = 'math1' classid='clsid:32F66A20-7614-11D4-BD11-00104BD3F987'></object>" +
            "<?import namespace= 'm' implementation='#math1' ?>";
            //функция распределения
            string s1 = "<m:math display='inline'>";
            s1 += "<m:mn>" + Math.Round(k1 / (2 * k2), 3) + "</m:mn><m:msup><m:mi>x</m:mi><m:mn>2</m:mn></m:msup>";
            s1 += "<m:mo>+</m:mo>" + "<m:mn>" + Math.Round(b1 / b2, 3) + "</m:mn><m:mi>x</m:mi>";
            s1 += "<m:mo>-</m:mo>" + "<m:mn>" + Math.Round(((k1 * Math.Pow(alpha, 2)) / (2 * k2)) + Math.Round(b1 * alpha / b2, 3), 3) + "</m:mn>";
            s1 += " </m:math>";
            s1 = Math.Round(k1 / (2 * k2), 3) + "x^2+" + Math.Round(b1 / b2, 3) + "x+" + Math.Round(((k1 * Math.Pow(alpha, 2)) / (2 * k2)) + Math.Round(b1 * alpha / b2, 3), 3);
            //string answer1=Math.Round(k1 / (2 * k2), 3) + Math.Pow(x,2) + Math.Round(b1 / b2, 3) + x+ Math.Round(((k1 * Math.Pow(alpha, 2)) / (2 * k2)) + Math.Round(b1 * alpha / b2, 3), 3) 
            //вероятность попадания в область
            string s2;
            s2 = answer2().ToString();
            //математическое ожидание
            string s4;
            s4 =answer4().ToString();
            //дисперсия
            string s5;
            s5 = answer5().ToString();
            //ско
            string s3;
            s3 = Math.Sqrt(answer5()).ToString();
            string[] MasTask = { s1, s2, s3, s4, s5,Head };
            if (i == 1)
                //return MasTask[5] + MasTask[x1+1];
                return MasTask[x1];
            if (i == 2)
                return MasTask[x1] + ";"+ MasTask[x2];
            if (i == 3)
                return MasTask[x1] + ";" + MasTask[x2] + ";" + MasTask[x3];
            //return(Head + ans1 + s1 + ans2 + s2 + ans3 + s3 + ans4 + s4);
            return Head;
        }

    }
}
