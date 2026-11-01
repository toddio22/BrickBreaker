using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        int level = Random.Range(0, 2);
        if (level == 0)
        {
            SceneManager.LoadScene("Level01");
        }
        else
        {
            SceneManager.LoadScene("Level02");
        }
    }

    public void exitGame()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }

}
