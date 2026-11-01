using Unity.VisualScripting;
using UnityEngine;

public enum powerUpType
{
    ScoreBonus,
    ExtraLife,
    WidePaddle
}

public class PowerUp : MonoBehaviour
{

    private GameManager gameManager;
    [SerializeField]
    private powerUpType powerUpType;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger Hit: " + collision.gameObject.name);

        if (collision.CompareTag("Paddle"))
        {
            Debug.Log("PowerUp Collected");
            switch (powerUpType)
            {
                case powerUpType.ScoreBonus:
                    gameManager.addBonusScore(100);
                    break;

                case powerUpType.ExtraLife:
                    gameManager.addLife();
                    break;

                case powerUpType.WidePaddle:
                    gameManager.widePaddle();
                    break;
            }

            Destroy(gameObject);
        }
    }



}
