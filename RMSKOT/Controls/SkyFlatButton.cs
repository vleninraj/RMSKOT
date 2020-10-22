using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace RMSKOT
{
    [DefaultEvent("Click")]
    public partial class SkyFlatButton : UserControl
    {
        #region Private Variables
        private Color _NormalColor=Color.SeaGreen;
        private Color _NormalTextColor=Color.White;
        private Color _HoverColor = Color.MediumSeaGreen;
        private Color _HoverTextColor=Color.White;
        #endregion
        #region Constructor
        public SkyFlatButton()
        {
            InitializeComponent();
            WireMouseEvents(this);

        }
        #endregion
        #region Properties
        public Color NormalColor{get { return _NormalColor; }set { _NormalColor = value; this.BackColor = _NormalColor; }}
        public Color NormalTextColor{get { return _NormalTextColor; }set { _NormalTextColor = value; this.ForeColor = _NormalTextColor; }}
        public Color HoverColor { get { return _HoverColor; } set { _HoverColor = value; } }
        public Color HoverTextColor { get { return _HoverTextColor; } set { _HoverTextColor = value; } }
        public string MainLabelCaption { get { return lblValue.Text; } set { lblValue.Text = value; } }
        public string SecondLabelCaption { get { return lblCaption.Text; } set { lblCaption.Text = value; } }
        #endregion
        #region Override Methods
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            this.BackColor = HoverColor;
            this.ForeColor = HoverTextColor;
            Debug.Write("On Mouse Hover \n");
        }
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            this.BackColor = HoverColor;
            this.ForeColor = HoverTextColor;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = NormalColor;
            this.ForeColor = NormalTextColor;
            Debug.Write("On Mouse Leave \n");
        }
        #endregion
        void WireMouseEvents(Control container)
        {
            foreach (Control c in container.Controls) {
                c.Click += (s, e) => OnClick(e);
                c.DoubleClick += (s, e) => OnDoubleClick(e);
                c.MouseHover += (s, e) => OnMouseHover(e);

                c.MouseClick += (s, e) => {
                    var p = PointToThis((Control)s, e.Location);
                    OnMouseClick(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
                };
                c.MouseDoubleClick += (s, e) => {
                    var p = PointToThis((Control)s, e.Location);
                    OnMouseDoubleClick(new MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta));
                };
                WireMouseEvents(c);
            };
        }

        Point PointToThis(Control c, Point p)
        {
            return PointToClient(c.PointToScreen(p));
        }

     

        
    }
}
