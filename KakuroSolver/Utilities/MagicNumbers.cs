using System.Collections.Generic;

namespace KakuroSolver.Utilities
{
    class IntegerPartitions
    {
        /// <summary>
        /// Gets the length of partition.
        /// </summary>
        public uint PartitionLength { get; private set; }

        /// <summary>
        /// Gets the total value of the partition.
        /// </summary>
        public uint Total { get; private set; }

        /// <summary>
        /// Gets a list of all of the valid integer partitions combinations.
        /// </summary>
        /// <remarks>
        /// The list returned is a deep copy of the original allowing the user
        /// to modifiy the list as required.
        /// </remarks>
        public List<List<uint>> Values
        {
            get { return values.ConvertAll(v => new List<uint>(v)); }
            private set { values = value; }
        }

        /// <summary>
        /// Underlying integer partition combinations values.
        /// </summary>
        private List<List<uint>> values;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="partitionLength">The length of the partition.</param>
        /// <param name="total">The total value of the partition.</param>
        /// <param name="values">List of the valid integer partition combinations.</param>
        public IntegerPartitions(uint partitionLength, uint total, List<List<uint>> values)
        {
            PartitionLength = partitionLength;
            Total = total;
            this.values = values;
        }
    }

    sealed class MagicNumbers
    {
        /// <summary>
        /// Collection of known magic numbers.
        /// </summary>
        public static readonly List<IntegerPartitions> MagicNumberValues = new()
        {
            new IntegerPartitions(2, 3, new List<List<uint>>() { new List<uint> { 1, 2, } }),
            new IntegerPartitions(2, 4, new List<List<uint>>() { new List<uint> { 1, 3, } }),
            new IntegerPartitions(2, 16, new List<List<uint>>() { new List<uint> { 7, 9, } }),
            new IntegerPartitions(2, 17, new List<List<uint>>() { new List<uint> { 8, 9, } }),
            new IntegerPartitions(3, 6, new List<List<uint>>() { new List<uint> { 1, 2, 3, } }),
            new IntegerPartitions(3, 7, new List<List<uint>>() { new List<uint> { 1, 2, 4, } }),
            new IntegerPartitions(3, 23, new List<List<uint>>() { new List<uint> { 6, 8, 9, } }),
            new IntegerPartitions(3, 24, new List<List<uint>>() { new List<uint> { 7, 8, 9, } }),
            new IntegerPartitions(4, 10, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, } }),
            new IntegerPartitions(4, 11, new List<List<uint>>() { new List<uint> { 1, 2, 3, 5, } }),
            new IntegerPartitions(4, 29, new List<List<uint>>() { new List<uint> { 5, 7, 8, 9, } }),
            new IntegerPartitions(4, 30, new List<List<uint>>() { new List<uint> { 6, 7, 8, 9, } }),
            new IntegerPartitions(5, 15, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, } }),
            new IntegerPartitions(5, 16, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 6, } }),
            new IntegerPartitions(5, 34, new List<List<uint>>() { new List<uint> { 4, 6, 7, 8, 9, } }),
            new IntegerPartitions(5, 35, new List<List<uint>>() { new List<uint> { 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(6, 21, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, } }),
            new IntegerPartitions(6, 22, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 7, } }),
            new IntegerPartitions(6, 38, new List<List<uint>>() { new List<uint> { 3, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(6, 39, new List<List<uint>>() { new List<uint> { 4, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(7, 28, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, } }),
            new IntegerPartitions(7, 29, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 8, } }),
            new IntegerPartitions(7, 41, new List<List<uint>>() { new List<uint> { 2, 4, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(7, 42, new List<List<uint>>() { new List<uint> { 3, 4, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(8, 36, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, 8, } }),
            new IntegerPartitions(8, 37, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, 9, } }),
            new IntegerPartitions(8, 38, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 8, 9, } }),
            new IntegerPartitions(8, 39, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 7, 8, 9, } }),
            new IntegerPartitions(8, 40, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 6, 7, 8, 9, } }),
            new IntegerPartitions(8, 41, new List<List<uint>>() { new List<uint> { 1, 2, 3, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(8, 42, new List<List<uint>>() { new List<uint> { 1, 2, 4, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(8, 43, new List<List<uint>>() { new List<uint> { 1, 3, 4, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(8, 44, new List<List<uint>>() { new List<uint> { 2, 3, 4, 5, 6, 7, 8, 9, } }),
            new IntegerPartitions(9, 45, new List<List<uint>>() { new List<uint> { 1, 2, 3, 4, 5, 6, 7, 8, 9, } }),
        };
    }
}
