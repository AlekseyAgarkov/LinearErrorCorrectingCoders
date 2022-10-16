namespace LinearErrorCorrectingCoders
{
    public class InverseCoder : AbstractCoder
    {
        public InverseCoder(int dataLength) : base(dataLength)
        {
            CheckLength = DataLength;
            TotalLength = CheckLength + DataLength;

            GeneratorMatrix = new CodeMatrix(DataLength, true);
            CodeMatrix rightPart = GeneratorMatrix.Inverse();
            GeneratorMatrix.AppendAllColumns(rightPart);

            CheckMatrix = GeneratorMatrix.Inverse();
        }
    }
}
