using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{

    private int lives = 3;
    [SerializeField]
    private BallController ball;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private TMP_Text lifeDisplay;
    private int score = 0;
    [SerializeField]
    private TMP_Text scoreDisplay;
    [SerializeField]
    private TMP_Text finalScore;
    [SerializeField]
    private Transform paddle;
    
    private Vector3 originalPaddleScale;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeDisplay.text = "Lives: " + lives;
        originalPaddleScale = paddle.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void lifeLost()
    {
        lives--;
        lifeDisplay.text = "Lives: " + lives;
        //Debug.Log("Lives remaining: " + lives);
        if (lives <= 0)
        {
            //Debug.Log("Game Over");
            finalScore.text = "Final Score: " + score;
            gameOver.SetActive(true);
        }
        else
        {
            ball.resetBall();
        }
    }

    public void addLife()
    {
        lives++;
        lifeDisplay.text = "Lives: " + lives;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void menuReturn()
    {
        Debug.Log("Exiting");
        SceneManager.LoadScene("Menu");
    }

    public void scoreUpdate()
    {
        score = score + 10;
        scoreDisplay.text = "Score: " + score;
    }

    public void addBonusScore (int bonus)
    {
        score += bonus;
        scoreDisplay.text = "Score: " + score;
    }

    public void widePaddle()
    {
        StopCoroutine(nameof(resetPaddleSize));

        paddle.localScale = new Vector3(
            originalPaddleScale.x * 1.5f,
            originalPaddleScale.y,
            originalPaddleScale.z
        );

        StartCoroutine(resetPaddleSize());
    }

    private IEnumerator resetPaddleSize()
    {
        yield return new WaitForSeconds(15f);

        paddle.localScale = originalPaddleScale;
    }

}
