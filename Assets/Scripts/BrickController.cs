using NUnit.Framework;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    [SerializeField]
    private Sprite[] damageBricks;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject[] powerUps;
    private float dropChance = 0.1f;
    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
       
        currentHealth--;

        gameManager.scoreUpdate();
        //Debug.Log("Brick Hit");
        if (currentHealth <= 0)
        {
            checkSpawnPowerUp();
            Destroy(this.gameObject);
            return;
        }

        int index = maxHealth - currentHealth - 1;

        if (index >= 0 && index < damageBricks.Length)
        {
            spriteRenderer.sprite = damageBricks[index];
        }
    }

    private void checkSpawnPowerUp()
    {
        if (powerUps == null || powerUps.Length == 0)
        {
            return;
        }

        if (Random.value < dropChance)
        {
            int index = Random.Range(0, powerUps.Length);

            Instantiate(powerUps[index], transform.position, Quaternion.identity);
        }
        


    }
}
