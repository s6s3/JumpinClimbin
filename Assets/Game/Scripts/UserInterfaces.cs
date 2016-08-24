using UnityEngine;
using System.Collections;
using System.IO;

public class UserInterfaces : MonoBehaviour {
    public UnityEngine.UI.Text titleLabel;
    public UnityEngine.UI.Text startLabel;
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Text highScoreLabel;
    public UnityEngine.UI.Text gameOverLabel;
    [SerializeField]
    private ScoreManager scoreManager;
    
	void Update () {
        scoreLabel.text = scoreManager.GetScoreText();
        highScoreLabel.text = "HighScore: " + scoreManager.GetHighScoreText();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Images"));
            Application.CaptureScreenshot("Images/Screenshot" + System.DateTime.Now.ToString("yyMMddHHmmss") + ".png");

        }
    }

    public void ToTitle()
    {
        titleLabel.gameObject.SetActive(true);
        startLabel.gameObject.SetActive(true);
        scoreLabel.gameObject.SetActive(false);
        gameOverLabel.gameObject.SetActive(false);

    }

    public void ToMain()
    {
        titleLabel.gameObject.SetActive(false);
        startLabel.gameObject.SetActive(false);
        scoreLabel.gameObject.SetActive(true);
        gameOverLabel.gameObject.SetActive(false);

    }

    public void ToGameOver()
    {
        titleLabel.gameObject.SetActive(false);
        startLabel.gameObject.SetActive(true);
        scoreLabel.gameObject.SetActive(true);
        gameOverLabel.gameObject.SetActive(true);

    }

}
