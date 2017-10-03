using System;
using System.Collections.Generic;
using PizzaPlanet.Models.DTO;
using PizzaPlanet.Models.VM;

namespace  PizzaPlanet.Repositories
{
    public interface IPizzaPlanetRepository
    {
        IEnumerable<MenuItemDto> GetMenuItems();
        MenuItemDto GetMenuItemsById(int menuItemId);
        void AddMenuItem(MenuItemViewModel menuItem);
        void DeleteMenuItem(int menuItemId);

         IEnumerable<OrderLiteDto> GetOrders();
        OrderDto GetOrderById(int orderId);
        void AddOrder(OrderViewModel order);
        void DeleteOrder(int orderId);
    }
}
