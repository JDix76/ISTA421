--AUTHOR:JAMES DIX
--DATE: 4 OCT 2018
--SUBJECT:ASPNETMVCLAB06

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            var initialItems = new[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            foreach (var p in initialItems)
            {
                AddProduct(p);
            }
            products.Add("Error", null);
        }

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(SimpleRepository.SharedRepository.Products
            .Where(p => p.Price < 50));
        
    }
}
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>WorkingWithVisualStudio</title>
</head>
<body>
    <h1> My <span style="font-size:24pt; color: aqua; background-color: #333333; border: 4px outset green; padding: 12px; ">Wonderful</span>Products</h1>
    <table>
        <thead>
            <tr><td>Name</td><td>Price</td></tr> 
        </thead>
        <tbody>
            @foreach (var p in Model)
               {<tr>
                    <td>@p.Name</td>
                    <td> @($"{p.Price:C2}") </td>
               </tr>
             } 
            </tbody>
    </table>
</body>
</html>
namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            var initialItems = new[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };

            foreach (var p in initialItems)
            {
                AddProduct(p);
            }
            products.Add("Error", null);
        }

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}

