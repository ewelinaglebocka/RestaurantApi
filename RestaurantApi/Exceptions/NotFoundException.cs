using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Globalization;

namespace RestaurantApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }   
    }
}
