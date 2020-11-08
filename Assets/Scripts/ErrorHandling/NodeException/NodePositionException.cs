namespace HitmanGO
{
    public class NodePositionException : NodeException
    {
        public NodePositionException() : base("An error occurred in the grid position of the node") { }
        public NodePositionException(string message) : base(message) { }
        public NodePositionException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
