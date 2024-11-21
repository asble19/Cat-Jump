using UnityEngine;

public class GraveSpawnScript : MonoBehaviour
{
    public GameObject grave1;
    public GameObject grave2;
    public GameObject grave3;
    public GameObject zombie;

    public float spawnRate = 2;
    public float heightOffset = 1;
    private float timer = 0;

    void Start()
    {
        spawnGrave();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnGrave();
            timer = 0;
        }
    }

    void spawnGrave()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Array of possible GameObjects to spawn
        GameObject[] graves = { grave1, grave2, grave3, zombie };

        // Choose a random GameObject from the array
        GameObject selectedGrave = graves[Random.Range(0, graves.Length)];

        // Instantiate the chosen GameObject
        GameObject spawnedObject = Instantiate(selectedGrave, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        // If the spawned object is a zombie, set its Animator parameter
        if (selectedGrave == zombie)
        {
            Animator zombieAnimator = spawnedObject.GetComponent<Animator>();
            if (zombieAnimator != null)
            {
                zombieAnimator.SetBool("isAlive", true); // Or false, depending on your logic
            }
        }
    }
}
