using DataLayer;
using HomeIO.Models.Entities;
using HomeIO.Models.Repositories;
using HomeIO.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomeIO.Controllers
{
    public class RecordController : Controller
    {
        private RecordRepository RecordRepo { get; set; }
        private RecordViewRepository RecordsRepo { get; set; }
        private TypeRepository TypeRepo { get; set; }

        public RecordController()
        {
            this.RecordRepo = new RecordRepository();
            this.RecordsRepo = new RecordViewRepository();
            this.TypeRepo = new TypeRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            
            return View(TypeRepo.GetAll());
        }

        [HttpPost]
        public ActionResult New(Record record)
        {
            RecordRepo.Create(record);
            return View("Thanks", record);
        }

        public ActionResult List()
        {
            var list = RecordsRepo.GetAll();
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            return View(new EditPageViewModel(id));
        }

        [HttpPost]
        public ActionResult Edit(Record record)
        {
            RecordRepo.Update(record);
            return View("Thanks", record);
        }

        public ActionResult Delete(int id)
        {
            RecordRepo.Delete(id);
            return RedirectToAction("List");
        }
    }
}