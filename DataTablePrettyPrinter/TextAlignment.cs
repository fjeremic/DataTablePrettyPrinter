namespace DataTablePrettyPrinter
{
    using System.Data;

    /// <summary>
    /// Enumerates the alignment of the text represented by a <see cref="DataTable"/> which is to be pretty printing to
    /// a string.
    /// </summary>
    public enum TextAlignment
    {
        /// <summary>
        /// Text is centered.
        /// </summary>
        Center,

        /// <summary>
        /// Text is aligned to the left.
        /// </summary>
        Left,

        /// <summary>
        /// Text is aligned to the right.
        /// </summary>
        Right,
    }
}
