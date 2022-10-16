
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.18.0
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace LinearErrorCorrectingCoders {
    using System;
    using Terminal.Gui;
    
    
    public partial class MainDialog : Terminal.Gui.Window {
        
        private Terminal.Gui.Label labelCoders;
        
        private Terminal.Gui.ComboBox comboboxCoders;
        
        private Terminal.Gui.Label labelRepeat;
        
        private Terminal.Gui.TextField textRepeat;
        
        private Terminal.Gui.Label labelDataLen;
        
        private Terminal.Gui.TextField textDataLen;
        
        private Terminal.Gui.Label labelCodeLen2;
        
        private Terminal.Gui.TextField textCodeLen;
        
        private Terminal.Gui.Label labelSyndromeLen;
        
        private Terminal.Gui.TextField textSyndromeLen;
        
        private Terminal.Gui.Label labelData;
        
        private Terminal.Gui.TextField textData;
        
        private Terminal.Gui.Label labelCode;
        
        private Terminal.Gui.Button buttonRefreshCode;
        
        private Terminal.Gui.TextField textCode;
        
        private Terminal.Gui.Label labelSyndrome;
        
        private Terminal.Gui.Button buttonRefreshSyndrome;
        
        private Terminal.Gui.TextField textSyndrome;
        
        private Terminal.Gui.TextView textviewMatrix;
        
        private void InitializeComponent() {
            this.textviewMatrix = new Terminal.Gui.TextView();
            this.textSyndrome = new Terminal.Gui.TextField();
            this.buttonRefreshSyndrome = new Terminal.Gui.Button();
            this.labelSyndrome = new Terminal.Gui.Label();
            this.textCode = new Terminal.Gui.TextField();
            this.buttonRefreshCode = new Terminal.Gui.Button();
            this.labelCode = new Terminal.Gui.Label();
            this.textData = new Terminal.Gui.TextField();
            this.labelData = new Terminal.Gui.Label();
            this.textSyndromeLen = new Terminal.Gui.TextField();
            this.labelSyndromeLen = new Terminal.Gui.Label();
            this.textCodeLen = new Terminal.Gui.TextField();
            this.labelCodeLen2 = new Terminal.Gui.Label();
            this.textDataLen = new Terminal.Gui.TextField();
            this.labelDataLen = new Terminal.Gui.Label();
            this.textRepeat = new Terminal.Gui.TextField();
            this.labelRepeat = new Terminal.Gui.Label();
            this.comboboxCoders = new Terminal.Gui.ComboBox();
            this.labelCoders = new Terminal.Gui.Label();
            this.Width = Dim.Fill(0);
            this.Height = Dim.Fill(0);
            this.X = 0;
            this.Y = 0;
            this.Modal = false;
            this.Text = "";
            this.Border.BorderStyle = Terminal.Gui.BorderStyle.Single;
            this.Border.Effect3D = false;
            this.Border.DrawMarginFrame = true;
            this.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Title = "";
            this.labelCoders.Width = 6;
            this.labelCoders.Height = 1;
            this.labelCoders.X = 0;
            this.labelCoders.Y = 0;
            this.labelCoders.Data = "label1";
            this.labelCoders.Text = "Код:";
            this.labelCoders.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.labelCoders);
            this.comboboxCoders.Width = 20;
            this.comboboxCoders.Height = 5;
            this.comboboxCoders.X = 6;
            this.comboboxCoders.Y = 0;
            this.comboboxCoders.Data = "combobox1";
            this.comboboxCoders.Text = "";
            this.comboboxCoders.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.comboboxCoders);
            this.labelRepeat.Width = 18;
            this.labelRepeat.Height = 1;
            this.labelRepeat.X = 28;
            this.labelRepeat.Y = 0;
            this.labelRepeat.Data = "labelRepeat";
            this.labelRepeat.Text = "Кол-во повторений:";
            this.labelRepeat.TextAlignment = Terminal.Gui.TextAlignment.Right;
            this.Add(this.labelRepeat);
            this.textRepeat.Width = 4;
            this.textRepeat.Height = 1;
            this.textRepeat.X = 46;
            this.textRepeat.Y = 0;
            this.textRepeat.Secret = false;
            this.textRepeat.Data = "textRepeat";
            this.textRepeat.Text = "1";
            this.textRepeat.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textRepeat);
            this.labelDataLen.Width = 16;
            this.labelDataLen.Height = 1;
            this.labelDataLen.X = 52;
            this.labelDataLen.Y = 0;
            this.labelDataLen.Data = "labelDataLen";
            this.labelDataLen.Text = "Длина данных:";
            this.labelDataLen.TextAlignment = Terminal.Gui.TextAlignment.Right;
            this.Add(this.labelDataLen);
            this.textDataLen.Width = 4;
            this.textDataLen.Height = 1;
            this.textDataLen.X = 68;
            this.textDataLen.Y = 0;
            this.textDataLen.Secret = false;
            this.textDataLen.Data = "textDataLen";
            this.textDataLen.Text = "0";
            this.textDataLen.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textDataLen);
            this.labelCodeLen2.Width = 16;
            this.labelCodeLen2.Height = 1;
            this.labelCodeLen2.X = 73;
            this.labelCodeLen2.Y = 0;
            this.labelCodeLen2.Data = "labelCodeLen2";
            this.labelCodeLen2.Text = "Длина кода:";
            this.labelCodeLen2.TextAlignment = Terminal.Gui.TextAlignment.Right;
            this.Add(this.labelCodeLen2);
            this.textCodeLen.Width = 4;
            this.textCodeLen.Height = 1;
            this.textCodeLen.X = 89;
            this.textCodeLen.Y = 0;
            this.textCodeLen.Secret = false;
            this.textCodeLen.Data = "textCodeLen";
            this.textCodeLen.Text = "0";
            this.textCodeLen.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textCodeLen);
            this.labelSyndromeLen.Width = 16;
            this.labelSyndromeLen.Height = 1;
            this.labelSyndromeLen.X = 94;
            this.labelSyndromeLen.Y = 0;
            this.labelSyndromeLen.Data = "labelSyndromeLen";
            this.labelSyndromeLen.Text = "Длина синдрома:";
            this.labelSyndromeLen.TextAlignment = Terminal.Gui.TextAlignment.Right;
            this.Add(this.labelSyndromeLen);
            this.textSyndromeLen.Width = 4;
            this.textSyndromeLen.Height = 1;
            this.textSyndromeLen.X = 110;
            this.textSyndromeLen.Y = 0;
            this.textSyndromeLen.Secret = false;
            this.textSyndromeLen.Data = "textSyndromeLen";
            this.textSyndromeLen.Text = "0";
            this.textSyndromeLen.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textSyndromeLen);
            this.labelData.Width = 4;
            this.labelData.Height = 1;
            this.labelData.X = 0;
            this.labelData.Y = 1;
            this.labelData.Data = "labelData";
            this.labelData.Text = "Данные:";
            this.labelData.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.labelData);
            this.textData.Width = Dim.Fill(4);
            this.textData.Height = 1;
            this.textData.X = 0;
            this.textData.Y = 2;
            this.textData.Secret = false;
            this.textData.Data = "textData";
            this.textData.Text = "";
            this.textData.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textData);
            this.labelCode.Width = 4;
            this.labelCode.Height = 1;
            this.labelCode.X = 0;
            this.labelCode.Y = 3;
            this.labelCode.Data = "labelCode";
            this.labelCode.Text = "Код:";
            this.labelCode.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.labelCode);
            this.buttonRefreshCode.Width = 16;
            this.buttonRefreshCode.X = Pos.Center();
            this.buttonRefreshCode.Y = 3;
            this.buttonRefreshCode.Data = "buttonRefreshCode";
            this.buttonRefreshCode.Text = "Обновить код";
            this.buttonRefreshCode.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.buttonRefreshCode.IsDefault = false;
            this.Add(this.buttonRefreshCode);
            this.textCode.Width = Dim.Fill(4);
            this.textCode.Height = 1;
            this.textCode.X = 0;
            this.textCode.Y = 4;
            this.textCode.Secret = false;
            this.textCode.Data = "textCode";
            this.textCode.Text = "";
            this.textCode.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textCode);
            this.labelSyndrome.Width = 4;
            this.labelSyndrome.Height = 1;
            this.labelSyndrome.X = 0;
            this.labelSyndrome.Y = 5;
            this.labelSyndrome.Data = "labelSyndrome";
            this.labelSyndrome.Text = "Синдром:";
            this.labelSyndrome.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.labelSyndrome);
            this.buttonRefreshSyndrome.Width = 20;
            this.buttonRefreshSyndrome.X = Pos.Center();
            this.buttonRefreshSyndrome.Y = 5;
            this.buttonRefreshSyndrome.Data = "buttonRefreshSyndrome";
            this.buttonRefreshSyndrome.Text = "Обновить синдром";
            this.buttonRefreshSyndrome.TextAlignment = Terminal.Gui.TextAlignment.Centered;
            this.buttonRefreshSyndrome.IsDefault = false;
            this.Add(this.buttonRefreshSyndrome);
            this.textSyndrome.Width = Dim.Fill(4);
            this.textSyndrome.Height = 1;
            this.textSyndrome.X = 0;
            this.textSyndrome.Y = 6;
            this.textSyndrome.Secret = false;
            this.textSyndrome.Data = "textSyndrome";
            this.textSyndrome.Text = "";
            this.textSyndrome.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textSyndrome);
            this.textviewMatrix.Width = Dim.Fill(4);
            this.textviewMatrix.Height = Dim.Fill(1);
            this.textviewMatrix.X = 0;
            this.textviewMatrix.Y = 8;
            this.textviewMatrix.AllowsTab = true;
            this.textviewMatrix.AllowsReturn = true;
            this.textviewMatrix.WordWrap = false;
            this.textviewMatrix.Data = "textviewMatrix";
            this.textviewMatrix.Text = "";
            this.textviewMatrix.TextAlignment = Terminal.Gui.TextAlignment.Left;
            this.Add(this.textviewMatrix);

            //Not Auto Generated
            this.textCodeLen.Enabled = false;
            this.textDataLen.Enabled = false;
            this.textSyndromeLen.Enabled = false;
            this.labelRepeat.Visible = false;
            this.textRepeat.Visible = false;
            //this.textviewMatrix.Enabled = false;
        }
    }
}
