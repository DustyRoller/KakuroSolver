using System.Collections.Generic;

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

    /// <summary>
    /// Base Cell class.
    /// </summary>
    abstract class Cell
    {
        /// <summary>
        /// Gets and sets the Cell's Coordinate.
        /// </summary>
        public Coordinate Coordinate { get; set; }
    }

    /// <summary>
    /// The BlankCell class represents a cell within the puzzle that acts as a
    /// end point for rows and columns.
    /// </summary>
    class BlankCell : Cell
    {
    }

    /// <summary>
    /// The ClueCell class represents a cell within the puzzle that gives
    /// either or both a horizontal or vertical clue, enabling the puzzle
    /// to be solved.
    /// </summary>
    class ClueCell : Cell
    {
        /// <summary>
        /// Gets and sets the Cell's column clue.
        /// </summary>
        public uint ColumnClue { get; set; }
        /// <summary>
        /// Gets and sets the Cell's row clue.
        /// </summary>
        public uint RowClue { get; set; }
    }

    /// <summary>
    /// The PuzzleCell class represents a cell within the puzzle that requires
    /// solving.
    /// </summary>
    class PuzzleCell : Cell
    {
        /// <summary>
        /// Gets the set of potential values that can be in this cell.
        /// </summary>
        public HashSet<uint> PotentialValues { get; set; } = new HashSet<uint>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9
        };

        /// <summary>
        /// Gets if this cell has been solved or not.
        /// </summary>
        public bool Solved { get; set; } = false;

        /// <summary>
        /// Gets the value of the cell, will be 0 if it hasn't been solved yet.
        /// </summary>
        public uint Value { get; set; } = 0u;
    }
}
