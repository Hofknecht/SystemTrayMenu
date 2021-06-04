// <copyright file="CustomScrollbar.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.UserInterface
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [Designer(typeof(ScrollbarControlDesigner))]
    public class CustomScrollbar : UserControl
    {
        private readonly Timer timerMouseStillClicked = new Timer();
        private readonly int controlWidth = 15;

        private float moLargeChange = 10;
        private float moSmallChange = 1;
        private int moMinimum = 0;
        private int moMaximum = 100;
        private int moValue = 0;
        private int nClickPoint;

        private float moSliderTop = 0;
        private bool moSliderDown = false;
        private bool moSliderDragging = false;
        private bool arrowUpHovered = false;
        private bool sliderHovered = false;
        private bool arrowDownHovered = false;
        private bool mouseStillClickedMoveUp = false;
        private bool mouseStillClickedMoveLarge;
        private int timerMouseStillClickedCounter = 0;
        private int lastValue = 0;
        private bool paintEnabledWasCalled = false;
        private bool paintEnabled = false;

        public CustomScrollbar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            Width = controlWidth;
            MinimumSize = new Size(controlWidth, Width + Width + GetScrollbarHeight());
            int GetScrollbarHeight()
            {
                int nTrackHeight = Height - (Width + Width);
                float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
                int nSliderHeight = (int)fSliderHeight;

                if (nSliderHeight > nTrackHeight)
                {
                    nSliderHeight = nTrackHeight;
                }

                if (nSliderHeight < 56)
                {
                    nSliderHeight = 56;
                }

                return nSliderHeight;
            }

            timerMouseStillClicked.Interval = 30;
            timerMouseStillClicked.Tick += TimerMouseStillClicked_Tick;
        }

        public new event EventHandler Scroll = null;

        public event EventHandler ValueChanged = null;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("LargeChange")]
        public float LargeChange
        {
            get
            {
                return moLargeChange;
            }

            set
            {
                moLargeChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("SmallChange")]
        public float SmallChange
        {
            get
            {
                return moSmallChange;
            }

            set
            {
                moSmallChange = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Minimum")]
        public int Minimum
        {
            get
            {
                return moMinimum;
            }

            set
            {
                moMinimum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Maximum")]
        public int Maximum
        {
            get
            {
                return moMaximum;
            }

            set
            {
                moMaximum = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Value")]
        public int Value
        {
            get
            {
                return moValue;
            }

            set
            {
                moValue = value;
                int nTrackHeight = Height - (Width + Width);
                float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
                int nSliderHeight = (int)fSliderHeight;
                if (nSliderHeight > nTrackHeight)
                {
                    nSliderHeight = nTrackHeight;
                    fSliderHeight = nTrackHeight;
                }

                if (nSliderHeight < 56)
                {
                    nSliderHeight = 56;
                    fSliderHeight = 56;
                }

                int nPixelRange = nTrackHeight - nSliderHeight;
                int nRealRange = Maximum - Minimum - (int)LargeChange;
                float fPerc = 0.0f;
                if (nRealRange != 0)
                {
                    fPerc = moValue / (float)nRealRange;
                }

                float fTop = fPerc * nPixelRange;
                moSliderTop = (int)fTop;
                Invalidate();
            }
        }

        public int Delta
        {
            get
            {
                return Value - lastValue;
            }
        }

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }

            set
            {
                base.AutoSize = value;
                if (base.AutoSize)
                {
                    Width = controlWidth;
                }
            }
        }

        public void CustomScrollbar_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                MoveUp(SmallChange * MenuDefines.Scrollspeed);
            }
            else
            {
                MoveDown(SmallChange * MenuDefines.Scrollspeed);
            }
        }

        internal void Reset()
        {
            moSliderTop = 0;
            moSliderDown = false;
            moSliderDragging = false;
            arrowUpHovered = false;
            sliderHovered = false;
            arrowDownHovered = false;
            mouseStillClickedMoveUp = false;
            mouseStillClickedMoveLarge = false;
            timerMouseStillClickedCounter = 0;
            lastValue = 0;
        }

        /// <summary>
        /// Show the control
        /// (workaround, because visible = false, was causing appearing scrollbars).
        /// </summary>
        internal void PaintEnable()
        {
            Enabled = true;
            if (!paintEnabled)
            {
                paintEnabledWasCalled = true;
            }

            paintEnabled = true;
            Invalidate();
        }

        /// <summary>
        /// Hide the control
        /// (workaround, because visible = false, was causing appearing scrollbars).
        /// </summary>
        internal void PaintDisable()
        {
            if (!paintEnabledWasCalled)
            {
                Enabled = false;
                Size = new Size(0, 0);
            }

            paintEnabled = false;
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            timerMouseStillClicked.Dispose();
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            Color colorArrows;
            Color colorArrowsHover;
            Color colorSlider;
            Color colorSliderHover;
            Color colorSliderDragging;
            Color colorBackground;
            if (Config.IsDarkMode())
            {
                colorArrows = Color.FromArgb(103, 103, 103);
                colorArrowsHover = Color.FromArgb(55, 55, 55);
                colorSlider = Color.FromArgb(77, 77, 77);
                colorSliderHover = Color.FromArgb(122, 122, 122);
                colorSliderDragging = Color.FromArgb(166, 166, 166);
                colorBackground = Color.FromArgb(23, 23, 23);
            }
            else
            {
                colorArrows = Color.FromArgb(96, 96, 96);
                colorArrowsHover = Color.FromArgb(0, 0, 0);
                colorSlider = Color.FromArgb(205, 205, 205);
                colorSliderHover = Color.FromArgb(166, 166, 166);
                colorSliderDragging = Color.FromArgb(96, 96, 96);
                colorBackground = Color.FromArgb(240, 240, 240);
            }

            if (!paintEnabled)
            {
                e.Graphics.FillRectangle(
                    new SolidBrush(colorBackground),
                    new Rectangle(0, 0, Width, Height));
                return;
            }

            // Draw background
            Brush brushScrollbarBorder = new SolidBrush(colorBackground);
            e.Graphics.FillRectangle(brushScrollbarBorder, new Rectangle(0, 0, Width, Height));

            // Draw arrowUp
            Pen penArrowUp;
            if (arrowUpHovered)
            {
                penArrowUp = new Pen(colorArrowsHover, 2.5F);
            }
            else
            {
                penArrowUp = new Pen(colorArrows, 2.5F);
            }

            int widthDevidedBy2 = Width / 2;
            int widthDevidedBy6 = Width / 6;
            int widthDevidedBy2PluswidthDevidedBy8 = widthDevidedBy2 + (Width / 8);
            PointF pointArrowUp1 = new PointF(widthDevidedBy2 - widthDevidedBy6, widthDevidedBy2PluswidthDevidedBy8);
            PointF pointArrowUp2 = new PointF(widthDevidedBy2 + widthDevidedBy6, widthDevidedBy2PluswidthDevidedBy8);
            PointF pointArrowUp3 = new PointF(widthDevidedBy2, widthDevidedBy2PluswidthDevidedBy8 - widthDevidedBy6);
            PointF pointArrowUp4 = pointArrowUp1;
            PointF[] curvePoints =
                     {
                 pointArrowUp1,
                 pointArrowUp2,
                 pointArrowUp3,
                 pointArrowUp4,
                     };
            e.Graphics.DrawPolygon(penArrowUp, curvePoints);

            // draw slider
            int nTrackHeight = Height - (Width * 2);
            float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
            int nSliderHeight = (int)fSliderHeight;

            if (nSliderHeight > nTrackHeight)
            {
                nSliderHeight = nTrackHeight;
            }

            if (nSliderHeight < 56)
            {
                nSliderHeight = 56;
            }

            int nTop = (int)moSliderTop;
            nTop += this.Width;

            SolidBrush solidBrushSlider;
            if (moSliderDragging)
            {
                solidBrushSlider = new SolidBrush(colorSliderDragging);
            }
            else if (sliderHovered)
            {
                solidBrushSlider = new SolidBrush(colorSliderHover);
            }
            else
            {
                solidBrushSlider = new SolidBrush(colorSlider);
            }

            Rectangle rectangleSlider = new Rectangle(1, nTop + 1, Width - 2, nSliderHeight - 1);
            e.Graphics.FillRectangle(solidBrushSlider, rectangleSlider);

            // Draw arrowDown
            Pen penArrowDown;
            if (arrowDownHovered)
            {
                penArrowDown = new Pen(colorArrowsHover, 2.5F);
            }
            else
            {
                penArrowDown = new Pen(colorArrows, 2.5F);
            }

            PointF pointArrowDown1 = new PointF(widthDevidedBy2 - widthDevidedBy6, Height - widthDevidedBy2PluswidthDevidedBy8);
            PointF pointArrowDown2 = new PointF(widthDevidedBy2 + widthDevidedBy6, Height - widthDevidedBy2PluswidthDevidedBy8);
            PointF pointArrowDown3 = new PointF(widthDevidedBy2, Height - widthDevidedBy2PluswidthDevidedBy8 + widthDevidedBy6);
            PointF pointArrowDown4 = pointArrowDown1;
            PointF[] curvePointsArrowDown =
                     {
                 pointArrowDown1,
                 pointArrowDown2,
                 pointArrowDown3,
                 pointArrowDown4,
                     };

            e.Graphics.DrawPolygon(penArrowDown, curvePointsArrowDown);
        }

        private void TimerMouseStillClicked_Tick(object sender, EventArgs e)
        {
            timerMouseStillClickedCounter++;

            int nTrackHeight = Height - (Width + Width);
            float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
            int nScrollbarHeight = (int)fSliderHeight;

            if (nScrollbarHeight > nTrackHeight)
            {
                nScrollbarHeight = nTrackHeight;
            }

            if (nScrollbarHeight < 56)
            {
                nScrollbarHeight = 56;
            }

            int nTop = (int)moSliderTop;
            nTop += Width;
            Point ptPoint = PointToClient(Cursor.Position);
            Rectangle thumbrect = new Rectangle(new Point(0, nTop), new Size(controlWidth + 1, nScrollbarHeight));
            if (thumbrect.Contains(ptPoint))
            {
                timerMouseStillClicked.Stop();
            }
            else if (timerMouseStillClickedCounter > 6)
            {
                float change;
                if (mouseStillClickedMoveLarge)
                {
                    change = SmallChange * MenuDefines.Scrollspeed;
                }
                else
                {
                    change = SmallChange;
                }

                if (mouseStillClickedMoveUp)
                {
                    MoveUp(change);
                }
                else
                {
                    MoveDown(change);
                }
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Name = "CustomScrollbar";
            MouseDown += CustomScrollbar_MouseDown;
            MouseMove += CustomScrollbar_MouseMove;
            MouseUp += CustomScrollbar_MouseUp;
            MouseLeave += CustomScrollbar_MouseLeave;

            // this.MouseWheel += CustomScrollbar_MouseWheel;
            ResumeLayout(false);
        }

        private void CustomScrollbar_MouseLeave(object sender, EventArgs e)
        {
            arrowUpHovered = false;
            sliderHovered = false;
            arrowDownHovered = false;
            Refresh();
        }

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point ptPoint = PointToClient(Cursor.Position);
            int nTrackHeight = Height - (Width + Width);
            float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
            int nScrollbarHeight = (int)fSliderHeight;

            if (nScrollbarHeight > nTrackHeight)
            {
                nScrollbarHeight = nTrackHeight;
            }

            if (nScrollbarHeight < 56)
            {
                nScrollbarHeight = 56;
            }

            int nTop = (int)moSliderTop;
            nTop += Width;

            Rectangle thumbrect = new Rectangle(new Point(0, nTop), new Size(controlWidth + 1, nScrollbarHeight));
            Rectangle trackRectangle = new Rectangle(new Point(0, Width), new Size(controlWidth + 1, nTrackHeight));
            if (thumbrect.Contains(ptPoint))
            {
                nClickPoint = ptPoint.Y - nTop;
                moSliderDown = true;
            }
            else if (trackRectangle.Contains(ptPoint))
            {
                if (e.Y < thumbrect.Y)
                {
                    MoveUp(Height);
                    mouseStillClickedMoveUp = true;
                }
                else
                {
                    MoveDown(Height);
                    mouseStillClickedMoveUp = false;
                }

                mouseStillClickedMoveLarge = true;
                timerMouseStillClickedCounter = 0;
                timerMouseStillClicked.Start();
            }

            Rectangle uparrowrect = new Rectangle(new Point(0, 0), new Size(controlWidth + 1, Width));
            if (uparrowrect.Contains(ptPoint))
            {
                MoveUp(SmallChange);
                mouseStillClickedMoveUp = true;
                mouseStillClickedMoveLarge = false;
                timerMouseStillClickedCounter = 0;
                timerMouseStillClicked.Start();
            }

            Rectangle downarrowrect = new Rectangle(new Point(0, Width + nTrackHeight), new Size(controlWidth + 1, Width));
            if (downarrowrect.Contains(ptPoint))
            {
                MoveDown(SmallChange);
                mouseStillClickedMoveUp = false;
                mouseStillClickedMoveLarge = false;
                timerMouseStillClickedCounter = 0;
                timerMouseStillClicked.Start();
            }
        }

        private void MoveDown(float change)
        {
            int nTrackHeight = Height - (Width + Width);
            float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
            int nSliderHeight = (int)fSliderHeight;

            if (nSliderHeight > nTrackHeight)
            {
                nSliderHeight = nTrackHeight;
                fSliderHeight = nTrackHeight;
            }

            if (nSliderHeight < 56)
            {
                nSliderHeight = 56;
                fSliderHeight = 56;
            }

            int nRealRange = Maximum - Minimum - (int)LargeChange;
            int nPixelRange = nTrackHeight - nSliderHeight;
            if (nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    float changeForOneItem = (change * nPixelRange) / (Maximum - LargeChange);

                    if ((moSliderTop + changeForOneItem) > nPixelRange)
                    {
                        moSliderTop = nPixelRange;
                    }
                    else
                    {
                        moSliderTop += changeForOneItem;
                    }

                    // figure out value
                    float fPerc = moSliderTop / nPixelRange;
                    float fValue = fPerc * (Maximum - LargeChange);

                    moValue = (int)fValue;

                    if (Value != lastValue)
                    {
                        ValueChanged?.Invoke(this, new EventArgs());
                        Scroll?.Invoke(this, new EventArgs());
                        lastValue = Value;
                    }

                    Invalidate();
                }
            }
        }

        private void MoveUp(float change)
        {
            int nTrackHeight = Height - (Width + Width);
            float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
            int nSliderHeight = (int)fSliderHeight;

            if (nSliderHeight > nTrackHeight)
            {
                nSliderHeight = nTrackHeight;
                fSliderHeight = nTrackHeight;
            }

            if (nSliderHeight < 56)
            {
                nSliderHeight = 56;
                fSliderHeight = 56;
            }

            int nRealRange = Maximum - Minimum - (int)LargeChange;
            int nPixelRange = nTrackHeight - nSliderHeight;
            if (nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    float changeForOneItem = (change * nPixelRange) / (Maximum - LargeChange);

                    if ((moSliderTop - changeForOneItem) < 0)
                    {
                        moSliderTop = 0;
                    }
                    else
                    {
                        moSliderTop -= changeForOneItem;
                    }

                    // figure out value
                    float fPerc = moSliderTop / nPixelRange;
                    float fValue = fPerc * (Maximum - LargeChange);

                    moValue = (int)fValue;

                    if (Value != lastValue)
                    {
                        ValueChanged?.Invoke(this, new EventArgs());
                        Scroll?.Invoke(this, new EventArgs());
                        lastValue = Value;
                    }

                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            moSliderDown = false;
            moSliderDragging = false;
            timerMouseStillClicked.Stop();
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (moSliderDown == true)
            {
                moSliderDragging = true;
            }

            if (moSliderDragging)
            {
                MoveSlider(e.Y);
            }

            if (Value != lastValue)
            {
                ValueChanged?.Invoke(this, new EventArgs());
                Scroll?.Invoke(this, new EventArgs());
                lastValue = Value;
            }

            // Remember hovered control
            Point ptPoint = PointToClient(Cursor.Position);
            int nTrackHeight = Height - (Width + Width);
            float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
            int nSliderHeight = (int)fSliderHeight;

            if (nSliderHeight > nTrackHeight)
            {
                nSliderHeight = nTrackHeight;
            }

            if (nSliderHeight < 56)
            {
                nSliderHeight = 56;
            }

            int nTop = (int)moSliderTop;
            nTop += Width;

            Rectangle scrollbarbrect = new Rectangle(new Point(0, nTop), new Size(controlWidth + 1, nSliderHeight));
            Rectangle trackRectangle = new Rectangle(new Point(0, Width), new Size(controlWidth + 1, nTrackHeight));
            if (scrollbarbrect.Contains(ptPoint))
            {
                if (e.Button != MouseButtons.Left)
                {
                    arrowUpHovered = false;
                    sliderHovered = true;
                    arrowDownHovered = false;
                }
            }
            else if (trackRectangle.Contains(ptPoint))
            {
                if (e.Y < scrollbarbrect.Y)
                {
                    arrowUpHovered = false;
                    sliderHovered = false;
                    arrowDownHovered = false;
                }
                else
                {
                    arrowUpHovered = false;
                    sliderHovered = false;
                    arrowDownHovered = false;
                }
            }

            Rectangle uparrowrect = new Rectangle(new Point(0, 0), new Size(controlWidth + 1, Width));
            if (uparrowrect.Contains(ptPoint))
            {
                arrowUpHovered = true;
                sliderHovered = false;
                arrowDownHovered = false;
            }

            Rectangle downarrowrect = new Rectangle(new Point(0, Width + nTrackHeight), new Size(controlWidth + 1, Width));
            if (downarrowrect.Contains(ptPoint))
            {
                arrowUpHovered = false;
                sliderHovered = false;
                arrowDownHovered = true;
            }

            Invalidate();
        }

        private void MoveSlider(int y)
        {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = Height - (Width + Width);
            float fSliderHeight = (float)LargeChange / Maximum * nTrackHeight;
            int nSliderHeight = (int)fSliderHeight;

            if (nSliderHeight > nTrackHeight)
            {
                nSliderHeight = nTrackHeight;
            }

            if (nSliderHeight < 56)
            {
                nSliderHeight = 56;
            }

            int nSpot = nClickPoint;

            int nPixelRange = nTrackHeight - nSliderHeight;
            if (moSliderDown && nRealRange > 0)
            {
                if (nPixelRange > 0)
                {
                    int nNewSliderTop = y - (Width + nSpot);

                    if (nNewSliderTop < 0)
                    {
                        moSliderTop = nNewSliderTop = 0;
                    }
                    else if (nNewSliderTop > nPixelRange)
                    {
                        moSliderTop = nNewSliderTop = nPixelRange;
                    }
                    else
                    {
                        moSliderTop = y - (Width + nSpot);
                    }

                    // figure out value
                    float fPerc = moSliderTop / nPixelRange;
                    float fValue = fPerc * (Maximum - LargeChange);
                    moValue = (int)fValue;

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }
    }
}