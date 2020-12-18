using System.Windows.Forms;

namespace DesktopApplication.Engine
{
    internal static class UserControlExtension
    {
        public static void Redirect(this UserControl userControl, Control content)
        {
            var parent = userControl.Parent;
            userControl.Parent.Controls.Clear();
            parent.Controls.Add(content);
            parent.Dock = DockStyle.Fill;
            userControl.Parent = parent;
        }
    }
}