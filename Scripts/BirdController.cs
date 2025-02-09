using UnityEngine;

public class BirdController : MonoBehaviour
{

    private Rigidbody2D rigidBody2d;
    public float flapForce = 10f;

    private bool hitThePipe;
    private bool canFly;
    private float deadZone = 6f;
    private AudioSource audioSource;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!canFly) return;

        if (Input.GetKeyDown(KeyCode.Space) && !hitThePipe)
        {
            rigidBody2d.linearVelocity = transform.up * flapForce;

            audioSource.Play();
        }

        if (transform.position.y > deadZone || transform.position.y < -deadZone)
        {
            StopFly();
        }
    }

    private void StopFly()
    {
        hitThePipe = true;

        GameObject.FindWithTag("Logic Manager").GetComponent<LogicManager>().EndGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopFly();
    }

    public void StartFly()
    {
        canFly = true;

        float normalGravityScale = 3.5f;
        rigidBody2d.gravityScale = normalGravityScale;
    }
}
