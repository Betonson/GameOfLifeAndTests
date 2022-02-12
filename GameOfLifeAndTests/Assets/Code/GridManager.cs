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

        private void Start()
        {
            _tileCollection = new Tile[_width, _height];
            GenerateGrid();
            FillNeighbours();
        }

        private void GenerateGrid()
        {
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
        
        private void FillNeighbours()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (x > 0)
                    {
                        _tileCollection[x-1, y].AddNeighbour(_tileCollection[x, y]);
                    }
                    if (x < _width-1)
                    {
                        _tileCollection[x+1, y].AddNeighbour(_tileCollection[x, y]);
                    }
                    if (y > 0)
                    {
                        _tileCollection[x, y-1].AddNeighbour(_tileCollection[x, y]);
                    }
                    if (y < _height-1)
                    {
                        _tileCollection[x, y+1].AddNeighbour(_tileCollection[x, y]);
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
    }
}