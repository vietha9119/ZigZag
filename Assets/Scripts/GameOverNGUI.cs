using UnityEngine;
using System.Collections;

public class GameOverNGUI : MyBehaviour{

    public GameObject[] _this;
    int count;
    public UILabel ScoreLabel;
    public UILabel BestScoreLabel;

	// Use this for initialization
	void Start () {

	}

    public void runAll()
    {
        count = 0;
        setValueScoreAndSave();
        StartCoroutine(run(_this[count]));
    }

    public void setValueScoreAndSave()
    {
        
        GameManager.Instance.bestScore = GameManager.Instance.getBestOldBestScore();

        if (GameManager.Instance.score > GameManager.Instance.bestScore)
        {
            GameManager.Instance.bestScore = GameManager.Instance.score;
        }

        GameManager.Instance.SaveBestScore();

        ScoreLabel.text = "Score: " + GameManager.Instance.score.ToString();
        BestScoreLabel.text = "Best Score: " + GameManager.Instance.bestScore.ToString();
    }

    IEnumerator run(GameObject go)
    {
        TweenPosition.Begin(go, 0.3f, new Vector3(0, go.transform.localPosition.y, 0), UITweener.Method.Linear).SetOnFinished(finish);
        yield return null;
    }

    void finish()
    {
        UITweener.current.onFinished = null;
        if (count < _this.Length - 1)
        {
            count++;
            StartCoroutine(run(_this[count]));
        }
    }


    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
