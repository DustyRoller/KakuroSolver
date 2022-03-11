using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace KakuroSolver.UnitTests
{
    [TestFixture]
    public class PuzzleCellUnitTests
    {
        [Test]
        public void PuzzleCell_CellValue_ThrowsExceptionIfValueIsGreaterThan9()
        {
            var puzzleCell = new PuzzleCell
            {
                Coordinate = new Coordinate(0u, 0u),
            };

            var ex = Assert.Throws<KakuroSolverException>(() => puzzleCell.CellValue = 10u);

            Assert.AreEqual($"Puzzle cell value cannot be greater than 9. {puzzleCell.Coordinate}.", ex.Message);
        }

        [Test]
        public void PuzzleCell_Solve_SolvesValueIfSingleColumnPossibility()
        {
            var columnSection = new Mock<ISection>();

            var columnPossibilities = new List<List<uint>>()
            {
                new List<uint> { 5u, },
            };

            columnSection.Setup(cs => cs.CalculateIntegerPartitions())
                         .Returns(columnPossibilities);

            var rowSection = new Mock<ISection>();

            var rowPossibilities = new List<List<uint>>()
            {
                new List<uint> { 6u, },
                new List<uint> { 7u, },
            };

            rowSection.Setup(rs => rs.CalculateIntegerPartitions())
                      .Returns(rowPossibilities);

            var puzzleCell = new PuzzleCell
            {
                ColumnSection = columnSection.Object,
                RowSection = rowSection.Object,
            };

            puzzleCell.Solve();

            Assert.IsTrue(puzzleCell.Solved);
            Assert.AreEqual(columnPossibilities[0][0], puzzleCell.CellValue);
        }

        [Test]
        public void PuzzleCell_Solve_SolvesValueIfSingleRowPossibility()
        {
            var columnSection = new Mock<ISection>();

            var columnPossibilities = new List<List<uint>>()
            {
                new List<uint> { 8u, },
                new List<uint> { 9u, },
            };

            columnSection.Setup(cs => cs.CalculateIntegerPartitions())
                         .Returns(columnPossibilities);

            var rowSection = new Mock<ISection>();

            var rowPossibilities = new List<List<uint>>()
            {
                new List<uint> { 1u, },
            };

            rowSection.Setup(rs => rs.CalculateIntegerPartitions())
                      .Returns(rowPossibilities);

            var puzzleCell = new PuzzleCell
            {
                ColumnSection = columnSection.Object,
                RowSection = rowSection.Object,
            };

            puzzleCell.Solve();

            Assert.IsTrue(puzzleCell.Solved);
            Assert.AreEqual(rowPossibilities[0][0], puzzleCell.CellValue);
        }

        [Test]
        public void PuzzleCell_Solve_SolvesValueIfSingleListOfColumnValuesWithUniqueValue()
        {
            var columnSection = new Mock<ISection>();

            var columnPossibilities = new List<List<uint>>()
            {
                new List<uint> { 4u, 5u, 8u, },
            };

            columnSection.Setup(cs => cs.CalculateIntegerPartitions())
                         .Returns(columnPossibilities);

            var rowSection = new Mock<ISection>();

            var rowPossibilities = new List<List<uint>>()
            {
                new List<uint> { 1u, 2u, 3u },
                new List<uint> { 1u, 2u, 4u },
                new List<uint> { 1u, 4u, 6u },
            };

            rowSection.Setup(rs => rs.CalculateIntegerPartitions())
                      .Returns(rowPossibilities);

            var puzzleCell = new PuzzleCell
            {
                ColumnSection = columnSection.Object,
                RowSection = rowSection.Object,
            };

            puzzleCell.Solve();

            Assert.IsTrue(puzzleCell.Solved);
            Assert.AreEqual(4u, puzzleCell.CellValue);
        }
    }
}
