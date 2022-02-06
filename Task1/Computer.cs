using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Computer
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
            return $"<{ID,2}> {Model,-32}- {cpuDescription,-33} /" +
                    $" RAM {RAMCapacity,2} ГБ / видео {GraphicsCardMemCapacity} ГБ" +
                    $"  —  ${Price,4}  ({Count,3} шт.)";
        }
        public string ToStringNoCPU() // Метод возвращает форматированную строку с характеристиками компьютера
                                      // за исключением CPU для вывода с группировкой по CPU
        {
            return $"\t<{ID,2}> {Model,-32}-" +
                    $" RAM {RAMCapacity,2} ГБ / видео {GraphicsCardMemCapacity} ГБ" +
                    $"  —  ${Price,4}  ({Count,3} шт.)";
        }
    }
}
