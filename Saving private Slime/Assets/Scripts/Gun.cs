using UnityEngine;

public class Gun : MonoBehaviour
{
    public float angleOffset;

    private GameObject player;
    private Rigidbody2D rigidBody;

    public float shootRate;
    private float nextShoot = 0;

    public GameObject bulletPrefab;

    public Transform shootPoint;
    public Transform directionPoint;

    public GameObject enemy;
    private Animator enemyAnimator;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        enemyAnimator = enemy.GetComponent<Animator>();
        shootRate = Random.Range(2, 3.5f);
        if (GameController.instance.pickedHero == GameController.instance.heroes[0])
            angleOffset = 0.52f;
    }

    private void Update()
    {
        Vector2 lookDirection = new Vector2(player.transform.position.x, player.transform.position.y) - rigidBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + angleOffset;
        rigidBody.rotation = angle;

        if (Time.time > nextShoot && enemyAnimator.GetBool("IsWalking") == false)
        {
            Shoot();
            nextShoot = Time.time + shootRate;
        }
    }

    private void Shoot()
    {
        AudioManager.instance.Play("Shoot");

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        float bulletSpeed = bullet.GetComponent<Bullet>().speed;
        bulletRigidBody.AddForce((directionPoint.position - shootPoint.position).normalized * bulletSpeed);
        Destroy(bullet, 4f);
    }
}
