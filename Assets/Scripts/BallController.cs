using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private Transform paddle;
    private Rigidbody2D rb;
    private bool launched = false;
    private Vector2 paddleOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        paddleOffset = (Vector2)transform.position - (Vector2)paddle.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched && Input.GetKeyDown(KeyCode.Space))
        {
            launch();
        }
    }

    private void FixedUpdate()
    {
        if(!launched)
        {
            
            rb.position = (Vector2)paddle.position + paddleOffset;
            
        }
        else if (rb.linearVelocity.sqrMagnitude > 0.001f)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }


    private void launch()
    {
        launched = true;

        Vector2 direction = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;

        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            bounceOffPaddle(collision);
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.SendMessage("takeDamage", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void bounceOffPaddle(Collision2D collision)
    {
        float halfWidth = collision.collider.bounds.extents.x;

        float hitOffset = (rb.position.x - collision.transform.position.x) / halfWidth;

        hitOffset = Mathf.Clamp(hitOffset, -1f, 1f);

        float angle = hitOffset * 60f;
        float radians = angle * Mathf.Deg2Rad;

        Vector2 direction = new Vector2 (Mathf.Sin(radians), Mathf.Cos(radians)).normalized;

        rb.linearVelocity = direction * speed;
    }

    public void resetBall()
    {
        Debug.Log("Reset Ball");
        Debug.Log(paddle.position.x);
        launched = false;
    }

}
