﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGamer.Application.Interfaces;
using TechGamer.Application.ViewModel;
using TechGamer.Domain.Entities;
using TechGamer.Domain.Interfaces;
using TechGamer.Domain.Shared.Transaction;

namespace TechGamer.Application.Services
{
    public class BasketAppService : BaseService, IBasketAppService
    {
        protected readonly IBasketRepository _repository;
        protected readonly IMapper _mapper;
        protected readonly IBasketItemRepository _itemRepository;
        protected readonly IProductRepository _productRepository;

        public BasketAppService(IBasketRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus,
            IBasketItemRepository itemRepository,
            IProductRepository productRepository) : base(unitOfWork, bus)
        {
            _repository = repository;
            _mapper = mapper;
            _itemRepository = itemRepository;
            _productRepository = productRepository;
        }

        public BasketViewModel AddBasket(BasketViewModel viewModel)
        {
            var domain = _mapper.Map<Basket>(viewModel);
            domain = _repository.Add(domain);
            Commit();

            var viewModelReturn = _mapper.Map<BasketViewModel>(domain);
            return viewModelReturn;
        }

        public IEnumerable<BasketItemViewModel> AddItemBasket(BasketItemViewModel viewModel)
        {
            var basket = _repository.GetById(viewModel.BasketId);
            if (basket != null)
            {
                if (basket.Items != null &&
                    basket.Items.Where(b => b.Id == viewModel.Id).Any())
                {
                    var item = basket.Items.FirstOrDefault(bi => bi.Id == viewModel.Id);
                    item.SetAmount(item.Amount + viewModel.Amount);
                    item = _itemRepository.Update(item);
                }
                else
                {
                    var item = _mapper.Map<BasketItem>(viewModel);
                    _ = _itemRepository.Add(item);
                }

                Commit();

                var basketFinal = _repository.GetById(viewModel.BasketId);

                foreach (var item in basketFinal.Items)
                {
                    if (item.Product == null)
                    {
                        item.SetProduct(_productRepository.
                            GetById(item.ProductId));
                    }
                }

                var items = _mapper.Map<IEnumerable<BasketItemViewModel>>(basketFinal.Items);
                return items;
            }
            else
            {
                throw new Exception("BasketId incorreto");
            }

        }

        public void ClearBasket(Guid basketId)
        {
            _itemRepository.Remove(bi => bi.BasketId == basketId);
            Commit();
        }

        public BasketViewModel GetById(Guid id)
        {
            var domain = _repository.GetById(id);
            var viewModel = _mapper.Map<BasketViewModel>(domain);
            return viewModel;
        }

        //TODO: Novo
        public IEnumerable<BasketItemViewModel> RemoveItemBasket(Guid basketId, Guid productId)
        {
            var item = _itemRepository.Search(bi => bi.BasketId == basketId &&
            bi.ProductId == productId);

            if (item != null)
            {
                return RemoveItemBasket(item.FirstOrDefault().Id);
            }
            else
            {
                throw new Exception("Item não encontrado");
            }
        }

        public IEnumerable<BasketItemViewModel> RemoveItemBasket(Guid idBasketItem)
        {
            _itemRepository.Remove(idBasketItem);
            Commit();

            var basketFinal = _repository.GetById(idBasketItem);
            var items = _mapper.Map<IEnumerable<BasketItemViewModel>>(basketFinal.Items);
            return items;
        }

        //TODO: Alterar aqui
        public void UpdateItemQuantity(BasketItemViewModel item, int quantity)
        {
            var domain = _mapper.Map<BasketItem>(item);
            domain.SetAmount(quantity);
            _ = _itemRepository.Update(domain);
            Commit();
        }
    }
}
