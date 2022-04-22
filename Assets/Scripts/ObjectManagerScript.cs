using System.Collections;
using UnityEngine;


public class ObjectManagerScript : MonoBehaviour
{
    private Animator anim;
    public float speed = 1f;
    public float lerpDuration = 1f;
    private SceneControllerScript sceneController;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sceneController = GameObject.Find("SceneController").GetComponent<SceneControllerScript>();
    }


    private void OnMouseDown()
    {
        if (sceneController.selectedItem != name && !sceneController.grouped)
        {
            anim.SetTrigger("animate");
            sceneController.onObjectSelected(name);
        }
    }

    public void moveToPosition(Vector3 pos)
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(startMove(pos));
    }

    private IEnumerator startMove(Vector3 pos)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, pos, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        //print(name + "Move complete!");
        sceneController.grouped = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void moveToStartPosition(Vector3 startPos, Quaternion startRot)
    {
        print(name + " ---->> moving to start position");
        Cursor.lockState = CursorLockMode.Locked;
        CoroutineChain.Start.Parallel(moveToStart(startPos), rotateToStart(startRot));
    }

    private IEnumerator moveToStart(Vector3 pos)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, pos, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        sceneController.grouped = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private IEnumerator rotateToStart(Quaternion startRot)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, startRot, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    
}
