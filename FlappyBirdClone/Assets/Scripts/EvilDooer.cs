using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject preFab;
    public float spawnRate = 5f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(preFab);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
