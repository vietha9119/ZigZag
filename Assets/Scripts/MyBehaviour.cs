using UnityEngine;
using System.Collections;

public class MyBehaviour : MonoBehaviour
{

    public void Invoke(System.Action action, float time)
    {
        StartCoroutine(Wait(action, time));
    }

    IEnumerator Wait(System.Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }

    public void Log(object message)
    {
        Debug.Log(message);
    }

}
