using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KakuroSolver
{
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
        /// <summary>
        /// Get a string representation of the cell.
        /// </summary>
        /// <returns>String representing the cell.</returns>
        public override string ToString()
        {
            return "x";
        }
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

        /// <summary>
        /// Get a string representation of the cell.
        /// </summary>
        /// <returns>String representing the cell.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (ColumnClue != 0u)
            {
                sb.Append(ColumnClue);
            }
            sb.Append('\\');
            if (RowClue != 0u)
            {
                sb.Append(RowClue);
            }

            return sb.ToString();
        }
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

        /// <summary>
        /// Get a string representation of the current state of the cell.
        /// </summary>
        /// <returns>String representing the current state of the cell.</returns>
        public override string ToString()
        {
            return Solved ? Value.ToString() : "-";
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
