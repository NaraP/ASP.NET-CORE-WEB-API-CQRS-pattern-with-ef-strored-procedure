using APICQRSDemo.Models;
using MediatR;

namespace APICQRSDemo.Queries
{
    public class GetProduct :IRequest<IEnumerable<Product>>
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}
