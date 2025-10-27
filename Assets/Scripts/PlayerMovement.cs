using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public bool canMove;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        
        float speedFactor = speed * Time.deltaTime;
        float x = speedFactor * Input.GetAxis("Horizontal");
        float y = speedFactor * Input.GetAxis("Vertical");
        float z = 0;

        transform.Translate(x, y, z);

        if (x > 0)
            spriteRenderer.flipX = true; 
        else if (x < 0)
            spriteRenderer.flipX = false;  
    }
    
}
