using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private float difficulty = 0.05f;
    [SerializeField] private BallController ballController;

    void FixedUpdate()
    {
        float yNeu = Mathf.Lerp(transform.position.y,ball.position.y, difficulty );
        
        if(yNeu >= 3.5f)
        {
            yNeu = 3.5f;
        }
        if(yNeu <= -3.5f)
        {
            yNeu = -3.5f;
        }

        transform.position = new Vector3(transform.position.x, yNeu, 0);
    }

    public void SetNewDifficulty(float value)
    {
        difficulty = value;
    }
}

