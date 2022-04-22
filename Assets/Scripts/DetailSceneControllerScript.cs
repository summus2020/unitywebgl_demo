using UnityEngine;
using UnityEngine.SceneManagement;

public class DetailSceneControllerScript : MonoBehaviour
{

    private GameObject myObject;
    private Vector3 mOffset;
    private float mZCoord;
    private bool isRotating = true;
    private bool mouseIsDown = false;
    private bool objectSelected = false;
    public float speed = 20;
    private Vector3 colliderSize = new Vector3(114f, 78f, 80f);

    // Start is called before the first frame update
    void Start()
    {
        string objName = SceneControllerScript.sendObjectName;
        myObject = GameObject.Find(objName);
        myObject.transform.position = new Vector3(0, 0, 0);
        myObject.transform.SetParent(this.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseIsDown = true;
            isRotating = true;
        }
        else if (Input.GetMouseButtonDown(2))
        {
            mouseIsDown = true;
            isRotating = false;
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }
        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
        {
            mouseIsDown = false;
            objectSelected = false;
        }

        if (mouseIsDown && objectSelected)
        {
            if (isRotating)
            {
                float rotX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

                transform.RotateAround(Vector3.up, -rotX);
                transform.RotateAround(Vector3.right, rotY);
            }
            else
            {
                transform.position = GetMouseWorldPos() + mOffset;
            }
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            objectSelected = true;
        }
    }
    // Buttn "Back" clicked
    //###########################################
    public void onBackButtonClicked()
    {
        Destroy(myObject);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    // Button 'Vivit site' clicked
    //###########################################
    public void onClickSiteButton()
    {
        Application.OpenURL("https://google.com");
    }
}
