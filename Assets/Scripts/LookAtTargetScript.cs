using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetScript : MonoBehaviour
{
    public Transform target;
    public float speed = 1;

    private Coroutine lookCoroutine;

    public void StartRotating()
    {
        if(lookCoroutine != null)
        {
            StopCoroutine(lookCoroutine);
        }

        lookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);

        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * speed;
            yield return null;
            
        }
        
    }

    public void changeTarget(Transform newTarget)
    {
        this.target = newTarget;
        StartRotating();
    }
}
