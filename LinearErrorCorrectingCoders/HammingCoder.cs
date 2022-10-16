namespace LinearErrorCorrectingCoders
{
    public class HammingCoder : AbstractCoder
    {
        public HammingCoder(int dataLength) : base(dataLength)
        {
            int codeBitsCount = 0;
            int bitsLeft = DataLength;
            while (bitsLeft > 0)
            {
                int NextBitNo = codeBitsCount + 1;
                if (!IsCheckBit(NextBitNo))
                    bitsLeft--;

                codeBitsCount++;
            }

            TotalLength = codeBitsCount;
            CheckLength = TotalLength - DataLength;

            GeneratorMatrix = new CodeMatrix(DataLength, TotalLength);
            int DataBitsCount = 0;
            int firstDataBit = 3;
            CheckMatrix = new CodeMatrix(CheckLength, TotalLength);
            int currentCheckRow = CheckLength - 1;
            for (int col = 0; col < GeneratorMatrix.GetColumns(); col++)
            {
                int BitNo = col + 1;
                if (IsCheckBit(BitNo))
                {
                    int mask = BitNo;
                    int nDataBitCount = 0;

                    for (int i = firstDataBit; i <= TotalLength; i++)
                    {
                        bool isCheckBit = (i & (i - 1)) == 0;
                        if (!isCheckBit)
                        {
                            nDataBitCount++;
                            bool isNeedCheck = (i & mask) != 0;
                            GeneratorMatrix.SetAt(nDataBitCount - 1, col, isNeedCheck);
                        }
                    }

                    for (int c = 0; c < TotalLength; c++)
                    {
                        bool isNeedCheck = ((c+1) & mask) != 0;
                        CheckMatrix.SetAt(currentCheckRow, c, isNeedCheck);
                    }
                    currentCheckRow--;
                }
                else
                {
                    GeneratorMatrix.SetAt(DataBitsCount, col, true);
                    DataBitsCount++;
                }
            }
        }

        protected static bool IsCheckBit(int bitnNo)
        {
            return (bitnNo & (bitnNo - 1)) == 0;
        }
    }
}
