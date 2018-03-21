using System;

namespace utils
{
    [Serializable]
    public class MatrixOfBool// : Matrix<bool>
    {
        //public MatrixOfBool(int width, int height) : base(width, height) { }
        private bool[] elements;
        public int width;
        public int height;

        public MatrixOfBool(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.elements = new bool[width * height];
        }
        public bool get(int x, int y)
        {
            return elements[x + y * width];
        }
        public void set(int x, int y, bool value)
        {
            elements[x + y * width] = value;
        }
    }

    [Serializable]
    public class Matrix<T>
    {
        private T[] elements;
        public int width;
        public int height;
        
        public Matrix(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.elements = new T[width * height];
        }
        public T get(int x, int y)
        {
            return elements[x + y * width];
        }
        public void set(int x, int y, T value)
        {
            elements[x + y * width] = value;
        }
    }
}
