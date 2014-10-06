using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ConsoleApplication12
{

    //При использовании типа ulong неизбежно произойдет переполнение
    //Для хранения больших чисел используются массивы
    class Program
    {
        public static ulong[] Mas(ulong[] mas, ulong n)
        {
            ulong[] outmas;

            int l = mas.Length, l1, l2; // l - длина массива

            l1 = l / 2; // l1 - длина первой половины массива
            l2 = l - l1; // l2 - длина второй половины массива

            outmas = new ulong[l2]; // Новый массив будет в 2 раза короче исходного

            if (l % 2 == 0)
            {
                for (int i = 0, j = 0; i < l2; i++, j = j + 2)
                    outmas[i] = mas[j] * mas[j + 1];
            }

            if (l % 2 != 0)
            {
                for (int i = 0, j = 0; i < l2 - 1; i++, j = j + 2)
                    outmas[i] = mas[j] * mas[j + 1];
                outmas[outmas.Length - 1] = mas[mas.Length - 1];
            }

            for (int i = 0; i < outmas.Length; i++)
                outmas[i] = outmas[i] - outmas[i] / n * n;

            for (int i = 0; i < outmas.Length; i++)
                Console.Write(outmas[i].ToString() + "   ");
            Console.WriteLine();
            Console.WriteLine();

            return outmas;
        }


        static void Main(string[] args)
        {
		
            ulong n, n1, a;
            /* n - заданное число, которое нужно проверить
             * n1 = n-1
             * a - рандомное число
             */

                Console.Write("Введите n: ");
                n = ulong.Parse(Console.ReadLine());

                n1 = n - 1;

                Console.Write("Введите a:");
                a = ulong.Parse(Console.ReadLine());

                Random ran = new Random();

                ulong s, k;
                s = n1 / 3;
                k = n1 - 3 * s;

                Console.WriteLine("{0} = {1}*3 + {2} <--- Разложение n-1 на множители\n", n1, s, k);

                //for (int t = 0; t < 200; t++) // Цикл программы, где t - количество разных a
                //{

                //    do
                //    {
                //        a = (ulong)ran.Next(500);
                //    } while (a % n == 0);

                    ulong[] mas = new ulong[s + 1];

                    for (int i = 0; i < mas.Length - 1; i++) // Каждый элемент массива - a^3
                        mas[i] = (ulong)Math.Pow(a, 3);

                    mas[mas.Length - 1] = (ulong)Math.Pow(a, k); // Последний элемент массива - a^k

                    Console.WriteLine("Массив множителей");
                    for (int i = 0; i < mas.Length; i++)
                        Console.Write(mas[i].ToString() + "   ");

                    Console.WriteLine();

                    for (int i = 0; i < mas.Length; i++)
                        mas[i] = mas[i] - mas[i] / n * n;

                    Console.WriteLine("Массив множителей по модулю n");

                    for (int i = 0; i < mas.Length; i++)
                        Console.Write(mas[i].ToString() + "   ");


                    Console.WriteLine();
                    Console.WriteLine();

                    int l = mas.Length, l1, l2; // l - длина массива

                    l1 = l / 2; // l1 - длина первой половины массива
                    l2 = l - l1; // l2 - длина второй половины массива

                    //Если длина массива четная, то l2 = l1

                    ulong[] outmas, rezultmus;
                    outmas = mas;
                    rezultmus = new ulong[2];

                    Console.WriteLine("Последующие массивы, уменьшающиеся в 2 раза:");
                    Console.WriteLine();
                    while (true)
                    {
                        outmas = Mas(outmas, n);
                        if (outmas.Length == 2)
                        {
                            rezultmus = outmas;
                            break;
                        }
                    }

                    ulong rezult = rezultmus[0] * rezultmus[1];
                    rezult = rezult - rezult / n * n; // Считаем результат по модулю

                    Console.WriteLine("a = {0,3}, a^n-1 = {1}", a, rezult);
                Console.ReadLine();


			//Пошаговый вывод массивов
			
            //for (int i = 0; i < mas.Length; i++) // Каждый элемент массива считаем по модулю n
            //    mas[i] = mas[i] - mas[i] / n * n;

            //ulong k1, k2;

            //k1 = (ulong)(mas.Length / 2); // Делим длину массива пополам
            //k2 = (ulong)mas.Length - k1;

            //ulong[] mas1 = new ulong[k1]; // Создаем 2 маленьких массива
            //ulong[] mas2 = new ulong[k2];

            //for (ulong i = 0; i < k1; i++) // Заполняем первый маленький массив
            //    mas1[i] = mas[i];

            //for (int i = 0; i < mas1.Length; i++)
            //    Console.Write(mas1[i].ToString() + "   ");

            //Console.WriteLine("   <-- Первый массив");

            //for (ulong i = 0, j = k1; i < (ulong)mas2.Length; i++, j++) // Заполняем второй маленький массив
            //    mas2[i] = mas[j];

            //for (int i = 0; i < mas2.Length; i++)
            //    Console.Write(mas2[i].ToString() + "   ");

            //Console.WriteLine("   <-- Второй массив");

            //ulong l11, l12, l21, l22;

            //l11 = k1 / 2; // Делим длину каждого мелкого массива пополам
            //l12 = k1 - l11;
            //l21 = k2 / 2;
            //l22 = k2 - l21;

            //ulong[] mas11 = new ulong[l11]; // Создаем 4 мелких массива
            //ulong[] mas12 = new ulong[l12];
            //ulong[] mas21 = new ulong[l21];
            //ulong[] mas22 = new ulong[l22];

            //for (ulong i = 0; i < l11; i++) // Заполняем первый мелкий массив
            //    mas11[i] = mas1[i];

            //for (ulong i = 0, j = l11; i < (ulong)mas12.Length; i++, j++) // Заполняем второй мелкий массив
            //    mas12[i] = mas1[j];

            //for (ulong i = 0; i < l21; i++) // Заполняем третий мелкий массив
            //    mas21[i] = mas2[i];

            //for (ulong i = 0, j = l21; i < (ulong)mas22.Length; i++, j++) // Заполняем четвертый мелкий массив
            //    mas22[i] = mas2[j];

            //ulong result1, result2, result11 = 1, result12 = 1, result21 = 1, result22 = 1;

            //for (int i = 0; i < mas11.Length; i++) // Перемножаем элементы первого мелкого массива
            //    result11 = result11 * mas11[i];

            //for (int i = 0; i < mas12.Length; i++) // Перемножаем элементы первого мелкого массива
            //    result12 = result12 * mas12[i];

            //for (int i = 0; i < mas21.Length; i++) // Перемножаем элементы первого мелкого массива
            //    result21 = result21 * mas21[i];

            //for (int i = 0; i < mas22.Length; i++) // Перемножаем элементы первого мелкого массива
            //    result22 = result22 * mas22[i];

            //Console.WriteLine("Рез.11: {0}\nРез.12: {1}\nРез.21: {2}\nРез.22: {3}\n", result11, result12, result21, result22);

            //result11 = result11 - result11 / n * n; // Считаем произведение по модулю
            //result12 = result12 - result12 / n * n;
            //result21 = result21 - result21 / n * n;
            //result22 = result22 - result22 / n * n;

            //Console.WriteLine("Рез.11 (mod {0}): {1}\nРез.12(mod {0}): {2}\nРез.21 (mod {0}): {3}\nРез.22(mod {0}): {4}\n", n, result11, result12, result21, result22);

            //result1 = result11 * result12;
            //result2 = result21 * result22;

            //result1 = result1 - result1 / n * n;
            //result2 = result2 - result2 / n * n;

            //ulong result = result1 * result2;

            //Console.WriteLine("Рез: {0}", result);

            //result = result - result / n * n; // Считаем результат по модулю

            //Console.WriteLine(result);
            //Console.ReadLine();
        }
    }

}
