using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{

    class Program
    {
        static void Main(string[] args)
        {
            /***** Условие задачи *****
            
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

            /***** Реализация задачи *****
            
            Задача реализована с помощью классов Computer и ComputerList (вынесены в отдельные файлы)
            Класс ComputerList имеет свойство Items, представляющее собой список List объектов Computer,
            а также набор методов, выполняющих операции LINQ над списком, а также методы, выводящие списки на экран.
            Некоторые из методов класса ComputerList возвращают выборку также в виде объекта ComputerList.
            */

            ComputersList compList = new ComputersList();
            compList.Items = new List<Computer>()
            {
                new Computer(){ ID = 1, Model = "Dell OptiPlex 5090 SFF", CPUType = "Intel Core i5-10505", CPUFreq = 3200,
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

                byte menuPoint; // Переменная для выбора пользователем пункта меню

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
                        compList.Print();
                        break;

                    case 2: // Выбрать компьютеры, указав тип процессора

                        // Сначала, чтобы помочь пользователю, выведем список всех имеющихся процессоров
                        Console.WriteLine("В компьютерах использованы следующие типы процессоров:\n");
                        compList.PrintCPUList();

                        Console.Write("\nВведите название типа процессора для выбора компьютеров " +
                                      "с соответствующей характеристикой: ");
                        string cpuType = Console.ReadLine();
                        Console.WriteLine();
                        compList.SelectComputersByCPU(cpuType).Print();
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
                            compList.SelectComputersByMinRAM(minRAMCapacity).Print();
                        }
                        else
                        {
                            Console.WriteLine("Требовалось ввести неотрицательное целое число.");
                        }
                        break;

                    case 4: // Вывести весь список, отсортированный по увеличению стоимости
                        compList.GetCopyOrderedByPrice().Print();
                        break;

                    case 5: // Вывести весь список, сгруппированный по типу процессора
                        compList.PrintGroupedByCPU();
                        break;

                    case 6: //найти самый дорогой и самый бюджетный компьютер;
                        Console.WriteLine("--- Компьютеры с максимальной ценой:");
                        compList.SelectComputersByPrice(compList.MaxPrice()).Print();

                        Console.WriteLine("--- Компьютеры с максимальной ценой:");
                        compList.SelectComputersByPrice(compList.MinPrice()).Print();

                        break;

                    case 7: // Определить, есть ли хотя бы один компьютер в количестве не менее 30 штук
                        const int RECUIRED_COUNT = 30;
                        if (compList.IsAvailableAtLeast(RECUIRED_COUNT))
                        {
                            Console.WriteLine($"Среди компьютеров есть хотя бы один в количестве " +
                                              $"не менее {RECUIRED_COUNT} штук");

                        }
                        else
                        {
                            Console.WriteLine($"Среди компьютеров нет ни одного в количестве " +
                                              $"не менее {RECUIRED_COUNT} штук");
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