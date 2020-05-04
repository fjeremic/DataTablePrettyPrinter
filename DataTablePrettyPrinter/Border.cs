namespace DataTablePrettyPrinter
{
    using System;
    using System.Data;

    /// <summary>
    /// Enumerates the border flags of the text represented by a <see cref="DataTable"/> which is to be drawn on a
    /// pretty printed string.
    /// </summary>
    [Flags]
    public enum Border
    {
        /// <summary>
        /// No border.
        /// </summary>
        None = 0,

        /// <summary>
        /// Bottom border.
        /// </summary>
        Bottom = 1,

        /// <summary>
        /// Left border.
        /// </summary>
        Left = 2,

        /// <summary>
        /// Right border.
        /// </summary>
        Right = 4,

        /// <summary>
        /// Top border.
        /// </summary>
        Top = 8,

        /// <summary>
        /// All borders.
        /// </summary>
        All = 15,
    }
}
