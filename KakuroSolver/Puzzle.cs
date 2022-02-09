using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KakuroSolver
{
    /// <summary>
    /// Class representing a kakuro puzzle.
    /// </summary>
    class Puzzle
    {
        /// <summary>
        /// Gets all of the Cells that make up the puzzle.
        /// </summary>
        public ReadOnlyCollection<Cell> Cells
        {
            get => cells.AsReadOnly();
        }

        /// <summary>
        /// Gets and sets the height of the puzzle by number of Cells.
        /// </summary>
        public uint Height { get; set; }

        /// <summary>
        /// Gets and sets the sections of cells that make up this puzzle.
        /// </summary>
        public List<Section> Sections { get; set; } = new List<Section>();


        /// <summary>
        /// Gets and sets the width of the puzzle by number of Cells.
        /// </summary>
        public uint Width { get; set; }

        /// <summary>
        /// List of all of the cells in the puzzle.
        /// </summary>
        private readonly List<Cell> cells;

        /// <summary>
        /// List of all of the puzzle cells in the puzzle.
        /// </summary>
        private readonly List<PuzzleCell> puzzleCells;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Puzzle()
        {
            cells = new List<Cell>();
            puzzleCells = new List<PuzzleCell>();
        }

        /// <summary>
        /// Add the given cell to this puzzle.
        /// </summary>
        /// <param name="cell">The cell to add.</param>
        public void AddCell(Cell cell)
        {
            cells.Add(cell);

            if (cell is PuzzleCell puzzleCell)
            {
                puzzleCells.Add(puzzleCell);
            }
        }

        /// <summary>
        /// Solve the puzzle.
        /// </summary>
        /// <returns>True if the puzzle was solved, otherwise false.</returns>
        public bool Solve()
        {
            var numCellsSolved = 0;
            var updatedSolvedNumber = 0;

            // Loop through each unsolved cell to try and solve the puzzle.
            // Will keep looping until either no new cells are solved, or all
            // the cells are solved.
            do
            {
                numCellsSolved = updatedSolvedNumber;

                puzzleCells.Where(pc => pc.Solved == false)
                           .ToList()
                           .ForEach(pc => pc.Solve());

                updatedSolvedNumber = puzzleCells.Count(pc => pc.Solved == true);
            }
            while (updatedSolvedNumber != numCellsSolved
                   || numCellsSolved != puzzleCells.Count);

            // Check that all the puzzle cells and sections are solved.
            return numCellsSolved == puzzleCells.Count &&
                   Sections.All(s => s.IsSolved());
        }

        /// <summary>
        /// Get a string representation of the current state of the puzzle.
        /// </summary>
        /// <returns>String representing the current state of the puzzle.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < cells.Count; ++i)
            {
                sb.Append('|');

                if (i != 0 && i % Width == 0)
                {
                    sb.AppendLine();
                    sb.Append('|');
                }

                sb.Append(cells[i].ToString());
            }

            sb.Append('|');

            return sb.ToString();
        }
    }
}
