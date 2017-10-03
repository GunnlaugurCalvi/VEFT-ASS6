using System;
using System.Runtime.Serialization;

namespace PizzaPlanet.Models.Exceptions
{
    public class InvalidMenuItemIDException : Exception //2 404
    {
        public InvalidMenuItemIDException() : base("Invalid MenuItemId, please try a valid one...") { }

        public InvalidMenuItemIDException(string message) : base(message)
        {
        }

        public InvalidMenuItemIDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidMenuItemIDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class DeleteInvalidMenuItemException : Exception //4 404
    {
        public DeleteInvalidMenuItemException() : base("Invalid MenuItemId, no such MenuItem.") { }

        public DeleteInvalidMenuItemException(string message) : base(message)
        {
        }

        public DeleteInvalidMenuItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteInvalidMenuItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class InvalidOrderListMenuIdException : Exception //3 412
    {
        public InvalidOrderListMenuIdException() : base("Invalid OrderList MenuItemId! The MenuItem you are trying to order does not exist.") { }

        public InvalidOrderListMenuIdException(string message) : base(message)
        {
        }

        public InvalidOrderListMenuIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidOrderListMenuIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    public class InvalidOrderIDException : Exception //6 404
    {
        public InvalidOrderIDException() : base("Invalid OrderId, please try a valid one...") { }

        public InvalidOrderIDException(string message) : base(message)
        {
        }

        public InvalidOrderIDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidOrderIDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    public class DeleteInvalidOrderIdException : Exception //7 412
    {
        public DeleteInvalidOrderIdException() : base("Invalid OrderId, no such Order.") { }

        public DeleteInvalidOrderIdException(string message) : base(message)
        {
        }

        public DeleteInvalidOrderIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteInvalidOrderIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}