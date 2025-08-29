using System.Collections.Generic;
using UnityEngine;

public class Evildooer : MonoBehaviour
{
    public GameObject preFab;
    public float spawnRate = 1;
    public float minHeight = -1.5f;
    public float maxHeight = 1.5f;
    public float difficultyParameter = 0.05f;
    public List<GameObject> activePipes;

    void Start()
    {
        InvokeRepeating(nameof(increaseDifficulty), 1, 1);
        activePipes = new List<GameObject>();
    }

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
        activePipes.Add(pipes);
    }

    void increaseDifficulty()
    {
        if (maxHeight <= 2.5f)
        {
            maxHeight = maxHeight + (difficultyParameter);
            minHeight = minHeight - (difficultyParameter);
        }

    }
    public void resetDifficulty()
    {
        maxHeight = 1.5f;
        minHeight = 1.5f;
    }
}
