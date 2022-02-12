using UnityEngine;

namespace GameOfLifeAndTests
{
	public class TileAliveState : TileBaseState
	{
        public override void OnEnterState(Tile tile)
        {
            Debug.Log("Changing in progress");
            tile.GetComponent<SpriteRenderer>().color = tile.aliveColor;
            tile.nextState = tile.deadState;
        }

        public override void OnExitState(Tile tile)
        {

        }

    }
}