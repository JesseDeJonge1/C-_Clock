using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
    /// <summary>
    /// The ClockDrawer class is responsible for drawing a clock on a given Graphics object.
    /// </summary>
    public class ClockDrawer
    {
        /// <summary>
        /// Draws the clock on the specified Graphics object.
        /// </summary>
        /// <param name="g">The Graphics object to draw on.</param>
        /// <param name="width">The width of the drawing area.</param>
        /// <param name="height">The height of the drawing area.</param>
        public void DrawClock(Graphics g, int width, int height)
        {
            // Center and radius for the clock
            int centerX = width / 2;
            int centerY = height / 2;
            int radius = Math.Min(centerX, centerY) - 10;

            // Draw clock circle
            g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);

            // Get current time
            DateTime now = DateTime.Now;
            float secondAngle = now.Second * 6; // 360 / 60
            float minuteAngle = now.Minute * 6 + now.Second * 0.1f; // 360 / 60
            float hourAngle = (now.Hour % 12) * 30 + now.Minute * 0.5f; // 360 / 12

            // Draw hands using trigonometry
            DrawHand(g, centerX, centerY, secondAngle, radius - 20, Pens.Red); // Second hand
            DrawHand(g, centerX, centerY, minuteAngle, radius - 30, Pens.Blue); // Minute hand
            DrawHand(g, centerX, centerY, hourAngle, radius - 50, Pens.Black); // Hour hand
        }

        /// <summary>
        /// Draws a clock hand on the specified Graphics object.
        /// </summary>
        /// <param name="g">The Graphics object to draw on.</param>
        /// <param name="centerX">The x-coordinate of the clock center.</param>
        /// <param name="centerY">The y-coordinate of the clock center.</param>
        /// <param name="angle">The angle of the hand in degrees.</param>
        /// <param name="length">The length of the hand.</param>
        /// <param name="pen">The Pen object used to draw the hand.</param>
        private void DrawHand(Graphics g, int centerX, int centerY, float angle, int length, Pen pen)
        {
            // Convert angle to radians and calculate the endpoint using sine and cosine
            double radian = (Math.PI / 180) * angle;
            int endX = centerX + (int)(length * Math.Sin(radian));
            int endY = centerY - (int)(length * Math.Cos(radian));

            // Draw line from center to endpoint
            g.DrawLine(pen, centerX, centerY, endX, endY);
        }
    }
}