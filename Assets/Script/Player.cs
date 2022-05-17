using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        
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


    }

}
