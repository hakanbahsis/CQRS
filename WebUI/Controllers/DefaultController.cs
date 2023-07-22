using Microsoft.AspNetCore.Mvc;
using WebUI.CQRSPattern.Comments;
using WebUI.CQRSPattern.Handlers;
using WebUI.CQRSPattern.Queries;
using WebUI.CQRSPattern.Results;

namespace WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly GetProductUpdateByIdQueryHandler _getProductUpdateByIdQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _getProductUpdateByIdQueryHandler = getProductUpdateByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct() { return View(); }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(RemoveProductCommand command)
        {
            _removeProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetProductById(GetProductByIdQuery query) 
        {
            _getProductByIdQueryHandler.Handle(query);
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
