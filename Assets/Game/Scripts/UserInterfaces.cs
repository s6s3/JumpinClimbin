using UnityEngine;
using System.Collections;

public class UserInterfaces : MonoBehaviour {
    public UnityEngine.UI.Text titleLabel;
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Text highScoreLabel;
    public UnityEngine.UI.Text gameOverLabel;
    [SerializeField]
    private ScoreManager scoreManager;
    
	void Update () {
        scoreLabel.text = scoreManager.GetScore().ToString();
        highScoreLabel.text = "High Score: " + scoreManager.GetHighScore();
	}

    public void visibleTitleLabel(bool val)
    {
        titleLabel.gameObject.SetActive(val);
    }

    public void visibleScoreLabel(bool val)
    {
        scoreLabel.gameObject.SetActive(val);
    }

    public void visibleGameOverLabel(bool val)
    {
        gameOverLabel.gameObject.SetActive(val);
    }
}
