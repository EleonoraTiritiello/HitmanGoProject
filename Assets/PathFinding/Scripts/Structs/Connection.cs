namespace HitmanGO
{
    /// <summary>
    /// Struct <c> Connection </c> saves the connection between two nodes
    /// </summary>
    public struct Connection
    {
        #region Private Variables

        /// <summary>
        /// The <c> Node </c> from which the connection starts
        /// </summary>
        public Node From { get; private set; }
        /// <summary>
        /// The <c> Node </c> the connection arrives at
        /// </summary>
        public Node To { get; private set; }

        #endregion

        public Connection(Node from, Node to)
        {
            From = from;
            To = to;
        }
    }
}
