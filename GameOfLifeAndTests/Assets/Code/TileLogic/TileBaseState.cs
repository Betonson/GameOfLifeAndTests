
namespace GameOfLifeAndTests
{
	public abstract class TileBaseState
	{
        public abstract void OnEnterState(TileStateMachine tileStateMachine);

        public abstract void OnExitState(TileStateMachine tileStateMachine);

    }
}