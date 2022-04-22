using UnityEngine;


public class CameraOrbitRotation : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Transform target;
    [SerializeField] private float distanceToTarget;
    [SerializeField] private float speed = 20f;
    

    private Vector3 previousPosition;


    private void Start()
    {
        //distanceToTarget = Vector3.Distance(target.position, cam.transform.position);
        //cam.transform.LookAt(target.transform);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
        else
        {
            MouseWheeling();
        }
    }

    void MouseWheeling()
    {
        if(cam == null)
        {
            return;
        }

        Vector3 pos = cam.transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            pos = pos - cam.transform.forward * speed;
            cam.transform.position = pos;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            pos = pos + cam.transform.forward * speed;
            cam.transform.position = pos;
        }

        distanceToTarget = Vector3.Distance(target.position, cam.transform.position);
    }

    public void changeTarget(Transform trg)
    {
        this.target = trg;
    }
    
}
