using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project19.ContextFolder;
using Project19.Entitys;

namespace Project19.Controllers
{
    public class MyDefaultController : Controller
    {
        static Contact concreteContact = new Contact()
        {
            ID = 0,
            Name = "",
            Surname = "",
            FatherName = "",
            TelephoneNumber = "",
            ResidenceAdress = "",
            Description = ""
        };

        static int currentId;

        public IActionResult Index()
        {
            ViewBag.Contacts = new DataContext().Contacts;
            return View();
        }

        /// <summary>
        /// Метод открытия нового View для добавления контакта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        /// <summary>
        /// Асинхронный метод, принимающий параметр int id. В методе 
        /// происходит перебор базы данных по параметру ID. Если параметр 
        /// совпадает, то данный контакт кешируется в статическую 
        /// переменную concreteContact и возвращается ключевым словом
        /// return для дальнейшего использования в качестве модели. 
        /// При этом происходит сохранение текущего id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            using (var db = new DataContext())
            {
                await
                foreach (var contact in db.Contacts)
                {
                    if (contact.ID == id)
                    {
                        currentId = id;
                        concreteContact = contact;
                    }
                }
                return View(concreteContact);
            }
        }
        
        /// <summary>
        /// Асинхронный метод, принимающий в себя параметры строкового
        /// типа. В данном методе происходит перебор базы данных в 
        /// цикле foreach, где в результате совпадения параметра ID
        /// с текущим закешированным currentID произойдет замена
        /// параметров текущего экземпляра Contact на указанные во 
        /// View. По окончанию происходит сохранение данных методом
        /// SaveChangesAsync и возврат на стартовую страницу.
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="residenceAdress"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangeDataFromViewField(string surname, string name,
        string fatherName, string telephoneNumber, string residenceAdress,
        string description)
        {
            using (var db = new DataContext())
            {
                await
                foreach (var contact in db.Contacts)
                {
                    if (contact.ID == currentId)
                    {
                        contact.Surname = surname;
                        contact.Name = name;
                        contact.FatherName = fatherName;
                        contact.TelephoneNumber = telephoneNumber;
                        contact.ResidenceAdress = residenceAdress;
                        contact.Description = description;
                        break;
                    }   
                }
                await db.SaveChangesAsync();
            }
            return Redirect("~/");
        }

        /// <summary>
        /// Асинхронный метод, принимающий в себя параметры строкового
        /// типа. В данном методе происходит добавление в базу данных
        /// нового контакта с параметрами, указанными во View. По
        /// окончанию происходит сохранение данных с помощью метода
        /// SaveChangesAsync и возврат на стартовую страницу.
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="telephoneNumber"></param>
        /// <param name="residenceAdress"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetDataFromViewField(string surname, string name,
        string fatherName, string telephoneNumber, string residenceAdress,
        string description)
        {
            await
            using (var db = new DataContext())
            {
                db.Contacts.Add(
                    new Contact()
                    {
                        Surname = surname,
                        Name = name,
                        FatherName = fatherName,
                        TelephoneNumber = telephoneNumber,
                        ResidenceAdress = residenceAdress,
                        Description = description
                    });
                await db.SaveChangesAsync();
            }
            return Redirect("~/");
        }

        /// <summary>
        /// Метод, возвращающий экземпляр класса Contact с указанным id, 
        /// данный метод принимает в себя int id. В методе происходит
        /// запуск цикла foreach, в котором сравнивается параметр ID с 
        /// принимаемым id. При совпадении происходит кеширование 
        /// экземпляра Contact в статическую переменную concreteContact 
        /// и возвращение этого экземпляра для использования в качестве
        /// модели.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            using (var db = new DataContext()) 
            { 
                foreach(var contact in db.Contacts)
                {
                    if (contact.ID == id)
                    {
                        concreteContact = contact;
                        break;
                    }
                }
            }
            return View(concreteContact);
        }

        /// <summary>
        /// Асинхронный метод возвращающий экземпляр типа Contact
        /// во View,принимающий переменную int id, в котором 
        /// происходит проверка базы данных по параметру ID. 
        /// Если параметр совпадает, то данный контакт кешируется
        /// в экземпляр типа Contact и с помощью ключевого слова 
        /// return происходит возврат экземпляра в action метод
        /// во View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            Contact newConcreteContact = new Contact()
            {
                ID = 0,
                Name = "",
                Surname = "",
                FatherName = "",
                TelephoneNumber = "",
                ResidenceAdress = "",
                Description = ""
            };

            if (id == null)
            {
                return NotFound();
            }
            using (var db = new DataContext())
            {
                await
                foreach (var contact in db.Contacts)
                {
                    if(contact.ID == id)
                    {
                        newConcreteContact = contact;
                        break;
                    }
                }
                //var contact = await db.Contacts.FirstOrDefaultAsync
                //                    (m => m.ID == id);
                //if (contact == null)
                //{
                //    return NotFound();
                //}
                //return View(contact);
            }
            return View(newConcreteContact);
        }

        /// <summary>
        /// Асинхронный метод, принимающий переменную int id.
        /// Атрибут ActionName("Delete") говорит о том, что
        /// данный метод будет вызван в результате action метода
        /// в представлении Index.cshtml.
        /// В данном методе, в цикле foreach происходит перебор
        /// базы данных на условие совпадения совпадения 
        /// параметра ID контакта с принимаемым id, после чего
        /// происходит удаление элемента базы данных, сохранение
        /// данных методом SaveChangesAsync и возврат на
        /// стартовую страницу.
        /// в котором происходит 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var db = new DataContext())
            {
                if (db.Contacts == null)
                {
                    return Problem("Entity set 'DataContext.Contact'  is null.");
                }

                await
                foreach (var cont in db.Contacts)
                {
                    if (cont.ID == id)
                    {
                        db.Contacts.Remove(cont);
                        break;
                    }
                }
                await db.SaveChangesAsync();
                return Redirect("~/");
                //var contact = await db.Contacts.FindAsync(id);
                //db.Contacts.Remove(contact);
                //await db.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult NewLayout()
        {
            ViewData["Tittle"] = "NewLayout";
            return View();
        }
    }
}
