namespace HitmanGO
{
    public class NodeConnectionException : NodeException
    {
        public NodeConnectionException() : base("A node connection error has occurred") { }
        public NodeConnectionException(string message) : base(message) { }
        public NodeConnectionException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
