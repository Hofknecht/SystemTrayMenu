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
        private float largeChange = 10;
        private float smallChange = 1;
        private int minimum = 0;
        private int maximum = 100;
        private int value = 0;
        private int lastValue = 0;
        private int clickPoint;
        private float sliderTop = 0;
        private bool sliderDown = false;
        private bool sliderDragging = false;
        private bool arrowUpHovered = false;
        private bool sliderHovered = false;
        private bool arrowDownHovered = false;
        private bool trackHovered = false;
        private bool mouseStillClickedMoveUp = false;
        private bool mouseStillClickedMoveLarge = false;
        private int timerMouseStillClickedCounter = 0;
        private bool paintEnabledWasCalled = false;
        private bool paintEnabled = false;

        public CustomScrollbar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
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
                return largeChange;
            }

            set
            {
                largeChange = value;
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
                return smallChange;
            }

            set
            {
                smallChange = value;
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
                return minimum;
            }

            set
            {
                minimum = value;
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
                return maximum;
            }

            set
            {
                maximum = value;
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
                return value;
            }

            set
            {
                this.value = value;
                int trackHeight = GetTrackHeight();
                int sliderHeight = GetSliderHeight(trackHeight);
                int pixelRange = trackHeight - sliderHeight;
                int realRange = GetRealRange();
                float percentage = 0.0f;
                if (realRange != 0)
                {
                    percentage = this.value / (float)realRange;
                }

                float top = percentage * pixelRange;
                sliderTop = (int)top;
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
            sliderTop = 0;
            sliderDown = false;
            sliderDragging = false;
            arrowUpHovered = false;
            sliderHovered = false;
            arrowDownHovered = false;
            trackHovered = false;
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
            Color colorArrowHoverBackground;
            Color colorArrowHover;
            Color colorArrowClicked;
            Color colorArrowClickedBackground;
            Color colorSliderArrowsAndTrackHover;
            Color colorSlider;
            Color colorSliderHover;
            Color colorSliderDragging;
            Color colorBackground;
            if (Config.IsDarkMode())
            {
                colorArrows = Color.FromArgb(103, 103, 103);
                colorArrowHoverBackground = Color.FromArgb(55, 55, 55);
                colorArrowHover = Color.FromArgb(103, 103, 103);
                colorArrowClicked = Color.FromArgb(23, 23, 23);
                colorArrowClickedBackground = Color.FromArgb(166, 166, 166);
                colorSliderArrowsAndTrackHover = Color.FromArgb(77, 77, 77);
                colorSlider = Color.FromArgb(77, 77, 77);
                colorSliderHover = Color.FromArgb(122, 122, 122);
                colorSliderDragging = Color.FromArgb(166, 166, 166);
                colorBackground = Color.FromArgb(23, 23, 23);
            }
            else
            {
                colorArrows = Color.FromArgb(96, 96, 96);
                colorArrowHoverBackground = Color.FromArgb(218, 218, 218);
                colorArrowHover = Color.FromArgb(0, 0, 0);
                colorArrowClicked = Color.FromArgb(255, 255, 255);
                colorArrowClickedBackground = Color.FromArgb(96, 96, 96);
                colorSliderArrowsAndTrackHover = Color.FromArgb(192, 192, 192);
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

            int trackHeight = GetTrackHeight();
            int sliderHeight = GetSliderHeight(trackHeight);
            int top = (int)sliderTop + Width;

            // Draw background
            Brush brushScrollbarBorder = new SolidBrush(colorBackground);
            e.Graphics.FillRectangle(brushScrollbarBorder, new Rectangle(0, 0, Width, Height));

            // Draw arrowUp
            SolidBrush solidBrushArrowUpBackground;
            SolidBrush solidBrushArrowUp;
            Pen penArrowUp;
            if (timerMouseStillClicked.Enabled &&
                !mouseStillClickedMoveLarge && mouseStillClickedMoveUp)
            {
                solidBrushArrowUpBackground = new SolidBrush(colorArrowClickedBackground);
                solidBrushArrowUp = new SolidBrush(colorArrowClicked);
                penArrowUp = new Pen(colorArrowClicked, 2.5F);
            }
            else if (arrowUpHovered)
            {
                solidBrushArrowUpBackground = new SolidBrush(colorArrowHoverBackground);
                solidBrushArrowUp = new SolidBrush(colorArrowHover);
                penArrowUp = new Pen(colorArrowHover, 2.5F);
            }
            else
            {
                solidBrushArrowUpBackground = new SolidBrush(colorBackground);
                solidBrushArrowUp = new SolidBrush(colorArrows);
                penArrowUp = new Pen(colorArrows, 2.5F);
            }

            e.Graphics.FillRectangle(solidBrushArrowUpBackground, GetUpArrowRectangleWithoutBorder());

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

            e.Graphics.FillPolygon(solidBrushArrowUp, curvePoints);
            e.Graphics.DrawPolygon(penArrowUp, curvePoints);

            // draw slider
            SolidBrush solidBrushSlider;
            if (sliderDragging)
            {
                solidBrushSlider = new SolidBrush(colorSliderDragging);
            }
            else if (sliderHovered)
            {
                solidBrushSlider = new SolidBrush(colorSliderHover);
            }
            else
            {
                if (arrowUpHovered || arrowDownHovered || trackHovered)
                {
                    solidBrushSlider = new SolidBrush(colorSliderArrowsAndTrackHover);
                }
                else
                {
                    solidBrushSlider = new SolidBrush(colorSlider);
                }
            }

            Rectangle rectangleSlider = new Rectangle(1, top, Width - 2, sliderHeight);
            e.Graphics.FillRectangle(solidBrushSlider, rectangleSlider);

            // Draw arrowDown
            SolidBrush solidBrushArrowDownBackground;
            SolidBrush solidBrushArrowDown;
            Pen penArrowDown;
            if (timerMouseStillClicked.Enabled &&
                !mouseStillClickedMoveLarge && !mouseStillClickedMoveUp)
            {
                solidBrushArrowDownBackground = new SolidBrush(colorArrowClickedBackground);
                solidBrushArrowDown = new SolidBrush(colorArrowClicked);
                penArrowDown = new Pen(colorArrowClicked, 2.5F);
            }
            else
            if (arrowDownHovered)
            {
                solidBrushArrowDownBackground = new SolidBrush(colorArrowHoverBackground);
                solidBrushArrowDown = new SolidBrush(colorArrowHover);
                penArrowDown = new Pen(colorArrowHover, 2.5F);
            }
            else
            {
                solidBrushArrowDownBackground = new SolidBrush(colorBackground);
                solidBrushArrowDown = new SolidBrush(colorArrows);
                penArrowDown = new Pen(colorArrows, 2.5F);
            }

            e.Graphics.FillRectangle(solidBrushArrowDownBackground, GetDownArrowRectangleWithoutBorder(trackHeight));

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

            e.Graphics.FillPolygon(solidBrushArrowDown, curvePointsArrowDown);
            e.Graphics.DrawPolygon(penArrowDown, curvePointsArrowDown);
        }

        private void TimerMouseStillClicked_Tick(object sender, EventArgs e)
        {
            timerMouseStillClickedCounter++;

            Point pointCursor = PointToClient(Cursor.Position);
            int trackHeight = GetTrackHeight();
            int sliderHeight = GetSliderHeight(trackHeight);
            int top = (int)sliderTop + Width;

            Rectangle sliderRectangle = GetSliderRectangle(sliderHeight, top);
            if (sliderRectangle.Contains(pointCursor))
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
            ResumeLayout(false);
        }

        private void CustomScrollbar_MouseLeave(object sender, EventArgs e)
        {
            arrowUpHovered = false;
            sliderHovered = false;
            arrowDownHovered = false;
            trackHovered = false;
            Refresh();
        }

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point pointCursor = PointToClient(Cursor.Position);
            int trackHeight = GetTrackHeight();
            int sliderHeight = GetSliderHeight(trackHeight);
            int top = (int)sliderTop + Width;

            Rectangle sliderRectangle = GetSliderRectangle(sliderHeight, top);
            Rectangle trackRectangle = GetTrackRectangle(trackHeight);
            if (sliderRectangle.Contains(pointCursor))
            {
                clickPoint = pointCursor.Y - top;
                sliderDown = true;
            }
            else if (trackRectangle.Contains(pointCursor))
            {
                if (e.Y < sliderRectangle.Y)
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

            Rectangle upArrowRectangle = GetUpArrowRectangle();
            if (upArrowRectangle.Contains(pointCursor))
            {
                MoveUp(SmallChange);
                mouseStillClickedMoveUp = true;
                mouseStillClickedMoveLarge = false;
                timerMouseStillClickedCounter = 0;
                timerMouseStillClicked.Start();
            }

            Rectangle downArrowRectangle = GetDownArrowRectangle(trackHeight);
            if (downArrowRectangle.Contains(pointCursor))
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
            int trackHeight = GetTrackHeight();
            int sliderHeight = GetSliderHeight(trackHeight);
            int realRange = GetRealRange();
            int pixelRange = trackHeight - sliderHeight;
            if (realRange > 0)
            {
                if (pixelRange > 0)
                {
                    float changeForOneItem = GetChangeForOneItem(change, pixelRange);

                    if ((sliderTop + changeForOneItem) > pixelRange)
                    {
                        sliderTop = pixelRange;
                    }
                    else
                    {
                        sliderTop += changeForOneItem;
                    }

                    CalculateValue(pixelRange);

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
            int trackHeight = GetTrackHeight();
            int sliderHeight = GetSliderHeight(trackHeight);
            int realRange = GetRealRange();
            int pixelRange = trackHeight - sliderHeight;
            if (realRange > 0)
            {
                if (pixelRange > 0)
                {
                    float changeForOneItem = GetChangeForOneItem(change, pixelRange);

                    if ((sliderTop - changeForOneItem) < 0)
                    {
                        sliderTop = 0;
                    }
                    else
                    {
                        sliderTop -= changeForOneItem;
                    }

                    CalculateValue(pixelRange);

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
            sliderDown = false;
            sliderDragging = false;
            timerMouseStillClicked.Stop();
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (sliderDown == true)
            {
                sliderDragging = true;
            }

            if (sliderDragging)
            {
                MoveSlider(e.Y);
            }

            if (Value != lastValue)
            {
                ValueChanged?.Invoke(this, new EventArgs());
                Scroll?.Invoke(this, new EventArgs());
                lastValue = Value;
            }

            Point pointCursor = PointToClient(Cursor.Position);
            int trackHeight = GetTrackHeight();
            int sliderHeight = GetSliderHeight(trackHeight);
            int top = (int)sliderTop + Width;

            Rectangle sliderRectangle = GetSliderRectangle(sliderHeight, top);
            Rectangle trackRectangle = GetTrackRectangle(trackHeight);
            if (sliderRectangle.Contains(pointCursor))
            {
                if (e.Button != MouseButtons.Left)
                {
                    arrowUpHovered = false;
                    sliderHovered = true;
                    arrowDownHovered = false;
                    trackHovered = false;
                }
            }
            else if (trackRectangle.Contains(pointCursor))
            {
                arrowUpHovered = false;
                sliderHovered = false;
                arrowDownHovered = false;
                trackHovered = true;
            }

            Rectangle upArrowRectangle = GetUpArrowRectangle();
            if (upArrowRectangle.Contains(pointCursor))
            {
                if (e.Button != MouseButtons.Left)
                {
                    arrowUpHovered = true;
                    sliderHovered = false;
                    arrowDownHovered = false;
                    trackHovered = false;
                }
            }

            Rectangle downArrowRectangle = GetDownArrowRectangle(trackHeight);
            if (downArrowRectangle.Contains(pointCursor))
            {
                if (e.Button != MouseButtons.Left)
                {
                    arrowUpHovered = false;
                    sliderHovered = false;
                    arrowDownHovered = true;
                    trackHovered = false;
                }
            }

            Invalidate();
        }

        private void MoveSlider(int y)
        {
            int nRealRange = Maximum - Minimum;
            int trackHeight = GetTrackHeight();
            int sliderHeight = GetSliderHeight(trackHeight);
            int spot = clickPoint;
            int pixelRange = trackHeight - sliderHeight;
            if (sliderDown && nRealRange > 0)
            {
                if (pixelRange > 0)
                {
                    int newSliderTop = y - (Width + spot);

                    if (newSliderTop < 0)
                    {
                        sliderTop = 0;
                    }
                    else if (newSliderTop > pixelRange)
                    {
                        sliderTop = pixelRange;
                    }
                    else
                    {
                        sliderTop = y - (Width + spot);
                    }

                    CalculateValue(pixelRange);

                    Invalidate();
                }
            }
        }

        private void CalculateValue(int pixelRange)
        {
            float percentage = sliderTop / pixelRange;
            float fValue = percentage * (Maximum - LargeChange);
            value = (int)fValue;
        }

        private Rectangle GetSliderRectangle(int sliderHeight, int top)
        {
            return new Rectangle(new Point(0, top), new Size(Width + 1, sliderHeight));
        }

        private Rectangle GetUpArrowRectangle()
        {
            return new Rectangle(new Point(0, 0), new Size(Width + 1, Width));
        }

        private Rectangle GetUpArrowRectangleWithoutBorder()
        {
            return new Rectangle(new Point(1, 0), new Size(Width - 2, Width));
        }

        private Rectangle GetDownArrowRectangle(int trackHeight)
        {
            return new Rectangle(new Point(0, Width + trackHeight), new Size(Width + 1, Width));
        }

        private Rectangle GetDownArrowRectangleWithoutBorder(int trackHeight)
        {
            return new Rectangle(new Point(1, Width + trackHeight), new Size(Width - 2, Width));
        }

        private Rectangle GetTrackRectangle(int trackHeight)
        {
            return new Rectangle(new Point(0, Width), new Size(Width + 1, trackHeight));
        }

        private int GetRealRange()
        {
            return Maximum - Minimum - (int)LargeChange;
        }

        private float GetChangeForOneItem(float change, int pixelRange)
        {
            return (change * pixelRange) / (Maximum - LargeChange);
        }

        private int GetTrackHeight()
        {
            return Height - (Width + Width);
        }

        private int GetSliderHeight(int trackHeight)
        {
            int sliderHeight = (int)((float)LargeChange / Maximum * trackHeight);

            if (sliderHeight > trackHeight)
            {
                sliderHeight = trackHeight;
            }

            if (sliderHeight < 56)
            {
                sliderHeight = 56;
            }

            return sliderHeight;
        }
    }
}