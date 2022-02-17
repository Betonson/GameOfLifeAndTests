using UnityEngine;

namespace GameOfLifeAndTests
{
	public class TileDeadState : TileBaseState
	{
        public override void OnEnterState(Tile tile)
        {
            tile.GetComponent<SpriteRenderer>().material = tile.deadMaterial;
            tile.nextState = tile.aliveState;
        }

        public override void OnExitState(Tile tile)
        {
            
        }

    }
}