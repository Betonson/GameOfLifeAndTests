using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
	public class Tile : MonoBehaviour
	{
		//[SerializeField] private GameObject _highlight;
		private GameController _gameController;
		/*public Color aliveColor;
		public Color deadColor;
		public Material aliveMaterial;
		public Material deadMaterial;
		private TileBaseState _currentState, _calculatedState;
		public TileBaseState nextState;
		public TileAliveState aliveState = new TileAliveState();
		public TileDeadState deadState = new TileDeadState();*/
		private List<Tile> _neighbours = new List<Tile>();
		private bool _isDisabled;
		public TileStateMachine tileStateMachine;

		private void Awake() {
			_gameController = FindObjectOfType<GameController>();
			_gameController.StartButtonPressed += StartButtonPressedActions;
			tileStateMachine = this.GetComponent<TileStateMachine>();

			/*aliveMaterial = (Material) Resources.Load("Materials/StandardTileAliveMaterial");
			deadMaterial = (Material) Resources.Load("Materials/StandardTileDeadMaterial");*/
			
			_isDisabled = false;
		}

		private void Start()
		{
			tileStateMachine.SetDefaultState();
		}

		private void OnMouseEnter()
        {
	        if (!_isDisabled)
	        {
		        tileStateMachine.SwitchHighlight(true);
		        foreach (var neighbour in _neighbours)
		        {
			        neighbour.tileStateMachine.SwitchHighlight(true);
		        }
	        }
        }

		private void OnMouseExit()
		{
			if (!_isDisabled)
			{
				tileStateMachine.SwitchHighlight(false);
				foreach (var neighbour in _neighbours)
				{
					neighbour.tileStateMachine.SwitchHighlight(false);
				}
			}
		}
		private void OnMouseDown()
		{
			if (!_isDisabled)
			{
				tileStateMachine.SwitchState();
			}
		}

		public void AddNeighbour(Tile newTile)
		{
			_neighbours.Add(newTile);
		}

		private void StartButtonPressedActions()
		{
			_isDisabled = !_isDisabled;
			if (_isDisabled)
			{
				tileStateMachine.SwitchHighlight(false);
			}
		}

		private int CountAliveNeighbours()
		{
			var aliveCount = 0;
			foreach (var neighbour in _neighbours)
			{
				if (neighbour.tileStateMachine.IsAlive())
				{
					aliveCount += 1;
				}
			}

			return aliveCount;
		}
		public void CalculateNewState(string survivalCurve)
		{
			 if (survivalCurve[CountAliveNeighbours()] == '1')
			{
 				tileStateMachine.calculatedState = tileStateMachine.aliveState;
			}
			else
			{
				tileStateMachine.calculatedState = tileStateMachine.deadState;
			}
		}
	}
}