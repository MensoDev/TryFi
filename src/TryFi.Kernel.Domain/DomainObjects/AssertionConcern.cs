using TryFi.Kernel.Domain.Exceptions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TryFi.Kernel.Domain.DomainObjects
{
    public class AssertionConcern
    {

        public static void MinLength(string value, int minLength, string errorMessage, PropertyInfo property = default)
        {
            if (value.Length < minLength)
            {
                ThrowException(errorMessage, property);
            }
        }

        public static void MaxLength(string value, int maxLength, string errorMessage, PropertyInfo property = default)
        {
            if (value.Length > maxLength)
            {
                ThrowException(errorMessage, property);
            }
        }


        public static void BiggerThen(decimal bigger, decimal then, string errorMessage, PropertyInfo property = default)
        {
            if (bigger < then)
            {
                ThrowException(errorMessage, property);
            }
        }

        public static void BiggerThen(int bigger, int then, string errorMessage, PropertyInfo property = default)
        {
            if (bigger < then)
            {
                ThrowException(errorMessage, property);
            }
        }

        public static void BiggerThen(long bigger, long then, string errorMessage, PropertyInfo property = default)
        {
            if (bigger < then)
            {
                ThrowException(errorMessage, property);
            }
        }



        public static void LessThanOrEqual(int less, int than, string errorMessage, PropertyInfo property = default)
        {
            var result = less <= than;
            if (!result)
            {
                ThrowException(errorMessage, property);
            }
        }

        public static void LessThanOrEqual(decimal less, decimal than, string errorMessage, PropertyInfo property = default)
        {
            var result = less <= than;
            if (!result)
            {
                ThrowException(errorMessage, property);
            }
        }


        public static void PositiveNumber(decimal value, string errorMessage, PropertyInfo property = default)
        {
            if (value < 0)
            {
                ThrowException(errorMessage, property);
            }
        }


        public static void NotNull(object value, string errorMessage, PropertyInfo property = default)
        {
            if (value == null)
            {
                ThrowException(errorMessage, property);
            }
        }

        public static void Null(object value, string errorMessage, PropertyInfo property = default)
        {
            if (value != null)
            {
                ThrowException(errorMessage, property);
            }
        }


        public static void NotEmpty(string value, string errorMessage, PropertyInfo property = default)
        {
            if (string.IsNullOrEmpty(value))
            {
                ThrowException(errorMessage, property);
            }
        }

        public static void NotEmpty(Guid value, string errorMessage, PropertyInfo property = default)
        {
            if (value == Guid.Empty)
            {
                ThrowException(errorMessage, property);
            }
        }


        public static void NotEquals(int value, int compare, string errorMessage, PropertyInfo property = default)
        {
            if (value.Equals(compare))
            {
                ThrowException(errorMessage, property);
            }
        }


        public static void HasMacAddress(string macAddress, string errorMessage, PropertyInfo property = default)
        {
            if (!IsMacAddress(macAddress))
            {
                ThrowException(errorMessage, property);
            }
        }

        #region Assert State 

        public static void False(bool boolValue, string message)
        {
            if (boolValue)
            {
                ThrowException(message);
            }
        }

        public static void True(bool boolValue, string message)
        {
            False(!boolValue, message);
        }

        #endregion

        public static void ThrowException(string message)
        {
            throw new DomainException(message);
        }

        public static void ThrowException(string message, PropertyInfo property)
        {
            throw new DomainException(message, property);
        }


        private static bool IsEmail(string email)
        {
            Regex rg = new(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);
        }

        private static bool IsMacAddress(string macAddress)
        {
            macAddress = macAddress.Replace(" ", "").Replace(":", "").Replace("-", "");
            Regex regex = new Regex("^[a-fA-F0-9]{12}$");
            return regex.IsMatch(macAddress);
        }

    }
}
