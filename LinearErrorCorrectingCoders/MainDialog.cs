
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.18.0
//      You can make changes to this file and they will not be overwritten when saving.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace LinearErrorCorrectingCoders {
    using System.Globalization;
    using System.Text;
    using Terminal.Gui;

    public enum CodersVariants
    {
        Hamming,
        HammingExt,
        Inverse,
        Repeat,
        AllPairityCoder,
        Unknown
    }

    public class CodersVariant
    {
        public CodersVariants Variant { get; private set; }
        public string Name { get; private set; }
        public CodersVariant(CodersVariants variant, string name)
        {
            Variant = variant;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public partial class MainDialog {

        private AbstractCoder CurrentCoder;
        private List<CodersVariant> CodersList;
        private CodersVariants CurrentCoderVariant = CodersVariants.Unknown;
        private string CurrentCodeString = "";
        private string CurrentRepeat = "";

        public MainDialog() {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentUICulture;

            UpdateLocalization();

            this.comboboxCoders.HideDropdownListOnClick = true;
            this.comboboxCoders.SelectedItem = 0;
            this.comboboxCoders.SelectedItemChanged += ComboboxCoders_SelectedItemChanged;
            this.buttonRefreshCode.Clicked += () => buttonRefreshCode_Click();
            this.buttonRefreshSyndrome.Clicked += ButtonRefreshSyndrome_Clicked;
        }

        private void UpdateLocalization()
        {
            CodersList = new List<CodersVariant>();
            CodersList.Add(new CodersVariant(CodersVariants.Hamming, strings.Hamming));
            CodersList.Add(new CodersVariant(CodersVariants.HammingExt, strings.HammingExt));
            CodersList.Add(new CodersVariant(CodersVariants.Inverse, strings.Inverse));
            CodersList.Add(new CodersVariant(CodersVariants.Repeat, strings.Repeat));
            CodersList.Add(new CodersVariant(CodersVariants.AllPairityCoder, strings.PairityOfAll));
            this.comboboxCoders.SetSource(CodersList);

            this.labelCoders.Text = strings.Code_;
            this.labelRepeat.Text = strings.RepeatCount_;
            this.labelDataLen.Text = strings.DataLength_;
            this.labelCodeLen2.Text = strings.CodeLength_;
            this.labelSyndromeLen.Text = strings.SyndromeLength_;
            this.labelData.Text = strings.Data_;
            this.labelCode.Text = strings.Code_;
            this.buttonRefreshCode.Text = strings.UpdateCode;
            this.labelSyndrome.Text = strings.Syndrome_;
            this.buttonRefreshSyndrome.Text = strings.UpdateSyndrome;
        }

        private void OnWrongCoderMessage()
        {
            MessageBox.Query(50, 7, strings.ErrorExclamation, strings.CoderNotSetExclamation, strings.Ok);
        }

        private void OnWrongCodeMessage(int codeLen, int CoderLen)
        {
            MessageBox.Query(50, 7, strings.AttentionExclamation, String.Format(strings.BadCodeLen, codeLen, CoderLen), strings.Ok);
        }

        private void OnEmptyDataMessage()
        {
            MessageBox.Query(50, 7, strings.AttentionExclamation, strings.YouMustFillDataExclamation, strings.Ok);
        }

        private void OnEmptyCodeMessage()
        {
            MessageBox.Query(50, 7, strings.AttentionExclamation, strings.CodeFieldIsEmptyExclamation, strings.Ok);
        }

        private void UpdateSyndrome()
        {
            if (!IsValidCurrentCoder())
            {
                OnWrongCoderMessage();
                return;
            }
                

            string code = this.textCode.Text.ToString();
            code = ReplaceNotBinChars(code);

            if(code == "")
            {
                OnEmptyCodeMessage();
                return;
            }

            if (CurrentCoder.GetTotalLength() != code.Length)
            {
                OnWrongCodeMessage(code.Length, CurrentCoder.GetTotalLength());
                return;
            }

            CodeMatrix dataToDecode = StringToMatrix(code);
            CodeMatrix codeByDecoder = CurrentCoder.Decode(dataToDecode);
            this.textSyndrome.Text = codeByDecoder.ToString();
        }

        private void ButtonRefreshSyndrome_Clicked()
        {
            UpdateSyndrome();
        }

        private void ChangeCoder(CodersVariants variant)
        {
            int codeLength = this.textData.Text.ToString().Length;
            int repeatCount = 1;
            bool repeatVisible = false;
            CurrentRepeat = this.textRepeat.Text.ToString();
            if (variant == CodersVariants.Repeat)
            {
                repeatVisible = true;
                if (!int.TryParse(this.textRepeat.Text.ToString(), out repeatCount))
                {
                    this.textRepeat.Text = "1";
                    repeatCount = 1;
                }
            }


            this.textRepeat.Visible = repeatVisible;
            this.labelRepeat.Visible = repeatVisible;

            if(codeLength < 1)
            {
                CurrentCoderVariant = CodersVariants.Unknown;
                CurrentCoder = null;
                return;
            }

            CurrentCoderVariant = variant;

            switch (variant)
            {
                case CodersVariants.Hamming:
                    CurrentCoder = new HammingCoder(codeLength);
                    break;
                case CodersVariants.HammingExt:
                    CurrentCoder = new HammingCoderExtended(codeLength);
                    break;
                case CodersVariants.Inverse:
                    CurrentCoder = new InverseCoder(codeLength);
                    break;
                case CodersVariants.Repeat:
                    CurrentCoder = new RepeatCoder(codeLength, repeatCount);
                    break;
                case CodersVariants.AllPairityCoder:
                    CurrentCoder = new AllPairityCoder(codeLength);
                    break;
                default:
                    CurrentCoderVariant = CodersVariants.Unknown;
                    CurrentCoder = null;
                    break;
            }

            if(IsValidCurrentCoder())
            {
                this.textDataLen.Text = CurrentCoder.GetDataLength().ToString();
                this.textCodeLen.Text = CurrentCoder.GetTotalLength().ToString();
                this.textSyndromeLen.Text = CurrentCoder.GetCheckLength().ToString();

                StringBuilder stringBuilderMatrix = new StringBuilder((CurrentCoder.GetTotalLength() * (CurrentCoder.GetDataLength() + 1)) + ((CurrentCoder.GetCheckLength() + 1) * (CurrentCoder.GetTotalLength() + 1) * 2) + 14);
                stringBuilderMatrix.Append("G:\n");
                stringBuilderMatrix.Append(CurrentCoder.GetGeneratorMatrix().ToString());
                stringBuilderMatrix.Append("\nH:\n");
                stringBuilderMatrix.Append(CurrentCoder.GetCheckMatrix().ToString());
                stringBuilderMatrix.Append("\nH^T:\n");
                stringBuilderMatrix.Append(CurrentCoder.GetCheckMatrix().Transpose().ToString());

                this.textviewMatrix.Text = stringBuilderMatrix.ToString();
            }
        }

        private string ReplaceNotBinChars(string code)
        {
            StringBuilder sb = new StringBuilder(code);
            for (int p = 0; p < sb.Length; p++)
            {
                if (sb[p] != '0')
                    sb[p] = '1';
            }

            return sb.ToString();
        }

        private static bool[,] StringToCodeArray(string text)
        {
            bool[,] dataBits2D = new bool[1, text.Length];
            for (int pos = 0; pos < text.Length; pos++)
            {
                dataBits2D[0, pos] = text[pos] == '0' ? false : true;
            }
            return dataBits2D;
        }

        private static CodeMatrix BoolArrayToMatrix(bool[,] data)
        {
            return new CodeMatrix(data);
        }

        private static CodeMatrix StringToMatrix(string text)
        {
            return BoolArrayToMatrix(StringToCodeArray(text));
        }

        private bool IsValidCurrentCoder()
        {
            return CurrentCoder != null && CurrentCoderVariant != CodersVariants.Unknown;
        }

        private bool IsNeedChageCoder()
        {
            if (CodersList.Count < 1 || comboboxCoders.SelectedItem >= CodersList.Count)
                return true;

            string codeData = this.textData.Text.ToString();
            codeData = ReplaceNotBinChars(codeData);

            return CurrentCodeString.Length != codeData.Length 
                || CurrentRepeat != this.textRepeat.ToString() 
                || CodersList[comboboxCoders.SelectedItem].Variant != CurrentCoderVariant;
        }

        private void ClearAll()
        {
            this.textCode.Text = "";
            this.textCodeLen.Text = "0";
            this.textviewMatrix.Text = "";
            this.textDataLen.Text = "0";
            this.textRepeat.Text = "1";
            this.textSyndrome.Text = "";
            this.textSyndromeLen.Text = "0";
        }

        private void UpdateCode()
        {
            string codeData = this.textData.Text.ToString();
            codeData = ReplaceNotBinChars(codeData);

            if(IsNeedChageCoder())
            {
                if (CodersList.Count < 1 || comboboxCoders.SelectedItem >= CodersList.Count)
                    ChangeCoder(CodersVariants.Unknown);
                else
                    ChangeCoder(CodersList[comboboxCoders.SelectedItem].Variant);
            }

            CurrentCodeString = codeData;

            if(codeData == "")
            {
                OnEmptyDataMessage();
                ClearAll();
            }

            if (!IsValidCurrentCoder())
            {  
                return;
            }
                

            CodeMatrix dataToEncode = StringToMatrix(codeData);
            CodeMatrix codeByEncoder = CurrentCoder.Encode(dataToEncode);

            this.textCode.Text = codeByEncoder.ToString();

            CodeMatrix codeByDecoder = CurrentCoder.Decode(codeByEncoder);
            this.textSyndrome.Text = codeByDecoder.ToString();
        }

        private void ComboboxCoders_SelectedItemChanged(ListViewItemEventArgs obj)
        {
            if(CodersList.Count < 1) return;
            if(obj.Item >= CodersList.Count) return;

            UpdateCode();
        }

        private void buttonRefreshCode_Click() {
            UpdateCode();
        }
    }
}
