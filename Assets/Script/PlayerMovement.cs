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

        //move y Axis
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //body.AddForce(Vector2.up * speed, ForceMode2D.Impulse); //jump in 2D
            body.linearVelocityY += jumpSpeed; // Add vertical velocity for jumping effect
        }



        Vector3 movement = new Vector3(InputX, 0f, InputY); //movement in 3D

        
        Vector2 direction = movement.normalized;

        if (direction != Vector2.zero)
        {
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float angle2 = InputX > 0 ? 0 : 180; // Adjust angle for 2D movement
            transform.rotation = Quaternion.Euler(0f, angle2, 0f);
        }
    }
}
