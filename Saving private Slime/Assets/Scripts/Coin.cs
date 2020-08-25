using UnityEngine;

public class Coin : MonoBehaviour
{
    public float firstSpawnY, secondSpawnY;
    public float speed;

    private float spawnYcoordinate;

    private CircleCollider2D circleCollider;

    private Animator animator;

    private void Start()
    {
        spawnYcoordinate = Random.Range(firstSpawnY, secondSpawnY);
        circleCollider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, spawnYcoordinate), speed * Time.fixedDeltaTime);

        if (transform.position.y == spawnYcoordinate)
        {
            circleCollider.enabled = true;
            animator.SetTrigger("NewIdle");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.Play("PickCoin");
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1); // plus one coin to money
            Destroy(gameObject);
        }
    }
}
