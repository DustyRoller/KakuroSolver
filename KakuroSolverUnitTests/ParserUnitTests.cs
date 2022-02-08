using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace KakuroSolver.UnitTests
{
    [TestClass]
    public class ParserUnitTests
    {
        private const string TestPuzzleFileName = "TestPuzzle.txt";

        private const string TestPuzzleDir = "TestPuzzles";

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Parser_ParsePuzzle_FailsWithNonExistantFile()
        {
            Parser.ParsePuzzle("randomfile");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parser_ParsePuzzle_FailsWithInvalidFileExtension()
        {
            var fileName = "test.fdg";

            File.Create(fileName).Close();

            Parser.ParsePuzzle(fileName);

            File.Delete(fileName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parser_ParsePuzzle_FailsWithEmptyFile()
        {
            File.Create(TestPuzzleFileName).Close();

            Parser.ParsePuzzle(TestPuzzleFileName);

            File.Delete(TestPuzzleFileName);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void Parser_ParsePuzzle_FailsWithPuzzleWithDifferentColumnLengths()
        {
            var sb = new StringBuilder();
            // First line has 3 columns, second has 4 columns.
            sb.AppendLine("|x|x|x|");
            sb.AppendLine("|x|x|x|x|");

            File.WriteAllText(TestPuzzleFileName, sb.ToString());

            Parser.ParsePuzzle(TestPuzzleFileName);

            File.Delete(TestPuzzleFileName);
        }

        [TestMethod]
        [ExpectedException(typeof(ParserException))]
        public void Parser_ParsePuzzle_FailsWithPuzzleWithInvalidCharacters()
        {
            var sb = new StringBuilder();
            sb.AppendLine("|x|x|x|");
            sb.AppendLine("|x|?|x|");

            File.WriteAllText(TestPuzzleFileName, sb.ToString());

            Parser.ParsePuzzle(TestPuzzleFileName);

            File.Delete(TestPuzzleFileName);
        }

        [TestMethod]
        public void Parser_ParsePuzzle_Successful()
        {
            var testFile = Path.Combine(TestPuzzleDir, "Easy4x4Puzzle.txt");

            Assert.IsTrue(File.Exists(testFile));

            var puzzle = Parser.ParsePuzzle(testFile);

            Assert.AreEqual(25, puzzle.Cells.Count);
            Assert.AreEqual(5u, puzzle.Width);
            Assert.AreEqual(5u, puzzle.Height);

            Assert.IsInstanceOfType(puzzle.Cells[0], typeof(BlankCell));

            Assert.AreEqual(17u, ((ClueCell)puzzle.Cells[1]).ColumnClue);
            Assert.AreEqual(new Coordinate(0u, 1u), puzzle.Cells[1].Coordinate);

            Assert.AreEqual(24u, ((ClueCell)puzzle.Cells[2]).ColumnClue);
            Assert.AreEqual(new Coordinate(0u, 2u), puzzle.Cells[2].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[3], typeof(BlankCell));
            Assert.IsInstanceOfType(puzzle.Cells[4], typeof(BlankCell));

            Assert.AreEqual(16u, ((ClueCell)puzzle.Cells[5]).RowClue);
            Assert.AreEqual(new Coordinate(1u, 0u), puzzle.Cells[5].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[6], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(1u, 1u), puzzle.Cells[6].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[7], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(1u, 2u), puzzle.Cells[7].Coordinate);

            Assert.AreEqual(20u, ((ClueCell)puzzle.Cells[8]).ColumnClue);
            Assert.AreEqual(new Coordinate(1u, 3u), puzzle.Cells[8].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[9], typeof(BlankCell));

            Assert.AreEqual(23u, ((ClueCell)puzzle.Cells[10]).RowClue);
            Assert.AreEqual(new Coordinate(2u, 0u), puzzle.Cells[10].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[11], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(2u, 1u), puzzle.Cells[11].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[12], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(2u, 2u), puzzle.Cells[12].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[13], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(2u, 3u), puzzle.Cells[13].Coordinate);

            Assert.AreEqual(15u, ((ClueCell)puzzle.Cells[14]).ColumnClue);
            Assert.AreEqual(new Coordinate(2u, 4u), puzzle.Cells[14].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[15], typeof(BlankCell));

            Assert.AreEqual(23u, ((ClueCell)puzzle.Cells[16]).RowClue);
            Assert.AreEqual(new Coordinate(3u, 1u), puzzle.Cells[16].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[17], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(3u, 2u), puzzle.Cells[17].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[18], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(3u, 3u), puzzle.Cells[18].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[19], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(3u, 4u), puzzle.Cells[19].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[20], typeof(BlankCell));
            Assert.IsInstanceOfType(puzzle.Cells[21], typeof(BlankCell));

            Assert.AreEqual(14u, ((ClueCell)puzzle.Cells[22]).RowClue);
            Assert.AreEqual(new Coordinate(4u, 2u), puzzle.Cells[22].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[13], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(4u, 3u), puzzle.Cells[23].Coordinate);

            Assert.IsInstanceOfType(puzzle.Cells[24], typeof(PuzzleCell));
            Assert.AreEqual(new Coordinate(4u, 4u), puzzle.Cells[24].Coordinate);
        }
    }
}
