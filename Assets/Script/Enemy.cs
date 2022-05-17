using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Creat two new variables that can be edit in unity
    public float speed = 0.2f;//f for allowing float variables
    public float boarder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Create a vector that contains 3 variables, and let it equals to position transform value 
        Vector3 newPosition = transform.position;
        //the x of the vector3 keeps adding the speed variable to move right
        newPosition.x += speed;


        if (newPosition.x > boarder)//when position > given boarder value
        {
            newPosition.x = -boarder;//move x to the left of the screen position
            newPosition.y = Random.Range(-3f, 5);//random height of the object
        }
        transform.position = newPosition;//transform position as the value in newPosition
    }
}
