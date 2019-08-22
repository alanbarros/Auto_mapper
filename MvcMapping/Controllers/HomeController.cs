using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MvcMapping.Models;
using MvcMapping.ViewModels;

namespace MvcMapping.Controllers
{
    public class HomeController : Controller
    {
        IMapper _mapper;
        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var usuario = new Cliente
            {
                Nome = "Alan",
                Sobrenome = "Barros",
                DataNascimento = new DateTime(1993, 04, 17),
                Ativo = true,
                //NumeroDaSorte = 17
            };

            var viewModel = _mapper.Map<Cliente, ClienteViewModel>(usuario);
            //var viewModel = _mapper.Map<ClienteViewModel, Cliente>(usuario);
            return View(viewModel);
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
    }
}
