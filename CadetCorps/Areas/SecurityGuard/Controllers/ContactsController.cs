using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadetCorps.Areas.SecurityGuard.ViewModels.Contacts;
using CadetCorps.Core.Interfaces;

namespace CadetCorps.Areas.SecurityGuard.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            var viewModel = new CreateContactsViewModel { MembersId = id };

            return View("Create", viewModel);
        } 

        [HttpPost]
        public ActionResult Create(CreateContactsViewModel viewModel)
        {
            _contactsService.CreateUser(viewModel);

            return RedirectToAction("Edit", "Members", new { area = "SecurityGuard", id = viewModel.MembersId });
        }
 
        public ActionResult Edit(int id)
        {

            var viewModel = _contactsService.GetContacts(id);
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditCreateViewModel viewModel)
        {

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
