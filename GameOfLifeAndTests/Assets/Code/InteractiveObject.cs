using UnityEngine;

namespace GameOfLifeAndTests
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; set; } = true;
        protected abstract void OnEnterInteraction();
        protected abstract void OnExitInteraction();

        private void OnTriggerEnter(Collider other)
        {
            if(!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            OnEnterInteraction();
        }
        private void OnTriggerExit(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            OnExitInteraction();
        }
        private void Start()
        {
            CustomUpdate();
        }

        public virtual void CustomUpdate()
        {
            
        }
    }
}
