using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static float score;//public variable that is static  and is accesible to all scripts
    public const float bulletSpeed = 1100;//variable that cannot be changed





    //The singleton pattern
    //here we set a variable of the type W2GameManager (our GM class) and call it instance
    private static GameManager instance;

 
    public static GameManager FindInstance()
    {
        return instance;
    }


    private void Awake()
    {

        if (instance != null && instance != this)//Make sure we choose a king game manager
        {
            Destroy(this);
        }
        else //if we do not have a king game manager,this will be the one
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //when we press keyboard Escape
        {
            SceneManager.LoadScene("Menu"); //load the new scene
        }
    }
}
