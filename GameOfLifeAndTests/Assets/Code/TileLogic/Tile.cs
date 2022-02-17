using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
	public class Tile : MonoBehaviour
	{
		[SerializeField] private GameObject _highlight;
		private GameController _gameController;
		public Color aliveColor;
		public Color deadColor;
		public Material aliveMaterial;
		public Material deadMaterial;
		private TileBaseState _currentState, _calculatedState;
		public TileBaseState nextState;
		public TileAliveState aliveState = new TileAliveState();
		public TileDeadState deadState = new TileDeadState();
		private List<Tile> _neighbours = new List<Tile>();
		private bool _isDisabled;

		private void Awake() {
			_gameController = FindObjectOfType<GameController>();
			_gameController.StartButtonPressed += StartButtonPressedActions;

			aliveMaterial = (Material) Resources.Load("Materials/StandardTileAliveMaterial");
			deadMaterial = (Material) Resources.Load("Materials/StandardTileDeadMaterial");
			
			SwitchState(aliveState);
			_isDisabled = false;
		}
		private void OnMouseEnter()
        {
	        if (!_isDisabled)
	        {
		        _highlight.SetActive(true);
		        /*foreach (var neighbour in _neighbours)
		        {
			        neighbour._highlight.SetActive(true);
		        }*/
	        }
        }

		private void OnMouseExit()
		{
			if (!_isDisabled)
			{
				_highlight.SetActive(false);
				/*foreach (var neighbour in _neighbours)
				{
					neighbour._highlight.SetActive(false);
				}*/
			}
		}
		private void OnMouseDown()
		{
			if (!_isDisabled)
			{
				SwitchState(nextState);
			}
		}

		public void SwitchState(TileBaseState newState)
		{
			_currentState = newState;
			newState.OnEnterState(this);
		}

		public bool IsAlive()
		{
			return _currentState == aliveState ? true : false;
		}

		public void AddNeighbour(Tile newTile)
		{
			_neighbours.Add(newTile);
		}

		private void StartButtonPressedActions()
		{
			_isDisabled = !_isDisabled;
			_highlight.SetActive(false);
		}

		public void CalculateNewState(string survivalCurve)
		{
			
		}
	}
}