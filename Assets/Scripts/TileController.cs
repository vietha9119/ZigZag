using UnityEngine;
using System.Collections;

public class TileController : MyBehaviour{

    public Rigidbody _rigidbody;
    public GameObject LeftAnchor;
    public GameObject TopAnchor;
    public TileManager _TileManager;
    public GameObject PickUp;
    public GameObject TextMeshEffect;
    public GameObject Ps;

    Vector3 startPoint;

	// Use this for initialization
	void Start () {
        //startPoint = TextMeshEffect.transform.localPosition;
	}

    public void RandomSpawnPickUp()
    {
        float random = Random.Range(0f, 1f);
        if (random < 0.2f)
        {
            PickUp.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            // Spawn
            _TileManager.SpawnTile();
            StartCoroutine(fallDown(1.5f));
        }
    }

    public void setScoreTextEffect()
    {
        TextMeshEffect.SetActive(true);
        TweenPosition.Begin(TextMeshEffect, 2f, TextMeshEffect.transform.localPosition, TextMeshEffect.transform.localPosition + 6 * Vector3.up, UITweener.Method.Linear).SetOnFinished(TextFinish);
        TweenAlpha.Begin(TextMeshEffect,2f,1f,0f,UITweener.Method.Linear);
    }

    void TextFinish()
    {
        TextMeshEffect.SetActive(false);
    }

    IEnumerator fallDown(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(2f);
        recycle();
    }

    void recycle()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        //TextMeshEffect.transform.localPosition = startPoint;
        gameObject.Recycle();
    }

    
}
