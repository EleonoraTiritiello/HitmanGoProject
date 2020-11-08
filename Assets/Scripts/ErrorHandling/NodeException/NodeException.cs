using System;

namespace HitmanGO
{
    public class NodeException : Exception
    {
        public NodeException() : base("A node error has occurred") { }
        public NodeException(string message) : base(message) { }
        public NodeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
    
