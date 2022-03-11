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

            var solvedPuzzleCells = PuzzleCells.FindAll(pc => pc.Solved);
            var numSolvedCells = solvedPuzzleCells.Count;
            var clueValue = ClueValue - (uint)solvedPuzzleCells.Sum(pc => pc.CellValue);

            if (clueValue == 0)
            {
                // This would only happen if our solving has gone wrong somewhere.
                throw new KakuroSolverException("Invalid clue value of 0 found");
            }

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
                    partitions.RemoveAll(p => p.Contains(solvedPuzzleCell.CellValue));
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
                   PuzzleCells.Sum(pc => pc.CellValue) == ClueValue &&
                   PuzzleCells.Select(pc => pc.CellValue).Distinct().Count() == PuzzleCells.Count;
        }

        /// <summary>
        /// Attempt to solve this Section.
        /// </summary>
        public void Solve()
        {
            // Get the currently unsolved puzzle cells.
            var unsolvedCells = PuzzleCells.FindAll(pc => !pc.Solved);

            foreach (var puzzleCell in unsolvedCells)
            {
                puzzleCell.Solve();

                if (puzzleCell.Solved && PuzzleCells.Any(pc => !pc.Coordinate.Equals(puzzleCell.Coordinate) &&
                                                               pc.Solved &&
                                                               pc.CellValue == puzzleCell.CellValue))
                {
                    throw new KakuroSolverException($"Value already exists in cell's sections. {puzzleCell.Coordinate}.");
                }
            }
        }
    }
}
