using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidBody;

    private Vector2 movement;

    public int maxHP = 3;
    private int HP;

    public bool isDamaged = true;

    private Animator animator;

    public GameObject dustPrefab;
    public Transform dustSpawnPoint;

    public GameObject playersBody;
    public Sprite[] bodyStates;
    private SpriteRenderer playersBodySpriteRenderer;

    public int flipOffset;

    public GameObject reloadBar;

    public string playerHitSound;
    public string playerComment;
    private float commentTimer;

    private void Start()
    {
        commentTimer = Random.Range(0f, 20f);
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playersBodySpriteRenderer = playersBody.GetComponent<SpriteRenderer>();
        HP = maxHP;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.magnitude);
        Flip();

        commentTimer += Time.deltaTime;
        if (commentTimer > 25f)
        {
            AudioManager.instance.Play(playerComment);
            commentTimer = 0;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
    }

    public void DamagePlayer(int damage)
    {
        if (isDamaged)
        {
            HP -= damage;
            AudioManager.instance.Play(playerHitSound);
        }

        isDamaged = true;

        ChangeBodyState();

        if (HP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        enabled = false;
        GameController.instance.Lose();
    }

    private void Flip()
    {
        if (movement.x > 0)
            transform.localScale = new Vector3(flipOffset * 1, 1, 1);
        if (movement.x < 0)
            transform.localScale = new Vector3(-flipOffset * 1, 1, 1);

        if (reloadBar && transform.localScale == new Vector3(-1, 1, 1))
            reloadBar.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        if (reloadBar && transform.localScale == new Vector3(1, 1, 1))
            reloadBar.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void SpawnDust()
    {
        GameObject dust = (GameObject)Instantiate(dustPrefab, dustSpawnPoint.position, Quaternion.identity);
        //AudioManager.instance.Play("Step");
        Destroy(dust, 3f);
    }

    private void ChangeBodyState()
    {
        for (int i = 0; i < bodyStates.Length; i++)
        {
            if (HP == i + 1)
                playersBodySpriteRenderer.sprite = bodyStates[i];
        }
    }
}
