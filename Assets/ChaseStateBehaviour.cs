using UnityEngine;
using System.Collections;

public class ChaseStateBehaviour : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBehavior enemyBehavior = animator.gameObject.GetComponent<EnemyBehavior>();
        enemyBehavior.StartChasing();
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EnemyBehavior enemyBehavior = animator.gameObject.GetComponent<EnemyBehavior>();
        enemyBehavior.StopChasing();
    }

}