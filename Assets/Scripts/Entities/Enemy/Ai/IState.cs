namespace Entities.Enemy.Ai
{
    public interface IState
    {
        void Tick();
    
        void FixedTick();
        void OnEnter();
        void OnExit();
    }
}