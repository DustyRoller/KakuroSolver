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
        /// <param name="total">The total value of the partition.</param>
        /// <param name="partitionLength">The length of the partition.</param>
        /// <param name="values">List of the valid integer partition combinations.</param>
        public IntegerPartitions(uint total, uint partitionLength, List<List<uint>> values)
        {
            PartitionLength = partitionLength;
            Total = total;
            this.values = values;
        }
    }
}
