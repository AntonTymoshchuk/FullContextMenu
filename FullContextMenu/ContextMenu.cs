using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullContextMenu
{
    public partial class ContextMenu : Form
    {
        private Button CopyButton;
        private Button PasteButton;
        private Button CutButton;
        private Button CloseButton;

        private int X, Y;

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public void Call(int X, int Y, Form ParentForm)
        {
            this.X = X;
            this.Y = Y;
            ShowDialog(ParentForm);
        }

        public ContextMenu()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            BackColor = Color.Tan;
            Size = new Size(200, 200);
            Shown += ContextMenu_Shown;

            RamGecTools.MouseHook mouseHook = new RamGecTools.MouseHook();
            mouseHook.LeftButtonDown += MouseHook_LeftButtonDown;
            mouseHook.Install();

            InitializeControls();
        }

        private void ContextMenu_Shown(object sender, EventArgs e)
        {
            Location = new Point(X, Y);
        }

        private void MouseHook_LeftButtonDown(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            CheckEventPoint(mouseStruct);
        }

        private void CheckEventPoint(RamGecTools.MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            int X = mouseStruct.pt.x;
            int Y = mouseStruct.pt.y;

            if (Bounds.Left >= X || Bounds.Right <= X || Bounds.Top >= Y || Bounds.Bottom <= Y)
                Dispose();
        }

        private void InitializeControls()
        {
            CopyButton = new Button();
            CopyButton.TabIndex = 0;
            CopyButton.TabStop = true;
            CopyButton.Location = new Point(0, 0);
            CopyButton.Size = new Size(Width, 30);
            CopyButton.FlatStyle = FlatStyle.Flat;
            CopyButton.BackColor = BackColor;
            CopyButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(BackColor.R + 15, BackColor.G + 15, BackColor.B + 15);
            CopyButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(BackColor.R + 30, BackColor.G + 30, BackColor.B + 30);
            CopyButton.FlatAppearance.BorderSize = 0;
            CopyButton.Font = new Font("Calibri", 14);
            CopyButton.ForeColor = Color.White;
            CopyButton.Text = "Copy";
            CopyButton.TextAlign = ContentAlignment.MiddleLeft;

            PasteButton = new Button();
            PasteButton.TabIndex = 0;
            PasteButton.TabStop = true;
            PasteButton.Location = new Point(0, CopyButton.Bottom);
            PasteButton.Size = new Size(Width, 30);
            PasteButton.FlatStyle = FlatStyle.Flat;
            PasteButton.BackColor = BackColor;
            PasteButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(BackColor.R + 15, BackColor.G + 15, BackColor.B + 15);
            PasteButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(BackColor.R + 30, BackColor.G + 30, BackColor.B + 30);
            PasteButton.FlatAppearance.BorderSize = 0;
            PasteButton.Font = new Font("Calibri", 14);
            PasteButton.ForeColor = Color.White;
            PasteButton.Text = "Paste";
            PasteButton.TextAlign = ContentAlignment.MiddleLeft;

            CutButton = new Button();
            CutButton.TabIndex = 0;
            CutButton.TabStop = true;
            CutButton.Location = new Point(0, PasteButton.Bottom);
            CutButton.Size = new Size(Width, 30);
            CutButton.FlatStyle = FlatStyle.Flat;
            CutButton.BackColor = BackColor;
            CutButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(BackColor.R + 15, BackColor.G + 15, BackColor.B + 15);
            CutButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(BackColor.R + 30, BackColor.G + 30, BackColor.B + 30);
            CutButton.FlatAppearance.BorderSize = 0;
            CutButton.Font = new Font("Calibri", 14);
            CutButton.ForeColor = Color.White;
            CutButton.Text = "Cut";
            CutButton.TextAlign = ContentAlignment.MiddleLeft;

            CloseButton = new Button();
            CloseButton.TabIndex = 0;
            CloseButton.TabStop = true;
            CloseButton.Location = new Point(0, CutButton.Bottom);
            CloseButton.Size = new Size(Width, 30);
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.BackColor = BackColor;
            CloseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(BackColor.R + 15, BackColor.G + 15, BackColor.B + 15);
            CloseButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(BackColor.R + 30, BackColor.G + 30, BackColor.B + 30);
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.Font = new Font("Calibri", 14);
            CloseButton.ForeColor = Color.White;
            CloseButton.Text = "Close";
            CloseButton.TextAlign = ContentAlignment.MiddleLeft;

            Controls.Add(CopyButton);
            Controls.Add(PasteButton);
            Controls.Add(CutButton);
            Controls.Add(CloseButton);
        }
    }
}
