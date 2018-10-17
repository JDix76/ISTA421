--AUTHOR:JAMES DIX
--DATE: 16 OCT 2018
--SUBJECT:MVCLAB#07

namespace WorkingWithVisualStudio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
namespace WorkingWithVisualStudio {
    public class Startup {


        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
namespace WorkingWithVisualStudio {
    public class Startup {


        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
namespace WorkingWithVisualStudio.Models {
    public class SimpleRepository : IRepository {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products
            = new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository => sharedRepository;

        public SimpleRepository() {
            var initialItems = new[] {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19.50M },
                new Product { Name = "Corner flag", Price = 34.95M }
            };
            foreach (var p in initialItems) {
                AddProduct(p);
            }
            products.Add("Error", null);
        }

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
namespace WorkingWithVisualStudio.Controllers {
    public class HomeController : Controller {
        public IRepository Repository = SimpleRepository.SharedRepository;

        public IActionResult Index() => View(Repository.Products);

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p) {
            Repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}
namespace WorkingWithVisualStudio.Models {

    public interface IRepository {

        IEnumerable<Product> Products { get; }
        void AddProduct(Product p);
    }
}
namespace WorkingWithVisualStudio.Models {

    public class Product {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
