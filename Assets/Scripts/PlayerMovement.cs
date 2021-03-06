﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MyBehaviour{

    [SerializeField]
    public float Speed;

    [SerializeField]
    private GameObject camera;

    

    public Transform _transform;
    public Rigidbody _rigidbody;

    public GameObject Ps;

    public LayerMask WhatIsGround;

    public Transform ContactPoint;

    public GameOverNGUI gov;

    private float AmountToMove = 0;

    bool isGround;

    bool isDead;

    private Vector3 _dir;

    private List<GameObject> _listTileMovedOn;

	// Use this for initialization
	void Start () {

        Application.targetFrameRate = 60;
        _dir = Vector3.zero;
        isDead = false;
        GameManager.Instance.isPlay = false;
        _listTileMovedOn = new List<GameObject>();

        GameManager.Instance.score = 0;
        
	}
	
	// Update is called once per frame
	void Update () {

        //if (!isGrounded() && !isDead)
        //{
        //    GameOver();
        //}

        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            if (!GameManager.Instance.isPlay)
            {
                GameManager.Instance.isPlay = true;
            }

            if (_dir == Vector3.forward)
            {
                _dir = Vector3.left;
                GameManager.Instance.score++;
                GameManager.Instance.setScore(GameManager.Instance.score);

            }
            else if (_dir == Vector3.left)
            {
                _dir = Vector3.forward;
                GameManager.Instance.score++;
                GameManager.Instance.setScore(GameManager.Instance.score);
            }
            else if (_dir == Vector3.zero)
            {
                _dir = Vector3.forward;
            }
        }

        if (!GameManager.Instance.isPlay)
        {
            _rigidbody.AddForce(new Vector3(0, -100, 0));
            return;
        }

        AmountToMove = Speed * Time.deltaTime;
        //transform.Translate(AmountToMove * _dir);
        _rigidbody.velocity = Speed * _dir;
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("PickUp"))
        {
            Vector3 psPos = transform.position + new Vector3(0,0.5f,0);
            Instantiate(Ps, psPos, Quaternion.Euler(new Vector3(25, -30, -180)));
            col.gameObject.SetActive(false);
            //_listTileMovedOn[0].GetComponent<TileController>().setScoreTextEffect();

            GameManager.Instance.score = GameManager.Instance.score + 2;
            GameManager.Instance.setScore(GameManager.Instance.score);
        }

        if (col.CompareTag("Tile"))
        {
            _listTileMovedOn.Add(col.gameObject);
        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Tile"))
        {

            _listTileMovedOn.Remove(col.gameObject);

            if (_listTileMovedOn.Count == 0)
            {
                GameOver();
            }
        }
    }


    bool isGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(ContactPoint.position, 0.05f, WhatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }

        return false;
    }

    public void GameOver()
    {
        if (!isDead)
        {
            isDead = true;
            gov.runAll();
            GameManager.Instance.isPlay = false;
        }
    }
}
