using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace RMSKOT
{
    public class SkyCheckBox:CheckBox
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
    }
}
