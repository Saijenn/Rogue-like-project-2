using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    [SerializeField]  private LayerMask groundLayer;
    [SerializeField] private float speed = 5.0f;

    [SerializeField] private float jumpSpeed = 10.0f;

    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputY = Input.GetAxisRaw("Vertical");


        //move x Axis
        body.linearVelocity = new Vector2(InputX * speed, body.linearVelocityY); //movement in 2D


        //Jump mechanic
        if (Input.GetKeyDown(KeyCode.Space) && grounded())
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        
    }

    //check if grounded
    private bool grounded()
    {
        //check a little bit under the player if there is ground with raycast
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,  // origin (where the box starts from)
            boxCollider.bounds.size,    // size of the box
            0f,                         // angle of the box (rotation in degrees)
            Vector2.down,               // direction to cast (here = downward)
            0.1f,                       // distance to cast
            groundLayer                 // which layers to detect
            );

        
        return raycastHit.collider != null; //check if we hit something with the raycast (floating in air scan nothing so it's null)
        
    }
}
