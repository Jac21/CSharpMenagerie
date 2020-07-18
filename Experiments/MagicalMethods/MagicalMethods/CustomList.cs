using System;
using System.Collections;
using System.Collections.Generic;

namespace MagicalMethods
{
    // Collection initialization syntax
    public class CustomList<T> : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }
    }

    // Collection initialization syntax with multiple parameters
    public class CustomListWithMultipleParameters<T> : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T item, string extraParameterOne, int extraParameterTwo)
        {
            throw new NotImplementedException();
        }
    }

    // Collection initialization syntax with dynamic parameters
    public class CustomListWithDynamicParameters<T> : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }

    // Adding collection initializer support for existing types
    public static class ExistingTypeExtensions
    {
        public static void Add<T>(ExistingType @this, T item) => throw new NotImplementedException();
    }

    public class ExistingType
    {
    }
}