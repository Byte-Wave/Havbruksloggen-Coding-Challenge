using System;
namespace Havbruksloggen_Coding_Challenge.Shared.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
