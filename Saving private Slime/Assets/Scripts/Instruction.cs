using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour
{
    public float timeToWait;

    public GameObject playButton;

    private void OnEnable()
    {
        StartCoroutine(ActivatePlayButton());
    }

    IEnumerator ActivatePlayButton()
    {
        yield return new WaitForSeconds(timeToWait);
        playButton.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Menu");
    }
}
