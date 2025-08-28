using JetBrains.Annotations;
using UnityEngine;

public class Birb : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5;
    public GameManager gameManager;
    public SpriteRenderer spriteRenderer;

    public float roatationSpeed = 30;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        gameObject.transform.Rotate(0, 0, -roatationSpeed * Time.deltaTime, Space.World);
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            gameManager.IncreaseScore();
        }
    }
    public void jump()
    {
        direction = Vector3.up * strength;
        //gameObject.transform.Rotate(0, 0, 45, Space.World); //Backflipping boy
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
        gameObject.transform.Rotate(0, 0, -roatationSpeed * Time.deltaTime, Space.World);

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
}

