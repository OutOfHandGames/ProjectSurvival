using UnityEngine;
using System.Collections;

public abstract class State {

    public abstract void updateState(float deltaTime);
    public abstract void startState();
    public abstract void endState();

}
