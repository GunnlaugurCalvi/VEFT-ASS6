using System;

namespace PizzaPlanet.Models.DTO
{
    /// <summary>
    /// A minimal version of MenuItem model which is exposed to the user.
    /// </summary>
    public class OrderLiteDto
    {
        /// <summary>
        /// Id of the Oder.
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }
        
        /// <summary>
        /// The DateOfOrder is the DateTime of the order.
        /// </summary>
        /// <returns></returns>
        public DateTime DateOfOrder { get; set; }
        
        /// <summary>
        /// CustomerName is the name of the Customer who placed the Order.
        /// </summary>
        /// <returns></returns>
        public string CustomerName { get; set; }
        
        /// <summary>
        /// IsPickup tells if the Order has been picked up.
        /// </summary>
        /// <returns></returns>
        public bool IsPickup { get; set; }
        
        /// <summary>
        /// The Address of the order. // Todo?
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
    }
}


