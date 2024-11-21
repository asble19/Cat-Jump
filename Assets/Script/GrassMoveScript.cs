using UnityEngine;

public class GrassMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;        // Speed of the movement in units per second
    public float startX = 0.5f;         // Starting position (X) - can be adjusted in the Inspector
    public float loopX = 13f;           // Looping position (X) - can be adjusted in the Inspector
    public float endX = -13f;           // Ending position (X) - when the tile moves offscreen
    public float tileWidth = 26f;       // Width of one tile (in Unity units) - adjust based on your tile size

    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        // Set the initial start position based on the value from the Inspector
        startPosition = new Vector3(startX, transform.position.y, transform.position.z);
        endPosition = new Vector3(endX, transform.position.y, transform.position.z);

        // Initialize the tile to its starting position
        transform.position = startPosition;
    }

    void Update()
    {
        // Move the tilemap to the left by moveSpeed each frame
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Check if the tile has passed the end position
        if (transform.position.x <= endPosition.x)
        {
            // Reset the tile to the loop position (X = 13)
            transform.position = new Vector3(loopX, transform.position.y, transform.position.z);
        }
    }
}
