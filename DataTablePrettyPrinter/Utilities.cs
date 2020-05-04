namespace DataTablePrettyPrinter
{
    /// <summary>
    /// A utility class with miscellaneous methods.
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Swaps the values of <paramref name="x"/> and <paramref name="y"/>.
        /// </summary>
        ///
        /// <typeparam name="T">
        /// The type of the values to swap.
        /// </typeparam>
        ///
        /// <param name="x">
        /// The value to swap with <paramref name="y"/>.
        /// </param>
        ///
        /// <param name="y">
        /// The value to swap with <paramref name="x"/>.
        /// </param>
        internal static void Swap<T>(ref T x, ref T y)
        {
            T z = x;

            x = y;
            y = z;
        }
    }
}
