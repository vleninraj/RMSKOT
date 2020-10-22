using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
namespace RMSKOT
{
   public  class SkyTextBox:TextBox
   {
       #region Private Fields
        double? _InitialValue = null;
		bool _TextChanged = false;
        #endregion
        public bool IsTextChanged()
        {
            return _TextChanged;
        }
        public bool isValueChanged
        {
            get
            {
                return _InitialValue != null && _InitialValue != this.Text.ToDouble();
            }
        }
       public bool isNumeric { get; set; }
       public bool isAllowNegative { get; set; }
       public string Format { get; set; }
       public void LoadSuggest(IEnumerable<Object> dataSource)
       {
           AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
           foreach (var s in dataSource)
           {
               stringCollection.Add(s.ToString());
           }

           this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
           this.AutoCompleteCustomSource = stringCollection;
       }
       protected override void InitLayout()
       {
           base.InitLayout();
           if (isNumeric)
           this.TextAlign = HorizontalAlignment.Right;
       }
       protected override void OnKeyDown(KeyEventArgs e)
       {
           base.OnKeyDown(e);
           if (this.Multiline) { return; }
           if (e.KeyCode == Keys.Return && e.Handled == false)
           {
               
                SendKeys.Send("{TAB}");
               e.Handled = true;

           }   
       }
       protected override void OnGotFocus(EventArgs e)
       {
           base.OnGotFocus(e);
           SelectionStart = 0;
           SelectionLength = Text.Length;
       }
       protected override void OnKeyPress(KeyPressEventArgs e)
       {
           base.OnKeyPress(e);
           bool _isNumber = false;
           if (isNumeric == true)
           {
               if (isAllowNegative)
               {
                   if (e.KeyChar == '-')
                   {
                       if (this.Text.Contains('-')) { e.Handled = true; }
                       return;
                   }
               }
              if (e.KeyChar == 8 || e.KeyChar == 46) { return; }
               int n;
               _isNumber = int.TryParse(Char.ConvertFromUtf32(e.KeyChar), out n);
               if (_isNumber == false)
               {
                   e.Handled = true;
               }
           }

       }
       protected override void OnEnter(EventArgs e)
       {
           base.OnEnter(e);
           this.SelectionStart = 0;
           this.SelectionLength = this.Text.Length;
           if (isNumeric)
           {
               _InitialValue = this.Text.ToDouble();
           }
           _TextChanged = false;
       }
       public decimal Value
       {
           //get;
           //set;
           get
           {   
               decimal ret = 0;
               if (this.Text.Length > 0 && (!this.Text.Substring(0, 1).isNumeric()))
               {
                   decimal.TryParse(this.Text.Substring(1), out ret);
               }
               else
               {
                   decimal.TryParse(this.Text, out ret);
               }

               return ret;
           }
           set
           {
               if (isNumeric)
                   this.Text = Common.getFormattedValue(Format, value);

           }
       }
       protected override void OnTextChanged(EventArgs e)
       {
           _TextChanged = true;
           base.OnTextChanged(e);
       }
    }
}
