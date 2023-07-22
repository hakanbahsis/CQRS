using WebUI.CQRSPattern.Comments;
using WebUI.DAL.Context;

namespace WebUI.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateProductCommand command)
        {
            var values = _context.Products.Find(command.Id);
            values.ProductName = command.ProductName;
            values.Brand = command.Brand;
            values.Category = command.Category;
            values.Stock = command.Stock;
            values.Price = command.Price;
            _context.SaveChanges();

        }
    }
}
