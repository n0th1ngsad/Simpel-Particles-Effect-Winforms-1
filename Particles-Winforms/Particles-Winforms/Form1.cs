using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Particles_Winforms
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private List<Particle> particles;
        private Random random;
        private Color customColor = Color.FromArgb(0xF7, 0xF9, 0xF2);
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            timer = new Timer();
            timer.Interval = 3; 
            timer.Tick += timer1_Tick;

            particles = new List<Particle>();
            random = new Random();

            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;

            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var particle in particles)
            {
                particle.Update();
            }

            this.Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                float velocityX = (float)(random.NextDouble() * 2 - 1);
                float velocityY = (float)(random.NextDouble() * 2 - 1);
                Color color = customColor;
                float size = (float)(random.NextDouble() * 10 + 5);

                Particle particle = new Particle(e.Location, new PointF(velocityX, velocityY), color, size);
                particles.Add(particle);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var particle in particles)
            {
                using (Brush brush = new SolidBrush(particle.Color))
                {
                    g.FillEllipse(brush, particle.Position.X, particle.Position.Y, particle.Size, particle.Size);
                }
            }
        }
    }
}
