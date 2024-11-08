using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath path = new GraphicsPath();
        int radius = 10; // Adjust the radius as needed

        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
        path.AddLine(radius, 0, Width - radius, 0);
        path.AddArc(Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
        path.AddLine(Width, radius, Width, Height - radius);
        path.AddArc(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2, 0, 90);
        path.AddLine(Width - radius, Height, radius, Height);
        path.AddArc(0, Height - radius * 2, radius * 2, radius * 2, 90, 90);
        path.AddLine(0, Height - radius, 0, radius);

        Region region = new Region(path);
        this.Region = region;

        base.OnPaint(e);
    }
}
