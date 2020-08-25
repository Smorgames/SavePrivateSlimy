using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;
    //private Animator pauseUIAnimator;

    //private void Start()
    //{
    //    pauseUIAnimator = pauseUI.GetComponent<Animator>();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf)
            {
                ToPause();
                GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
            }
            else
            {
                ToUnpause();
                GameObject.FindWithTag("Player").GetComponent<Player>().enabled = true;
            }
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ToPause()
    {
        Time.timeScale = 0f;
    }

    private void ToUnpause()
    {
        Time.timeScale = 1f;
    }
}