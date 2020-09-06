using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMachine : MonoBehaviour
{

    private State currentState;
    State eating, playing, sleeping;
    Symbol getHungry, getsDark, getsBall;
    MonoBehaviour currentBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        getHungry = new Symbol("Get Hungry");
        getsDark = new Symbol("Gets Dark");
        getsBall = new Symbol("Gets Ball");

        eating = new State("EATING");
        playing = new State("PLAYING");
        sleeping = new State("SLEEPING");

        eating.AddTransition(getHungry, eating);
        eating.AddTransition(getsDark, sleeping);
        eating.AddTransition(getsBall, playing);

        playing.AddTransition(getHungry, playing);
        playing.AddTransition(getsDark, sleeping);
        playing.AddTransition(getsBall, playing);

        sleeping.AddTransition(getHungry, sleeping);
        sleeping.AddTransition(getsDark, eating);
        sleeping.AddTransition(getsBall, eating);

        currentState = playing;

        currentBehaviour = gameObject.AddComponent<EatingBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
