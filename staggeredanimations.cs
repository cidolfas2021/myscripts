using UnityEngine;
using System.Collections;

public class staggeredanimations : MonoBehaviour
{
    public GameObject treadPrefab;
    public int numberOfTreads = 55;
    public float staggerDelay = 0.1f;

    void Start()
    {
        StartCoroutine(SpawnTreads());
    }

    IEnumerator SpawnTreads()
    {
        for (int i = 0; i < numberOfTreads; i++)
        {
            GameObject tread = Instantiate(treadPrefab, transform.position, Quaternion.identity);

            // Add a delay before starting the animation.
            yield return new WaitForSeconds(staggerDelay);

            // Start the animation on the tread.
            Animation animation = tread.GetComponent<Animation>();
            if (animation != null)
            {
                animation.Play(); // Start the animation.
            }
        }
    }
}
