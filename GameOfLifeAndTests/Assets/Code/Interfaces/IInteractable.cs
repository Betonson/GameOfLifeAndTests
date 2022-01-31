namespace GameOfLifeAndTests
{
    public interface IInteractable : IUpdatable
    {
        bool IsInteractable { get; set; }
    }
}