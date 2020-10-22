using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RMSKOT
{
    public partial class PaggedPannel : UserControl
    {
        public enum flowDirection
        {
           LeftToRight,
            TopDown
        }
        int _gapLeft = 5;
        int _gapTop = 5;
        private Panel _LastPageShown;
        private List<Control> _Controls;



        public flowDirection FlowDirection
        {
            get;
            set;
        }
        private List<Control> _AllPages;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Control> ChildControls
        {
            get
            {
                return _Controls;
            }
            set
            {
                _Controls = value;

                AddControls();
            }
        }
        private void AddControls()
        {
            try
            {
                pnlButtons.Controls.Clear();
                pnlMain.Controls.Clear();
                if (_Controls.Count > 0)
                {

                    int pageNo = 1;
                    Panel CurrentPage = CreatePage(pageNo);
                    int _left = _gapLeft;
                    int _top = _gapTop;
                    pnlMain.Controls.Add(CurrentPage);
                    foreach (Control ctr in _Controls)
                    {
                        if (FlowDirection == PaggedPannel.flowDirection.LeftToRight)
                        {

                            if (_left + ctr.Width > pnlMain.Width)
                            {
                                _top += ctr.Height + _gapTop;
                                _left = _gapLeft;
                            }
                            if (_top + ctr.Height > pnlMain.Height)
                            {
                                CurrentPage = CreatePage(++pageNo);
                                pnlMain.Controls.Add(CurrentPage);
                                _left = _gapLeft;
                                _top = _gapTop;

                            }

                            // ctr.Left = _left;
                            // ctr.Top = _top;
                            CurrentPage.Controls.Add(ctr);
                            _left += ctr.Width + _gapLeft;
                        }
                        else
                        {

                        }
                    }
                    atGradientPanel Btn = pnlButtons.Controls.Find("btnPAge_1", false)[0] as atGradientPanel;
                    ShowPage(Btn, 1);
                }
            }
            catch (Exception)
            {
               
            }
        }
        public PaggedPannel()
        {
            InitializeComponent();
            ChildControls = new List<Control>();
            _AllPages = new List<Control>();
            FlowDirection = flowDirection.LeftToRight;


            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
          
        }

        private Panel CreatePage(int pageNo)
        {

            atGradientPanel btnPage = new atGradientPanel();
            btnPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            btnPage.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPage.Location = new System.Drawing.Point(3, 3);
            btnPage.Name = "btnPAge_" + pageNo.ToString();
            btnPage.Selected = true;
            btnPage.Tag = pageNo;
            btnPage.AllowMultiSelect = false;
            btnPage.Angle = 110F;
            btnPage.Font = new System.Drawing.Font("Open Sans", 13);
            btnPage.BackColor = System.Drawing.Color.SteelBlue;
            btnPage.BottomColor = System.Drawing.Color.DodgerBlue;
            btnPage.ForeColor = System.Drawing.Color.White;
            btnPage.TextAdjestmentHeight = 0;
            btnPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnPage.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(77)))), ((int)(((byte)(125)))));

            btnPage.Size = new System.Drawing.Size(45, 45);
            btnPage.TabIndex = 1;
            btnPage.Text = pageNo.ToString();
            
            
            
            
            pnlButtons.Controls.Add(btnPage);



            FlowLayoutPanel Page = new FlowLayoutPanel();
            if (this.FlowDirection == flowDirection.LeftToRight)
                Page.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            else
                Page.FlowDirection = System.Windows.Forms.FlowDirection.TopDown ;
            Page.BackColor = Color.White;
            Page.Dock = DockStyle.Fill;
            Page.Tag = pageNo;
            Page.Name = "Page_" + pageNo.ToString();
           

            btnPage.Click += (snd, ee) =>
            {
                ShowPage(btnPage,Convert.ToInt32(btnPage.Tag));

            };           
            pnlMain.Controls.Add(Page);
            Page.Visible = false;
            return Page;
        }
        private void ShowPage(atGradientPanel btn, int pageNo)
        {
            if (_LastPageShown != null)
                _LastPageShown.Visible = false;
            Panel Pg = pnlMain.Controls.Find("Page_" + pageNo.ToString(), false)[0] as Panel;
            Pg.BringToFront();
            Pg.Visible = true;
            _LastPageShown = Pg;

            btn.Selected = true;
        }

        private void pnlMain_Resize(object sender, EventArgs e)
        {
            AddControls();
        }
      

    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace TouchPOS.Controls
