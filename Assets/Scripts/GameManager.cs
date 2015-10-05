using UnityEngine;
using System.Collections;

public class GameManager : MyBehaviour{

    static public GameManager Instance { get; private set; }

    // This method is called when the script is loaded
    protected void Awake()
    {
        // Check for other instance
        if (Instance == null)
        {
            // No? Let me be one
            Instance = this;
        }
        else
        {
            // Already has one? I better destroy myself
            Destroy(this);
        }
    }

    // This method is called when the script is destroy
    protected void OnDestroy()
    {
        // I am the singleton ?
        //If yes then I should release the singleton as well
        if (Instance == this)
        {
            Instance = null;
        }

        
    }

    public bool isPlay;
    public UILabel ScoreLabel;
    public int score;
    public int bestScore;

    public void setScore(int _score)
    {
        score = _score;
        ScoreLabel.text = score.ToString();
    }

    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("bestScore", bestScore);
    }

    public int getBestOldBestScore()
    {
        if (PlayerPrefs.HasKey("bestScore"))
        {
            return PlayerPrefs.GetInt("bestScore");
        }
        return 0;
    }

}
