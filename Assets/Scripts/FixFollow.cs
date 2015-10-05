using UnityEngine;
using System.Collections;

public class FixFollow : MyBehaviour{

    public Transform target;
    Vector3 distance;

    void Awake()
    {
        distance = target.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = target.position - distance;
    }

}
