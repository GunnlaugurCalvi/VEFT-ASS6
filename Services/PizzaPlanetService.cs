using System;
using PizzaPlanet.Repositories;
using System.Collections.Generic;
using PizzaPlanet.Models.DTO;
using PizzaPlanet.Models.VM;
using Microsoft.Extensions.Caching.Memory;

namespace  PizzaPlanet.Services
{
    public class PizzaPlanetService : IPizzaPlanetService
    {
        private readonly IPizzaPlanetRepository _repo;

        private IMemoryCache _cache;

        public PizzaPlanetService(IPizzaPlanetRepository repo, IMemoryCache memorycache) 
        {
            _cache = memorycache;
            _repo = repo;
        }

        public IEnumerable<MenuItemDto> GetMenuItems() {
            IEnumerable<MenuItemDto> menuitems;
            if(!_cache.TryGetValue("menuitems", out menuitems)) {
                menuitems = _repo.GetMenuItems();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(8));

                _cache.Set("menuitems", menuitems, cacheEntryOptions);
            }
            return menuitems;
        }
        public MenuItemDto GetMenuItemsById(int menuItemId) {
            MenuItemDto menuitem;
            if(!_cache.TryGetValue(("menuitem_" + menuItemId.ToString()), out menuitem)) {
                menuitem = _repo.GetMenuItemsById(menuItemId);
                 var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(8));

                _cache.Set(("menuitem_" + menuItemId.ToString()), menuitem, cacheEntryOptions);
            }
            return menuitem;
        }
        public void AddMenuItem(MenuItemViewModel menuItem) {
            _repo.AddMenuItem(menuItem);
            _cache.Remove("menuitems");
        }
        public void DeleteMenuItem(int menuItemId) {
            _repo.DeleteMenuItem(menuItemId);
            _cache.Remove("menuitems");
            _cache.Remove("menuitem_" + menuItemId.ToString());
        }
        public IEnumerable<OrderLiteDto> GetOrders() {
            IEnumerable<OrderLiteDto> orders;
            if(!_cache.TryGetValue("orders", out orders)) {
                orders = _repo.GetOrders();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(8));

                _cache.Set("orders", orders, cacheEntryOptions);
            }
            return orders;
        }
        public OrderDto GetOrderById(int orderId) {
            OrderDto order;
            if(!_cache.TryGetValue(("order_" + orderId.ToString()), out order)) {
                order = _repo.GetOrderById(orderId);
                 var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(8));

                _cache.Set(("order_" + orderId.ToString()), order, cacheEntryOptions);
            }
            return order;
        }
        public void AddOrder(OrderViewModel order) {
            _repo.AddOrder(order);
            _cache.Remove("orders");
        }
        public void DeleteOrder(int orderId) {
            _repo.DeleteOrder(orderId);
            _cache.Remove("orders");
            _cache.Remove("order_" + orderId.ToString());
        }
    }
}
