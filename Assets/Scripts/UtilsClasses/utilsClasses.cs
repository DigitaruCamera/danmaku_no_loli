using System;
using System.Collections.Generic;

namespace utils
{
    public class UtilsList
    {
        public List<T> Resize<T>(T[] _list, int sz) where T : new()
        {
            List<T> list = new List<T>(_list);
            if (list.Count < sz)
            {
                while (list.Count < sz)
                {
                    list.Add(new T());
                }
            }
            else if (list.Count > sz)
            {
                list.RemoveRange(sz, list.Count - sz);
            }
            return list;
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
