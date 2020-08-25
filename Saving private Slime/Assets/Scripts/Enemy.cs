using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public GameObject enemy;

    private Animator enemysAnimator;

    [HideInInspector]
    public string moveDirection;
    [HideInInspector]
    public float stopCoordinate;

    private void Start()
    {
        enemysAnimator = enemy.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveBehaviour();
    }

    private void MoveBehaviour()
    {
        if (moveDirection == "FLTR") // from left to right
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(stopCoordinate, transform.position.y), speed * Time.fixedDeltaTime);

            if (transform.position.x >= stopCoordinate)
                enemysAnimator.SetBool("IsWalking", false);
        }

        if (moveDirection == "FRTL") // from right to left
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(stopCoordinate, transform.position.y), speed * Time.fixedDeltaTime);

            if (transform.position.x <= stopCoordinate)
                enemysAnimator.SetBool("IsWalking", false);
        }

        if (moveDirection == "FTTB") // from top to bottom
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, stopCoordinate), speed * Time.fixedDeltaTime);

            if (transform.position.y <= stopCoordinate)
                enemysAnimator.SetBool("IsWalking", false);
        }

        if (moveDirection == "FBTT") // from bottom to top
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, stopCoordinate), speed * Time.fixedDeltaTime);

            if (transform.position.y >= stopCoordinate)
                enemysAnimator.SetBool("IsWalking", false);
        }
    }
}
