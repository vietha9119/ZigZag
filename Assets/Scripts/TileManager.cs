using UnityEngine;
using System.Collections;

public class TileManager : MyBehaviour{

    public TileController LeftTilePrefab;
    public TileController TopTilePrefab;
    public TileController CurrentTile;

    int startCount = 5;
    int countCheckOnCameraSight;
    int minCountOnCameraSight = 0;
    int maxCountOnCameraSight = 9;

	// Use this for initialization
	void Start () {

        countCheckOnCameraSight = startCount;

        for (int i = 0; i < 30; i++)
        {
            SpawnTile();
        }
        
	}
	

    public void SpawnTile()
    {
        GameObject _currentGameObject = null;

        int random = randomCountToSpawn();
        
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

    public void SpawnTopTile()
    {
        GameObject _currentGameObject = (GameObject)TopTilePrefab.gameObject.Spawn(CurrentTile.TopAnchor.transform.position);
        CurrentTile = _currentGameObject.GetComponent<TileController>();
        CurrentTile._TileManager = this;
    }

    public void SpawnLeftTile()
    {
        GameObject _currentGameObject = (GameObject)LeftTilePrefab.gameObject.Spawn(CurrentTile.LeftAnchor.transform.position);
        CurrentTile = _currentGameObject.GetComponent<TileController>();
        CurrentTile._TileManager = this;
    }


    int randomCountToSpawn()
    {

        int random = Random.Range(0, 2);

        if (random == 0)
        {
            if (countCheckOnCameraSight > maxCountOnCameraSight - 1)
            {
                random = 1;
                countCheckOnCameraSight--;
            }
            else
            {
                countCheckOnCameraSight++;
            }
        }
        else if(random == 1){
            if (countCheckOnCameraSight < minCountOnCameraSight + 1)
            {
                random = 0;
                countCheckOnCameraSight++;
            }
            else
            {
                countCheckOnCameraSight--;
            }
        }

        return random;
    }
}
