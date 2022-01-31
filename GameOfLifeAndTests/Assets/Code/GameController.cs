using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListUpdatableObject _updatableObjects;
        private GameMaster _gameMaster;
        public void Awake()
        {
            _gameMaster = FindObjectOfType<GameMaster>();
            _updatableObjects = new ListUpdatableObject();

            foreach (var objct in _updatableObjects)
            {
                //if (objct is BadBonus badBonus)
                //{
                //    badBonus.BadBonusContact += BadBonusContact;
                //    badBonus.BadBonusContact += _gameMaster.DisplayGameOverScreen;
                //}
            }

        }

        public void BadBonusContact(object value)
        {
            Time.timeScale = 0.0f;
        }

        public void Update()
        {
            for (var i = 0; i < _updatableObjects.Length; i++)
            {
                var updatableObject = _updatableObjects[i];
                if (updatableObject == null)
                {
                    Debug.Log("Test1");
                    continue;
                }
                updatableObject.CustomUpdate();
            }
        }
        public void Dispose()
        {
            foreach (var o in _updatableObjects)
            {
                if (o is UpdatableObject updatableObject)
                {
                    //if (o is BadBonus badBonus)
                    //{
                    //    badBonus.BadBonusContact -= BadBonusContact;
                    //    badBonus.BadBonusContact -= _gameMaster.DisplayGameOverScreen;
                    //}
                    Debug.Log("I did a thing!");
                    Destroy(updatableObject.gameObject);
                }
            }
        }
    }
}
