namespace HitmanGO {
    /// <summary>
    /// Struct <c> EnabledConnections </c> tells which directions a <c> Node </c> can make connections
    /// </summary>
    [System.Serializable]
    public struct Directions
    {
        /// <summary>
        /// If the <c> Node </c> connects with a <c> Node </c> above
        /// </summary>
        public bool Up;
        /// <summary>
        /// If the <c> Node </c> connects with a <c> Node </c> below
        /// </summary>
        public bool Down;
        /// <summary>
        /// If the <c> Node </c> connects with a <c> Node </c> on the left
        /// </summary>
        public bool Left;
        /// <summary>
        /// If the <c> Node </c> connects with a <c> Node </c> on the right
        /// </summary>
        public bool Right;
    }
}
