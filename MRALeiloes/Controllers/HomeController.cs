using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MRALeiloes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading.Tasks;

namespace MRALeiloes.Controllers
{
    public class HomeController : Controller
    {
        public Produto Produto { get; set; }
        public Leilao LeilaoObj { get; set; }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
            Produto = new Produto("VanGogh", 120000, 0.00);
            LeilaoObj = new Leilao("Raros", Produto);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Leilao()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public IActionResult ReceberLance([Bind("Participante", "Valor")] Lance lance)
        {   
            try
            {
                LeilaoObj.RecebeLance(lance);
                lance.Participante.DarLance(lance);
                TempData["Message"] = "Lance registrado!";
            }
            catch (Exception e)
            {
                TempData["MessageErro"] = e.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
