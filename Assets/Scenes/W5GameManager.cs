using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W5GameManager : MonoBehaviour
{
    //singleton setup
    private static W5GameManager instance;
    

    public static W5GameManager FindInstance() {
        return instance;
    }

    public int cardCount; //number of cards in our deck

    

    //all potential game states
    public enum State {
        CreateCards,
        Select,
        CardChoosen,
        Resolve
    }

    public State currentState; //tracks the state the game is on now

    void Awake() {
        //singleton 
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null) {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TransitionStates(State.CreateCards); //start by creating cards
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionStates(State newState)
    {

        currentState = newState;
        switch (newState) //check the newState
        { //if the newState is...
            case State.CreateCards:  

                TransitionStates(State.Select); //go to the selection state
                break;
            case State.Select:
                break;
            case State.CardChoosen:
                break;
            case State.Resolve:
                break;
            default:
                Debug.Log("this state doesn't exist");
                break;
        }
    }
}
