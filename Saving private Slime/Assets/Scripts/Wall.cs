using UnityEngine;

public class Wall : MonoBehaviour
{
    public int health;

    public GameObject ruinsPrefab;
    public GameObject dustEffect;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        // logic for block to player don't stack in it
        if (gameObject.tag == "Block")
            GetComponent<Collider2D>().isTrigger = true;
    }

    public void DamageWall(int damage)
    {
        health -= damage;

        animator.SetTrigger(health.ToString());

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GameObject dust = (GameObject)Instantiate(dustEffect, transform.position, Quaternion.identity);
        Destroy(dust, 7f);

        if (ruinsPrefab != null)
        {
            GameObject ruins = (GameObject)Instantiate(ruinsPrefab, transform.position, Quaternion.identity);
            Destroy(ruins, 10f);
        }

        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Block" && collision.gameObject.tag == "Player")
            GetComponent<Collider2D>().isTrigger = false;
    }
}
