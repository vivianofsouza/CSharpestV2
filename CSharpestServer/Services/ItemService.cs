﻿using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CSharpestServer.Services
{
    public class ItemService : IItemService
    {
        private readonly StoreContext _storeContext;

        public ItemService(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Task ChangeStock(Guid itemId, int quantity, bool addOrRemove)
        {
            Item? _item = _storeContext.items.Find(itemId);
            if (_item == null)
            {
                throw new InvalidOperationException($"Item with ID {itemId} not found.");
            }

            if (addOrRemove) //True: add
            {
                _item.Stock += quantity;
            }
            else //False: remove
            {
                if (quantity > _item.Stock) { _item.Stock = 0; }
                else { _item.Stock -= quantity; }
            }

            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ChangePriceAsync(Guid itemId, decimal price)
        {
            Item? _item = _storeContext.items.Find(itemId);
            if (_item == null)
            {
                throw new InvalidOperationException($"Item with ID {itemId} not found.");
            }

            if (price >= 0)
            {
                _item.Price = price;
            } else
            {
                throw new InvalidOperationException("Item cannot have negative price");
            }

            _storeContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddItem(Item item)
        {
            
            if (_storeContext.items == null)
            {
                throw new InvalidOperationException("Error loading items database");
            }

            try {
                _storeContext.items.Add(item);
                _storeContext.SaveChanges();

            } catch {
                throw new InvalidOperationException($"Error adding {item.Name} to database");
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Item>> GetAllAsync()
        {
            return Task.FromResult(_storeContext.items.AsEnumerable());
        }

        public Task RemoveItem(Guid id)
        {
            try
            {
                var item = _storeContext.items.Find(id);

                if (item == null)
                {
                    throw new InvalidOperationException($"Could not find item {id}");
                }

                _storeContext.items.Remove(item);
                _storeContext.SaveChanges();

            } catch
            {
                throw;
            }

            return Task.CompletedTask;
        }
    }
}
