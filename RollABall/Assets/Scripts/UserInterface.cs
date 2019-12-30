using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private Text countText;
    [SerializeField] private Text winLoseText;
    [SerializeField] private Text extitRetryText;

    private bool isFinished;

    private void Start()
    {
        //this.countText.text = "";
        this.winLoseText.text = "";
        this.extitRetryText.text = "";
        this.isFinished = false;
    }

    private void Update()
    {
        if (this.isFinished)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {                
                this.ExitGame();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {               
                this.RetryGame();
            }
        }
    }

    private IEnumerator CountTextAnimationCoroutine()
    {
        float waitingTime = 0.3f;
        this.countText.color = Color.red;
        
        yield return new WaitForSeconds(waitingTime);

        this.countText.color = Color.white;

        yield return new WaitForSeconds(waitingTime);

        this.countText.color = Color.red;

        yield return new WaitForSeconds(waitingTime);

        this.countText.color = Color.white;
    }

    public void UpdateItemsAmount(int itemsAmount)
    {
        this.countText.text = "Total count: " + itemsAmount;

        StartCoroutine(this.CountTextAnimationCoroutine());
    }

    public void ShowWinText()
    {
        this.winLoseText.text = "You win!";
    }

    public void ShowLoseText()
    {
        this.winLoseText.text = "You lose!";
    }

    public void ShowGameOptions()
    {
        this.extitRetryText.text = "Press 'space' to retry or 'escape' to exit";
        this.isFinished = true;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
