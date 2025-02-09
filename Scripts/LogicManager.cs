using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{

    public PipeSpawner pipeSpawner;
    public BirdController birdController;
    public GameObject startScreen, gameOverScreen;
    public Text scoreText;

    private int score;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AddScore(int value)
    {
        score = score + value;

        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        pipeSpawner.StartSpawner();
        birdController.StartFly();

        startScreen.SetActive(false);
    }

    public void EndGame()
    {
        if (birdController == null) return;

        birdController = null;

        pipeSpawner.StopSpawner();

        gameOverScreen.SetActive(true);

        audioSource.Play();

        GameObject.FindWithTag("Music Player").GetComponent<AudioSource>().Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
