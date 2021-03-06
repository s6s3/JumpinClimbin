﻿using UnityEngine;
using System.Collections;
using System;

public class CheckGameOver : MonoBehaviour {
    public float deadLine = 3;
    public float distanceToGameOver = 50;

    public Action toGameOver = () => { };

    public bool checkGameOver = false;

    private GameSystem gameSystem;

    public void initCheckPlayer(GameSystem gs)
    {
        gameSystem = gs;
    }
    
	void Update () {
        if (checkGameOver)
        {
            if (gameSystem.scoreManager.GetScore() - gameSystem.playerManager.transform.position.y 
                    > distanceToGameOver 
                || gameSystem.playerManager.transform.position.y < deadLine)
            {
                toGameOver();
                checkGameOver = false;
            }
        }
	
	}
}
