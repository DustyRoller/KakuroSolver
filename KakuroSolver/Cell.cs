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
            return "  x  ";
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
                if (ColumnClue < 10)
                {
                    sb.Append(" ");
                }
                sb.Append(ColumnClue);
            }
            else
            {
                sb.Append("  ");
            }
            sb.Append('\\');
            if (RowClue != 0u)
            {
                sb.Append(RowClue);
                if (RowClue < 10)
                {
                    sb.Append(" ");
                }
            }
            else
            {
                sb.Append("  ");
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
        public bool Solved => CellValue != 0u;

        /// <summary>
        /// Gets and sets the value of the cell, will be 0 if it hasn't been solved yet.
        /// </summary>
        public uint CellValue
        {
            get => cellValue;
            set
            {
                if (value > 9)
                {
                    throw new KakuroSolverException($"Puzzle cell value cannot be greater than 9. {Coordinate}.");
                }

                cellValue = value;
            }
        }

        /// <summary>
        /// Gets the possible values for this cell.
        /// </summary>
        /// <remarks>
        /// This calculates the integer partitions for the column and row
        /// sections that this cell belongs to, and returns all of the common
        /// values into a single list.
        /// </remarks>
        public List<uint> PossibleValues => ColumnSection.CalculateIntegerPartitions()
                                                         .SelectMany(ip => ip)
                                                         .Intersect(RowSection.CalculateIntegerPartitions()
                                                                              .SelectMany(ip => ip))
                                                         .ToList();

        /// <summary>
        /// Gets and Sets the column section that this cell belongs to.
        /// </summary>
        public ISection ColumnSection { get; set; }

        /// <summary>
        /// Gets and Sets the row section that this cell belongs to.
        /// </summary>
        public ISection RowSection { get; set; }

        private uint cellValue = 0u;

        /// <summary>
        /// Get a string representation of the current state of the cell.
        /// </summary>
        /// <returns>String representing the current state of the cell.</returns>
        public override string ToString()
        {
            return Solved ? $"  {CellValue}  " : "  -  ";
        }
    }
}
