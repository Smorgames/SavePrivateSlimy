using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Menu");
    }
}
