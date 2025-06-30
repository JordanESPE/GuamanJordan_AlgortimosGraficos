using System.Drawing;
using System.Windows.Forms;

namespace GuamanJordan_PruebaParcial2
{
    public class LoadingForm : Form
    {
        public LoadingForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(220, 80);
            this.BackColor = Color.White;
            Label lbl = new Label()
            {
                Text = "⏳ Cargando...",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lbl);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoadingForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "LoadingForm";
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.ResumeLayout(false);

        }

        private void LoadingForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}