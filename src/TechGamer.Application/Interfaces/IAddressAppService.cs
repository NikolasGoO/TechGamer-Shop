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
    public interface IAddressAppService
    {
        AddressViewModel GetById(Guid id);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression,
            int pageNumber,
            int pageSize);
        AddressViewModel Add(AddressViewModel viewModel);
        AddressViewModel Update(AddressViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Address, bool>> expression);
    }
}
