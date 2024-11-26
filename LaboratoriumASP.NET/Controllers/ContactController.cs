﻿using LaboratoriumASP.NET.Models;
using LaboratoriumASP.NET.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaboratoriumASP.NET.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        public ActionResult Index()
        {
            return View(_contactService.GetAll());
        }
        
        public ActionResult Add()
        {
            var model = new ContactModel();
            model.Organizations = _contactService
                .FindAllOrganizations()
                .Select(o => new SelectListItem()
                {
                    Value = o.Id.ToString(),
                    Text = o.Name,
                    Selected = o.Id == 1
                }).ToList();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _contactService.Add(model);
            return RedirectToAction(nameof(Index)); 
        }
        
        public ActionResult Edit(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); 
            }
            return View(contact);
        }

       
        [HttpPost]
        public ActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _contactService.Update(model);
            return RedirectToAction(nameof(Index)); 
        }

        
        public ActionResult Delete(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); 
            }
            return View(contact);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }
        public ActionResult Details(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); 
            }
            return View(contact);
        }

    }
}