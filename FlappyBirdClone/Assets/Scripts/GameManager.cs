using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Birb birb;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameButton;
    public GameObject overButton;


    private int score;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        pause();

    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameButton.SetActive(false);
        overButton.SetActive(false);

        Time.timeScale = 1f;
        birb.enabled = true;
    }
    public void pause()
    {
        Time.timeScale = 0f;
        birb.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        gameButton.SetActive(true);
        overButton.SetActive(true);
        pause();
        playButton.SetActive(true);
    }

}
