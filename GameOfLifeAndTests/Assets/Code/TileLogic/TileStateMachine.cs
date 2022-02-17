using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace GameOfLifeAndTests
{
    public class TileStateMachine : MonoBehaviour
    {
        private GameObject _highlight;
        public Material aliveMaterial;
        public Material deadMaterial;
        public TileBaseState currentState, calculatedState;
        public TileBaseState nextState;
        public TileAliveState aliveState = new TileAliveState();
        public TileDeadState deadState = new TileDeadState();

        private void Awake()
        {
            _highlight = GetChildByName("Highlight");
            //SwitchHighlight(false);
            aliveMaterial = (Material) Resources.Load("Materials/StandardTileAliveMaterial");
            deadMaterial = (Material) Resources.Load("Materials/StandardTileDeadMaterial");
        }

        public void SwitchHighlight(bool state)
        {
            _highlight.SetActive(state);
        }
        public void SwitchState(TileBaseState newState = null)
        {
            if (newState != null)
            {
                currentState = newState;
                newState.OnEnterState(this);
            }
            else
            {
                currentState = nextState;
                nextState.OnEnterState(this);
            }
        }

        public void SwitchToAlive()
        {
            currentState = aliveState;
            aliveState.OnEnterState(this);
        }
        public void SwitchToDead()
        {
            currentState = deadState;
            deadState.OnEnterState(this);
        }
        public void SwitchToCalculated()
        {
            currentState = calculatedState;
            calculatedState.OnEnterState(this);
        }

        public bool IsAlive()
        {
            return currentState == aliveState ? true : false;
        }
        
        private GameObject GetChildByName(string name)
        {
            Transform[] children = GetComponentsInChildren<Transform>(true);
            foreach (Transform childTransform in children)
            {
                if (childTransform.gameObject.name == name)
                {
                    return childTransform.gameObject;
                }
            }

            return null;
        }

        public void SetDefaultState()
        {
            SwitchState(deadState);
        }
    }
}
