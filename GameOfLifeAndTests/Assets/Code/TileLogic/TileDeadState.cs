using UnityEngine;

namespace GameOfLifeAndTests
{
	public class TileDeadState : TileBaseState
	{
        public override void OnEnterState(TileStateMachine tileStateMachine)
        {
            tileStateMachine.GetComponent<SpriteRenderer>().material = tileStateMachine.deadMaterial;
            tileStateMachine.nextState = tileStateMachine.aliveState;
        }

        public override void OnExitState(TileStateMachine tileStateMachine)
        {
            
        }

    }
}