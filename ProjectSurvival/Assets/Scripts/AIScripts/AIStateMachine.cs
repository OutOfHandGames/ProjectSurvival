using UnityEngine;
using System.Collections;

public class AIStateMachine : MonoBehaviour {
    public State[] currentStates = new State[0];


    void Update()
    {
        foreach(State s in currentStates)
        {
            if (s != null)
            {
                s.updateState(Time.deltaTime);
            }
        }
    }

    public void changeState(State newState)
    {
        currentStates[0].endState();
        currentStates[0] = newState;
        currentStates[0].startState();
    }


}
