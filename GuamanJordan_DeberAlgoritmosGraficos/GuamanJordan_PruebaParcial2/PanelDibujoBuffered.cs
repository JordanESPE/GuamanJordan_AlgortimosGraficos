using System.Windows.Forms;

public class PanelDibujoBuffered : Panel
{
    public PanelDibujoBuffered()
    {
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.ResizeRedraw |
                      ControlStyles.UserPaint, true);
        this.UpdateStyles();
    }
}
