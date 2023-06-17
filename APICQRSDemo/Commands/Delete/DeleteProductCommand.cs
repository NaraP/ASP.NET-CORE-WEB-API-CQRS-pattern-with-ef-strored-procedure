using MediatR;

namespace APICQRSDemo.Commands.Delete
{
    public class DeleteProductCommand :IRequest<long>
    {
        public long ProductId { get; set; }
    }
}
