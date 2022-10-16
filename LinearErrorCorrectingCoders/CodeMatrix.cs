using System.Collections;
using System.Text;

namespace LinearErrorCorrectingCoders
{
    /// <summary>
    /// Marix for strore logical (bool) values and make simple operations. Target for applying in linear error-correcting codes
    /// </summary>
    public class CodeMatrix
    {
        protected List<BitArray> ColumnsData;
        private int Rows;
        private int Cols;

        /// <summary>
        /// Creates matrix row x col dimentions filled by "false" value
        /// </summary>
        /// <param name="row">Number of rows in new matrix/param>
        /// <param name="col">Number of columns in new matrix</param>
        /// <exception cref="ArgumentException">Raise exception if rows or cols is LE 0</exception>
        public CodeMatrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("rows or cols is LE 0");
            Rows = rows;
            Cols = cols;
            ColumnsData = new List<BitArray>(Cols);
            for(int c = 0; c < Cols; c++)
            {
                ColumnsData.Add(new BitArray(Rows));
            }
        }

        /// <summary>
        /// Creates square marix
        /// </summary>
        /// <param name="order">Order of square marix</param>
        /// <exception cref="ArgumentException">Raise exception if order LE 0</exception>
        public CodeMatrix(int order)
        {
            if (order <= 0)
                throw new ArgumentException("order is LE 0");
            Rows = order;
            Cols = order;
            ColumnsData = new List<BitArray>(Cols);
            for (int c = 0; c < Cols; c++)
            {
                ColumnsData.Add(new BitArray(Rows));
            }
        }

        /// <summary>
        /// Creates square marix
        /// </summary>
        /// <param name="order">Order of square marix</param>
        /// <param name="identy">if true creates identy marix</param>
        public CodeMatrix(int order, bool identy) : this(order)
        {
            if(identy)
            {
                for (int c = 0; c < Cols; c++)
                {
                    ColumnsData[c].Set(c, true);
                }
            }
        }

