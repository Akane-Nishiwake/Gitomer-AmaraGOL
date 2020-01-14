using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Change the namespace to your project's namespace.
namespace Gitomer_AmaraGOL
{
    class GraphicsPanel : Panel
    {
        // Default constructor
        public GraphicsPanel()
        {
            // Turn on double buffering.
            this.DoubleBuffered = true;

            // Allow repainting when the window is resized.
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
}
