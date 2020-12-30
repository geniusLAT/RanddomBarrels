using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomBarrels
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            int N;
            List<int> Inside = new List<int>();
            List<int> Outside = new List<int>();
            int ReadFromConsole(string message)//Метод чтения числа с консоли
            {
                int a = 0;//Сюда пишем значение
                while (a == 0)//Пока оно ноль продолжаем требовать ввод
                {
                    Console.Write(message);//Пишем, что мы хотим от юзера
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());//Берём ввод с клавиатуры и пытаемся сделать цифрой
                        if (a < 1)//Нужно положительное число
                        {
                            Console.Write("Некорректный ввод.\n" );//Выводим просьбу
                            a = 0;//Чтобы цикл продолжился
                        }
                    }
                    catch (Exception e)//Сделать цифрой не получилось
                    {
                        Console.Write("Некорректный ввод.\n" );//Выводим просьбу
                        a = 0;//Чтобы цикл продолжился
                    }

                }
                return a;//Возвращаем
            }
            void FillInside(int z)//Заполняем массив бочками
            {
                for(int i = 0; i < z; i++)//Цикл для N бочек
                {
                    Inside.Add(i + 1);// Ставим +1, чтобы генерация шла не с 0, а с 1
                }
            }
            void PrintList(List<int> L)//Выводим на экран список
            {
                int[] array = L.ToArray();//Делаем массив в целях оптимизации
                foreach (int z in array) Console.Write(" " + z.ToString());//Все элементы выводим через пробел
            }
            void RandomBarrel()//Выпадение случайной бочки
            {
               
                int[] array = Inside.ToArray();//Делаем массив в целях оптимизации
                Random rnd = new Random();//Объявляем рандомизатор
                int f = Inside[rnd.Next(0, Inside.ToArray().Length)];//Случайное число от 0 до длины массива 
                Outside.Add(f);//Вписываем в список вытянутых бочек
                Inside.Remove(f);//Вычёркиваем из списка бочек в мешке
                Console.WriteLine("Выпало число " + f.ToString());//Уведомляем о том, какое число выпало
            }
             N = ReadFromConsole("Введите N:");//ввод N
            FillInside(N);//Заполняем список бочек в мешке
            Console.WriteLine("В мешке бочки с номерами: ");//Выводим
            PrintList(Inside);
            while (Inside.ToArray().Length != 0)//Пока бочки в мешке есть
            {
                Console.ReadLine();//Ждём когда пользователь нажмёт Enter
                RandomBarrel();//Функция для случайной бочки
            }
            Console.WriteLine("\n Из мешка вытащены бочки:");//Выводим список вытянутых бочек в порядке вытягивания
            PrintList(Outside);
            Console.ReadLine();//Если этой строчки не будет, то консоль сразу закрывается. 
        }
    }
}
