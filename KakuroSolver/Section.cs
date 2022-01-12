using System.Collections.Generic;

namespace KakuroSolver
{
    /// <summary>
    /// A section represents a ClueCell and a list of PuzzleCells.
    /// The sum of the values of the PuzzleCells must add up to the value
    /// of the ClueCell.
    /// </summary>
    class Section
    {
        public enum SectionDirection
        {
            Column,
            Row,
        }

        public ClueCell ClueCell { get; set; }

        public SectionDirection Direction { get; set; }

        public List<PuzzleCell> PuzzleCells { get; set; }
    }
}
