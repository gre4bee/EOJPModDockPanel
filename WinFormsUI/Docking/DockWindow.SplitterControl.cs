using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
    public partial class DockWindow
    {
        internal class DefaultSplitterControl : SplitterBase
        {
            private ISplitterHost _host;

            public DefaultSplitterControl(ISplitterHost host)
            {
                _host = host;
            }

            protected override int SplitterSize
            {
                get { return _host.DockPanel.Theme.Measures.SplitterSize; }
            }

            protected override void StartDrag()
            {
                DockWindow window = Parent as DockWindow;
                if (window == null)
                    return;
                if (!window.DockPanel.AllowChangeLayout)
                    return;
                window.DockPanel.BeginDrag(window, window.RectangleToScreen(Bounds));
            }
        }
    }
}
