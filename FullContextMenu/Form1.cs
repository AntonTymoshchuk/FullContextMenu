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
    public partial class Form1 : Form
    {
        private Label TestLabel;

        public Form1()
        {
            InitializeComponent();
            Size = new Size(600, 400);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;

            InitializeControls();
        }

        public void InitializeControls()
        {
            TestLabel = new Label();
            TestLabel.TabIndex = 0;
            TestLabel.Location = new Point(100, 100);
            TestLabel.Size = new Size(200, 200);
            TestLabel.FlatStyle = FlatStyle.Flat;
            TestLabel.BorderStyle = BorderStyle.None;
            TestLabel.BackColor = Color.Gainsboro;
            TestLabel.Font = new Font("Calibri", 24);
            TestLabel.ForeColor = Color.Black;
            TestLabel.Text = "Test";
            TestLabel.TextAlign = ContentAlignment.MiddleCenter;
            TestLabel.MouseClick += TestLabel_MouseClick;

            Controls.Add(TestLabel);
        }

        private void TestLabel_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.Call(Bounds.Left + TestLabel.Left + e.X, Bounds.Top + TestLabel.Top + e.Y, this);
        }
    }
}
