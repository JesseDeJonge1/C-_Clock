using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// The Form1 class represents the main form of the clock application.
    /// </summary>
    public partial class Form1 : Form
    {
        private ClockDrawer clockDrawer;

        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            clockDrawer = new ClockDrawer();

            // Start the timer
            timer1.Interval = 1000; // 1000 ms = 1 second
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// Forces the form to repaint.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Force the form to repaint
            this.Invalidate();
        }

        /// <summary>
        /// Overrides the OnPaint method to draw the clock.
        /// </summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            clockDrawer.DrawClock(e.Graphics, this.ClientSize.Width, this.ClientSize.Height);
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// Forces the form to repaint every 1000 milliseconds.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Force the form to repaint
            this.Invalidate();
        }
    }
}