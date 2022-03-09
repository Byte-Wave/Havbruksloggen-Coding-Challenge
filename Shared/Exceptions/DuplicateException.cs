using System;
namespace Havbruksloggen_Coding_Challenge.Shared.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message)
        {
        }
    }
}
