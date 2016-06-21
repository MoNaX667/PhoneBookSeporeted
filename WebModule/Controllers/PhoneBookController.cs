/// <summary>
/// View of contact list
/// </summary>
namespace WebModule.Controllers
{
    using PhoneBookCore;
    using System.Linq;
    using System.Web.Mvc;
    using WebModule.Models;

    /// <summary>
    /// Phone book controller
    /// </summary>
    public class PhoneBookController : Controller
    {
        // GET: PhoneBook

        /// <summary>
        /// index method show start page data
        /// </summary>
        /// <returns>Action of default</returns>
        public ActionResult Index()
        {
            var service = new DataService();
            return this.View(
                service.GetPersonList().ToList().Select(selectedPerson =>
                new ContactView
                {
                    Id = selectedPerson.Id,
                    Name = selectedPerson.Name,
                    PhoneNumber = selectedPerson.PhoneNumber
                }));
        }

        // GET: PhoneBook/Details/5
        public ActionResult Details(int id)
        {
            var service = new DataService();
            var person = service.GetPerson(id);
            return View(new ContactView()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Id = person.Id
            });
        }

        // GET: PhoneBook/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: PhoneBook/Create
        [HttpPost]
        public ActionResult Create(ContactView contactView)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var service = new DataService();
                    service.Add(new Person { Name = contactView.Name, PhoneNumber = contactView.PhoneNumber });
                    return RedirectToAction("Index");
                }

                return View();

                return RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }

        // GET: PhoneBook/Edit/5
        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // POST: PhoneBook/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }

        // GET: PhoneBook/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: PhoneBook/Delete/5
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
                return this.View();
            }
        }
    }
}
