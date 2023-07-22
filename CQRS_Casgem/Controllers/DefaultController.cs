using CQRS_Casgem.CQRSPattern.Commands;
using CQRS_Casgem.CQRSPattern.Commends;
using CQRS_Casgem.CQRSPattern.Handlers;
using CQRS_Casgem.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Casgem.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductGetByIdQueryHandler _getProductGetByIdQueryHandler;
        private readonly GetProductUpdateByIdQueryHandler _getProductUpdateByIdQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductGetByIdQueryHandler getProductGetByIdQueryHandler, GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductGetByIdQueryHandler = getProductGetByIdQueryHandler;
            _getProductUpdateByIdQueryHandler = getProductUpdateByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {

            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(int id)
        {
            var values = _getProductGetByIdQueryHandler.Handle(new GetProductGetByIdQuery(id));
            return View(values);
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
