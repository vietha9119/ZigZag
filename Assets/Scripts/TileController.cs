using UnityEngine;
using System.Collections;

public class TileController : MyBehaviour{

    public Rigidbody rigidbody;
    public GameObject LeftAnchor;
    public GameObject TopAnchor;
    public TileManager _TileManager;
    public GameObject PickUp;
    public GameObject Ps;

	// Use this for initialization
	void Start () {
	
	}

    public void RandomSpawnPickUp()
    {
        float random = Random.Range(0f, 1f);
        if (random < 0.3f)
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

    IEnumerator fallDown(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        rigidbody.isKinematic = false;
        yield return new WaitForSeconds(2f);
        recycle();
    }

    void recycle()
    {
        rigidbody.isKinematic = true;
        gameObject.Recycle();
    }

    
}
