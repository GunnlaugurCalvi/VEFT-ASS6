using System;

namespace PizzaPlanet.Models.DTO
{
    /// <summary>
    /// MenuItem model which is exposed to the user.
    /// </summary>
    public class MenuItemDto
    {
        /// <summary>
        /// Id of the MenuItem.
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }

        /// <summary>
        /// Name of the MenuItem.
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// Description of the MenuItem.
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }

        /// <summary>
        /// The Price of the MenuItem.
        /// </summary>
        /// <returns></returns>
        public double Price { get; set; }

    }
}