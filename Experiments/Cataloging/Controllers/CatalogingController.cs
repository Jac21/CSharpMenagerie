using System.Reflection;
using Cataloging.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cataloging.Controllers
{
    public class CatalogingController : Controller
    {
        // GET: Cataloging
        public ActionResult Index()
        {
            var markerType = typeof(Program);

            var controllers =
                (from t in markerType.Assembly.GetTypes()
                    where !t.IsAbstract && t.IsPublic && typeof(Controller).IsAssignableFrom(t)
                    let m = t.GetMethods(BindingFlags.Instance
                                         | BindingFlags.DeclaredOnly
                                         | BindingFlags.Public)
                        .Where(m => !m.GetCustomAttributes<NonActionAttribute>().Any())
                    let c = t.GetConstructors().First()
                    select new CatalogingInfoModel
                    {
                        Type = t,
                        Actions = m,
                        Constructor = c,
                    }).ToList();

            Console.WriteLine(controllers.Count.ToString());
            Console.WriteLine(controllers.SelectMany(c => c.Actions).Count().ToString());

            foreach (var controller in controllers)
            {
                Console.WriteLine(
                    $"{controller.Type.FullName}\t{controller.Actions.Count()}\t{controller.Constructor.GetParameters().Length}");
            }

            return View(controllers);
        }
    }
}