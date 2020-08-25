using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    private bool upArrowWasPressed;
    private bool downArrowWasPressed;
    private bool leftArrowWasPressed;
    private bool rightArrowWasPressed;
    private bool spaceWasPressed;

    public Image upButton;
    public Image downButton;
    public Image leftButton;
    public Image rightButton;
    public Image space;

    public GameObject trainingManager;
    public GameObject instructionPanel;

    [HideInInspector]
    public bool canSkipTraining;
    public GameObject fader;

    private void Start()
    {
        canSkipTraining = true;

        bool[] variablesArray = new bool[5] { upArrowWasPressed, downArrowWasPressed, leftArrowWasPressed, rightArrowWasPressed, spaceWasPressed };

        for (int i = 0; i < variablesArray.Length; i++)
            variablesArray[i] = false;
    }

    private void Update()
    {
        if (trainingManager.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !leftArrowWasPressed)
            {
                leftArrowWasPressed = true;
                leftButton.GetComponent<Animator>().SetTrigger("OK");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && !rightArrowWasPressed)
            {
                rightArrowWasPressed = true;
                rightButton.GetComponent<Animator>().SetTrigger("OK");
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && !upArrowWasPressed)
            {
                upArrowWasPressed = true;
                upButton.GetComponent<Animator>().SetTrigger("OK");
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && !downArrowWasPressed)
            {
                downArrowWasPressed = true;
                downButton.GetComponent<Animator>().SetTrigger("OK");
            }

            if (Input.GetKeyDown(KeyCode.Space) && !spaceWasPressed)
            {
                spaceWasPressed = true;
                space.GetComponent<Animator>().SetTrigger("OK");
            }

            if (isAllVariablesTrue())
            {
                StartCoroutine(StartGame());
            }
        }

        if (canSkipTraining && Input.GetKeyDown(KeyCode.Escape))
            fader.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.transform.position = Vector3.zero;
    }

    private bool isAllVariablesTrue()
    {
        bool[] variablesArray = new bool[5] { upArrowWasPressed, downArrowWasPressed, leftArrowWasPressed, rightArrowWasPressed, spaceWasPressed };
        int trueSumm = 0;

        for (int i = 0; i < variablesArray.Length; i++)
            if (variablesArray[i] == true)
                trueSumm++;

        if (trueSumm == variablesArray.Length)
            return true;
        else
            return false;
    }


    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);

        trainingManager.SetActive(false);
        instructionPanel.SetActive(true);
        canSkipTraining = false;
    }
}
