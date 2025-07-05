using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMaker
{
    public class Animation
    {
        string segmentName;
        double position;
        double segmentHeight;
        Color segmentColor;
        public Animation(string segmentName, double position, double segmentHeight, Color segmentColor) {
            this.position = position;
            this.segmentHeight = segmentHeight;
            this.segmentName = segmentName;
            this.segmentColor = segmentColor;
        }


        public static void fillSegment(Graphics g, string segmentName, double prev_y, double segmentHeight, Color segmentColor)
        {
            double width = 280.00; // first diameter of ecplipse
            double height = 442.00; // second diameter of eclipse
            int position_x = 190; // x position of bounding rectangle of eclipse top-left corner
            int position_y = -48; // y position of bounding rectangle of eclipse top-left corner
            // 474 is y of bottom of cup, 56 is first segment height (espresso), prev_y is the height of all previous added segments

            Animation a = new Animation(segmentName, prev_y, segmentHeight, segmentColor);
            Pen p = new Pen(Color.Gray);
            SolidBrush b = new SolidBrush(segmentColor);

            int bottomY = position_y + (int)height;
            int clipY = bottomY - ((int)segmentHeight);
            PointF textCenter = new PointF(
                       position_x + (float)(width / 2),
                       clipY + ((int)segmentHeight / 2)); // point of text in the slice


            GraphicsState state = g.Save();
            if (prev_y != 0.0)
            {
                int sliceTopY = (int)(bottomY - prev_y - (int)segmentHeight);
                textCenter = new PointF(
                        position_x + (float)(width / 2),                   
                        sliceTopY + ((int)segmentHeight / 2));
                g.SetClip(new Rectangle(position_x, sliceTopY, (int)width, ((int)segmentHeight)));
            }
            else
            {
                g.SetClip(new Rectangle(position_x, clipY, (int)width, ((int)segmentHeight)));
            }            

            //g.SetClip(new Rectangle(position_x, position_y, 340, ((int)segmentHeight)));
            g.DrawEllipse(p, position_x, position_y, ((float)width), ((float)height));
            g.FillEllipse(b, position_x, position_y, ((float)width), ((float)height));

            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,     // center horizontally
                LineAlignment = StringAlignment.Center  // center vertically
            };

            if (segmentName == "sugar")
            {
                segmentName = "";
            }
            g.DrawString(segmentName, new Font("Arial", 12), Brushes.Black, textCenter, format);

        }
    }
}
