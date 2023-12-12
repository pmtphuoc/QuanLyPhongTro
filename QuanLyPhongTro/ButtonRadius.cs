using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace QuanLyPhongTro
{
   public class ButtonRadius : Button 
    {
        private int borderSize = 0;
        private int borderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;

        [Category("Code Advance")]
        public int BorderSize { get { return borderSize; } set { borderSize = value; this.Invalidate(); } }
        [Category("Code Advance")]
        public int BorderRadius { get { return borderRadius; } set { borderRadius = value; this.Invalidate(); } }
        [Category("Code Advance")]
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        //constructor
        public ButtonRadius()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
        }
        //methods
        private GraphicsPath GetGraphicsPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width-radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width-radius, rect.Height-radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height-radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if(borderRadius > 2) 
            {
                using (GraphicsPath pathSurface = GetGraphicsPath(rectSurface,borderRadius))
                using (GraphicsPath pathBorder = GetGraphicsPath(rectBorder,borderRadius-1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor,2))
                using (Pen penBorder = new Pen(borderColor,borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    //Button boder
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }    
            }    
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
    }
      
}
