using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public GameObject ground;
    public float spawnRate = 1;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(ground, transform.position, transform.rotation);
            timer = 0;
        }
    }
}