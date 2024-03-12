using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praktika_personnel_department
{
    internal class Program
    {
        //Объявление глобальных переменных
        static string[] mas_fio = new string[0];         //массив ФИО
        static string[] mas_position = new string[0];    //масиив должностей

        static void Main(string[] args)
        {
            string programm_title = @"

   █▀█ █▀▀ █▀█ █▀ █▀█ █▄░█ █▄░█ █▀▀ █░░   █▀▄ █▀▀ █▀█ ▄▀█ █▀█ ▀█▀ █▀▄▀█ █▀▀ █▄░█ ▀█▀
   █▀▀ ██▄ █▀▄ ▄█ █▄█ █░▀█ █░▀█ ██▄ █▄▄   █▄▀ ██▄ █▀▀ █▀█ █▀▄ ░█░ █░▀░█ ██▄ █░▀█ ░█░

";

            string programm_menu = "   ** Меню программы:\r\n" +
                "\r\n      1 - добавить досье;" +
                "\r\n      2 - вывести все имеющиеся досье;" +
                "\r\n      3 - удалить досье;" +
                "\r\n      4 - поиск досье по фамилии;" +
                "\r\n      5 - закрыть программу\r\n";

            string programm_work_area = "** Рабочее окно **";
            string programm_choice = ">> Выберите действие:";
            string user_choice = "";
           
            while (user_choice != "5")
            {
                Console.Clear();
                int y = 19;

                Console.WriteLine(programm_title);
                Console.WriteLine(programm_menu);
                Console.WriteLine(new string('_', Console.WindowWidth));

                Console.SetCursorPosition(3, 17);
                Console.WriteLine(programm_work_area);

                Console.SetCursorPosition(3, y);
                Console.WriteLine(programm_choice);
                y++;
                Console.SetCursorPosition(6, y);
                user_choice = Console.ReadLine();
                y++;

                switch (user_choice)
                {
                    case "1":
                        Add_dossier(y);
                        break;

                    case "2":
                        Print_all_dossier(y);
                        break;

                    case "3":
                        Delete_dossier(y);
                        break;

                    case "4":
                        Search_dossier(y);
                        break;

                    case "5":
                        Console.WriteLine("   >> Завершение программы...\r\n");
                        break;

                    default:
                        y++;
                        Console.SetCursorPosition(3, y);
                        Console.WriteLine(">> Такого действия нет - смотрите меню программы...");
                        y++; y++;
                        Console.SetCursorPosition(3, y);
                        break;
                }
            }
        }

        //Функция добавления записи в массив (добавить досье)
        static void Add_dossier(int y)
        {
            Console.SetCursorPosition(3, y);
            Console.WriteLine(">> Введите ФИО: ");
            y++;
            Console.SetCursorPosition(6, y);
            string new_fio = Console.ReadLine();
            y++;
            Console.SetCursorPosition(3, y);
            Console.WriteLine(">> Введите должность: ");
            y++;
            Console.SetCursorPosition(6, y);
            string new_position = Console.ReadLine();
            y++;

            Array.Resize(ref mas_fio, mas_fio.Length + 1);
            mas_fio[mas_fio.Length - 1] = new_fio;

            Array.Resize(ref mas_position, mas_position.Length + 1);
            mas_position[mas_position.Length - 1] = new_position;

            Console.SetCursorPosition(3, y);
            Console.WriteLine(">> ДОСЬЕ УСПЕШНО ДОБАВЛЕНО!");
            y++;
            y++;

            Thread.Sleep(5000);
        }

        //Функция вывода всех имеющихся досье
        static void Print_all_dossier(int y)
        {
            y++;
            Console.SetCursorPosition(6, y);

            for (int i = 0;i < mas_fio.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {mas_fio[i]} - {mas_position[i]}");
                y++;
                Console.SetCursorPosition(6, y);
            }

            y++;
            Console.SetCursorPosition(3, y);
            Console.WriteLine(">> Для завершения просмотра всех досье нажмите любую клавишу + Enter...");
            y++;

            Console.SetCursorPosition(6, y);
            string exit_print_all_dossier = Console.ReadLine();

            if (exit_print_all_dossier == "") Thread.Sleep(0);
        }

        //Функция удаления записи в массиве (удалить досье)
        static void Delete_dossier(int y)
        {
            y++;
            Console.SetCursorPosition(3, y);
            Console.WriteLine(">> Введите порядковый номер досье для последующего его удаления: ");

            y++;
            Console.SetCursorPosition(6, y);
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < mas_fio.Length)
            {
                for (int i = index; i < mas_fio.Length - 1; i++)
                {
                    mas_fio[i] = mas_fio[i + 1];
                    mas_position[i] = mas_position[i + 1];
                }
                Array.Resize(ref mas_fio, mas_fio.Length - 1);
                Array.Resize(ref mas_position, mas_position.Length - 1);

                y++;
                Console.SetCursorPosition(3, y);
                Console.WriteLine(">> ДОСЬЕ УСПЕШНО УДАЛЕНО!");
                Thread.Sleep(5000);
            }
            else
            {
                y++;
                Console.SetCursorPosition(3, y);
                Console.WriteLine(">> Неверный порядковый номер!!!");
                Thread.Sleep(5000);
            }
        }

        //Функция поиска записи в массиве (поиск досье по фамилии)
        static void Search_dossier(int y)
        {
            y++;
            Console.SetCursorPosition(3, y);
            Console.WriteLine(">> Введите фамилию для поиска: ");

            y++;
            Console.SetCursorPosition(6, y);
            string enter_f = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < mas_fio.Length; i++)
            {
                if (mas_fio[i].Contains(enter_f))
                {
                    y++;
                    Console.SetCursorPosition(6, y);
                    Console.WriteLine($"{mas_fio[i]} - {mas_position[i]}");
                    found = true;
                }
            }

            if (!found)
            {
                y++;
                Console.SetCursorPosition(3, y);
                Console.WriteLine(">> Досье не найдено...");
            }

            Thread.Sleep(5000);
        }
    }
}