using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class ComputersList
    // Класс ComputerList предназначен для работы со списком компьютеров (объектов класса Computer),
    // который хранится в свойстве Items в виде List.
    // Класс также содержит набор методов выполняющих операции LINQ над списком, а также методы,
    // выводящие списки на экран.
    // Некоторые из методов класса ComputerList возвращают выборку компьютеров также в виде объекта ComputerList.
    {
        public List<Computer> Items { get; set; } // Свойство для хранения списка компьютеров
        public void Print(bool noCPU = false)
        // Метод печатает список компьютеров, используя методы объекта Computer ToString и ToStringNoCPU
        // в зависимости от опции noCPU
        {
            if (this.Items.Count > 0)
            {
                foreach (Computer item in this.Items)
                {
                    Console.WriteLine((!noCPU) ? item.ToString() : item.ToStringNoCPU());
                }
            }
            else
            {
                Console.WriteLine("В выборке нет ни одного компьютера.");
            }
        }
        public string[] GetCPUList()
        // Метод возвращает строковый массив со списком типов процессоров
        {
            // С помощью LINQ формируем строковый список типов процессоров, отсортированный по алфавиту
            return this.Items.Select(d => d.CPUType).Distinct().OrderBy(d => d).ToArray();
        }
        public void PrintCPUList()
        // Метод печатает список процессоров, полученный из метода GetCPUList()
        {
            string[] cpuList = this.GetCPUList();
            if (cpuList.Length > 0)
            {
                foreach (string item in cpuList)
                {
                    Console.WriteLine($"\t{item}"); // Печатаем список с отступом
                }
            }
            else
            {
                Console.WriteLine("В списке нет ни одного процессора.");
            }
        }
        public ComputersList SelectComputersByCPU(string cpu)
        // Метод возвращает новый ComputersList с выборкой компьютеров по типу CPU
        {
            ComputersList selectedComputers = new ComputersList();
            // Выполняем выборку по заданному типу процессора с помощью LINQ
            selectedComputers.Items = this.Items.Where(d => d.CPUType == cpu).ToList();
            return selectedComputers;
        }
        public ComputersList SelectComputersByMinRAM(int min_ram_gb)
        // Метод возвращает новый ComputersList с выборкой компьютеров по заданному минимуму ОЗУ
        {
            ComputersList selectedComputers = new ComputersList();
            // Выполняем выборку по заданному минимуму ОЗУ с помощью LINQ
            selectedComputers.Items = this.Items.Where(d => d.RAMCapacity >= min_ram_gb).ToList();
            return selectedComputers;
        }
        public ComputersList GetCopyOrderedByPrice()
        {
            // Метод возвращает новый ComputersList с полным списком компьютеров, но отсортированным по цене
            ComputersList selectedComputers = new ComputersList();
            // Выполняем сортировку списка по стоимости помощью LINQ
            selectedComputers.Items = this.Items.OrderBy(d => d.Price).ToList();
            return selectedComputers;
        }
        public Dictionary<string, ComputersList> GetGroupedByCPU()
        // Метод возвращает словарь, в котором ключи соответствуют типам процессора, а значения являются объектами
        // ComputerList, каждый из которых содержит список компьютеров с данным типом процессора
        {
            Dictionary<string, ComputersList> dictGroupedComputers = new Dictionary<string, ComputersList>();

            // Выполняем группировку списка по типу процессора помощью LINQ
            // Получаем коллекцию из групп ключ-список, где ключ - тип процессора
            // а список включает все компьютеры с данным процессором
            foreach (var group in this.Items.OrderBy(d => d.CPUType).GroupBy(d => d.CPUType))
            {
                // Перебирая коллекцию, формируем словарь из пар ключ-значение
                ComputersList selectedComputers = new ComputersList();
                selectedComputers.Items = group.ToList();
                dictGroupedComputers.Add(group.Key, selectedComputers);
            }
            return dictGroupedComputers;
        }
        public void PrintGroupedByCPU()
        // Метод печатает список компьютеров, сгруппированный по типу процессора, полученный из метода GetGroupedByCPU()
        {
            Dictionary<string, ComputersList> dictGroupedComputers = this.GetGroupedByCPU();
            if (dictGroupedComputers.Count > 0)
            {
                // Перебираем словарь, возвращаемый методом ComputersList.GetGroupedByCPU()
                // В словаре ключи соответствуют типам процессоров, а значения — объектам ComputersList,
                // каждый из которых содержит выборку компьютеров с данным процессором
                foreach (KeyValuePair<string, ComputersList> item in dictGroupedComputers)
                {
                    // Печатаем ключ - тип процессора
                    Console.WriteLine($"--- Компьютеры с процессором {item.Key} ---");
                    // Печатаем соответствующий ключу список компьютеров
                    item.Value.Print(true); // В методе Print используем оцию noCPU,
                                            // чтобы не печатать информацию о процессоре
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("В списке нет ни одного компьютера.");
            }
        }
        public decimal MaxPrice()
        // Метод возвращает максимальную цену компьютера в списке
        {
            if (this.Items.Count > 0)
            {
                // C помощью LINQ возвращаем максимальную цену компьютера
                return this.Items.Max(d => d.Price);
            }
            else
            {
                return -1;
            }
        }
        public decimal MinPrice()
        // Метод возвращает минимальную цену компьютера в списке
        {
            if (this.Items.Count > 0)
            {
                // C помощью LINQ возвращаем минимальную цену компьютера
                return this.Items.Min(d => d.Price);
            }
            else
            {
                return -1;
            }
        }
        public ComputersList SelectComputersByPrice(decimal price)
        // Метод возвращает новый ComputersList с выборкой компьютеров по заданной цене
        {
            ComputersList selectedComputers = new ComputersList();
            // Выполняем выборку по заданной цене с помощью LINQ
            selectedComputers.Items = this.Items.Where(d => d.Price == price).ToList();
            return selectedComputers;
        }
        public bool IsAvailableAtLeast(int count)
        // Метод сообщает, имеется ли хотя бы один компьютер в количестве не менее заданного
        {
            // C помощью LINQ выполняем проверку и возвращаем логическое значение
            return this.Items.Any(d => d.Count >= count);
        }
    }
}
