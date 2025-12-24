using System.Collections.Generic;

using UnityEngine;

public class TaskFSM : MonoBehaviour
{
    
    public abstract class TaskState
    {
        public  string Name;
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
        public abstract bool CanTransitionTo(string nextState);
    }

    private Dictionary<string, TaskState> _states = new Dictionary<string, TaskState>();
    private TaskState _currentState;
    private Queue<string> _stateQueue = new Queue<string> ();

    public void AddState(string stateName, TaskState state)
    {
        _states[stateName] = state;
    }
    public void SetStateSequence(List<string> stateSequence)
    {
        _stateQueue = new Queue<string> (stateSequence);
        TransitionToNextState();
    }
    public void CompleteCurrentState() 
    {
        if (_currentState != null) 
        {
            _currentState.Exit();
            TransitionToNextState();

        }
    }
    public void TransitionToNextState()
    {
        if (_stateQueue.Count>0)
        {
            string nextStateName = _stateQueue.Dequeue ();
            if (_states.ContainsKey(nextStateName))
            {
                if (_currentState == null || _currentState.CanTransitionTo(nextStateName))
                {
                    _currentState = _states[nextStateName];
                    _currentState.Enter();
                }
            }
        }
        else
        {
            Debug.Log("все конец");
        }
            
    }
}
