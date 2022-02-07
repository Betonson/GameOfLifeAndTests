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
		private TileBaseState _currentState;
		public TileBaseState _nextState;
		public TileAliveState aliveState = new TileAliveState();
		public TileDeadState deadState = new TileDeadState();

		private void Awake() {
			SwitchState(aliveState);
		}
		private void OnMouseEnter()
        {
			_highlight.SetActive(true);
		}

		private void OnMouseExit()
		{
			_highlight.SetActive(false);
		}
		private void OnMouseDown()
		{
			SwitchState(_nextState);
		}

		public void SwitchState(TileBaseState newState)
		{
			Debug.Log("Switching state to: " + newState.ToString());
			_currentState = newState;
			newState.OnEnterState(this);
		}
	}
}