//{
//    public partial class PaggedPannel : UserControl
//    {
//        public enum flowDirection
//        {
//            RightToLeft,
//            BottomToRight
//        }
//        int _gapLeft = 5;
//        int _gapTop= 5;
//        private Panel _LastPageShown;
//        private List<Control> _Controls;

        

//        public flowDirection FlowDirection
//        {
//            get;
//            set;
//        }
//        private List<Control> _AllPages;

//        public List<Control> ChildControls
//        {
//            get
//            {
//                return _Controls;
//            }
//            set
//            {
//                _Controls = value;
//                if (_Controls != null)
//                {
//                    pnlButtons.Controls.Clear();
//                    pnlMain.Controls.Clear();
//                    int pageNo = 1;
//                    Panel CurrentPage = CreatePage(pageNo);
//                    int _left = _gapLeft;
//                    int _top = _gapTop;
//                    pnlMain.Controls.Add(CurrentPage);
//                    foreach (Control ctr in _Controls)
//                    {
//                        if (FlowDirection == PaggedPannel.flowDirection.RightToLeft)
//                        {


//                            if (_left + ctr.Width > pnlMain.Width)
//                            {
//                                _top +=  ctr.Height + _gapTop;
//                                _left = _gapLeft;
//                            }
//                            if (_top + ctr.Height > pnlMain.Height)
//                            {
//                                CurrentPage = CreatePage(++pageNo);
//                                pnlMain.Controls.Add(CurrentPage);
//                                _left = _gapLeft;
//                                _top = _gapTop;

//                            }
                            
//                            ctr.Left = _left;
//                            ctr.Top = _top;
//                            CurrentPage.Controls.Add(ctr);
//                            _left += ctr.Width + _gapLeft;
//                        }
//                        else
//                        {

//                        }
//                    }
//                }
//            }
//        }
//        public PaggedPannel()
//        {
//            InitializeComponent();
//            _Controls = new List<Control>();
//            _AllPages = new List<Control>();
//            FlowDirection = flowDirection.RightToLeft;
           
           
//        }
        
//        private Panel  CreatePage(int pageNo)
//        {

//            CustomButton btnPage = new CustomButton();
//            btnPage.AllowMultiSelect = false;
//            btnPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
//            btnPage.BackColor = System.Drawing.Color.White;
//            btnPage.BackgroundImage =  global::Controls.Resource.GlassnewItemGreen;
//            btnPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
//            btnPage.Cursor = System.Windows.Forms.Cursors.Hand;
//            btnPage.Disabled = false;
//            btnPage.DisabledImage =  global::Controls.Resource.GlassnewDisabled;
//            btnPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            btnPage.Icon = null;
//            btnPage.IconAdjestmentHeight = 0;
//            btnPage.IconAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            btnPage.Image =  global::Controls.Resource.GlassnewItemGreen;
//            btnPage.InImage =  global::Controls.Resource.Glassnew;
//            btnPage.Location = new System.Drawing.Point(3, 3);
//            btnPage.Name = "btnPAge_" + pageNo.ToString();
//            btnPage.Selected = true;
//            btnPage.SelectTypeButton = true;
//            btnPage.AllowMultiSelect = false;
//            btnPage.Size = new System.Drawing.Size(45, 45);
//            btnPage.TabIndex = 1;
//            btnPage.Text = pageNo.ToString();
//            btnPage.Tag = pageNo;
//            btnPage.TextAdjestmentHeight = 0;
//            btnPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            pnlButtons.Controls.Add(btnPage);



//            Panel Page = new Panel();
//            Page.BackColor = Color.Red;
//            Page.Dock = DockStyle.Fill;
//            Page.Tag = pageNo;
//            Page.Name = "Page_" + pageNo.ToString();
//            Page.Visible = false;

//            btnPage.Click += (snd, ee) =>
//                {
//                    ShowPage(Convert.ToInt32(btnPage.Tag));

//                };

//            pnlMain.Controls.Add(Page);

//            return Page;
//        }
//        private void ShowPage(int pageNo)
//        {
//            if (_LastPageShown != null)
//                _LastPageShown.Visible = false;
//            Panel Pg = pnlMain.Controls.Find("Page_" + pageNo.ToString(), false)[0] as Panel;
//            Pg.BringToFront();
//            Pg.Visible = true;
//            _LastPageShown = Pg;
//        }
//        private void AddControl( Control Ctrl)
//        {
            
//        }
       
//    }
//}
