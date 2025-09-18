using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player; // Reference to the player object
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, 0f); // Offset from the player position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        //smooth camera movement
        float smoothSpeed = 0.05f; // Adjust this value to change the smoothness of the camera movement
        Vector3 targetPos = new Vector3(
         player.transform.position.x + offset.x,
         player.transform.position.y + offset.y,
         transform.position.z // <- keep camera's current Z
        );
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

        //stiff camera movement
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
