using MediatR;

namespace APICQRSDemo.Commands.Create
{
    public class CreateProductCommand : IRequest<long>
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}
