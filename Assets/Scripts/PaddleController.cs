using UnityEngine;

public class PaddleController : MonoBehaviour
{

    [SerializeField]
    private float leftLimit = -5.8f;
    [SerializeField]
    private float rightLimit = 11f;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float targetX;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        targetX = rb.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera == null)
        {
            return;
        }

        float cameraDistance = Mathf.Abs(transform.position.z - mainCamera.transform.position.z);

        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance));

        float halfWidth = GetComponent<Collider2D>().bounds.extents.x;

        targetX = Mathf.Clamp(mouseWorld.x, leftLimit + halfWidth, rightLimit - halfWidth);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(new Vector2(targetX, rb.position.y));
    }
}
