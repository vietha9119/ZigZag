using UnityEngine;
using System.Collections;

public class PlayerMovement : MyBehaviour{

    [SerializeField]
    private float _speed;

    [SerializeField]
    private GameObject camera;

    private Vector3 _dir;

    private Transform _transform;

    public GameObject Ps;

    public GameOverNGUI gov;

    bool isDead;



    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

	// Use this for initialization
	void Start () {
        _dir = Vector3.zero;
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            if (_dir == Vector3.forward)
            {
                _dir = Vector3.left;
            }
            else
            {
                _dir = Vector3.forward;
            }
        }

        float amountToMove = _speed * Time.deltaTime;
        _transform.Translate(amountToMove * _dir);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("PickUp"))
        {
            Instantiate(Ps, transform.position, Quaternion.identity);
            col.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Tile"))
        {
            RaycastHit hit;

            Ray downRay = new Ray(transform.position, - Vector3.up);

            if (!Physics.Raycast(downRay, out hit))
            {
                // Kill Player
                camera.transform.parent = null;
                isDead = true;
                gov.runAll();
            }
        }
    }
}
