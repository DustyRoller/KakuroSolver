using System;
using System.Collections.Generic;
using System.Linq;

namespace KakuroSolver.Utilities
{
    class IntegerPartitionCalculator
    {
        /// <summary>
        /// Calculate the distinct integer partitionss for the given set
        /// of arguments.
        /// </summary>
        /// <param name="sum">The sum that the partitions must add up to.</param>
        /// <param name="partitionLength">The number of partitions.</param>
        /// <param name="minimumValue">The minimum value to be used in the partitions.</param>
        /// <param name="maximumValue">The maximum value to be used in the partitions.</param>
        /// <returns>A List of integer partitions.</returns>
        public static List<List<uint>> CalculateDistinctIntegerPartitions(uint sum, uint partitionLength, uint minimumValue = 1, uint maximumValue = 9)
        {
            // Provide some input validation before calling the recursive function.
            if (maximumValue > 9)
            {
                throw new ArgumentException("Maximum value cannot be greater than 9.");
            }

            if (maximumValue >= sum)
            {
                throw new ArgumentException("Maximum value cannot be greater than or equal to sum.");
            }

            if (minimumValue >= maximumValue)
            {
                throw new ArgumentException("Minimum value must be less than the maximum value.");
            }

            if (maximumValue <= minimumValue)
            {
                throw new ArgumentException("Maximum value must be greater than the minimum value.");
            }

            // Check if the given parameters match those of a magic number.
            var magicNumber = MagicNumbers.MagicNumberValues.FirstOrDefault(mn => mn.Total == sum &&
                                                                            mn.PartitionLength == partitionLength &&
                                                                            mn.Values[0].All(v => v >= minimumValue && v <= maximumValue));

            // If the value is a magic number then return those values,
            // otherwise calculate the partitions.
            return (magicNumber != null) ? magicNumber.Values
                                         : CalculateDistinctIntegerPartitionsRecursive(sum, partitionLength,
                                                                                       minimumValue, maximumValue);
        }

        /// <summary>
        /// Recursively calculate the distinct integer partitionss for the
        /// given set of arguments.
        /// </summary>
        /// <param name="sum">The sum that the partitions must add up to.</param>
        /// <param name="partitionLength">The number of partitions.</param>
        /// <param name="minimumValue">The minimum value to be used in the partitions.</param>
        /// <param name="maximumValue">The maximum value to be used in the partitions.</param>
        /// <returns>A List of integer partitions.</returns>
        private static List<List<uint>> CalculateDistinctIntegerPartitionsRecursive(uint sum, uint partitionLength, uint minimumValue = 1, uint maximumValue = 9)
        {
            var partitions = new List<List<uint>>();

            // Recursively find the integer partitions until we get to 1 or less.
            if (sum > 1)
            {
                for (var i = Math.Min(sum, maximumValue); i >= minimumValue; i--)
                {
                    var recursivePartitions = CalculateDistinctIntegerPartitionsRecursive(sum - i, partitionLength - 1, minimumValue, i);
                    foreach (var recursivePartition in recursivePartitions)
                    {
                        recursivePartition.Add(i);

                        // Do any of the other partitions also contain the same numbers in a different order.
                        if (!partitions.Any(r => r.All(recursivePartition.Contains))
                            && recursivePartition.Distinct().Count() == recursivePartition.Count
                            && partitionLength == recursivePartition.Count
                            && recursivePartition.Sum() == sum)
                        {
                            partitions.Add(recursivePartition);
                        }
                    }
                }
            }
            else
            {
                var partition = (sum == 0 || sum < minimumValue)
                    ? new List<uint>()
                    : new List<uint>() { sum };

                partitions.Add(partition);
            }

            return partitions;
        }
    }
}
