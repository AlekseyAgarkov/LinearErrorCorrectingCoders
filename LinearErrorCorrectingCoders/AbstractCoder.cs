namespace LinearErrorCorrectingCoders
{
    public abstract class AbstractCoder
    {
        protected int DataLength;
        protected int CheckLength;
        protected int TotalLength;
        protected CodeMatrix GeneratorMatrix;
        protected CodeMatrix CheckMatrix;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataLength"></param>
        /// <param name="checkLength">-1 - авто размер проверочных разрядов</param>
        protected AbstractCoder(int dataLength)
        {
            if (dataLength < 1)
                throw new ArgumentException("dataLength < 1");
            DataLength = dataLength;
            CheckLength = -1;
        }

        public CodeMatrix GetGeneratorMatrix()
        {
            return new CodeMatrix(GeneratorMatrix);
        }

        public CodeMatrix GetCheckMatrix()
        {
            return new CodeMatrix(CheckMatrix);
        }

        public CodeMatrix Encode(CodeMatrix code)
        {
            if(DataLength != code.GetColumns())
                throw new ArgumentException("DataLength != code.GetColumns()");

            return code * GeneratorMatrix;
        }

        public CodeMatrix Decode(CodeMatrix code)
        {
            if (TotalLength != code.GetColumns())
                throw new ArgumentException("TotalLength != code.GetColumns()");

            return code * CheckMatrix.Transpose();
        }

        public int GetDataLength()
        {
            return DataLength;
        }

        public int GetCheckLength()
        {
            return CheckLength;
        }

        public int GetTotalLength()
        {
            return TotalLength;
        }
    }
}
