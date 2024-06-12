using System.Drawing;
using System.Windows.Forms;

namespace Super_Text_Editor
{
    internal class ColorStyles
    {
        internal class Light
        {
            public static Color MenuStrip = SystemColors.Control;
            public static Color ToolStrip = SystemColors.Control;
            public static Color Content = SystemColors.Window;
            public static Color StatusBar = SystemColors.Control;
            public static Color MenuStripFore = SystemColors.ControlText;
            public static Color ContentFore = SystemColors.WindowText;
            public static Color StatusBarFore = SystemColors.ControlText;

            public static void Append(MenuStrip strip, ToolStripMenuItem[] items, ToolStrip tstrip, RichTextBox content, StatusStrip statusb, ToolStripStatusLabel[] labels, ToolStripSeparator[] sep)
            {
                strip.BackColor = MenuStrip;
                strip.ForeColor = MenuStripFore;
                tstrip.BackColor = ToolStrip;
                content.BackColor = Content;
                content.ForeColor = ContentFore;
                statusb.BackColor = StatusBar;

                foreach (ToolStripMenuItem it in items)
                {
                    it.BackColor = MenuStrip;
                    it.ForeColor = MenuStripFore;
                }

                foreach (ToolStripStatusLabel lbl in labels)
                {
                    lbl.BackColor = StatusBar;
                    lbl.ForeColor = StatusBarFore;
                }

                foreach (ToolStripSeparator s in sep)
                {
                    s.BackColor = MenuStrip;
                }
            }
        }

        internal class Dark
        {
            public static Color MenuStrip = Color.FromArgb(20, 20, 20);
            public static Color ToolStrip = Color.FromArgb(20, 20, 20);
            public static Color Content = Color.FromArgb(40, 40, 40);
            public static Color StatusBar = Color.FromArgb(20, 20, 20);
            public static Color MenuStripFore = SystemColors.Window;
            public static Color ContentFore = SystemColors.Window;
            public static Color StatusBarFore = SystemColors.Window;

            public static void Append(MenuStrip strip, ToolStripMenuItem[] items, ToolStrip tstrip, RichTextBox content, StatusStrip statusb, ToolStripStatusLabel[] labels, ToolStripSeparator[] sep)
            {
                strip.BackColor = MenuStrip;
                strip.ForeColor = MenuStripFore;
                tstrip.BackColor = ToolStrip;
                content.BackColor = Content;
                content.ForeColor = ContentFore;
                statusb.BackColor = StatusBar;

                foreach (ToolStripMenuItem it in items)
                {
                    it.BackColor = MenuStrip;
                    it.ForeColor = MenuStripFore;
                }

                foreach (ToolStripStatusLabel lbl in labels)
                {
                    lbl.BackColor = StatusBar;
                    lbl.ForeColor = StatusBarFore;
                }

                foreach (ToolStripSeparator s in sep)
                {
                    s.BackColor = MenuStrip;
                }
            }
        }
    }
}
