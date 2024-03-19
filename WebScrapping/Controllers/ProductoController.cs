using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;

namespace WebScrapping.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult WebScrapping()
        {
            ML.Producto producto1 = new ML.Producto();
            producto1.Productos = new List<object>();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.mercadolibre.com.mx/#from=homecom");

            var inputSearch = driver.FindElement(By.ClassName("nav-search-input"));

            inputSearch.SendKeys("petacas miguel");
            inputSearch.Submit();

            var datos = driver.FindElements(By.ClassName("ui-search-layout__item"));    

            foreach (var prod in datos)
            {
                ML.Producto producto = new ML.Producto();

                var nombre = prod.FindElement(By.ClassName("ui-search-item__title"));
                producto.Nombre = nombre.Text;

                var rutaImagenElement = prod.FindElement(By.ClassName("ui-search-result-image__element"));
                producto.RutaImagen = rutaImagenElement.GetAttribute("src");

                var precioElement = prod.FindElement(By.ClassName("andes-money-amount__fraction"));
                producto.Precio = float.Parse(precioElement.Text, CultureInfo.InvariantCulture.NumberFormat);

                producto1.Productos.Add(producto);
            }

            return View(producto1);
        }

    }
}
