using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    [SerializeField]
    private GameObject player;

    private float score = 0;
    private float highScore = 0;

	void Start () {
        ResetScore();
        highScore = 0;
    }
	
	void Update () {
        float tmp = player.transform.position.y;
        if (tmp > score) score = tmp;
        if (score > highScore) highScore = score;
	
	}

    public float GetScore()
    {
        return score;
    }

    public float GetHighScore()
    {
        return highScore;
    }

    public string GetScoreText()
    {
        return score.ToString("0.0") + "m";
    }

    public string GetHighScoreText()
    {
        return highScore.ToString("0.0") + "m";
    }

    public void ResetScore()
    {
        score = 0;
    }
}
