using System;

namespace HitmanGO
{
    public class GridException : Exception
    {
        public GridException() : base("An error occurred in the node grid") { }
        public GridException(string message) : base(message) { }
        public GridException(string message, Exception innerException) : base(message, innerException) { }
    }
}
