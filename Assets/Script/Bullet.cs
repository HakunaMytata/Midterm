using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager myManager;
    
    public GameObject bullet;
    float timer;
    public float waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        myManager = GameManager.FindInstance();//Variables from GameManager
    }

   void Fire()
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;//clone the prefab object
        Rigidbody2D tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody2D>();//Put a rigidbody on the cloned object
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * GameManager.bulletSpeed);//Quote variable from game manager
        Destroy(tempBullet, 2f);

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {

            timer = 0;
            Fire();
        }
    }
}
