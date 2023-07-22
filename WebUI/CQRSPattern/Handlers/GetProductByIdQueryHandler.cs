using WebUI.CQRSPattern.Queries;
using WebUI.CQRSPattern.Results;
using WebUI.DAL;
using WebUI.DAL.Context;

namespace WebUI.CQRSPattern.Handlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly Context _context;

        public GetProductByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIdQueryResult Handle(GetProductByIdQuery query)
        {
            var values = _context.Set<Product>().Find(query.Id);

            return new GetProductByIdQueryResult
            {
                Id=values.Id,
                ProductBrand = values.Brand,
                ProductName=values.ProductName
            };
        }
    }
}
