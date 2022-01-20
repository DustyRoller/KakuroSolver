using System.Collections.Generic;

namespace KakuroSolver.Utilities
{
    class IntegerPartitions
    {
        public uint PartitionLength;
        public uint Total;
        public List<List<uint>> Values;
    }

    sealed class MagicNumbers
    {
        /// <summary>
        /// Collection of known magic numbers.
        /// </summary>
        public static readonly List<IntegerPartitions> MagicNumberValues = new()
        {
            new IntegerPartitions { PartitionLength = 2, Total = 3, Values = new List<List<uint>>() { new List<uint> { 1, 2, } } },
            new IntegerPartitions { PartitionLength = 2, Total = 4, Values = new List<List<uint>>() { new List<uint> { 1, 3, } } },
            new IntegerPartitions { PartitionLength = 2, Total = 16, Values = new List<List<uint>>() { new List<uint> { 7, 9, } } },
            new IntegerPartitions { PartitionLength = 2, Total = 17, Values = new List<List<uint>>() { new List<uint> { 8, 9, } } },
            new IntegerPartitions { PartitionLength = 3, Total = 6, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, } } },
            new IntegerPartitions { PartitionLength = 3, Total = 7, Values = new List<List<uint>>() { new List<uint> { 1, 2, 4, } } },
            new IntegerPartitions { PartitionLength = 3, Total = 23, Values = new List<List<uint>>() { new List<uint> { 6, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 3, Total = 24, Values = new List<List<uint>>() { new List<uint> { 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 4, Total = 10, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, } } },
            new IntegerPartitions { PartitionLength = 4, Total = 11, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 5, } } },
            new IntegerPartitions { PartitionLength = 4, Total = 29, Values = new List<List<uint>>() { new List<uint> { 5, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 4, Total = 30, Values = new List<List<uint>>() { new List<uint> { 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 5, Total = 15, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, } } },
            new IntegerPartitions { PartitionLength = 5, Total = 16, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 6, } } },
            new IntegerPartitions { PartitionLength = 5, Total = 34, Values = new List<List<uint>>() { new List<uint> { 4, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 5, Total = 35, Values = new List<List<uint>>() { new List<uint> { 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 6, Total = 21, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, } } },
            new IntegerPartitions { PartitionLength = 6, Total = 22, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 7, } } },
            new IntegerPartitions { PartitionLength = 6, Total = 38, Values = new List<List<uint>>() { new List<uint> { 3, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 6, Total = 39, Values = new List<List<uint>>() { new List<uint> { 4, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 7, Total = 28, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, } } },
            new IntegerPartitions { PartitionLength = 7, Total = 29, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 8, } } },
            new IntegerPartitions { PartitionLength = 7, Total = 41, Values = new List<List<uint>>() { new List<uint> { 2, 4, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 7, Total = 42, Values = new List<List<uint>>() { new List<uint> { 3, 4, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 36, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, 8, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 37, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 38, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 39, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 40, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 41, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 42, Values = new List<List<uint>>() { new List<uint> { 1, 2, 4, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 43, Values = new List<List<uint>>() { new List<uint> { 1, 3, 4, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 8, Total = 44, Values = new List<List<uint>>() { new List<uint> { 2, 3, 4, 5, 6, 7, 8, 9, } } },
            new IntegerPartitions { PartitionLength = 9, Total = 45, Values = new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, 8, 9, } } },
        };
    }
}
