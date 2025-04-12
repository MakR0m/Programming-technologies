using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BAD_SRP
{
    internal class Report
    {
        public string Tittle {  get; set; }
        public string Content {  get; set; }

        public void Generate() { /*логика генерации */ }

        public void SaveToFile() { /*сохранение в файл */ }

        public void SendEmail() { /* отправка mail */ }

        //Почему плохо: изменится формат файла - надо менять класс
        // Изменится логика отправки письма - надо менять класс
        // Изменится структура отчета - надо менять класс

        //Как минимум три причины менять класс - нарушение единственной ответственности
    }
}
