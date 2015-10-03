using UnityEngine;
using System.Collections;

public class GameOverNGUI : MyBehaviour{

    public GameObject[] _this;
    int count;

	// Use this for initialization
	void Start () {

	}

    public void runAll()
    {
        count = 0;
        StartCoroutine(run(_this[count]));
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
