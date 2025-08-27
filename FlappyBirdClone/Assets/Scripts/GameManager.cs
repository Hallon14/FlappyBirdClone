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
        
    }
    public void Play()
    {
        
    }
    public void pause()
    {
        
    }

    public void IncreaseScore()
    {
        score++;
        scoreText = score.ToString();
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
    }

}
