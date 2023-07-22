﻿using Microsoft.AspNetCore.Mvc;
using WebUI.CQRSPattern.Handlers;

namespace WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }
    }
}