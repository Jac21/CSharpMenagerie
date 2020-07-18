using System;
using System.Runtime.CompilerServices;

namespace MagicalMethods
{
    // Custom awaitable types
    public class CustomAwaiter : INotifyCompletion
    {
        public void OnCompleted(Action continuiation)
        {
            throw new NotImplementedException();
        }

        public bool IsCompleted()
        {
            throw new NotImplementedException();
        }

        public void GetResult()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomAwaitable
    {
        public CustomAwaiter GetAwaiter()
        {
            throw new NotImplementedException();
        }
    }
}