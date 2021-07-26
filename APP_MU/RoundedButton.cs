using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BrbVideoManager.Controls
{
    class RoundedButton : Button
    {
        private int b_radius = 50;
        private float b_width = 1.75f;
        private Color b_color = Color.Blue;
        private Color b_over_color,b_down_color;
        private float b_over_width = 0;
        private float b_down_width = 0;

        public bool IsMouseOver { get; private set; }
        private bool IsMouseDown { get; set; }

        [Category("Border"),DisplayName("Border Width")]
        public float BorderWidth
        {
            get {
                return b_width;
            }
            set {
                if (b_width == value) return;
                b_width = value;
                Invalidate();
            }
        }

        [Category("Border"), DisplayName("Border Over Width")]
        public float BorderOverWidth
        {
            get
            {
                return b_over_width;
            }
            set
            {
                if (b_over_width == value) return;
                b_over_width = value;
                Invalidate();
            }
        }

        [Category("Border"), DisplayName("Border Down Width")]
        public float BorderDownWidth
        {
            get
            {
                return b_down_width;
            }
            set
            {
                if (b_down_width == value) return;
                b_down_width = value;
                Invalidate();
            }
        }

        [Category("Border"), DisplayName("Border Color")]
        public Color BorderColor
        {
            get { return b_color; }
            set
            {
                if (b_color == value) return;
                b_color = value;
                Invalidate();
            }
        }

        [Category("Border"), DisplayName("Border Over Color")]
        public Color BorderOverColor
        {
            get { return b_over_color; }
            set
            {
                if (b_over_color == value) return;
                b_over_color = value;
                Invalidate();
            }
        }

        [Category("Border"), DisplayName("Border Down Color")]
        public Color BorderDownColor
        {
            get { return b_down_color; }
            set
            {
                if (b_down_color == value) return;
                b_down_color = value;
                Invalidate();
            }
        }

        [Category("Border"), DisplayName("Border Radius")]
        public int BorderRadius
        {
            get {
                //b_radius = Math.Min(Math.Min(Height, Width), b_radius);
                return b_radius;
            }
            set
            {
                if (b_radius == value) return;
                //b_radius = Math.Min(Math.Min(Height, Width), value);
                b_radius = value;
                Invalidate();
            }
        }

        GraphicsPath GetRoundPath(RectangleF Rect, int radius, float width=0)
        {
            //Fix radius to rect size
            radius = (int) Math.Max(( Math.Min(radius, Math.Min(Rect.Width, Rect.Height)) - width),1);
            float r2 = radius / 2f;
            float w2 = width / 2f;            
            GraphicsPath GraphPath = new GraphicsPath();

            //Top-Left Arc
            GraphPath.AddArc(Rect.X + w2, Rect.Y + w2, radius, radius, 180, 90);

            //Top-Right Arc
            GraphPath.AddArc(Rect.X + Rect.Width - radius - w2, Rect.Y + w2, radius, radius, 270, 90);

            //Bottom-Right Arc
            GraphPath.AddArc(Rect.X + Rect.Width - w2 - radius,
                               Rect.Y + Rect.Height - w2 - radius, radius, radius, 0, 90);
            //Bottom-Left Arc
            GraphPath.AddArc(Rect.X + w2, Rect.Y - w2 + Rect.Height - radius, radius, radius, 90, 90);

            //Close line ( Left)           
            GraphPath.AddLine(Rect.X + w2, Rect.Y + Rect.Height - r2 - w2, Rect.X + w2,Rect.Y + r2 + w2);
                       
            //GraphPath.CloseFigure();            
            
            return GraphPath;
        }

        private void DrawText(Graphics g,RectangleF Rect)
        {
            float r2 = BorderRadius / 2f;
            float w2 = BorderWidth / 2f;
            Point point = new Point();
            StringFormat format = new StringFormat();

            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                    point.X = (int)(Rect.X + r2/2 + w2 + Padding.Left);
                    point.Y = (int)(Rect.Y + r2/2 + w2 + Padding.Top);
                    format.LineAlignment = StringAlignment.Center;                    
                    break;
                case ContentAlignment.TopCenter:
                    point.X = (int)(Rect.X + Rect.Width/2f);
                    point.Y = (int)(Rect.Y + r2/2 + w2 + Padding.Top);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                    point.X = (int)(Rect.X + Rect.Width - r2/2 - w2 - Padding.Right);
                    point.Y = (int)(Rect.Y + r2 / 2 + w2 + Padding.Top);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleLeft:
                    point.X = (int)(Rect.X + r2 / 2 + w2 + Padding.Left);
                    point.Y = (int)(Rect.Y + Rect.Height/2);
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleCenter:
                    point.X = (int)(Rect.X +Rect.Width / 2);
                    point.Y = (int)(Rect.Y + Rect.Height / 2);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleRight:
                    point.X = (int)(Rect.X + Rect.Width - r2 / 2 - w2 - Padding.Right);
                    point.Y = (int)(Rect.Y + Rect.Height / 2);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomLeft:
                    point.X = (int)(Rect.X + r2 / 2 + w2 + Padding.Left);
                    point.Y = (int)(Rect.Y + Rect.Height - r2 / 2 - w2 - Padding.Bottom);
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomCenter:
                    point.X = (int)(Rect.X + Rect.Width/2);
                    point.Y = (int)(Rect.Y + Rect.Height - r2 / 2 - w2 - Padding.Bottom);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomRight:
                    point.X = (int)(Rect.X + Rect.Width - r2 / 2 - w2 - Padding.Right);
                    point.Y = (int)(Rect.Y + Rect.Height - r2 / 2 - w2 - Padding.Bottom);
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Far;
                    break;
                default:
                    break;
            }
            
            /* Debug
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawLine(pen, new Point(0, 0), point);
                g.DrawLine(pen, point.X, 0, point.X, point.Y);
                g.DrawLine(pen, 0, point.Y, point.X, point.Y);
            }
            */

            using (Brush brush = new SolidBrush(ForeColor))
                g.DrawString(Text, Font, brush, point, format);           
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            Brush brush = new SolidBrush(this.BackColor);
            //Pen pen = new Pen(BorderColor, BorderWidth);
            
            GraphicsPath GraphPath = GetRoundPath(Rect, BorderRadius);

            this.Region = new Region(GraphPath);
            
            //Draw Back Color
            if(IsMouseDown && !FlatAppearance.MouseDownBackColor.IsEmpty)
                using (Brush mouseDownBrush = new SolidBrush(FlatAppearance.MouseDownBackColor))
                    e.Graphics.FillPath(mouseDownBrush, GraphPath);
            else if (IsMouseOver && !FlatAppearance.MouseOverBackColor.IsEmpty)
                using (Brush overBrush = new SolidBrush(FlatAppearance.MouseOverBackColor))
                    e.Graphics.FillPath(overBrush, GraphPath);
            else            
                e.Graphics.FillPath(brush, GraphPath);

            //Draw Border
            #region DrawBorder

            GraphicsPath GraphInnerPath;
            Pen pen;

            if (IsMouseDown && !BorderDownColor.IsEmpty)
            {
                GraphInnerPath = GetRoundPath(Rect, BorderRadius, BorderDownWidth);
                pen = new Pen(BorderDownColor, BorderDownWidth);
            }                
            else if (IsMouseOver && !BorderOverColor.IsEmpty)
            {
                GraphInnerPath = GetRoundPath(Rect, BorderRadius, BorderOverWidth);
                pen = new Pen(BorderOverColor, BorderOverWidth);
            }                
            else
            {
                GraphInnerPath = GetRoundPath(Rect, BorderRadius, BorderWidth);
                pen = new Pen(BorderColor, BorderWidth);
            }
                

            pen.Alignment = PenAlignment.Inset;
            if(pen.Width>0)
                e.Graphics.DrawPath(pen, GraphInnerPath);
            #endregion

            //Draw Text
            DrawText(e.Graphics,Rect);
        }// End Paint Method

        protected override void OnMouseEnter(EventArgs e)
        {
            IsMouseOver = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            IsMouseOver = false;
            IsMouseDown = false;
            Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            IsMouseDown = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            IsMouseDown = false;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        
    }
}
