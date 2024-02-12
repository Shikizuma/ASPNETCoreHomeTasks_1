using ASPNETCoreHomeTasks_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreHomeTasks_1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductReader _reader;

        // УВАГА.
        // Кожен запит опрацьовує новий екземпляр контролера.
        // Конструктор буде викликатися перед викликом методу List та методу Details
        // Після обробки запиту, екземпляр контролера буде видалено з пам'яті
        public ProductsController()
        {
            _reader = new ProductReader();
        }

        // Products/List
        public IActionResult List()
        {
            List<Product> products = _reader.ReadFromFile();
            // Повернення уявлення List та передача уявленню моделі у вигляді колекції products
            // Отримати доступ до колекції у виставі можна буде через властивість представлення Model
            return View(products);
        }

        // Products/Details/1
        public IActionResult Details(int id)
        {
            List<Product> products = _reader.ReadFromFile();
            Product product = products.Where(x => x.Id == id).FirstOrDefault();

            if (product != null)
            {
                // Повернення представлення з ім'ям Details та передача представлення екземпляра product
                // Надання доступу до екземпляру можна отримати через властивість представлення Model
                return View(product);
            }
            else
            {
                // Повернення помилки 404
                return NotFound();
            }
        }
    }
}