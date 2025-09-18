using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player; // Reference to the player object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
