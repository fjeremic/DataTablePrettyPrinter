using System;

namespace DataTablePrettyPrinter
{
    /// <summary>
    /// An extension class providing <see cref="Char"/> utility methods for pretty printing to a string.
    /// </summary>
    internal static class CharExtensions
    {
        /// <summary>
        /// Draws a border on a canvas given a bounding box specified by coordinates
        /// </summary>
        /// 
        /// <param name="canvas">
        /// The canvas to draw on which is assumed to be large enough.
        /// </param>
        /// 
        /// <param name="x1">
        /// The x coordinate of the beginning of the bounding box to draw.
        /// </param>
        /// 
        /// <param name="y1">
        /// The y coordinate of the beginning of the bounding box to draw.
        /// </param>
        /// 
        /// <param name="x2">
        /// The x coordinate of the end of the bounding box to draw.
        /// </param>
        /// 
        /// <param name="y2">
        /// The y coordinate of the end of the bounding box to draw.
        /// </param>
        /// 
        /// <param name="border">
        /// The border flags which dictate which border to draw.
        /// </param>
        internal static void DrawBorder(this Char[,] canvas, Int32 x1, Int32 y1, Int32 x2, Int32 y2, Border border)
        {
            if (border.HasFlag(Border.Top))
            {
                canvas.DrawLine(x1, y1, x2, y1);
            }

            if (border.HasFlag(Border.Bottom))
            {
                canvas.DrawLine(x1, y2, x2, y2);
            }

            if (border.HasFlag(Border.Left))
            {
                canvas.DrawLine(x1, y1, x1, y2);
            }

            if (border.HasFlag(Border.Right))
            {
                canvas.DrawLine(x2, y1, x2, y2);
            }
        }

        /// <summary>
        /// Draws a line on a canvas given a beginning and an end coordinate.
        /// </summary>
        /// 
        /// <param name="canvas">
        /// The canvas to draw on which is assumed to be large enough.
        /// </param>
        /// 
        /// <param name="x1">
        /// The x coordinate of the beginning of the line to draw.
        /// </param>
        /// 
        /// <param name="y1">
        /// The y coordinate of the beginning of the line to draw.
        /// </param>
        /// 
        /// <param name="x2">
        /// The x coordinate of the end of the line to draw.
        /// </param>
        /// 
        /// <param name="y2">
        /// The y coordinate of the end of the line to draw.
        /// </param>
        /// 
        /// <remarks>
        /// If this line crosses any other line drawn on the canvas then a '+' is inserted on the crossing boundary.
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the line is neither horizontal nor vertical.
        /// </exception>
        internal static void DrawLine(this Char[,] canvas, Int32 x1, Int32 y1, Int32 x2, Int32 y2)
        {
            if (x1 != x2 && y1 != y2)
            {
                throw new ArgumentException("Cannot draw non-horizontal or non-vertical lines");
            }

            if (x1 == x2)
            {
                if (y1 > y2)
                {
                    Utilities.Swap(ref y1, ref y2);
                }

                for (var y = y1; y <= y2; ++y)
                {
                    canvas[y, x1] = (y == y1 || y == y2 || canvas[y, x1] == '-' || canvas[y, x1] == '+') ? '+' : '|';
                }
            }
            else
            {
                if (x1 > x2)
                {
                    Utilities.Swap(ref x1, ref x2);
                }

                for (var x = x1; x <= x2; ++x)
                {
                    canvas[y1, x] = (x == x1 || x == x2 || canvas[y1, x] == '|' || canvas[y1, x] == '+') ? '+' : '-';
                }
            }
        }

        /// <summary>
        /// Draws a string on a canvas with alignment specified.
        /// </summary>
        /// 
        /// <param name="canvas">
        /// The canvas to draw on which is assumed to be large enough.
        /// </param>
        /// 
        /// <param name="x1">
        /// The x coordinate of the beginning of the string to draw.
        /// </param>
        /// 
        /// <param name="y1">
        /// The y coordinate of the beginning of the string to draw.
        /// </param>
        /// 
        /// <param name="x2">
        /// The x coordinate of the end of the string to draw.
        /// </param>
        /// 
        /// <param name="y2">
        /// The y coordinate of the end of the string to draw.
        /// </param>
        /// 
        /// <param name="text">
        /// The text to draw.
        /// </param>
        /// 
        /// <param name="alignment">
        /// The alignment of the <paramref name="text"/> to draw.
        /// </param>
        /// 
        /// <remarks>
        /// If the text cannot be contained within the bounding box specified by the coordinates then either nothing is
        /// drawn or the input string is truncated and '..' is added to the end.
        /// </remarks>
        internal static void DrawText(this Char[,] canvas, Int32 x1, Int32 y1, Int32 x2, Int32 y2, String text, TextAlignment alignment)
        {
            // Truncate the text if it will not fit in the text box bounds
            if (text.Length > x2 - x1 + 1)
            {
                if (x2 - x1 >= 1)
                {
                    text = text.Substring(0, x2 - x1 - 1) + "..";
                }
                else
                {
                    return;
                }
            }

            // Update the coordinates based the text alignment
            switch (alignment)
            {
                case TextAlignment.Center:
                {
                    y1 = (y2 + y1) / 2;
                    y2 = y1;

                    x1 += (x2 - x1 + 1 - text.Length) / 2;
                }
                break;

                case TextAlignment.Left:
                {
                    y1 = (y2 + y1) / 2;
                    y2 = y1;
                }
                break;

                case TextAlignment.Right:
                {
                    y1 = (y2 + y1) / 2;
                    y2 = y1;

                    x1 = x2 - text.Length + 1;
                }
                break;

                default:
                {
                    throw new InvalidOperationException("Unreachable case reached");
                }
            }

            for (var x = x1; x < x1 + text.Length; ++x)
            {
                canvas[y1, x] = text[x - x1];
            }
        }
    }
}
