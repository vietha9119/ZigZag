using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightEffect : MyBehaviour{

    public List<Color> Colors;
    public List<Color> currentList;

	// Use this for initialization
	void Start () {
        addColorToCurrentList();
        InvokeRepeating("Tween", 10f, 10f);
	}

    public void Tween()
    {
        Color randomColor = randomColorInCurrentList();
        TweenColor.Begin(gameObject, 2f, randomColor);
    }

    Color randomColorInCurrentList()
    {
        if (currentList.Count == 0)
        {
            addColorToCurrentList();
        }
        int random = Random.Range(0, currentList.Count - 1);
        Color randomColor = currentList[random];
        currentList.RemoveAt(random);
        return randomColor;
    }

    void addColorToCurrentList()
    {
        currentList = new List<Color>();
        for (int i = 0; i < Colors.Count; i++)
        {
            currentList.Add(Colors[i]);
        }
    }
}
