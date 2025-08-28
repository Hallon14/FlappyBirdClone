using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Birb birb;
    public Pipes preFab;
    private SpriteRenderer upperPipe;
    private SpriteRenderer lowerPipe;


    public Text scoreText;
    private bool isPlaying = false;

    public GameObject playButton;
    public GameObject gameButton;
    public GameObject overButton;
    public GameObject normalButton;
    public GameObject chinaButton;
    private Pipes[] pipes;

    //Sprites Below
    private SpriteRenderer birbSpriteRenderer;
    public Sprite[] activeSprites;

    public Sprite birbChina;
    public Sprite pipeChina;
    public Sprite[] chinaSprites;

    public Sprite birbNormal;
    public Sprite pipeNormal;
    public Sprite[] normalSprites;
    private int spriteIndex;

    private int score;

    void Start()
    {
        upperPipe = preFab.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        lowerPipe = preFab.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        upperPipe.sprite = pipeNormal;
        lowerPipe.sprite = pipeNormal;
        activeSprites = normalSprites;

        birbSpriteRenderer = birb.spriteRenderer;
        InvokeRepeating(nameof(AnimateSprite), .15f, .15f);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isPlaying == false)
        {
            Play();
            birb.jump();
        }
    } 



    public void Awake()
    {
        Application.targetFrameRate = 60;
        pause();

    }
    public void Play()
    {
        isPlaying = true;
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameButton.SetActive(false);
        overButton.SetActive(false);
        normalButton.SetActive(false);
        chinaButton.SetActive(false);

        Time.timeScale = 1f;
        birb.enabled = true;
        birb.transform.rotation = Quaternion.Euler(0, 0, 0);
        birb.transform.position = new Vector3(0, 0, 0);

        //Fråga anton varför detta fungerar.
        pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None);
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject); // Important: destroy the GameObject, not just the component
        }
        

    }
    public void pause()
    {
        Time.timeScale = 0f;
        birb.enabled = false;
        isPlaying = false;
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
        normalButton.SetActive(true);
        chinaButton.SetActive(true);

    }
    
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= activeSprites.Length)
        {
            spriteIndex = 0;
        }
        birb.spriteRenderer.sprite = activeSprites[spriteIndex];
    }


    public void normalBirb()
    {
        //Debug.Log("Default Mode");
        activeSprites = normalSprites;
        birb.spriteRenderer.sprite = birbNormal;
        upperPipe.sprite = pipeNormal;
        lowerPipe.sprite = pipeNormal;

    }
    public void chinaBirb()
    {
        //Debug.Log("China Mode");
        activeSprites = chinaSprites;
        upperPipe.sprite = pipeChina;
        lowerPipe.sprite = pipeChina;
        birb.spriteRenderer.sprite = birbChina;
    }
}
