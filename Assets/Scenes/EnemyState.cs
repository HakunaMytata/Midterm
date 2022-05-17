using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{

    

    public float timer;
    W5GameManager myManager;
    



    //an enum is a special class that lets us define constants
    //as if they were a new data type
    //here, we've created a thing called a "State"
    //which can be one of three things
    public enum State
    {
        FaceUp,
        FaceDown,
        CleanUp
    }

    State currentState; //keeps track of the state we're on

    // Start is called before the first frame update
    void Start()
    {
        myManager = W5GameManager.FindInstance(); //get the game manager
        TransitionState(State.FaceDown); //set to face down
        
        

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(myManager.currentState);
        if (myManager.currentState == W5GameManager.State.Select) //if we're in the select state
        {
            Countdown();
            
            

            if (timer > 5)
            {
                timer = 0;

                TransitionState(State.FaceDown);

            }
            if (currentState == State.FaceDown) //if the card is face down
            {
                Countdown();
                if (timer > 5)
                {
                    timer = 0;
                    TransitionState(State.FaceDown);
                    TransitionState(State.FaceUp); //move to the faceup state
                    myManager.TransitionStates(W5GameManager.State.CardChoosen); //move to cardchoosen state                                                                                
                }

            }
            else if (currentState == State.FaceUp) //if the card is face up
            {
                Countdown();
                if (timer > 5)
                {
                    timer = 0;
                    TransitionState(State.CleanUp);
                }
            }
        }
    }

    //void OnMouseDown()
    //{ //when the mouse is clicked

    //}

    void TransitionState(State newState)

    {
        currentState = newState; //set the new state to be the current state
        switch (newState) //check the value of newState
        { //if new state is...
            case State.FaceDown: //face down 

                break;
            case State.FaceUp: //face up

                break;
            default: //if none of these are the state, go here
                Debug.Log("no transition for this state");
                break;
        }
    }

    void Countdown(){
        timer += Time.deltaTime;

    }

}
