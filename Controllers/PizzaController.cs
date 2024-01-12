using Microsoft.AspNetCore.Mvc;
using AspNetMVC.Models;
using System.Collections.Generic;

public class PizzaController : Controller
{
    public IActionResult RegisterUser()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterUser(User user)
    {
        if (user.Age >= 16)
        {
            var products = new List<Product>
            {
                new Product { Name = "Маргарита", Quantity = 0 },
                new Product { Name = "Пепероні", Quantity = 0 },
                new Product { Name = "Вегетаріанська", Quantity = 0 }
            };
            user.Products = products; // Присвоїти продукти користувачеві
            return View("OrderPizza", user);

        }
        else
        {
            return Content("Sorry, you must be at least 16 years old to order.");
        }
    }

    [HttpPost]
    public IActionResult OrderPizza(User user)
    {
        return View("OrderSummary", user);
    }

    [HttpPost]
    public IActionResult OrderSummary(List<Product> products)
    {
        return View(products);
    }
}
