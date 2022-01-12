using System.Collections.Generic;

namespace KakuroSolver
{
    /// <summary>
    /// Class representing a kakuro puzzle.
    /// </summary>
    class Puzzle
    {
        /// <summary>
        /// Gets and sets the height of the puzzle by number of Cells.
        /// </summary>
        public uint Height { get; set; }

        /// <summary>
        /// Gets and sets the width of the puzzle by number of Cells.
        /// </summary>
        public uint Width { get; set; }

        /// <summary>
        /// Gets and sets the Cells that make up this puzzle.
        /// </summary>
        public List<Cell> Cells { get; set; } = new List<Cell>();

        /// <summary>
        /// Gets and sets the sections of cells that make up this puzzle.
        /// </summary>
        public List<Section> Sections { get; set; } = new List<Section>();
    }
}
