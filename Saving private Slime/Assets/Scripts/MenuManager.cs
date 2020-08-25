using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject shopUI;

    public void OpenShop()
    {
        shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
