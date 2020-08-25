using UnityEngine;

public class WalkToStartPosition : StateMachineBehaviour
{
    public float speed;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(-27f, animator.transform.position.y), speed * Time.deltaTime);

        if (animator.transform.position.x >= -27f)
            animator.SetBool("IsWalking", false);
    }
}
