using KakuroSolver.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace KakuroSolver
{
    /// <summary>
    /// A section represents a ClueCell and a list of PuzzleCells.
    /// The sum of the values of the PuzzleCells must add up to the value
    /// of the ClueCell.
    /// </summary>
    class Section : ISection
    {
        public uint ClueValue { get; private set; }

        public List<PuzzleCell> PuzzleCells { get; private set; } = new List<PuzzleCell>();

        public Section(uint clueValue)
        {
            if (clueValue == 0u)
            {
                throw new ArgumentException("Clue value must be greater than 0.");
            }

            ClueValue = clueValue;
        }

        /// <summary>
        /// Calculate all of the possible integer partitions for this section,
        /// taking into account already solved cells.
        /// </summary>
        /// <returns>List of integer partitions.</returns>
        public List<List<uint>> CalculateIntegerPartitions()
        {
            if (PuzzleCells.All(pc => pc.Solved == true))
            {
                // This section is solved so return an empty list.
                return new List<List<uint>>();
            }

            List<List<uint>> partitions;

            var numSolvedCells = PuzzleCells.Count(pc => pc.Solved == true);

            var solvedPuzzleCells = PuzzleCells.Where(pc => pc.Solved);
            var clueValue = ClueValue - (uint)solvedPuzzleCells.Sum(pc => pc.Value);

            // If we only have on cell left then we can figure out what its
            // value will be.
            if (numSolvedCells == PuzzleCells.Count - 1)
            {
                partitions = new List<List<uint>>() { new List<uint> { clueValue, } };
            }
            else
            {
                // Need to actually calculate the partitions.
                var maxValue = (clueValue <= 9) ? (clueValue - 1) : 9;
                var numCells = (uint)(PuzzleCells.Count - numSolvedCells);

                partitions = IntegerPartitionCalculator.CalculateDistinctIntegerPartitions(clueValue, numCells, 1u, maxValue);

                // Remove any partitions that contain a solved value.
                foreach (var solvedPuzzleCell in solvedPuzzleCells)
                {
                    partitions.RemoveAll(p => p.Contains(solvedPuzzleCell.Value));
                }
            }

            return partitions;
        }

        /// <summary>
        /// Is this Section solved with valid answers.
        /// </summary>
        /// <returns>True if section is solved, otherwise false.</returns>
        public bool IsSolved()
        {
            // Make sure that all puzzle cells are solved, that the total of
            // their value adds up to the clue value and that they all have
            // unique values.
            return PuzzleCells.All(pc => pc.Solved) &&
                   PuzzleCells.Sum(pc => pc.Value) == ClueValue &&
                   PuzzleCells.Select(pc => pc.Value).Distinct().Count() == PuzzleCells.Count;
        }
    }
}
