﻿namespace KakuroSolver
{
    /// <summary>
    /// Exception class for exceptions throw whilst parsing a puzzle.
    /// </summary>
    internal class ParserException : KakuroSolverException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        /// <param name="message">The message to be associate with the exception.</param>
        public ParserException(string message)
            : base(message)
        {
        }
    }
}
