namespace HitmanGO
{
    public class NoNodeException : NodeException
    {
        public NoNodeException() : base("A node that does not exist has been referenced") { }
        public NoNodeException(string message) : base(message) { }
        public NoNodeException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
