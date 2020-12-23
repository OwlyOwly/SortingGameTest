using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesBin : MonoBehaviour
{
    [SerializeField] private string binType;
    [SerializeField] GameObject spawnerObject;
    [SerializeField] GameObject particleEffect;
    private Shape collidedShape;
    private ShapeSpawner spawner;

    private void Start()
    {
        spawner = spawnerObject.GetComponent<ShapeSpawner>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collidedShape = collision.gameObject.GetComponent<Shape>();
        if (collidedShape.GetShapeType() == binType)
        {
            Destroy(collision.gameObject);
            Instantiate(particleEffect, gameObject.transform);
            spawner.SpawnShape();
        }
    }
}
