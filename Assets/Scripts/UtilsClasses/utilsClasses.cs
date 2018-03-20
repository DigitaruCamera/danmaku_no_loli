namespace utils
{
  class Matrix<T>
  {
     private T[] elements;
     public int width { get; }
     public int height { get; }

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
