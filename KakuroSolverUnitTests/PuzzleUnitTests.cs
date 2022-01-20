using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace KakuroSolver.UnitTests
{
    [TestClass]
    public class PuzzleUnitTests
    {
        private const string TestPuzzleDir = "TestPuzzles";

        [TestMethod]
        public void Puzzle_Solve_4x4Puzzle()
        {
            var testFile = Path.Combine(TestPuzzleDir, "Easy4x4Puzzle.txt");

            Assert.IsTrue(File.Exists(testFile));

            var puzzle = Parser.ParsePuzzle(testFile);

            Assert.IsTrue(puzzle.Solve());
        }

        [TestMethod]
        public void Puzzle_Solve_4x4Puzzle2()
        {
            var testFile = Path.Combine(TestPuzzleDir, "Easy4x4Puzzle2.txt");

            Assert.IsTrue(File.Exists(testFile));

            var puzzle = Parser.ParsePuzzle(testFile);

            Assert.IsTrue(puzzle.Solve());
        }
    }
}
