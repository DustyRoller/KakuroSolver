namespace KakuroSolver
{
    /// <summary>
    /// Coordinate of a cell within a puzzle, describing its X and Y position
    /// within the puzzle grid, starting 0, 0 at the top left hand corner.
    /// </summary>
    class Coordinate
    {
        /// <summary>
        /// Gets the Coordinate's X position.
        /// </summary>
        public uint X { get; private set; }

        /// <summary>
        /// Gets the Coordinate's Y position.
        /// </summary>
        public uint Y { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Coordinate(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Does this Coordinate equal the given object.
        /// </summary>
        /// <param name="obj">The object to be comparing against.</param>
        /// <returns>True if the Coordinates are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            // Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var otherCoordinate = (Coordinate)obj;
            return (X == otherCoordinate.X) && (Y == otherCoordinate.Y);
        }

        /// <summary>
        /// Get the Coordinate's hash code.
        /// </summary>
        /// <returns>The Coordinate's hash code.</returns>
        public override int GetHashCode()
        {
            return (int)(X ^ Y);
        }
    }
}
