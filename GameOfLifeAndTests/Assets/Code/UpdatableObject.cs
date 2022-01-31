using UnityEngine;

namespace GameOfLifeAndTests
{
    public abstract class UpdatableObject : MonoBehaviour, IUpdatable
    {
        public abstract void CustomUpdate();
    }
}
