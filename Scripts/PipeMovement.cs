using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private float deadZone = -12f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = transform.position - new Vector3(moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindWithTag("Logic Manager").GetComponent<LogicManager>().AddScore(1);

        audioSource.Play();
    }
}
