using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
    public sealed class GameController : MonoBehaviour
    {
        public delegate void OnStartButtonPressed();

        public event OnStartButtonPressed StartButtonPressed;
        private GridManager _gridManager;

        private void Awake()
        {
            _gridManager = FindObjectOfType<GridManager>();
        }

        private void Start()
        {   
            _gridManager.GenerateGrid();
            _gridManager.FillNeighbours();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartButtonPressed?.Invoke();
            }
        }
    }
}
