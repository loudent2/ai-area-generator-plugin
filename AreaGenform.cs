using System;
using System.Windows.Forms;

namespace AIAreaGeneratorPlugin
{
    public class AreaGenForm : Form
    {
        public AreaGenForm()
        {
            this.Text = "AI Area Generator";
            this.Width = 400;
            this.Height = 300;

            Label info = new Label
            {
                Text = "This is where you'll define area generation parameters.",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.Controls.Add(info);
        }
    }
}
