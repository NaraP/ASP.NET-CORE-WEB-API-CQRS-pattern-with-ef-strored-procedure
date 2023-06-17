using MediatR;

namespace APICQRSDemo.Commands.Update
{
    public class UpdateProductCommand: IRequest<long>
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}
