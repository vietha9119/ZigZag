using UnityEngine;
using System.Collections;

public class StartGameNGUI : MyBehaviour{

    bool isStart;

    public GameObject TapToPlay;
	// Use this for initialization
	void Start () {
        isStart = false;
        TapToPlay.SetActive(true);
	}

    void OnClick()
    {
        if (!isStart)
        {
            isStart = true;
            TweenPosition.Begin(gameObject, 1, new Vector3(0, 1000, 0));
            TapToPlay.SetActive(false);
        }
    }
}
