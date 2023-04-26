
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProdutcs();
        Task<ProductDTO> GetById(int? id);

        //herdado pelo método GetById
        //Task<ProductDTO> GetProductCategory(int? categoryId);

        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Delete(int? id);
    }
}
