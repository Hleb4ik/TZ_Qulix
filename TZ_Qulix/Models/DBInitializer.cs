using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TZ_Qulix.Models 
{
    public class DBInitializer : DropCreateDatabaseAlways<WorkerContext>
    {
        protected override void Seed(WorkerContext context)
        {
            //Делаем записи в БД Работники---------------------------------------------------

            context.Workers.Add(new Worker() { Surname = "Иванов", Name = "Иван", Otchestvo = "Иванович", Date = "24.01.2020", Post = "Разработчик", Company = "Компания1" });

            context.Workers.Add(new Worker() { Surname = "Тестов", Name = "Тест", Otchestvo = "Тестович", Date = "14.07.2018", Post = "Менеджер", Company = "Компания2" });

            context.Workers.Add(new Worker() { Surname = "Петров", Name = "Петр", Otchestvo = "Петрович", Date = "01.03.2019", Post = "Тестировщик", Company = "Компания3" });

            //-------------------------------------------------------------------------------

            //Делаем записи в БД Компании----------------------------------------------------

            context.Companies.Add(new Company() { Name = "Компания1", Size = 400, Form = "ЗАО" });

            context.Companies.Add(new Company() { Name = "Компания2", Size = 500, Form = "ОАО" });

            context.Companies.Add(new Company() { Name = "Компания3", Size = 600, Form = "ООО" });

            base.Seed(context);
        }
    }
}