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

        /// <summary>
        /// Detail get method
        /// </summary>
        /// <param name="id">target id</param>
        /// <returns>return some action</returns>
        public ActionResult Details(int id)
        {
            var service = new DataService();
            var person = service.GetPerson(id);

            return this.View(
                new ContactView()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Id = person.Id
            });
        }

        // GET: PhoneBook/Create

        /// <summary>
        /// Create some person
        /// </summary>
        /// <returns>Return create action</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: PhoneBook/Create

        /// <summary>
        /// Create Post action
        /// </summary>
        /// <param name="contactView"></param>
        /// <returns>Do create action</returns>
        [HttpPost]
        public ActionResult Create(ContactView contactView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new DataService();
                    service.Add(new Person { Name = contactView.Name, PhoneNumber = contactView.PhoneNumber });
                    return this.RedirectToAction("Index");
                }

                return this.View();
            }
            catch
            {
                return this.View();
            }
        }

        // GET: PhoneBook/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new DataService();
            var person = service.GetPerson(id);

            return this.View(new Person
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Id = person.Id
            });
        }

        // POST: PhoneBook/Edit/5

        /// <summary>
        /// Post some edit action
        /// </summary>
        /// <param name="id">target id</param>
        /// <param name="targetPerson">new values</param>
        /// <returns>Do edit action</returns>
        [HttpPost]
        public ActionResult Edit(int id, Person targetPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new DataService();
                    service.UpdatePerson(
                        id,
                        new Person { Name = targetPerson.Name, PhoneNumber = targetPerson.PhoneNumber, });

                    return this.RedirectToAction("Index");
                }

                return this.View();
            }
            catch
            {
                return this.View();
            }
        }

        // GET: PhoneBook/Delete/5

        /// <summary>
        /// Post delete action
        /// </summary>
        /// <param name="id">target id</param>
        /// <returns>get some action</returns>
        public ActionResult Delete(int id)
        {
            var service = new DataService();
            var person = service.GetPerson(id);

            return this.View(new Person
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Id = person.Id
            });
        }

        // POST: PhoneBook/Delete/5

        /// <summary>
        /// Do delete action
        /// </summary>
        /// <param name="id">target id</param>
        /// <param name="targetPerson">new values</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, Person targetPerson)
        {
            try
            {
                var service = new DataService();
                service.Remove(id);

                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }
    }
}
