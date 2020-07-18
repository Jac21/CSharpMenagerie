namespace MagicalMethods
{
    // Deconstructors 
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) => (x, y) = (x, y);

        public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
    }

    // add to types declared outside the source code
    public static class PointExtensions
    {
        public static void Deconstruct(this Point @this, out int x, out int y)
            => (x, y) = (@this.X, @this.Y);
    }
}