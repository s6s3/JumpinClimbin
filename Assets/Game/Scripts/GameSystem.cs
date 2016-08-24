using UnityEngine;
using System.Collections;
using System;

public class GameSystem : MonoBehaviour {
    public PlayerManager playerManager;
    public JumpersManager jumpersManager;
    public ScoreManager scoreManager;
    public CheckGameOver checkGameOver;

    public UserInterfaces userInterfaces;
    public SoundEffects soundEffects;
    
    private GameState gameState;
    
    public enum GameState
    {
        TITLE,
        MAIN,
        GAMEOVER
    }

    void Start()
    {
        jumpersManager.SetManager(playerManager,scoreManager);
        checkGameOver.initCheckPlayer(this);
        checkGameOver.checkGameOver = false;
        checkGameOver.toGameOver = ToGameOver;
        soundEffects.init(this);
        gameState = GameState.TITLE;
        
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.TITLE:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ToMain();
                }
                
                break;
            case GameState.MAIN:
                jumpersManager.UpdateMain();

                break;
            case GameState.GAMEOVER:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ToTitle();
                }

                break;
        }
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void ToTitle()
    {
        playerManager.ToTitle();
        jumpersManager.ToTitle();
        userInterfaces.visibleTitleLabel(true);
        userInterfaces.visibleScoreLabel(false);
        userInterfaces.visibleGameOverLabel(false);
        soundEffects.OnSelect();

        gameState = GameState.TITLE;
    }
    
    public void ToMain()
    {
        
        playerManager.ToMain();
        jumpersManager.ToMain();
        scoreManager.ResetScore();
        checkGameOver.checkGameOver = true;
        userInterfaces.visibleTitleLabel(false);
        userInterfaces.visibleScoreLabel(true);
        userInterfaces.visibleGameOverLabel(false);
        soundEffects.OnSelect();
        soundEffects.PlayBGM();

        gameState = GameState.MAIN;

    }

    public void ToGameOver()
    {
        playerManager.ToGameOver();
        userInterfaces.visibleTitleLabel(false);
        userInterfaces.visibleScoreLabel(true);
        userInterfaces.visibleGameOverLabel(true);
        soundEffects.StopBGM();
        
        gameState = GameState.GAMEOVER;

    }


}
