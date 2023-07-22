using WebUI.CQRSPattern.Results;
using WebUI.DAL.Context;

namespace WebUI.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x => new GetProductQueryResult
            {
                ProductName = x.ProductName,
                Brand=x.Brand,
                Category=x.Category,
                Price=x.Price,
                Stock=x.Stock,
            }).ToList();

            return values;
        }
    }
}
