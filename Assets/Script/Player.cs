using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Player : MonoBehaviour
{

    public float speed;

   

    public float health = 3.0f;
    public GameManager myManager;
    const char DELIMITER = '|';


    string content;

    //the name of our file
    //we're making it a const because it's a variable that really never needs to change
    //you must include the file ending
    const string FILE_NAME = "Save.txt";



    // Start is called before the first frame update
    void Start()
    {
        


        StreamWriter writer = new StreamWriter(FILE_NAME, false); //open the file
        
        writer.Write("playerName" + DELIMITER + myManager.playerScore + DELIMITER + "\n"); //write the player's name and score, which will look like: karina popp | 1000

        writer.Close(); //close the file

        StreamReader reader = new StreamReader(FILE_NAME); //open the file
        content = reader.ReadToEnd(); //read the file

        char[] delimiterChars = { '|' }; //add delimiters
        //the split funciton asks for an array of chars, even through right now we only need one
        string[] scoreSplit = content.Split(delimiterChars); //split the line based on our delimiter

        List<int> allScores = new List<int>();
        for (int i = 0; i < scoreSplit.Length; i++)
        {
            //Debug.Log(scoreSplit[i]);
            if (i % 2 != 0)
            {
                allScores.Add(int.Parse(scoreSplit[i]));
            }
        }

        allScores.Sort();

        int highestScore = allScores[allScores.Count - 1];

        Debug.Log("the highest score is " + highestScore);

        for (int i = allScores.Count - 1; i >= 0; i--)
        {
            //this for loop goes through the sorted list of scores
            //from top to bottom
            //we can use the scores to make a high score board
        }

        int highScore = int.Parse(scoreSplit[1]); //turn the score (which is a string) into an int
        int allHighScores = 100 + highScore; //b/c it's now an int, we can use it as a number

        //Debug.Log(allHighScores);

        //Debug.Log("name: " + scoreSplit[0]);
        //Debug.Log("score: " + scoreSplit[1]);

        //Debug.Log(content);
        reader.Close(); //close the file


    }

    // Update is called once per frame
    void Update()
    {


        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.W))//WASD CONTROLLER
        {
            newPos.y += speed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, 0);


        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= speed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, -90);

        }
        transform.position = newPos;//transform position value to the newPos value

        if (health <= 0)
        {
            Debug.Log("You're dead");

            SceneManager.LoadScene("Menu"); //load the new scene

        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") //when we hit an enemy
        {
            Debug.Log("collide");
            health -= 1f; //decrease our health
            
        }


    }

}
