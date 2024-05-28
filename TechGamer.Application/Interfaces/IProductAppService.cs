using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Application.ViewModel;
using TechGamer.Domain.Entities;

namespace TechGamer.Application.Interfaces
{
    public interface IProductAppService
    {
        ProductViewModel GetById(Guid id);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> expression);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> expression,
            int pageNumber,
            int pageSize);
        ProductViewModel Add(ProductViewModel viewModel);
        ProductViewModel Update(ProductViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Product, bool>> expression);
        void UpdateStock(Guid productId, int quantity);
        int CheckQuantityStock(Guid productId);
    }
}
