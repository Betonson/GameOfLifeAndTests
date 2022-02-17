using UnityEngine;

namespace GameOfLifeAndTests
{
	public class TileAliveState : TileBaseState
	{
        public override void OnEnterState(TileStateMachine tileStateMachine)
        {
            tileStateMachine.GetComponent<SpriteRenderer>().material = tileStateMachine.aliveMaterial;
            tileStateMachine.nextState = tileStateMachine.deadState;
        }

        public override void OnExitState(TileStateMachine tileStateMachine)
        {

        }

    }
}