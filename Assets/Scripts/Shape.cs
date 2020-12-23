﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private string shapeType;
    private float elapsedTime;
    private float rigidbodySleepTime = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.Sleep();
        if (TryGetComponent(out Circle circle))
            shapeType = circle.ShowType();
        if (TryGetComponent(out Square square))
            shapeType = square.ShowType();
        if (TryGetComponent(out Triangle triangle))
            shapeType = triangle.ShowType();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= rigidbodySleepTime)
        {
            rb.WakeUp();
        }

        if (Input.touchCount > 0 && !rb.IsSleeping())
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    public string GetShapeType()
    {
        return shapeType;
    }
}
