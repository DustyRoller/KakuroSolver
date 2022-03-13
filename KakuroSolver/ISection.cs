using System.Collections.Generic;

namespace KakuroSolver
{
    interface ISection
    {
        /// <summary>
        /// Gets the clue value of this Section.
        /// </summary>
        uint ClueValue { get; }

        /// <summary>
        /// Gets the list of PuzzleCells that make up this section.
        /// </summary>
        List<PuzzleCell> PuzzleCells { get; }

        /// <summary>
        /// Gets a list of the unsolved PuzzleCells left in this section.
        /// </summary>
        List<PuzzleCell> UnsolvedPuzzleCells { get; }

        /// <summary>
        /// Calculate all of the possible integer partitions for this section,
        /// taking into account already solved cells.
        /// </summary>
        /// <returns>List of integer partitions.</returns>
        List<List<uint>> CalculateIntegerPartitions();

        /// <summary>
        /// Is this Section solved with valid answers.
        /// </summary>
        /// <returns>True if section is solved, otherwise false.</returns>
        bool IsSolved();

        /// <summary>
        /// Attempt to solve this Section.
        /// </summary>
        void Solve();
    }
}
