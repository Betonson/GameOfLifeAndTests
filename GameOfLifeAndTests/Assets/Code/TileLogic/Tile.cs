using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
	public class Tile : MonoBehaviour
	{
		[SerializeField] private GameObject _highlight;
		public Color aliveColor;
		public Color deadColor;
		private TileBaseState _currentState, _calculatedState;
		public TileBaseState nextState;
		public TileAliveState aliveState = new TileAliveState();
		public TileDeadState deadState = new TileDeadState();
		private List<Tile> _neighbours = new List<Tile>();

		private void Awake() {
			SwitchState(aliveState);
		}
		private void OnMouseEnter()
        {
			_highlight.SetActive(true);
			foreach (var neighbour in _neighbours)
			{
				neighbour._highlight.SetActive(true);
			}
		}

		private void OnMouseExit()
		{
			_highlight.SetActive(false);
			foreach (var neighbour in _neighbours)
			{
				neighbour._highlight.SetActive(false);
			}
		}
		private void OnMouseDown()
		{
			SwitchState(nextState);
		}

		public void SwitchState(TileBaseState newState)
		{
			Debug.Log("Switching state to: " + newState.ToString());
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

		public void CalculateNewState(string survivalCurve)
		{
			
		}
	}
}