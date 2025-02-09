using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public GameObject pipePrefab;
    public float spawnRate;
    public float heightOffset;

    private float time;
    private bool isActive;

    void Update()
    {
        if (!isActive) return;

        if (time < spawnRate)
        {
            time += Time.deltaTime;

        } else
        {
            time = 0f;
            SpawnPipe();
        }

    }

    private void SpawnPipe()
    {
        float minOffset = -heightOffset;
        float maxOffset = heightOffset;

        Instantiate(pipePrefab, transform.position + new Vector3(0, Random.Range(minOffset, maxOffset), 0), transform.rotation);
    }

    public void StartSpawner()
    {
        isActive = true;
    }

    public void StopSpawner()
    {
        isActive = false;
    }
}
