using System;
using System.Collections.Generic;

namespace Modules.Platforms
{
    public class Pool<T> where T : class
    {
        private readonly Dictionary<Type, Stack<T>>   _availableInstances;
        private readonly Dictionary<Type, HashSet<T>> _usedInstances;

        private Func<T> _createFunc;

        public Pool(Func<T> create)
        {
            _createFunc = create;
            _availableInstances = new Dictionary<Type, Stack<T>>();
            _usedInstances = new Dictionary<Type, HashSet<T>>();
        }

        /*
         * Take.
         */

        public T Take()
        {
            return Take(out var isNewInstance);
        }
        
        public T Take(out bool isNewInstance)
        {
            T instance;
            var usedInstances = GetUsedInstances(typeof(T), true);
            var availableInstances = GetAvailableInstances(typeof(T), true);
            if (availableInstances.Count > 0)
            {
                instance = availableInstances.Pop();
                usedInstances.Add(instance);

                isNewInstance = false;
                return instance;
            }

            instance = _createFunc();
            usedInstances.Add(instance);

            isNewInstance = true;
            return instance;
        }
        
        /*
         * Return.
         */
        
        public void Return(T instance)
        {
            if (instance == null)
                return;
            
            var commandType = instance.GetType();
            var usedInstances = GetUsedInstances(commandType, false);
            if (usedInstances == null || !usedInstances.Remove(instance))
                return;

            GetAvailableInstances(commandType, false).Push(instance);
        }

        /*
         * Private.
         */

        private Stack<T> GetAvailableInstances(Type type, bool create)
        {
            if (_availableInstances.TryGetValue(type, out var availableInstances) || !create)
                return availableInstances;
            availableInstances = new Stack<T>();
            _availableInstances.Add(type, availableInstances);
            return availableInstances;
        }

        private HashSet<T> GetUsedInstances(Type type, bool create)
        {
            if (_usedInstances.TryGetValue(type, out var usedInstances) || !create)
                return usedInstances;
            usedInstances = new HashSet<T>();
            _usedInstances.Add(type, usedInstances);
            return usedInstances;
        }

        public void ReturnAll(Type type, Action<T> action)
        {
            var usedInstances = new HashSet<T>(GetUsedInstances(type, false));
            foreach (var instance in usedInstances)
            {
                action?.Invoke(instance);
                Return(instance);
            }
        }
    }
}