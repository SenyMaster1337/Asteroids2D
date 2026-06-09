using System;
using System.Collections.Generic;

namespace Code.Infrastructure.Services.ObjectPools
{
    public class ObjectPool<T> where T : class
    {
        private readonly Func<T> _factory;
        private readonly Queue<T> _pool = new();
        private readonly HashSet<T> _activeObjects = new();
        private readonly int _initialCount;

        public ObjectPool(Func<T> factory, int initialCount)
        {
            _factory = factory;
            _initialCount = initialCount;
        }

        public void Prewarm()
        {
            for (int i = 0; i < _initialCount; i++)
            {
                T obj = _factory();
                _pool.Enqueue(obj);
            }
        }

        public T Get()
        {
            T obj = _pool.Count > 0 ? _pool.Dequeue() : _factory();
            _activeObjects.Add(obj);
            return obj;
        }

        public void Return(T obj)
        {
            _activeObjects.Remove(obj);
            _pool.Enqueue(obj);
        }
    }
}