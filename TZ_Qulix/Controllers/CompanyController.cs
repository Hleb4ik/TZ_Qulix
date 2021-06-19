using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TZ_Qulix.Models;
using System.Data.Entity;

namespace TZ_Qulix.Controllers
{
    public class CompanyController : Controller
    {
        WorkerContext workerContext = new WorkerContext(); //Объявление workerContext

        //Добавление компании---------------------------------------------------
        [HttpGet]
        public ActionResult AddCompany(int id = 1)
        {
            ViewBag.Id = id;//Присваиваем id

            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(Company company)
        {

            workerContext.Companies.Add(company);//Записываем данные в БД

            workerContext.SaveChanges();//Сохраняем 

            Response.Redirect("/Home/Companies/");//Переход на форму

            return View();
        }
        //----------------------------------------------------------------------

        //Удаление компании-------------------------------------------------------------
        public ActionResult DeletedCompany(int id)
        {
            Company company = workerContext.Companies.FirstOrDefault(g => g.Id == id);//Получаем ID записи в БД
            Company dbEntry = workerContext.Companies.Find(company.Id);//Присваиваем
            if (dbEntry != null)//Проверяем чтобы ID не был равен 0
            {
                workerContext.Companies.Remove(dbEntry);//Удаляем запись из БД с таким ID
                workerContext.SaveChanges();//Сохраняем 
            }
            workerContext.SaveChanges();//Сохраняем 
            Response.Redirect("/Home/Companies/");//Переход на форму
            return View();
        }
        //------------------------------------------------------------------------------

        //Редактирование компании-------------------------------------------------------
        [HttpGet]
        public ActionResult EditCompany(int id)
        {
            ViewBag.Id = id;

            Company company = workerContext.Companies.FirstOrDefault(g => g.Id == id);//Получаем ID записи в БД
            Company dbEntry = workerContext.Companies.Find(company.Id);//Присваиваем
            if (dbEntry != null)//Проверяем чтобы ID не был равен 0
            {
                dbEntry.Name = company.Name;//
                dbEntry.Size = company.Size;//Присваиваем значение полям
                dbEntry.Form = company.Form;//
            }

            return View(company);
        }

        [HttpPost]
        public ActionResult EditCompany(Company company)
        {
            if (company.Id == default)
            {
                Response.Redirect("/Home/");//Переход на форму
            }
            else
            {
                workerContext.Entry(company).State = EntityState.Modified;//Обновляем запись в БД
            }
            workerContext.SaveChanges();//Сохраняем 
            Response.Redirect("/Home/Companies/");//Переход на форму
            return View();
        }
    }
}