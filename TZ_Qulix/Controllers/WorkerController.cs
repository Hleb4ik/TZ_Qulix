using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TZ_Qulix.Models;
using System.Data.Entity;

namespace TZ_Qulix.Controllers
{
    public class WorkerController : Controller
    {
        WorkerContext workerContext = new WorkerContext();

        //Добавление работника--------------------------------------------------
        [HttpGet]
        public ActionResult AddWorker(int id = 1)
        {
            ViewBag.Id = id;//Присваиваем id

            return View();
        }

        [HttpPost]
        public ActionResult AddWorker(Worker worker)
        {
            workerContext.Workers.Add(worker);//Записываем данные в БД

            workerContext.SaveChanges();//Сохраняем 

            Response.Redirect("/Home/Workers/");//Переход на форму

            return View();
        }
        //----------------------------------------------------------------------

        //Удаление работника------------------------------------------------------------
        public ActionResult DeletedWorker(int id)
        {
            Worker worker = workerContext.Workers.FirstOrDefault(g => g.Id == id);//Получаем ID записи в БД
            Worker dbEntry = workerContext.Workers.Find(worker.Id);//Присваиваем
            if (dbEntry != null)//Проверяем чтобы ID не был равен 0
            {
                workerContext.Workers.Remove(dbEntry);//Удаляем запись из БД с таким ID
                workerContext.SaveChanges();//Сохраняем 
            }
            workerContext.SaveChanges();//Сохраняем 
            Response.Redirect("/Home/Workers/");//Переход на форму
            return View();
        }
        //------------------------------------------------------------------------------

        //Редактирование----------------------------------------------------------------
        [HttpGet]
        public ActionResult EditWorker(int id)
        {
            ViewBag.Id = id;

            Worker worker = workerContext.Workers.FirstOrDefault(g => g.Id == id);//Получаем ID записи в БД
            Worker dbEntry = workerContext.Workers.Find(worker.Id);//Присваиваем
            if (dbEntry != null)//Проверяем чтобы ID не был равен 0
            {
                dbEntry.Surname = worker.Surname;//
                dbEntry.Name = worker.Name;//
                dbEntry.Otchestvo = worker.Otchestvo;//Присваиваем значение полям
                dbEntry.Date = worker.Date;//
                dbEntry.Post = worker.Post;//
                dbEntry.Company = worker.Company;//
            }

            return View(worker);
        }

        [HttpPost]
        public ActionResult EditWorker(Worker worker)
        {
            if (worker.Id == default)
            {
                Response.Redirect("/Home/");//Переход на форму
            }
            else
            {
                workerContext.Entry(worker).State = EntityState.Modified;//Обновляем запись в БД
            }
            workerContext.SaveChanges();//Сохраняем 
            Response.Redirect("/Home/Workers/");//Переход на форму
            return View();
        }
        //------------------------------------------------------------------------------
    }
}