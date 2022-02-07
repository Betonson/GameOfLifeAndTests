using UnityEngine;

namespace GameOfLifeAndTests
{
	public class TileDeadState : TileBaseState
	{
        public override void OnEnterState(Tile tile)
        {
            Debug.Log("Changing in progress");
            tile.GetComponent<SpriteRenderer>().color = tile.deadColor;
            tile._nextState = tile.aliveState;
        }

        public override void OnExitState(Tile tile)
        {
            
        }

    }
}