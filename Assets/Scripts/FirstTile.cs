using UnityEngine;
using System.Collections;

public class FirstTile : MyBehaviour{

    public Rigidbody rigidbody;

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
        rigidbody.isKinematic = false;
        yield return new WaitForSeconds(2f);
        destroy();
    }

    void destroy()
    {
        Destroy(gameObject);
    }



}
