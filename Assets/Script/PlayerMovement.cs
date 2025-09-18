using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed = 5.0f;

    [SerializeField] private float jumpSpeed = 10.0f;
   


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputY = Input.GetAxisRaw("Vertical");


        //move x Axis
        body.linearVelocity = new Vector2(InputX * speed, body.linearVelocityY); //movement in 2D


        //Jump mechanic
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            body.linearVelocityY += jumpSpeed; // Add vertical velocity for jumping effect
        }

        //Flip player based on movement direction
        if (InputX != 0)
        {
            float angle = InputX > 0 ? 0 : 180; // Adjust angle for 2D movement
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        
    }
}
