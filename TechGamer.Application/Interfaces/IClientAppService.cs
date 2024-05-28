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
    public interface IClientAppService
    {
        ClientViewModel GetById(Guid id);
        IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> expression);
        IEnumerable<ClientViewModel> Search(Expression<Func<Client, bool>> expression,
            int pageNumber,
            int pageSize);
        ClientViewModel Add(ClientViewModel viewModel);
        ClientViewModel Update(ClientViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Client, bool>> expression);
        ClientViewModel SetAddAddressClient(Guid clientId, AddressViewModel addressViewModel);
    }
}
