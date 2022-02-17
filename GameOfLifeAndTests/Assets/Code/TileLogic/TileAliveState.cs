using UnityEngine;

namespace GameOfLifeAndTests
{
	public class TileAliveState : TileBaseState
	{
        public override void OnEnterState(Tile tile)
        {
            tile.GetComponent<SpriteRenderer>().material = tile.aliveMaterial;
            tile.nextState = tile.deadState;
        }

        public override void OnExitState(Tile tile)
        {

        }

    }
}