using UnityEngine;
using System.Collections;

public class SawThePlayer : MonoBehaviour
{

    public EnemyBehavior enemyBehavior;


    void OnTriggerEnter2D(Collider2D o)
    {

        if (o.gameObject.tag == "Player")
            
        {
            Debug.Log("Find Ya!");

               
            enemyBehavior.inViewCone = true;
        }
    }

    void OnTriggerExit2D(Collider2D o)
    {


        if (o.gameObject.tag == "Player")
        {
            enemyBehavior.inViewCone = false;
            Debug.Log("88");
        }
    }
}