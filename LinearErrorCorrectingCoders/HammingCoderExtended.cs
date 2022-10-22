namespace LinearErrorCorrectingCoders
{
    public class HammingCoderExtended : HammingCoder
    {
        public HammingCoderExtended(int dataLength) : base(dataLength)
        {
            CodeMatrix tmpMatrix = new CodeMatrix(GeneratorMatrix.GetColumns(), 1);
            tmpMatrix.Fill(true);
            CodeMatrix ExtendedColumn = GeneratorMatrix * tmpMatrix;
            GeneratorMatrix.AppendColumn(ExtendedColumn.GetCol(0));
            CheckLength++;
            TotalLength = DataLength + CheckLength;

            tmpMatrix = new CodeMatrix(1, TotalLength);
            tmpMatrix.Fill(true);

            

            //CheckMatrix.AppendColumn();
            //CheckMatrix.AppendRow(tmpMatrix.GetRow(0));
            CheckMatrix.AppendRow();
            CheckMatrix.AppendColumn(tmpMatrix.GetRow(0));
            
        }
    }
}
