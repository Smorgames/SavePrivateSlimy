using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroShop : MonoBehaviour
{
    public int cost;
    public Button choseButton;
    public string heroName;

    public TextMeshProUGUI moneyAmount;

    private void Awake()
    {
        if (PlayerPrefs.GetString(heroName) == "Bought")
        {
            gameObject.SetActive(false);
            choseButton.interactable = true;
        }
        else
        {
            gameObject.SetActive(true);
            choseButton.interactable = false;
        }

    }

    public void BuyHero()
    {
        if (PlayerPrefs.GetInt("Money") >= cost)
        {
            AudioManager.instance.Play("BuyHero");
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - cost);
            moneyAmount.text = PlayerPrefs.GetInt("Money", 0).ToString();
            choseButton.interactable = true;
            PlayerPrefs.SetString(heroName, "Bought");
            gameObject.SetActive(false);
        }
    }

    public void PickTheHero(int heroNumber)
    {
        PlayerPrefs.SetInt("HeroNumber", heroNumber);
    }
}
