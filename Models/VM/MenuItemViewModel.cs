using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlanet.Models.VM
{
    /// <summary>
    /// A view model of a MenuItem, which is the data required from users.
    /// </summary>
    public class MenuItemViewModel
    {
        /// <summary>
        /// Name of the MenuItem.
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The SpicyLevel of the MenuItem.
        /// </summary>
        /// <returns></returns>
        [Required]
        public int? SpicyLevel { get; set; }

        /// <summary>
        /// Description of the MenuItem.
        /// </summary>
        /// <returns></returns>
        [Required]
        public string Description { get; set; }
        
        /// <summary>
        /// The Price of the MenuItem.
        /// </summary>
        /// <returns></returns>
        [Required]
        public double? Price { get; set; }

    }
}