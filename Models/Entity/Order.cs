using System;

namespace PizzaPlanet.Models.EntityModels
{
    /// <summary>
    /// Entity model for the Order. This is a direct mapping from the database and should not be exposed to public users.
    /// </summary>
    public class Order
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
        
        /// <summary>
        /// IsCancelled tells if the Order has been cancelled.
        /// </summary>
        /// <returns></returns>
        public bool IsCancelled { get; set; }

    }
}


