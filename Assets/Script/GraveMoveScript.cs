using UnityEngine;

public class GraveMoveScript : MonoBehaviour
{
    public float moveSpeed = 25;
    public float deadZone = -80;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Grave deleted");
            Destroy(gameObject);
        }
    }
}