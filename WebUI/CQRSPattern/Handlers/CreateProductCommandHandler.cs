using WebUI.CQRSPattern.Comments;
using WebUI.DAL;
using WebUI.DAL.Context;

namespace WebUI.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                Brand = command.Brand,
                Category = command.Category,
                ProductName = command.ProductName,
                Price = command.Price,
                Stock = command.Stock
            });
            _context.SaveChanges();
        }
    }
}
