using NUnit.Framework;
using System.IO;

namespace KakuroSolver.UnitTests
{
    [TestFixture]
    public class PuzzleUnitTests
    {
        private const string TestPuzzleDir = "TestPuzzles";

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
