
using UnityEngine;
using System.Collections;

public class SelectWaypointState : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBehavior enemyBehavior = animator.gameObject.GetComponent<EnemyBehavior>();
        enemyBehavior.SetNextPoint();

    }

}