using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace RMSKOT
{
   public class SkyLabel:Label
    {
       protected override void OnDoubleClick(EventArgs e)
       {
           base.OnDoubleClick(e);
           //EnterNewTextView frm = new EnterNewTextView(this.Text,this.Name);
           //if (frm.ShowDialog() == DialogResult.OK)
           //{
           //    this.Text = frm.NewText;
               
           //}
       }

    }
}
