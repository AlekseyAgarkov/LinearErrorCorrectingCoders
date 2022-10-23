namespace LinearErrorCorrectingCoders
{
    public class RepeatCoder : AbstractCoder
    {
        public RepeatCoder(int dataLength, int repeatCount) : base(dataLength)
        {
            if (repeatCount <= 0)
                repeatCount = 1;

            repeatCount = repeatCount + 1;
            CheckLength = (DataLength * repeatCount) - DataLength;

            TotalLength = CheckLength + DataLength;

            GeneratorMatrix = new CodeMatrix(DataLength, true);

            int repeat = repeatCount;
            for (int n = 1; n < repeat; n++)
            {
                for(int c = 0; c < DataLength; c++)
                {
                    GeneratorMatrix.AppendColumn(GeneratorMatrix.GetCol(c));
                }
            }

            for (int n = 1; n < repeat; n++)
            {
                CodeMatrix tmpMatrix = new CodeMatrix(GeneratorMatrix);
                int startRange = (DataLength * n);
                int endRange = (DataLength * n + DataLength) - 1;
                for (int c = DataLength; c < TotalLength; c++)
                {
                    if (c >= startRange && c <= endRange)
                        continue;

                    for (int r = 0; r < tmpMatrix.GetRows(); r++)
                    {
                        tmpMatrix.SetAt(r, c, false);
                    }
                }

                if (CheckMatrix == null)
                    CheckMatrix = new CodeMatrix(tmpMatrix);
                else
                    CheckMatrix.AppendAllRows(tmpMatrix);
            }

            CheckMatrix = CheckMatrix.Transpose();
        }
    }
}
