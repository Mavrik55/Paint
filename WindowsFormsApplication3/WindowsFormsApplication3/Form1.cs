using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        Color CurrentColor = Color.Black;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                for_paint();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void for_paint()
        {
            Pen p = new Pen(CurrentColor);
            g.DrawLine(p, PrevPoint, CurrentPoint);
        }
    }
}
