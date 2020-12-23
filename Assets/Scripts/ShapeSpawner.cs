using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] shapes;
    private void Start()
    {
        SpawnShape();
    }

    public void SpawnShape()
    {
        Instantiate(shapes[Random.Range(0, 3)], gameObject.transform);
    }
}
