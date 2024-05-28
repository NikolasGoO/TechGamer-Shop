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
    public interface IPaymentMethodAppService
    {
        PaymentMethodViewModel GetById(Guid id);
        IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> expression);
        IEnumerable<PaymentMethodViewModel> Search(Expression<Func<PaymentMethod, bool>> expression,
            int pageNumber,
            int pageSize);
        PaymentMethodViewModel Add(PaymentMethodViewModel viewModel);
        PaymentMethodViewModel Update(PaymentMethodViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<PaymentMethod, bool>> expression);
    }
}
