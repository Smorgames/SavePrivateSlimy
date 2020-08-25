using System.Collections;
using UnityEngine;

public class LevelWaves : MonoBehaviour
{
    public IEnumerator Level(string levelNumber)
    {
        if (levelNumber == "Level1")
        {
            GameController.instance.canSpawn = false;
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy(); // 6 enemies
        }

        if (levelNumber == "Level2")
        {
            GameController.instance.canSpawn = false;
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            GameController.instance.SpawnEnemy(); // 6 enemies
        }

        if (levelNumber == "Level3")
        {
            GameController.instance.canSpawn = false;
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            GameController.instance.SpawnEnemy(); // 6 enemies
        }

        if (levelNumber == "Level4")
        {
            GameController.instance.canSpawn = false;
            GameController.instance.SpawnEnemy();
            GameController.instance.SpawnEnemy();
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            GameController.instance.SpawnEnemy();
            yield return new WaitForSeconds(10f);
            GameController.instance.SpawnEnemy();
            GameController.instance.SpawnEnemy(); // 9 enemies
        }

        if (levelNumber == "Level5")
        {
            GameController.instance.canSpawn = false;
            while(true)
            {
                PickRandomEdgeToSpawnEnemy();
                GameController.instance.SpawnEnemy();
                yield return new WaitForSeconds(5f);
            }
        }
    }

    private void PickRandomEdgeToSpawnEnemy()
    {
        int number = Random.Range(1, 5);

        if (number == 1)
        {
            GameController.instance.spawnCoordinates[0] = 42f;
            GameController.instance.spawnCoordinates[1] = 42f;
            GameController.instance.spawnCoordinates[2] = 12.5f;
            GameController.instance.spawnCoordinates[3] = -12.5f;
        }

        if (number == 2)
        {
            GameController.instance.spawnCoordinates[0] = -42f;
            GameController.instance.spawnCoordinates[1] = -42f;
            GameController.instance.spawnCoordinates[2] = 12.5f;
            GameController.instance.spawnCoordinates[3] = -12.5f;
        }

        if (number == 3)
        {
            GameController.instance.spawnCoordinates[0] = -27f;
            GameController.instance.spawnCoordinates[1] = 27f;
            GameController.instance.spawnCoordinates[2] = 27.5f;
            GameController.instance.spawnCoordinates[3] = 27.5f;
        }

        if (number == 4)
        {
            GameController.instance.spawnCoordinates[0] = -27f;
            GameController.instance.spawnCoordinates[1] = 27f;
            GameController.instance.spawnCoordinates[2] = -27.5f;
            GameController.instance.spawnCoordinates[3] = -27.5f;
        }
    }
}
