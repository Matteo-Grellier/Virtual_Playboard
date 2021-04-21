using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    RectTransform rectTransform;
    void Start () 
    {
     rectTransform = GetComponent<RectTransform>();
    }

    public void playGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        print("Quit !");
        Application.Quit();
    }

    public void MenueLeft()
    {
        Vector2 aPos = rectTransform.position;
        aPos.x = aPos.x * Time.deltaTime;
        rectTransform.position = aPos;
    }

    public void MenueRight()
    {
        Vector2 aPos = rectTransform.position;
        aPos.x = aPos.x * Time.deltaTime;
        rectTransform.position = aPos;
    }

    public void Settings()
    {
        
    }
}
