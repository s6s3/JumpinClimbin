using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    [SerializeField]
    private GameObject player;

    private int score = 0;
    private int highScore = 0;

	void Start () {
        ResetScore();
        highScore = 0;
    }
	
	void Update () {
        int tmp = (int)player.transform.position.y;
        if (tmp > score) score = tmp;
        if (score > highScore) highScore = score;
	
	}

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }


    public void ResetScore()
    {
        score = 0;
    }
}
