using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace KakuroSolver.UnitTests
{
    [TestFixture]
    public class ParserUnitTests
    {
        private const string TestPuzzleFileName = "TestPuzzle.txt";

        private const string TestPuzzleDir = "TestPuzzles";

        [Test]
        public void Parser_ParsePuzzle_FailsWithNonExistantFile()
        {
            var ex = Assert.Throws<FileNotFoundException>(() => Parser.ParsePuzzle("randomfile"));

            Assert.AreEqual("Unable to find puzzle file.", ex.Message);
        }

        [Test]
        public void Parser_ParsePuzzle_FailsWithInvalidFileExtension()
        {
            var fileName = "test.fdg";

            File.Create(fileName).Close();

            var ex = Assert.Throws<ArgumentException>(() => Parser.ParsePuzzle(fileName));

            Assert.AreEqual("Invalid file type, expected .txt. (Parameter 'puzzleFilePath')", ex.Message);

            File.Delete(fileName);
        }

        [Test]
        public void Parser_ParsePuzzle_FailsWithEmptyFile()
        {
            File.Create(TestPuzzleFileName).Close();

            var ex = Assert.Throws<ArgumentException>(() => Parser.ParsePuzzle(TestPuzzleFileName));

            Assert.AreEqual("Puzzle file is empty. (Parameter 'puzzleFilePath')", ex.Message);

            File.Delete(TestPuzzleFileName);
        }

        [Test]
        public void Parser_ParsePuzzle_FailsWithPuzzleWithDifferentColumnLengths()
        {
            var sb = new StringBuilder();
            // First line has 3 columns, second has 4 columns.
            sb.AppendLine("|x|x|x|");
            sb.AppendLine("|x|x|x|x|");

            File.WriteAllText(TestPuzzleFileName, sb.ToString());

            var ex = Assert.Throws<ParserException>(() => Parser.ParsePuzzle(TestPuzzleFileName));

            Assert.AreEqual("Mismatch in row width on row 1.", ex.Message);

            File.Delete(TestPuzzleFileName);
        }

        [Test]
        public void Parser_ParsePuzzle_FailsWithPuzzleWithInvalidCharacters()
        {
            var sb = new StringBuilder();
            sb.AppendLine("|x|x|x|");
            sb.AppendLine("|x|?|x|");

            File.WriteAllText(TestPuzzleFileName, sb.ToString());

            var ex = Assert.Throws<ParserException>(() => Parser.ParsePuzzle(TestPuzzleFileName));

            Assert.AreEqual("Found invalid cell data: ?.", ex.Message);

            File.Delete(TestPuzzleFileName);
        }

        [Test]
        public void Parser_ParsePuzzle_Successful()
        {
            var testFile = Path.Combine(TestPuzzleDir, "Easy4x4Puzzle.txt");

            Assert.IsTrue(File.Exists(testFile));

            var puzzle = Parser.ParsePuzzle(testFile);

            Assert.AreEqual(25, puzzle.Cells.Count);
            Assert.AreEqual(5u, puzzle.Width);
            Assert.AreEqual(5u, puzzle.Height);

            Assert.IsInstanceOf(typeof(BlankCell), puzzle.Cells[0]);

            Assert.AreEqual(17u, ((ClueCell)puzzle.Cells[1]).ColumnClue);
            Assert.AreEqual(new Coordinate(1u, 0u), puzzle.Cells[1].Coordinate);

            Assert.AreEqual(24u, ((ClueCell)puzzle.Cells[2]).ColumnClue);
            Assert.AreEqual(new Coordinate(2u, 0u), puzzle.Cells[2].Coordinate);

            Assert.IsInstanceOf(typeof(BlankCell), puzzle.Cells[3]);
            Assert.IsInstanceOf(typeof(BlankCell), puzzle.Cells[4]);

            Assert.AreEqual(16u, ((ClueCell)puzzle.Cells[5]).RowClue);
            Assert.AreEqual(new Coordinate(0u, 1u), puzzle.Cells[5].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[6]);
            Assert.AreEqual(new Coordinate(1u, 1u), puzzle.Cells[6].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[7]);
            Assert.AreEqual(new Coordinate(2u, 1u), puzzle.Cells[7].Coordinate);

            Assert.AreEqual(20u, ((ClueCell)puzzle.Cells[8]).ColumnClue);
            Assert.AreEqual(new Coordinate(3u, 1u), puzzle.Cells[8].Coordinate);

            Assert.IsInstanceOf(typeof(BlankCell), puzzle.Cells[9]);

            Assert.AreEqual(23u, ((ClueCell)puzzle.Cells[10]).RowClue);
            Assert.AreEqual(new Coordinate(0u, 2u), puzzle.Cells[10].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[11]);
            Assert.AreEqual(new Coordinate(1u, 2u), puzzle.Cells[11].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[12]);
            Assert.AreEqual(new Coordinate(2u, 2u), puzzle.Cells[12].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[13]);
            Assert.AreEqual(new Coordinate(3u, 2u), puzzle.Cells[13].Coordinate);

            Assert.AreEqual(15u, ((ClueCell)puzzle.Cells[14]).ColumnClue);
            Assert.AreEqual(new Coordinate(4u, 2u), puzzle.Cells[14].Coordinate);

            Assert.IsInstanceOf(typeof(BlankCell), puzzle.Cells[15]);

            Assert.AreEqual(23u, ((ClueCell)puzzle.Cells[16]).RowClue);
            Assert.AreEqual(new Coordinate(1u, 3u), puzzle.Cells[16].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[17]);
            Assert.AreEqual(new Coordinate(2u, 3u), puzzle.Cells[17].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[18]);
            Assert.AreEqual(new Coordinate(3u, 3u), puzzle.Cells[18].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[19]);
            Assert.AreEqual(new Coordinate(4u, 3u), puzzle.Cells[19].Coordinate);

            Assert.IsInstanceOf(typeof(BlankCell), puzzle.Cells[20]);
            Assert.IsInstanceOf(typeof(BlankCell), puzzle.Cells[21]);

            Assert.AreEqual(14u, ((ClueCell)puzzle.Cells[22]).RowClue);
            Assert.AreEqual(new Coordinate(2u, 4u), puzzle.Cells[22].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[13]);
            Assert.AreEqual(new Coordinate(3u, 4u), puzzle.Cells[23].Coordinate);

            Assert.IsInstanceOf(typeof(PuzzleCell), puzzle.Cells[24]);
            Assert.AreEqual(new Coordinate(4u, 4u), puzzle.Cells[24].Coordinate);
        }
    }
}
