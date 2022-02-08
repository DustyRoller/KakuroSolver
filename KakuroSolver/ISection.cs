using System.Collections.Generic;

namespace KakuroSolver
{
    interface ISection
    {
        public uint ClueValue { get; }

        public List<PuzzleCell> PuzzleCells { get; }

        /// <summary>
        /// Calculate all of the possible integer partitions for this section,
        /// taking into account already solved cells.
        /// </summary>
        /// <returns>List of integer partitions.</returns>
        public List<List<uint>> CalculateIntegerPartitions();

        /// <summary>
        /// Is this Section solved with valid answers.
        /// </summary>
        /// <returns>True if section is solved, otherwise false.</returns>
        public bool IsSolved();
    }
}
