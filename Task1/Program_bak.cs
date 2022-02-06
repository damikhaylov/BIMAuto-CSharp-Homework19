using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Task1
{
    public class Computer
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string CPUType { get; set; }
        public int CPUFreq { get; set; }
        public int RAMCapacity { get; set; }
        public int DriveCapacity { get; set; }
        public int GraphicsCardMemCapacity { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public override string ToString() // Переопределённый метод возвращает форматированную строку
                                          // с характеристиками компьютера
        {
            string cpuDescription = CPUType + " " + CPUFreq + " МГц";
            return $"{ID,-3}{Model,-32}- {cpuDescription,-33} /" +
                    $" RAM {RAMCapacity,2} ГБ / видео {GraphicsCardMemCapacity} ГБ" +
                    $"  —  ${Price,4}  {Count,3} шт.";
        }
    }
    class Program
    {
        static void PrintComputersList(List<Computer> computers) // Вспомогательный метод для печати списка компьютеров
        {
            if (computers.Count > 0)
            {
                foreach (Computer item in computers) Console.WriteLine(item.ToString());
            }
            else
            {
                Console.WriteLine("В выборке нет ни одного компьютера.");
            }
        }
        static void Main(string[] args)
        {
            /*
            Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой 
            работы  процессора,  объемом оперативной памяти, объемом жесткого диска,объемом памяти видеокарты,
            стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии. Создать список,
            содержащий 6-10 записей с различным набором значений характеристик.

            Определить:

            - все компьютеры с указанным процессором. Название процессора запросить у пользователя;

            - все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;

            - вывести весь список, отсортированный по увеличению стоимости;

            - вывести весь список, сгруппированный по типу процессора;

            - найти самый дорогой и самый бюджетный компьютер;

            - есть ли хотя бы один компьютер в количестве не менее 30 штук?

                */

            List<Computer> computers = new List<Computer>()
            {
                new Computer(){ ID = 1, Model = "Dell OptiPlex 5090 SFF", CPUType = "Core i5-10505", CPUFreq = 3200,
                                RAMCapacity = 8,  DriveCapacity = 256, GraphicsCardMemCapacity = 0, Price = 850, Count = 10},
                new Computer(){ ID = 2, Model = "ASUS ExpertCenter D5 SFF D500SC", CPUType = "Intel Pentium Gold G6405", CPUFreq = 4100,
                                RAMCapacity = 4,  DriveCapacity = 128, GraphicsCardMemCapacity = 0, Price = 392, Count = 24},
                new Computer(){ ID = 3, Model = "MSI MPG Trident 3 11SI-006XRU", CPUType = "Intel Core i5-11400F", CPUFreq = 2600,
                                RAMCapacity = 16,  DriveCapacity = 512, GraphicsCardMemCapacity = 6, Price = 1230, Count = 8},
                new Computer(){ ID = 4, Model = "HP Pavilion TP01-2053ur", CPUType = "Intel Core i7-11700", CPUFreq = 2500,
                                RAMCapacity = 16,  DriveCapacity = 1000, GraphicsCardMemCapacity = 0, Price = 1040, Count = 6},
                new Computer(){ ID = 5, Model = "Lenovo IdeaCentre G5 14IMB05", CPUType = "Intel Core i3-10100", CPUFreq = 3600,
                                RAMCapacity = 16,  DriveCapacity = 512, GraphicsCardMemCapacity = 4, Price = 909, Count = 11},
                new Computer(){ ID = 6, Model = "HP ProDesk 400 G7 MT", CPUType = "Intel Core i5-11400F", CPUFreq = 3100,
                                RAMCapacity = 8,  DriveCapacity = 256, GraphicsCardMemCapacity = 0, Price = 857, Count = 11},
                new Computer(){ ID = 7, Model = "Acer Veriton M4680G", CPUType = "Intel Core i7-11700", CPUFreq = 2500,
                                RAMCapacity = 16,  DriveCapacity = 2048, GraphicsCardMemCapacity = 4, Price = 1425, Count = 5},
                new Computer(){ ID = 8, Model = "Acer Revo RN96", CPUType = "Intel Core i3-1115G4", CPUFreq = 3000,
                                RAMCapacity = 4,  DriveCapacity = 256, GraphicsCardMemCapacity = 0, Price = 424, Count = 35},
                new Computer(){ ID = 9, Model = "Lenovo IdeaCentre 3 07ADA05", CPUType = "AMD Athlon Silver 3050U", CPUFreq = 2300,
                                RAMCapacity = 4,  DriveCapacity = 512, GraphicsCardMemCapacity = 0, Price = 377, Count = 29},
                new Computer(){ ID = 10, Model = "Acer Nitro N50-620", CPUType = "Intel Core i5-11400F", CPUFreq = 2600,
                                RAMCapacity = 16,  DriveCapacity = 512, GraphicsCardMemCapacity = 4, Price = 948, Count = 9},
            };

            List<Computer> selComputers; // Определяем список для выборок компьютеров

            byte menuPoint = 0; // Переменная для выбора пользователем пункта меню

            while (true) // Программа выполняется в бесконечном цикле, пока пользователь не выберет вариант выхода в меню
            {
                Console.WriteLine("\n>>> Выберите действие со списком компьютеров:\n");
                Console.WriteLine("1 — Вывести весь список без сортировки");
                Console.WriteLine("2 — Выбрать компьютеры, указав тип процессора");
                Console.WriteLine("3 — Выбрать компьютеры, указав минимальный объемом ОЗУ");
                Console.WriteLine("4 — Вывести весь список, отсортированный по увеличению стоимости");
                Console.WriteLine("5 — Вывести весь список, сгруппированный по типу процессора");
                Console.WriteLine("6 — Найти самый дорогой и самый бюджетный компьютер");
                Console.WriteLine("7 — Определить, есть ли хотя бы один компьютер в количестве не менее 30 штук");
                Console.WriteLine("0 — Завершить работу программы");
                Console.Write("\nВаш выбор: ");
                try
                {
                    menuPoint = Convert.ToByte(Console.ReadLine());
                }
                catch (Exception) // В случае некорректного ввода
                {
                    menuPoint = 255; // присваиваем переменной выбора меню значение, соответствующее 
                                     // дальнейшей обработке по-умолчанию ("Такого пункта меню нет в списке.")
                }
                Console.WriteLine();
                switch (menuPoint) // Выполнение действий согласно выбранному пункту меню
                {
                    case 0: break;
                    case 1: // Вывести весь список без сортировки
                        PrintComputersList(computers); // печатаем список с помощью метода PrintComputersList
                        break;

                    case 2: // Выбрать компьютеры, указав тип процессора

                        // Сначала, чтобы помочь пользователю, выведем список всех доступных процессоров
                        Console.WriteLine("В компьютерах использованы следующие типы процессоров:\n");

                        // С помощью LINQ формируем строковый список типов процессоров, отсортированный по алфавиту
                        List<string> cpuTypes = computers.Select(d => d.CPUType).Distinct().OrderBy(d => d).ToList();
                        foreach (string s in cpuTypes)
                        {
                            Console.WriteLine($"\t{s}"); // Печатаем список с отступом
                        }

                        Console.Write("\nВведите название типа процессора для выбора компьютеров " +
                                          "с соответствующей характеристикой: ");
                        string cpuType = Console.ReadLine();
                        Console.WriteLine();
                        // Выполняем выборку по заданному типу процессора с помощью LINQ
                        selComputers = computers.Where(d => d.CPUType == cpuType).ToList();
                        PrintComputersList(selComputers); // печатаем список с помощью метода PrintComputersList
                        break;

                    case 3: // Выбрать компьютеры, указав минимальный объемом ОЗУ
                        Console.Write("Укажите минимальный объём ОЗУ (в ГБ) для выбора компьютеров " +
                                            "соответствующих данному критерию: ");
                        int minRAMCapacity; // Переменная для указания минимального объёма памяти
                        try
                        {
                            minRAMCapacity = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception) // В случае некорректного ввода
                        {
                            minRAMCapacity = -1; // присваиваем объёму памяти значение, которое будет указывать
                                                 // на ошибку ввода
                        }
                        Console.WriteLine();
                        if (minRAMCapacity >= 0)
                        {
                            // Выполняем выборку по заданному типу процессора с помощью LINQ
                            selComputers = computers.Where(d => d.RAMCapacity >= minRAMCapacity).ToList();
                            PrintComputersList(selComputers); // печатаем список с помощью метода PrintComputersList
                        }
                        else
                        {
                            Console.WriteLine("Требовалось ввести неотрицательное целое число.");
                        }
                        break;

                    case 4: // Вывести весь список, отсортированный по увеличению стоимости
                        // Выполняем сортировку списка по стоимости помощью LINQ
                        selComputers = computers.OrderBy(d => d.Price).ToList();
                        PrintComputersList(selComputers); // печатаем список с помощью метода PrintComputersList
                        break;

                    case 5: // Вывести весь список, сгруппированный по типу процессора

                        // Выполняем группировку списка по типу процессора помощью LINQ
                        // Получаем коллекцию из элементов ключ-список, где ключ - тип процессора
                        // а список включает все компьютеры с данным процессором
                        var groupedComputers = computers.GroupBy(d => d.CPUType).ToList();

                        foreach (var item in groupedComputers)
                        {
                            // Печатаем ключ - тип процессора
                            Console.WriteLine($"--- Компьютеры с процессором {item.Key} ---");
                            // Печатаем соответствующий ключу список с помощью метода PrintComputersList
                            PrintComputersList(item.ToList()); // печатаем список с помощью метода PrintComputersList
                            Console.WriteLine();
                        }
                        break;

                    case 6: //найти самый дорогой и самый бюджетный компьютер;
                        // Сначала помощью LINQ находим максимальную цену компьютера
                        decimal maxPrice = computers.Max(d => d.Price);
                        // Затем помощью LINQ выбираем компьютеры с ценой, равной максимальной (их может быть несколько)
                        selComputers = computers.Where(d => d.Price == maxPrice).ToList();
                        Console.WriteLine("--- Компьютеры с максимальной ценой:");
                        PrintComputersList(selComputers); // печатаем список с помощью метода PrintComputersList

                        // Сначала помощью LINQ находим минимальную цену компьютера
                        decimal minPrice = computers.Min(d => d.Price);
                        // Затем помощью LINQ выбираем компьютеры с ценой, равной минимальной (их может быть несколько)
                        selComputers = computers.Where(d => d.Price == minPrice).ToList();
                        Console.WriteLine("--- Компьютеры с минимальной ценой:");
                        PrintComputersList(selComputers); // печатаем список с помощью метода PrintComputersList

                        break;

                    case 7: // Определить, есть ли хотя бы один компьютер в количестве не менее 30 штук
                        if (computers.Any(d => d.Count >= 30))
                        {
                            Console.WriteLine("Среди компьютеров есть хотя бы один в количестве не менее 30 штук");

                        }
                        else
                        {
                            Console.WriteLine("Среди компьютеров нет ни одного в количестве не менее 30 штук");
                        }
                        break;

                    default:
                        Console.WriteLine("Такого пункта меню нет в списке.");
                        break;
                }

                if (menuPoint != 0)
                {
                    Console.Write("\nНажмите любую клавишу для возврата к меню ");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else
                {
                    break; // Выход из программы
                }
            }
        }
    }
}