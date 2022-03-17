// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1633:File should have header", Justification = "Not applicable")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1200:Using directives should be placed correctly", Justification = "This should be addressed.")]
[assembly: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:Prefix local calls with this", Justification = "Disagree with use of this")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1208:System using directives should be placed before other using directives", Justification = "Disagree with ordering")]
[assembly: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "This could be investigated")]
[assembly: SuppressMessage("Critical Code Smell", "S2365:Properties should not make collection or array copies", Justification = "Acceptable for now", Scope = "member", Target = "~P:KakuroSolver.Cells.PuzzleCell.PossibleValues")]
[assembly: SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "Not required", Scope = "type", Target = "~T:KakuroSolver.KakuroSolverException")]
