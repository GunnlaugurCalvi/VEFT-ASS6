using System;
using System.Linq;
using System.Collections.Generic;
using PizzaPlanet.Models.DTO;
using PizzaPlanet.Models.VM;
using PizzaPlanet.Models.EntityModels;
using PizzaPlanet.Models.Exceptions;

namespace  PizzaPlanet.Repositories
{
    public class PizzaPlanetRepository : IPizzaPlanetRepository
    {
        
        private readonly  AppDataContext _db;

        public PizzaPlanetRepository(AppDataContext db) {
            _db = db;
        }
        public IEnumerable<MenuItemDto> GetMenuItems() {
            var menu = (    from m in _db.MenuItems
                            where m.isDeleted == false
                            select new MenuItemDto 
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                Price = m.Price
                            }).ToList();
            return menu;
        }
        public MenuItemDto GetMenuItemsById(int menuItemId) {
            var menu = (    from m in _db.MenuItems
                            where m.Id == menuItemId && m.isDeleted == false
                            select new MenuItemDto 
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                Price = m.Price
                            }).SingleOrDefault();
            if (menu == null) { throw new InvalidMenuItemIDException(); } 
            return menu;        
        }
        public void AddMenuItem(MenuItemViewModel menuItem) {
            _db.MenuItems.Add(new MenuItem { 
                        Name = menuItem.Name,
                        Description = menuItem.Description,
                        Price = (double)menuItem.Price,
                        SpicyLevel =(int) menuItem.SpicyLevel,
                        isDeleted = false
                }
            );
            _db.SaveChanges();
        }
        public void DeleteMenuItem(int menuItemId) {
            var menuItem = _db.MenuItems.SingleOrDefault(m => m.Id == menuItemId);
            if (menuItem != null && menuItem.isDeleted == false) {
                menuItem.isDeleted = true;
                _db.MenuItems.Update(entity: menuItem);
                _db.SaveChanges();
            } else {
                throw new DeleteInvalidMenuItemException();
            }
        }
        public IEnumerable<OrderLiteDto> GetOrders() {
            var orders = (  from o in _db.Orders
                            where o.IsCancelled == false
                            select new OrderLiteDto 
                            {
                                Id = o.Id,
                                DateOfOrder = o.DateOfOrder,
                                CustomerName = o.CustomerName,
                                IsPickup = o.IsPickup,
                                Address = o.Address
                            }).ToList();
            return orders;
        }
        public OrderDto GetOrderById(int orderId) {
            var order = (   from o in _db.Orders
                            where o.Id == orderId && o.IsCancelled == false
                            select new OrderDto 
                            {
                                Id = o.Id,
                                DateOfOrder = o.DateOfOrder,
                                CustomerName = o.CustomerName,
                                IsPickup = o.IsPickup,
                                Address = o.Address,
                                OrderedItems = getMenuItemsInOrder(o.Id),//getMenuItemsInOrder(orderId); //Todo Linq magic get orders from OrderList
                            }).SingleOrDefault();
            if (order == null) { throw new InvalidOrderIDException(); }
            return order;
        }
        public void AddOrder(OrderViewModel order) {

            if(!validMenuItems(order.OrderItemsIds)) { throw new InvalidOrderListMenuIdException(); }

            Order new_order = new Order { 
                    DateOfOrder = (DateTime)order.DateOfOrder,
                    CustomerName = order.CustomerName,
                    IsPickup = (bool)order.IsPickup,
                    Address = order.Address,
                    IsCancelled = false
                };

            _db.Orders.Add(new_order);
            _db.SaveChanges();

            foreach(int i in order.OrderItemsIds) {
                var orderlink = new OrderLink {
                            OrderId = new_order.Id,
                            MenuItemId = i
                        };
                _db.OrderLinks.Add(orderlink);
                _db.SaveChanges();

            }

        }
        public void DeleteOrder(int orderId) {
            var order = _db.Orders.SingleOrDefault(o => o.Id == orderId);

            if (order != null && order.IsCancelled == false) {
                 order.IsCancelled = true;
                _db.Orders.Update(entity: order);
                _db.SaveChanges();
            } else {
                throw new DeleteInvalidOrderIdException();
            }
        }

        private bool validMenuItems(IEnumerable<int> menuItems) {
            if (menuItems == null || menuItems.Count() == 0) { return false; }
              foreach(int i in menuItems) {
                  if(!validMenuItem(i)) {
                      return false;
                  }
              }
              return true;
        }

        private bool validMenuItem(int menuItemId) {
            var menuItem = _db.MenuItems.SingleOrDefault(m => m.Id == menuItemId);
            if (menuItem != null && menuItem.isDeleted == false) {
                return true;
            }
            else {
                return false;
            }
        }

        private List<MenuItemDto> getMenuItemsInOrder(int orderId) {
            var menuitemsinorder = (    from ol in _db.OrderLinks
                                        join m in _db.MenuItems on ol.MenuItemId equals m.Id 
                                        where m.isDeleted == false && ol.OrderId == orderId
                                        select new MenuItemDto 
                                        {
                                            Id = m.Id,
                                            Name = m.Name,
                                            Description = m.Description,
                                            Price = m.Price
                                        }).ToList();

            return menuitemsinorder;
        }
    }
}
