using NUnit.Framework;
using System.IO;

namespace KakuroSolver.UnitTests
{
    [TestFixture]
    public class PuzzleUnitTests
    {
        private const string TestPuzzleDir = "TestPuzzles";

        [Test]
        public void Puzzle_NumberOfUnsolvedCells_SuccessfullyReturnsNumberOfUnsolvedCellsIfNoneAreSolved()
        {
            var puzzle = new Puzzle();

            puzzle.AddCell(new PuzzleCell());
            puzzle.AddCell(new PuzzleCell());

            Assert.AreEqual(2, puzzle.NumberOfUnsolvedCells);
        }

        [Test]
        public void Puzzle_NumberOfUnsolvedCells_SuccessfullyReturnsNumberOfUnsolvedCellsIfSomeAreSolved()
        {
            var puzzle = new Puzzle();

            puzzle.AddCell(new PuzzleCell());
            puzzle.AddCell(new PuzzleCell());
            puzzle.AddCell(new PuzzleCell()
            {
                CellValue = 1u,
            });

            Assert.AreEqual(2, puzzle.NumberOfUnsolvedCells);
        }

        [Test]
        public void Puzzle_NumberOfUnsolvedCells_SuccessfullyReturnsZeroIfAllCellsAreSolved()
        {
            var puzzle = new Puzzle();

            puzzle.AddCell(new PuzzleCell()
            {
                CellValue = 1u,
            });
            puzzle.AddCell(new PuzzleCell()
            {
                CellValue = 1u,
            });

            Assert.AreEqual(0, puzzle.NumberOfUnsolvedCells);
        }

        [TestCase("Easy4x4Puzzle.txt")]
        [TestCase("Easy4x4Puzzle2.txt")]
        public void Puzzle_Solve_SuccessfullySolvesTestPuzzles(string testPuzzleFileName)
        {
            var testFile = Path.Combine(TestPuzzleDir, testPuzzleFileName);

            Assert.IsTrue(File.Exists(testFile));

            var puzzle = Parser.ParsePuzzle(testFile);

            Assert.IsTrue(puzzle.Solve());
        }
    }
}
