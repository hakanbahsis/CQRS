using WebUI.CQRSPattern.Queries;
using WebUI.CQRSPattern.Results;
using WebUI.DAL.Context;

namespace WebUI.CQRSPattern.Handlers
{
    public class GetProductUpdateByIdQueryHandler
    {
        private readonly Context _context;
        public GetProductUpdateByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateByIdQueryResult Handle(GetProductUpdateByIdQuery query)
        {
            var value = _context.Products.Find(query.Id);
            return new GetProductUpdateByIdQueryResult
            {
                Brand = value.Brand,
                Category = value.Category,
                ProductName = value.ProductName,
                Price = value.Price,
                Id = value.Id,
                Stock = value.Stock
            };
        }
    }
}
