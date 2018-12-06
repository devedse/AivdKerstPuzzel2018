namespace AivdKerstPuzzel2018.Helpers
{
    public class Gridje<T>
    {
        private readonly T[,] innerArray;

        public int Width { get; }
        public int Height { get; }

        public Gridje(int width, int height)
        {
            innerArray = new T[width, height];
            Width = width;
            Height = height;
        }

        public T this[int x, int y]
        {
            get => innerArray[x, y];
            set => innerArray[x, y] = value;
        }
    }
}
