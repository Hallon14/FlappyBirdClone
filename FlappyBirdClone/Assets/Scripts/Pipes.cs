using System.Linq;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;
    public Evildooer spawner;

    void Start()
    {
        spawner = FindAnyObjectByType<Evildooer>();
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        
    }
    void LateUpdate()
    {
       transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
            spawner.activePipes.Remove(gameObject);
        } 
    }
}
