using System.Collections.Generic;

namespace Entities.Enemy.Ai.States
{
    public class MultipleStates: IState
    {
        private readonly List<IState> _states;

        public MultipleStates(List<IState> states)
        {
            _states = states;
        }

        public void Tick()
        {
            foreach (var state in _states)
            {
                state.Tick();
            }
        }

        public void FixedTick()
        {
            foreach (var state in _states)
            {
                state.FixedTick();
            }
        }

        public void OnEnter()
        {
            foreach (var state in _states)
            {
                state.OnEnter();
            }
        }

        public void OnExit()
        {
            foreach (var state in _states)
            {
                state.OnExit();
            }
        }
    }
}