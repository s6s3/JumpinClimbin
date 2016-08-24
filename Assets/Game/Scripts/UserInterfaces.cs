using UnityEngine;
using System.Collections;
using System.IO;

public class UserInterfaces : MonoBehaviour {
    public UnityEngine.UI.Text titleLabel;
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Text highScoreLabel;
    public UnityEngine.UI.Text gameOverLabel;
    [SerializeField]
    private ScoreManager scoreManager;
    
	void Update () {
        scoreLabel.text = scoreManager.GetScoreText();
        highScoreLabel.text = "High Score: " + scoreManager.GetHighScoreText();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Images"));
            Application.CaptureScreenshot("Images/Screenshot" + System.DateTime.Now.ToString("yyMMddHHmmss") + ".png");

        }
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
