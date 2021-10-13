#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

namespace CzyDobrze.Core
{
    public abstract class ValueObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Objects used to compare value object of the same type.</returns>
        protected abstract IEnumerable<object?> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return ((ValueObject)obj)
                .GetEqualityComponents()
                .SequenceEqual(GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Where(x=>x is not null)
                .Select(x => x!.GetHashCode())
                .Aggregate(HashCode.Combine);
        }
        
        
        public static bool operator==(ValueObject a, object? b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, object? b)
        {
            return !(a == b);
        }
    }
}