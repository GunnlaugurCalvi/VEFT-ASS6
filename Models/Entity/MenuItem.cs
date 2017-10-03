using System;

namespace PizzaPlanet.Models.EntityModels
{
    /// <summary>
    /// Entity model for the MenuItem. This is a direct mapping from the database and should not be exposed to public users.
    /// </summary>
    public class MenuItem
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
        /// The SpicyLevel of the MenuItem.
        /// </summary>
        /// <returns></returns>
        public int SpicyLevel { get; set; }

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

        /// <summary>
        /// Tells if the MenuItem has been removed.
        /// </summary>
        /// <returns></returns>
        public bool isDeleted { get; set; }

    }
}