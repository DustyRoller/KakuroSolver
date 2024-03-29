﻿using System.Text;

namespace KakuroSolver.Cells
{
    /// <summary>
    /// The ClueCell class represents a cell within the puzzle that gives
    /// either or both a horizontal or vertical clue, enabling the puzzle
    /// to be solved.
    /// </summary>
    internal class ClueCell : Cell
    {
        /// <summary>
        /// Gets or sets the Cell's column clue.
        /// </summary>
        public uint ColumnClue { get; set; }

        /// <summary>
        /// Gets or sets the Cell's row clue.
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
}
