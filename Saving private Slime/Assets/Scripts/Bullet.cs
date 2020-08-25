using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject[] explodePrefabs;

    private Rigidbody2D rigidBody;

    public int damage;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            collision.gameObject.GetComponent<Wall>().DamageWall(damage);
            GameObject explode = (GameObject)Instantiate(explodePrefabs[Random.Range(0, explodePrefabs.Length)], transform.position, Quaternion.identity);
            AudioManager.instance.Play("Explosion");
            Destroy(explode, 1f);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Helmet")
        {
            collision.gameObject.GetComponent<Helmet>().DamageHelmet(damage);
            GameObject explode = (GameObject)Instantiate(explodePrefabs[Random.Range(0, explodePrefabs.Length)], transform.position, Quaternion.identity);
            AudioManager.instance.Play("Explosion");
            Destroy(explode, 1f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explode = (GameObject)Instantiate(explodePrefabs[Random.Range(0, explodePrefabs.Length)], transform.position, Quaternion.identity);
        AudioManager.instance.Play("Explosion");
        Destroy(explode, 1f);

        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<Player>().DamagePlayer(damage);

        if (collision.gameObject.tag == "Wall")
            collision.gameObject.GetComponent<Wall>().DamageWall(damage);

        if (collision.gameObject.tag == "Block")
            collision.gameObject.GetComponent<Wall>().DamageWall(damage);

        Destroy(gameObject);
    }
}
