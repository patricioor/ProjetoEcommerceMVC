using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProdutcs()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery == null) throw new Exception($"Entuty could not be loaded");
            
            var result = await _mediator.Send(productsQuery);
            
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProcuctByIdQuery(id.Value);

            if (productByIdQuery == null) throw new ArgumentNullException($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //herdado pelo método GetById
        //public async Task<ProductDTO> GetProductCategory(int? categoryId)
        //{
        //    var productByQueryCategoryId = new GetProcuctByIdQuery(categoryId.Value);

        //    if (productByQueryCategoryId == null) throw new ArgumentNullException($"Entity could not be loaded.");

        //    var result = await _mediator.Send(productByQueryCategoryId);
        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null) throw new ArgumentNullException($"Entity could not be loaded");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
