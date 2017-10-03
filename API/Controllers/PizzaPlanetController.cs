using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaPlanet.Models.VM;
using PizzaPlanet.Services;
using PizzaPlanet.Models.Exceptions;

namespace API.Controllers
{
    [Route("api/")]
    public class PizzaPlanetController : Controller
    {
        #region Setup
        private readonly IPizzaPlanetService _service;

        public PizzaPlanetController(IPizzaPlanetService service) 
        {
            _service = service;
        }
        #endregion

        #region MenuItems
        [HttpGet]
        [Route("menu", Name = "GetMenuItems")]
        public IActionResult GetMenuItems()
        {
            var menu = _service.GetMenuItems();
            return Ok(menu);
        }

        [HttpGet]
        [Route("menu/{menuItemId:int}", Name = "GetMenuItemsById")]
        public IActionResult GetMenuItemsById(int menuItemId)
        {
            try {
                var menuitem = _service.GetMenuItemsById(menuItemId);
                return Ok(menuitem);
            }
            catch (InvalidMenuItemIDException e) {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost]
        [Route("menu", Name = "AddMenuItem")]
        public IActionResult AddMenuItem([FromBody] MenuItemViewModel menuitem)
        {
            if(menuitem == null || !ModelState.IsValid) {
                return StatusCode(412);
            }
            _service.AddMenuItem(menuitem);
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("menu/{menuItemId:int}", Name = "DeleteMenuItem")]
        public IActionResult DeleteMenuItem(int menuItemId)
        {
            try {
                _service.DeleteMenuItem(menuItemId);
                return StatusCode(204);
            } catch (DeleteInvalidMenuItemException e) {
                return StatusCode(404, e.Message);
            }
        }
        #endregion

        #region Orders
        [HttpGet]
        [Route("orders", Name = "GetOrders")]
        public IActionResult GetOrders()
        {
             var orders = _service.GetOrders();
            return Ok(orders);
        }

        [HttpGet]
        [Route("orders/{orderId:int}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int orderId)
        {
            // Todo use exeptions
            try {
                var order = _service.GetOrderById(orderId);
                return Ok(order);
            } catch (InvalidOrderIDException e) {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost]
        [Route("orders", Name = "AddOrder")]
        public IActionResult AddOrder([FromBody] OrderViewModel order)
        {
            //Todo 412 if order is not valid else 201
            //exceptions
            if(order == null || !ModelState.IsValid) {
                return StatusCode(412);
            }
            try {
                _service.AddOrder(order);
                return StatusCode(201);
            } catch (InvalidOrderListMenuIdException e) {
                return StatusCode(412, e.Message);
            }

        }

        [HttpDelete]
        [Route("orders/{orderId:int}", Name = "DeleteOrder")]
        public IActionResult DeleteOrder(int orderId)
        {
            // Todo return 404 if menuitem is not valid
            try {
                _service.DeleteOrder(orderId);
                return StatusCode(204);
            } catch (DeleteInvalidOrderIdException e) {
                return StatusCode(404, e.Message);
            }

        }
        #endregion
    }
}
