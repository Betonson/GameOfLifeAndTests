using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace GameOfLifeAndTests
{
    public sealed class ListUpdatableObject : IEnumerator, IEnumerable
    {
        private IUpdatable[] _updatableObjects;
        private int _index = -1;
        //private InteractiveObject _current;

        public ListUpdatableObject()
        {
            var updatableObjects = Object.FindObjectsOfType<UpdatableObject>();
            for (var i = 0; i < updatableObjects.Length; i++)
            {
                if (updatableObjects[i] is IUpdatable updatableObject)
                {
                    AddUpdatableObject(updatableObject);
                }
            }
        }

        public void AddUpdatableObject(IUpdatable update)
        {
            if (_updatableObjects == null)
            {
                _updatableObjects = new[] { update };
                return;
            }
            Array.Resize(ref _updatableObjects, Length + 1);
            _updatableObjects[Length - 1] = update;
        }

        public IUpdatable this[int index]
        {
            get => _updatableObjects[index];
            private set => _updatableObjects[index] = value;
        }

        public int Length => _updatableObjects.Length;

        public bool MoveNext()
        {
            if (_index == _updatableObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _updatableObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

