using UnityEngine;
using System.Collections;

public class TileManager : MyBehaviour{

    public TileController LeftTilePrefab;
    public TileController TopTilePrefab;
    public TileController CurrentTile;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 25; i++)
        {
            SpawnTile();
        }
	}
	

    public void SpawnTile()
    {
        int random = Random.Range(0, 2);
        GameObject _currentGameObject = null ;
        if (random == 0)
        {
            _currentGameObject = (GameObject)TopTilePrefab.gameObject.Spawn(CurrentTile.TopAnchor.transform.position);
        }
        else if(random == 1)
        {
            _currentGameObject = (GameObject)LeftTilePrefab.gameObject.Spawn(CurrentTile.LeftAnchor.transform.position);
            
        }

        CurrentTile = _currentGameObject.GetComponent<TileController>();
        CurrentTile._TileManager = this;
        CurrentTile.RandomSpawnPickUp();
    }
}
