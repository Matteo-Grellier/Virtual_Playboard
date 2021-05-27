using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    RectTransform rectTransform;
    // GameObject buttonA = GameObject.Find("chess button");
    public AudioSource audioSource;
    public AudioClip menue;


    void Start () 
    {
        rectTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
        // menue = 
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
        aPos.x += 180;
        rectTransform.position = aPos;
        print("aPos" + aPos);
        // Vector3 pos = buttonA.transform.position;
        // pos.x -= 180;
        // buttonA.transform.position = pos;
        // audioSource.Play();
    }

    public void MenueRight()
    {
        Vector2 aPos = rectTransform.position;
        aPos.x -= 180;
        rectTransform.position = aPos;
        print("aPos" + aPos);

    }

    public void Settings()
    {
        // audioSource.PlayOneShot(menue, 0.7f);
    }
}
