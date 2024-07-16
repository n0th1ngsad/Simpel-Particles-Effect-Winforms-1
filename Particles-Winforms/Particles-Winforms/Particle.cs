using System.Drawing;

public class Particle
{
    public PointF Position { get; set; }
    public PointF Velocity { get; set; }
    public Color Color { get; set; }
    public float Size { get; set; }

    public Particle(PointF position, PointF velocity, Color color, float size)
    {
        Position = position;
        Velocity = velocity;
        Color = color;
        Size = size;
    }

    public void Update()
    {
        Position = new PointF(Position.X + Velocity.X, Position.Y + Velocity.Y);
    }
}
