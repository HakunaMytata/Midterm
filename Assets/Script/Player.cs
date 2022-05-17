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

    float timeCount = 0;
    int intTime = 0;

    string content;


    const string FILE_NAME = "Save.txt";



    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(FILE_NAME);
        content = reader.ReadToEnd();

        char[] delimiterChars = { '|' };

        string[] scoreSplit = content.Split(delimiterChars);

        List<int> allScores = new List<int>();
        for (int i = 0; i < scoreSplit.Length; i++)
        {
            Debug.Log(scoreSplit[i]);
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
            Debug.Log("allScores");

        }

        int highScore = int.Parse(scoreSplit[1]);
        int allHighScores = 100 + highScore;

        Debug.Log(allHighScores);

        Debug.Log("name: " + scoreSplit[0]);
        Debug.Log("score: " + scoreSplit[1]);

        Debug.Log(content);
        reader.Close();





    }

    // Update is called once per frame
    void Update()
    {
        timeCount += 100 * Time.deltaTime;
        intTime = Mathf.RoundToInt(timeCount);

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
        transform.position = newPos;

        if (health <= 0)
        {
            Debug.Log("You're dead");

            Debug.Log(timeCount);



            StreamWriter writer = new StreamWriter(FILE_NAME, true);

            writer.Write("Score:" + DELIMITER + intTime + DELIMITER + "\n");


            writer.Close();


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
