using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    public TextMeshProUGUI moneyAmount;

    private void Awake()
    {
        PlayerPrefs.SetInt("Level" + 1.ToString(), 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level" + (i + 1).ToString(), 0) == 0)
                levelButtons[i].interactable = false;
            else
                levelButtons[i].interactable = true;
        }

        moneyAmount.text = PlayerPrefs.GetInt("Money", 0).ToString();
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    private void Update() // Reset level buttons interactable and player's money when press R
    {
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.B))
        {
            for (int i = 0; i < levelButtons.Length; i++)
                PlayerPrefs.SetInt("Level" + (i + 1).ToString(), 0);

            PlayerPrefs.SetInt("Money", 0);

            //
            PlayerPrefs.SetString("ShieldGuy", "q");
            PlayerPrefs.SetString("SpeedGuy", "q");
            PlayerPrefs.SetString("PowerfulGuy", "q");
            PlayerPrefs.SetString("MechGuy", "q");
            //
        }

        //if (Input.GetKeyDown(KeyCode.M))
        //    PlayerPrefs.SetInt("Money", 1000);
    }
}
