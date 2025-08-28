using UnityEngine;

public class Evildooer : MonoBehaviour
{
    public GameObject preFab;
    public float spawnRate = 1;
    public float minHeight = -1.5f;
    public float maxHeight = 1.5f;
    public float difficultyParameter = 0.05f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(preFab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
    void Start()
    {
        InvokeRepeating(nameof(increaseDifficulty), 1, 1);
    }

    void increaseDifficulty()
    {
        while (maxHeight <= 2.5)
        {
            maxHeight = maxHeight + (difficultyParameter);
            minHeight = minHeight - (difficultyParameter);
        }

    }
}
