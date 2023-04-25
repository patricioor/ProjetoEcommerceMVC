using CleanArchMvc.Domain.Entities;
using MediatR;


namespace CleanArchMvc.Application.Products.Queries
{
    public class GetProcuctByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProcuctByIdQuery(int id)
        {
            Id = id;
        }
    }
}
