using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace RMSKOT
{
    public class SkyButton:Button
    {
        #region Override Methods
        protected override void InitLayout()
        {
            base.InitLayout();
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = System.Drawing.Color.FromArgb(61, 77, 125);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Return && e.Handled == false)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion
    }
}
