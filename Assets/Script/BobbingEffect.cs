using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    // Parameters for bobbing motion
    public float bobbingHeight = 0.5f; // Maximum height of the bob
    public float bobbingSpeed = 2f;    // Speed of the bobbing motion

    // Original position
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the spotlight
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;

        // Apply the new position
        transform.localPosition = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}
