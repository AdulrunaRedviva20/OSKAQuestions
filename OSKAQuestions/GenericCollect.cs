﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OSKAQuestions
{
    public class MultiGenericCollect<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        private readonly List<T> _list = new List<T>();
        public T this[int index] { get { return _list[index]; } set { _list[index] = value;  } }

        public int Count { get; }
        public bool IsReadOnly { get; }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear(); 
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            _list[index]=item;
        }

        public bool Remove(T item)
        {
            _list.Remove(item);

            return true;
        }

        public void RemoveAt(int index)
        {
           _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