        /// <summary>
        /// Number elements in this matrix (Rows * Cols)
        /// </summary>
        /// <returns>Number elements in this matrix</returns>
        public int GetLength()
        {
            return Rows * Cols;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="codeMatrix">object to copys</param>
        public CodeMatrix(CodeMatrix codeMatrix)
        {
            Rows = codeMatrix.Rows;
            Cols = codeMatrix.Cols;
            ColumnsData = new List<BitArray>(Cols);
            bool[] arr = new bool[Rows];
            for (int c = 0; c < Cols; c++)
            {
                codeMatrix.ColumnsData[c].CopyTo(arr, 0);
                ColumnsData.Add(new BitArray(arr));
            }
        }

        /// <summary>
        /// Constructor from 2D array
        /// </summary>
        /// <param name="array">2D array</param>
        /// <exception cref="ArgumentException">Raise exception if number of dimention in array lower than 2 or number of elements LE 0</exception>
        public CodeMatrix(bool[,] array)
        {
            if (array.Rank < 2)
                throw new ArgumentException("array.Rank < 2");
            if (array.GetLength(0) <= 0)
                throw new ArgumentException("array.GetLength(0) is LE 0");
            if (array.GetLength(1) <= 0)
                throw new ArgumentException("array.GetLength(1) is LE 0");
            Rows = array.GetLength(0);
            Cols = array.GetLength(1);

            ColumnsData = new List<BitArray>(Cols);
            for (int c = 0; c < Cols; c++)
            {
                ColumnsData.Add(new BitArray(Rows));
                for (int r = 0; r < Rows; r++)
                {
                    ColumnsData[c].Set(r, array[r, c]);
                }
            }
        }

        /// <summary>
        /// String respresentaion of CodeMatrix where "0" - false, "1" - true;
        /// </summary>
        /// <returns>String respresentaion of matrix</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Rows * Cols + Rows + 1);
            for (int r = 0; r < Rows; r++)
            {
                if (sb.Length != 0)
                    sb.Append("\n");
                for (int c = 0; c < Cols; c++)
                {
                    sb.Append(ColumnsData[c].Get(r) ? "1" : "0");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Cast CodeMatrix to 2D array 
        /// </summary>
        /// <param name="codeMatrix"></param>
        public static explicit operator bool[,] (CodeMatrix codeMatrix)
        {
            bool[,] arr = new bool[codeMatrix.Rows, codeMatrix.Cols];
            for (int r = 0; r < codeMatrix.Rows; r++)
            {
                for (int c = 0; c < codeMatrix.Cols; c++)
                {
                    arr[r, c] = codeMatrix.ColumnsData[c].Get(r);
                }
            }
            return arr;
        }

        /// <summary>
        /// Cast 2D array to CodeMatrix
        /// </summary>
        /// <param name="array"></param>
        public static implicit operator CodeMatrix(bool[,] array)
        {
            return new CodeMatrix(array);
        }

        /// <summary>
        /// Number of columns in this matrix
        /// </summary>
        /// <returns>Number of columns in this matrix</returns>
        public int GetColumns()
        {
            return Cols;
        }

        /// <summary>
        /// Number of rows in this matrix
        /// </summary>
        /// <returns>Number of rows in this matrix</returns>
        public int GetRows()
        {
            return Rows;
        }

        /// <summary>
        /// Raise exception if row<0 or col >= Rows in this matrix. Raise exception if col<0 or col >= Cols in this matrix
        /// </summary>
        /// <param name="row">Number of row<</param>
        /// <param name="col">Number of column</param>
        protected void RowsColsCheck(int row, int col)
        {
            RowsCheck(row);
            ColsCheck(col);
        }

        /// <summary>
        /// Raise exception if row<0 or col >= Rows in this matrix
        /// </summary>
        /// <param name="row">Number of row</param>
        /// <exception cref="ArgumentException">Raise exception if row<0 or col >= Rows in this matrix</exception>
        protected void RowsCheck(int row)
        {
            if (row < 0)
                throw new ArgumentException("row < 0");
            if (row >= Rows)
                throw new ArgumentException("row >= Rows in Matrix");
        }

        /// <summary>
        /// Raise exception if col<0 or col >= Cols in this matrix
        /// </summary>
        /// <param name="col">Number of column</param>
        /// <exception cref="ArgumentException">Raise exception if col<0 or col >= Cols in this matrix</exception>
        protected void ColsCheck(int col)
        {
            if (col < 0)
                throw new ArgumentException("col < 0");
            if (col >= Cols)
                throw new ArgumentException("col >= Cols in Matrix");
        }

        /// <summary>
        /// Get value of element of this matrix
        /// </summary>
        /// <param name="row">Number of row in this matrix, row must exists</param>
        /// <param name="col">Number of column in this matrix, column must exists</param>
        /// <returns>Value of element of this matrix</returns>
        public bool GetAt(int row, int col)
        {
            RowsColsCheck(row, col);

            return ColumnsData[col].Get(row);
        }

        /// <summary>
        /// Set value for element of this matrix
        /// </summary>
        /// <param name="row">Number of row in this matrix, row must exists</param>
        /// <param name="col">Number of column in this matrix, column must exists</param>
        /// <param name="bValue">Logical value</param>
        public void SetAt(int row, int col, bool bValue)
        {
            RowsColsCheck(row, col);

            ColumnsData[col].Set(row, bValue);
        }

        /// <summary>
        /// Row from this matrix as BitArray
        /// </summary>
        /// <param name="row">Number of row in this matrix, row must exists</param>
        /// <returns>Row as BitArray</returns>
        public BitArray GetRow(int row)
        {
            RowsCheck(row);
            BitArray tmpBitArray = new BitArray(Cols);
            for (int c = 0; c < Cols; c++)
            {
                tmpBitArray[c] = ColumnsData[c].Get(row);
            }
            return tmpBitArray;
        }

        /// <summary>
        /// Column from this matrix as BitArray
        /// </summary>
        /// <param name="col">Number of column in this matrix, column must exists</param>
        /// <returns>Column as BitArray</returns>
        public BitArray GetCol(int col)
        {
            ColsCheck(col);
            bool[] arr = new bool[Rows];
            ColumnsData[col].CopyTo(arr, 0);
            BitArray tmpBitArray = new BitArray(arr);
            return tmpBitArray;
        }

        /// <summary>
        /// Set values in passed number of columns same as in passed columnData
        /// </summary>
        /// <param name="columnData">columnData length must equals number of rows in this matrix</param>
        /// <param name="col">Number of column in this matrix, column must exists</param>
        public void SetColumn(BitArray columnData, int col)
        {
            ColsCheck(col);
            RowsCheck(columnData.Length - 1);
            ColumnsData[col] = columnData;
        }

        /// <summary>
        /// Set values in passed number of row same as in passed rowData
        /// </summary>
        /// <param name="rowData">rowData length must equals number of columns in this matrix</param>
        /// <param name="row">Number of row in this matrix, row must exists</param>
        public void SetRow(BitArray rowData, int row)
        {
            ColsCheck(rowData.Length - 1);
            RowsCheck(row);
            for(int c = 0; c < Cols; c++)
            {
                for (int r = 0; r < Rows; r++)
                    ColumnsData[c].Set(r, rowData[r]);
            }
        }

        /// <summary>
        /// Append column filled by columnData
        /// </summary>
        /// <param name="columnData">columnData length must equals Rows in this matrix</param>
        public void AppendColumn(BitArray columnData)
        {
            RowsCheck(columnData.Length - 1);
            Cols++;
            ColumnsData.Add(columnData);
        }

        /// <summary>
        /// Append column filled by "false" value
        /// </summary>
        public void AppendColumn()
        {
            BitArray columnData = new BitArray(Rows);
            Cols++;
            ColumnsData.Add(columnData);
        }

        /// <summary>
        /// Append all Columns from passed matrix to this matrix
        /// </summary>
        /// <param name="codeMatrix">Rows count in codeMatrix must equals Rows count in this matrix</param>
        public void AppendAllColumns(CodeMatrix codeMatrix)
        {
            RowsCheck(codeMatrix.Rows - 1);

            for(int c = 0; c < codeMatrix.Cols; c++)
            {
                AppendColumn(codeMatrix.GetCol(c));
            }
        }

        /// <summary>
        /// Prepend row filled by rowData
        /// </summary>
        /// <param name="rowData">rowData length must equals Columns count in this matrix</param>
        public void AppendRow(BitArray rowData)
        {
            ColsCheck(rowData.Length - 1);
            Rows++;
            for (int c = 0; c < Cols; c++)
            {
                bool[] arr = new bool[Rows];
                ColumnsData[c].CopyTo(arr, 0);
                arr[Rows - 1] = rowData[c];
                ColumnsData[c] = new BitArray(arr);
            }
        }

        /// <summary>
        /// Append all Rows from passed matrix to this matrix
        /// </summary>
        /// <param name="codeMatrix">Columns count in codeMatrix must equals Columns count in this matrix</param>
        public void AppendAllRows(CodeMatrix codeMatrix)
        {
            ColsCheck(codeMatrix.Cols - 1);

            for (int r = 0; r < codeMatrix.Rows; r++)
            {
                AppendRow(codeMatrix.GetRow(r));
            }
        }

        /// <summary>
        /// Prepend column filled by columnData
        /// </summary>
        /// <param name="columnData">columnData length must equals Rows in this matrix</param>
        public void PrependColumn(BitArray columnData)
        {
            RowsCheck(columnData.Length - 1);
            Cols++;
            ColumnsData.Insert(0, columnData);
        }

        /// <summary>
        /// Prepend column filled by "false" value
        /// </summary>
        public void PrependColumn()
        {
            BitArray columnData = new BitArray(Rows);
            Cols++;
            ColumnsData.Insert(0, columnData);
        }

        /// <summary>
        /// Creates copy of this matrix and apply Transposition operation to copy of matrix
        /// </summary>
        /// <returns>Transposed variant of this matrix</returns>
        public CodeMatrix Transpose()
        {
            CodeMatrix newCodeMatrix2 = new CodeMatrix(Cols, 1);

            newCodeMatrix2.SetColumn(GetRow(0), 0);
            for(int r = 1; r < Rows; r++)
            {
                newCodeMatrix2.AppendColumn(GetRow(r));
            }
            return newCodeMatrix2;
        }

        /// <summary>
        /// Assign passed to all elements of this matrix
        /// </summary>
        /// <param name="value">value to set</param>
        public void Fill(bool value)
        {
            for(int c = 0; c < Cols; c++)
            {
                ColumnsData[c].SetAll(value);
            }
        }

        /// <summary>
        /// Apply logocal NOT operation to all elements of this matrix
        /// </summary>
        /// <returns>New matrix where elements are inverted</returns>
        public CodeMatrix Inverse()
        {
            CodeMatrix codeMatrix = new CodeMatrix(this);
            for(int c = 0; c < codeMatrix.Cols; c++)
            {
                codeMatrix.ColumnsData[c].Not();
            }
            return codeMatrix;
        }

        /// <summary>
        /// Make multiplication operation for matrices by same rules as generix mathematics matrix, but instead of "*" applying logical AND operaion and instead of "+" applying XOR logical operaion
        /// </summary>
        /// <param name="codeMatrix1">Left arg</param>
        /// <param name="codeMatrix2">Right arg</param>
        /// <returns>Result of operation</returns>
        /// <exception cref="ArgumentException">Raise ArgumentException if Columns in left matrix not equals Rows in right matrix or one of matrix is empty</exception>
        public static CodeMatrix operator *(CodeMatrix codeMatrix1, CodeMatrix codeMatrix2)
        {
            if (codeMatrix1.Cols != codeMatrix2.Rows)
                throw new ArgumentException("codeMatrix1.Cols != codeMatrix2.Rows");

            if (codeMatrix1.GetLength() <= 0 || codeMatrix2.GetLength() <= 0)
                throw new ArgumentException("one of matrix is empty");

            CodeMatrix newCM = new CodeMatrix(codeMatrix1.Rows, codeMatrix2.Cols);

            for (int c = 0; c < codeMatrix2.Cols; c++)
            {
                BitArray mulBitArray = new BitArray(codeMatrix1.Rows);
                for (int r = 0; r < codeMatrix1.Rows; r++)
                {
                    BitArray tmpRow = codeMatrix1.GetRow(r);
                    BitArray tmpCol = codeMatrix2.GetCol(c);
                    tmpCol.And(tmpRow);
                    bool val = tmpCol.Get(0);
                    for (int nBit = 1; nBit < tmpCol.Length; nBit++)
                    {
                        val = val ^ tmpCol.Get(nBit);
                    }
                    mulBitArray[r] = val;
                    newCM.SetColumn(mulBitArray, c);
                }
            }

            return newCM;
        }

        /// <summary>
        /// Apply XOR operation to emelents of 2 matrices
        /// </summary>
        /// <param name="codeMatrix1">Left arg</param>
        /// <param name="codeMatrix2">Right arg</param>
        /// <returns>Result of operation</returns>
        /// <exception cref="ArgumentException">Raise ArgumentException if demention of matrices not equals or one of matrix is empty</exception>
        public static CodeMatrix operator +(CodeMatrix codeMatrix1, CodeMatrix codeMatrix2)
        {
            if (codeMatrix1.Rows != codeMatrix2.Rows || codeMatrix1.Cols != codeMatrix2.Cols)
                throw new ArgumentException("codeMatrix1.Rows != codeMatrix2.Rows || codeMatrix1.Cols != codeMatrix2.Cols");

            if (codeMatrix1.GetLength() <= 0 || codeMatrix2.GetLength() <= 0)
                throw new ArgumentException("one of matrix is empty");

            CodeMatrix newCodeMatrix2 = new CodeMatrix(codeMatrix1);
            for(int c = 0; c < newCodeMatrix2.Cols; c++)
            {
                newCodeMatrix2.ColumnsData[c].Xor(codeMatrix2.ColumnsData[c]);
            }

            return newCodeMatrix2;
        }
    }
}
