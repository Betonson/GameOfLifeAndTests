using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int _width, _height;
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private Transform _mainCamera;
        [SerializeField] private string _survivalCurve;
        private Tile[,] _tileCollection;
        public bool gameOfLifeRunning;

        private void Start()
        {
            gameOfLifeRunning = false;
            FindObjectOfType<GameController>().StartButtonPressed += SwitchGameOfLife;
            /*_tileCollection = new Tile[_width, _height];
            GenerateGrid();
            FillNeighbours();*/
        }

        public void GenerateGrid()
        {
            _tileCollection = new Tile[_width, _height];
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    _tileCollection[x, y] = spawnedTile;
                }
            }
            _mainCamera.position = new Vector3((float) _width / 2 - 0.5f, (float) _height / 2 - 0.5f, -10);
        }
        
        public void FillNeighbours()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (x > 0)
                    {
                        _tileCollection[x-1, y].AddNeighbour(_tileCollection[x, y]);
                    }
                    if (x > 0 && y < _height-1)
                    {
                        _tileCollection[x-1, y+1]?.AddNeighbour(_tileCollection[x, y]);
                    }
                    if (y < _height-1)
                    {
                        _tileCollection[x, y+1].AddNeighbour(_tileCollection[x, y]);
                    }
                    if (x < _width-1 &&y < _height-1)
                    {
                        _tileCollection[x+1, y+1]?.AddNeighbour(_tileCollection[x, y]);
                    }
                    if (x < _width-1)
                    {
                        _tileCollection[x+1, y].AddNeighbour(_tileCollection[x, y]);
                    }
                    if (x < _width-1 && y > 0)
                    {
                        _tileCollection[x+1, y-1]?.AddNeighbour(_tileCollection[x, y]);
                    }
                    if (y > 0)
                    {
                        _tileCollection[x, y-1].AddNeighbour(_tileCollection[x, y]);
                    }
                    if (x > 0 && y > 0)
                    {
                        _tileCollection[x-1, y-1]?.AddNeighbour(_tileCollection[x, y]);
                    }
                }
            }
        }

        private void CalculateNewStates()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _tileCollection[x, y].CalculateNewState(_survivalCurve);
                }
            }
        }

        private void SwitchAllToCalculatedState()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _tileCollection[x, y].tileStateMachine.SwitchToCalculated();
                }
            }
        }
        private void SwitchGameOfLife()
        {
            if (!gameOfLifeRunning)
            {
                StartCoroutine(GameOfLife());
                gameOfLifeRunning = true;
            }
            else
            {
                StopAllCoroutines();
                gameOfLifeRunning = false;
            }
            
        }

        IEnumerator GameOfLife()
        {
            while (true)
            {
                CalculateNewStates();
                SwitchAllToCalculatedState();
                yield return new WaitForSecondsRealtime(1);
            }
        }
    }
}