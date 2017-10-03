using System;

namespace PizzaPlanet.Models.EntityModels
{
    /// <summary>
    /// Entity model for the OrderLink.The OrderLink is the relationship between an Order and a MenuItem. 
    /// This is a direct mapping from the database and should not be exposed to public users.
    /// </summary>
    public class OrderLink
    {
        /// <summary>
        /// Id of the OrderLink.
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }

         /// <summary>
        /// Id of the Order.
        /// </summary>
        /// <returns></returns>
        public int OrderId { get; set; }

         /// <summary>
        /// Id of the MenuItem.
        /// </summary>
        /// <returns></returns>
        public int MenuItemId { get; set; }

    }
}