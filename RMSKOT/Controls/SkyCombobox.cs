using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace RMSKOT
{
    public class SkyCombobox:ComboBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Return && e.Handled == false)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;

            }
        }
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
    }
}
