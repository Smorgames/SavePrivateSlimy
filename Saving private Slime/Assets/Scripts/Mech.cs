using UnityEngine;
using UnityEngine.UI;

public class Mech : MonoBehaviour
{
    public GameObject blockPrefab;

    public float blockSpawnRate;
    public float nextSpawn;

    public GameObject reloadBoreder;
    private Slider slider;

    private void Start()
    {
        slider = reloadBoreder.GetComponent<Slider>();
        slider.maxValue = blockSpawnRate;
        slider.value = nextSpawn;
    }

    void Update()
    {
        nextSpawn += Time.deltaTime;
        slider.value = nextSpawn;

        if (nextSpawn > blockSpawnRate && Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.Play("PutDownMechBlock");
            Instantiate(blockPrefab, transform.position, Quaternion.identity);
            nextSpawn = 0f;
        }
    }
}
