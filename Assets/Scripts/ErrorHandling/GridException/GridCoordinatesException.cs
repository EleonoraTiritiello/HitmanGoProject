namespace HitmanGO
{
    public class GridCoordinatesException : GridException
    {
        public GridCoordinatesException() : base("An error occurred in the grid coordinates") { }
        public GridCoordinatesException(string message) : base(message) { }
        public GridCoordinatesException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
