using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AoqibaoStore.Models;
using AoqibaoStore.Abstract;

namespace AoqibaoStore.Controllers
{
    public class ContactController : Controller
    {
        private IContactProcessor contactProcessor;

        public ContactController(IContactProcessor contactc)
        {
            contactProcessor = contactc;
        }
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Complete(string name,string phone,string email,string body)
        {

            Contact contact = new Contact();
            contact.name = name;
            contact.phone = phone;
            contact.email = email;
            contact.body = body;

            if (ModelState.IsValid)
            {
                contactProcessor.ProcessContact(contact);
                return View("Completed");
            }


            return View();
        }
    }
}
