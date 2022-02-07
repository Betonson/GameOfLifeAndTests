
namespace GameOfLifeAndTests
{
	public abstract class TileBaseState
	{
        public abstract void OnEnterState(Tile tile);

        public abstract void OnExitState(Tile tile);

    }
}