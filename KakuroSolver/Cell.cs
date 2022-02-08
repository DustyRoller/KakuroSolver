using System.Collections.Generic;
using System.Linq;

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
        /// Gets if this cell has been solved or not.
        /// </summary>
        public bool Solved => Value != 0u;

        /// <summary>
        /// Gets the value of the cell, will be 0 if it hasn't been solved yet.
        /// </summary>
        public uint Value { get; set; } = 0u;

        /// <summary>
        /// Gets and Sets the column section that this cell belongs to.
        /// </summary>
        public ISection ColumnSection { get; set; }

        /// <summary>
        /// Gets and Sets the row section that this cell belongs to.
        /// </summary>
        public ISection RowSection { get; set; }

        public void Solve()
        {
            // Should this throw?
            if (Solved)
            {
                return;
            }

            // Use the sections to calculate the possible numbers that this
            // cell could be.
            var columnPossibilities = ColumnSection.CalculateIntegerPartitions();
            var rowPossibilities = RowSection.CalculateIntegerPartitions();

            // If the possibilities from either section only contain a single
            // value then that is our value.
            if (rowPossibilities.Count == 1 && rowPossibilities[0].Count == 1)
            {
                Value = rowPossibilities[0][0];
            }
            else if (columnPossibilities.Count == 1 && columnPossibilities[0].Count == 1)
            {
                Value = columnPossibilities[0][0];
            }
            else if (columnPossibilities.Count == 1 && rowPossibilities.Count != 1)
            {
                FindUniqueValue(columnPossibilities[0], rowPossibilities);
            }
            else if (columnPossibilities.Count != 1 && rowPossibilities.Count == 1)
            {
                FindUniqueValue(rowPossibilities[0], columnPossibilities);
            }
            else if (columnPossibilities.Count == 1 && rowPossibilities.Count == 1)
            {
                // We only have one set of possibilities from both sections,
                // so see if there is only one number in common between the
                // two of them. If there is then thats our value.
                var differences = columnPossibilities[0].Intersect(rowPossibilities[0]).ToList();
                if (differences.Count == 1)
                {
                    // We have solved our cell.
                    Value = differences[0];
                }
            }
        }

        private void FindUniqueValue(List<uint> singlePartitionValues, List<List<uint>> multiplePartitionValues)
        {
            // Remove any partition lists from the multiple partitions list if
            // they don't contain the values from the single partition list.
            var updatedMultiplePossibilities = new List<List<uint>>();
            foreach (var possibilities in multiplePartitionValues)
            {
                var contains = false;
                foreach (var val in singlePartitionValues)
                {
                    if (possibilities.Contains(val))
                    {
                        contains = true;
                        break;
                    }
                }

                if (contains)
                {
                    updatedMultiplePossibilities.Add(possibilities);
                }
            }

            // If only one of the possible values exists in the updated lists
            // then we have found our number.

            // Keep track of what numbers occur.
            var valueOccurances = new Dictionary<uint, uint>();
            singlePartitionValues.ForEach(hp => valueOccurances.Add(hp, 0u));

            foreach (var rowPoss in updatedMultiplePossibilities)
            {
                foreach (var val in singlePartitionValues)
                {
                    if (rowPoss.Contains(val))
                    {
                        valueOccurances[val]++;
                    }
                }
            }

            var uniqueValue = true;
            var value = 0u;

            foreach (var valueOccurance in valueOccurances.Keys)
            {
                if (value == 0u)
                {
                    // See if this value has occured.
                    if (valueOccurances[valueOccurance] > 0)
                    {
                        value = valueOccurance;
                    }
                }
                else
                {
                    if (valueOccurances[valueOccurance] > 0)
                    {
                        // No longer a unique value.
                        uniqueValue = false;
                        break;
                    }
                }
            }

            if (uniqueValue)
            {
                // We have solved our cell.
                Value = value;
            }
        }
    }
}
