using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.Models.VM
{
    /// <summary>
    /// A view model of an Order, which is the data required from users.
    /// </summary>
    public class OrderViewModel
    {   
        /// <summary>
        /// The DateOfOrder is the DateTime of the order.
        /// </summary>
        /// <returns></returns>
        [Required]
        public DateTime? DateOfOrder { get; set; }
        
        /// <summary>
        /// CustomerName is the name of the Customer who placed the Order.
        /// </summary>
        /// <returns></returns>
        [Required]
        public string CustomerName { get; set; }
        
        /// <summary>
        /// IsPickup tells if the Order has been picked up.
        /// </summary>
        /// <returns></returns>
        [Required]
        public bool? IsPickup { get; set; }
        
        /// <summary>
        /// The Address of the order. // Todo?
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Address { get; set; }
        
        /// <summary>
        /// Contains the Ids of the MenuItems that are being ordered.
        /// </summary>
        /// <returns></returns>
        [Required]
        public List<int> OrderItemsIds { get; set;}
    }
}


