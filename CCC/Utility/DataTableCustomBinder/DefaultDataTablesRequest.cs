﻿#region Copyright
/* The MIT License (MIT)

Copyright (c) 2014 Anderson Luiz Mendes Matos

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion Copyright

namespace DataTables.Mvc
{
    /// <summary>
    /// Implements a default DataTables request.
    /// </summary>
    public class DefaultDataTablesRequest : IDataTablesRequest
    {
        /// <summary>
        /// Gets/Sets the draw counter from DataTables.
        /// </summary>
        public virtual int Draw { get; set; }
        /// <summary>
        /// Gets/Sets the start record number (jump) for paging.
        /// </summary>
        public virtual int Start { get; set; }
        /// <summary>
        /// Gets/Sets the length of the page (paging).
        /// </summary>
        public virtual int Length { get; set; }
        /// <summary>
        /// Gets/Sets the global search term.
        /// </summary>
        public virtual Search Search { get; set; }
        /// <summary>
        /// Gets/Sets the column collection.
        /// </summary>
        public virtual ColumnCollection Columns { get; set; }


        public string SortColumnName
        {

            get
            {
                string s = string.Empty;

                foreach (var col in Columns)
                {
                    if (col.IsOrdered)
                        s = col.Name;
                }
                return s;
            }

        }


        public Column.OrderDirection SortDirection
        {
            get
            {
                string s = string.Empty;

                foreach (var col in Columns)
                {
                    if (col.IsOrdered)
                        return col.SortDirection;
                }
                return Column.OrderDirection.Ascendant;
            }
        }


        public int PageIndex
        {
            get
            {

                if (Start == 0)
                    return 1;
                else
                {
                    return (Start / Length) + 1;
                }


            }
        }


        public bool frmCurrentPage { get; set; }

    }
}
