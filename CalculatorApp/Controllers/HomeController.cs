using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the selected condition based on the selectedCondition value
                var selectedCondition = model.Conditions.FirstOrDefault(c => c.NHSWaitTime == model.selectedCondition);

                if(model.selectedCondition == 1)
                {
                    selectedCondition = new Condition("Custom", model.CustomWaitTime, 0);
                }

                if (selectedCondition != null)
                {
                    // Perform calculation based on the selected condition
                    model.Result1 = selectedCondition.NHSWaitTime * (model.Income/52);
                    if (selectedCondition.Name != "Custom")
                    {
                        model.Result2 = selectedCondition.PrivateCost;

                    }
                }
            }

            return View("Index", model);
        }
    }
}
