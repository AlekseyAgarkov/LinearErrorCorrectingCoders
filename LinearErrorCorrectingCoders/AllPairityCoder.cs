namespace LinearErrorCorrectingCoders
{
    public class AllPairityCoder : AbstractCoder
    {
        public AllPairityCoder(int dataLength) : base(dataLength)
        {
            CheckLength = 1;
            TotalLength = DataLength + CheckLength;

            GeneratorMatrix = new CodeMatrix(DataLength, true);
            CodeMatrix pairityColumn = new CodeMatrix(DataLength, CheckLength);
            pairityColumn.Fill(true);
            GeneratorMatrix.AppendAllColumns(pairityColumn);

            CheckMatrix = new CodeMatrix(CheckLength, TotalLength);
            CheckMatrix.Fill(true);
        }
    }
}
