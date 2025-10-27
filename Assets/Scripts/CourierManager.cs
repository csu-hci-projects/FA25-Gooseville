using UnityEngine;

public class CourierManager : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    private Vector2 targetPos;
    private bool moving = false;

    public void MoveTo(Vector2 position)
    {
        targetPos = position;
        moving = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) return;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            moving = false;
        }
    }
}
