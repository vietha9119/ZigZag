using UnityEngine;
using System.Collections;

public class FirstTile : MyBehaviour{

    public Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            // Spawn
            StartCoroutine(fallDown(0.2f));
        }
    }

    IEnumerator fallDown(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(2f);
        destroy();
    }

    void destroy()
    {
        Destroy(gameObject);
    }



}
