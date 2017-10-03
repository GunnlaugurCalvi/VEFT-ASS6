using System;
using System.Collections.Generic;
using PizzaPlanet.Models.DTO;
using PizzaPlanet.Models.VM;

namespace  PizzaPlanet.Services
{
    public interface IPizzaPlanetService
    {
        /*
            /api/menu [GET] – (20%)
            /api/menu/{menuItemId:int} [GET] – (10%)
            /api/menu [POST] – (25%)
            /api/menu/{menuItemId:int} [DELETE] – (20%)

            /api/orders [GET] – (5%)
            /api/orders/{orderId:int} [GET] – (5%)
            /api/orders [POST] – (10%) 
            /api/orders{orderId:int} [DELETE] – (5%)
         */

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


