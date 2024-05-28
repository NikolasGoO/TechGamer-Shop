﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Application.Interfaces;
using TechGamer.Application.ViewModel;
using TechGamer.Domain.Entities;
using TechGamer.Domain.Interfaces;
using TechGamer.Domain.Shared.Transaction;

namespace TechGamer.Application.Services
{
    public class AddressAppService : BaseService, IAddressAppService
    {
        protected readonly IAddressRepository _repository;
        protected readonly IMapper _mapper;

        public AddressAppService(IAddressRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AddressViewModel Add(AddressViewModel viewModel)
        {
            Address domain = _mapper.Map<Address>(viewModel);
            domain = _repository.Add(domain);
            Commit();

            AddressViewModel viewModelReturn = _mapper.Map<AddressViewModel>(domain);
            return viewModelReturn;
        }

        public AddressViewModel GetById(Guid id)
        {
            Address address = _repository.GetById(id);
            AddressViewModel addressViewModel = _mapper.Map<AddressViewModel>(address);
            return addressViewModel;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Address, bool>> expression)
        {
            _repository.Remove(expression);
            Commit();
        }

        public IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression)
        {
            var addresses = _repository.Search(expression);
            var addressesViewModel = _mapper.Map<IEnumerable<AddressViewModel>>(addresses);
            return addressesViewModel;
        }

        public IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression,
            int pageNumber,
            int pageSize)
        {
            var addresses = _repository.Search(expression, pageNumber, pageSize);
            var addressesViewModel = _mapper.Map<IEnumerable<AddressViewModel>>(addresses);
            return addressesViewModel;
        }


        public AddressViewModel Update(AddressViewModel viewModel)
        {
            var address = _mapper.Map<Address>(viewModel);
            address = _repository.Update(address);
            Commit();

            var addressViewModel = _mapper.Map<AddressViewModel>(address);
            return addressViewModel;
        }
    }
}
