using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace KakuroSolver.UnitTests
{
    [TestClass]
    public class PuzzleCellUnitTests
    {
        [TestMethod]
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
            Assert.AreEqual(columnPossibilities[0][0], puzzleCell.Value);
        }

        [TestMethod]
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
            Assert.AreEqual(rowPossibilities[0][0], puzzleCell.Value);
        }

        [TestMethod]
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
            Assert.AreEqual(4u, puzzleCell.Value);
        }
    }
}
