using UnityEngine;

public class Helmet : MonoBehaviour
{
    public int maxHP;
    private int HP;

    public GameObject bloodEffect;

    private void Start()
    {
        HP = maxHP;
    }

    public void DamageHelmet(int damage)
    {
        HP -= damage;
        AudioManager.instance.Play("HelmetHit");

        if (HP <= 0)
        {
            AudioManager.instance.Play("BreakHelmet");

            if (bloodEffect != null)
                bloodEffect.SetActive(true);

            Destroy(gameObject);
        }
    }
}
