using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    public float sensitivity = 100f;
    public float zoomFactor = 3f;
    public float sensZoomMult = 4f;
    public GameObject playerCamera;

    private Camera _cam;
    private Transform _camTr;
    private float _xRot;
    private bool _crouching;

    private void Start()
    {
        _cam = playerCamera.GetComponent<Camera>();
        _camTr = playerCamera.transform;
        
        Debug.Log("Initial camera Y " + _camTr.localPosition);
    }

    void Update()
    {
        if (Input.GetButtonDown("Zoom"))
        {
            _cam.fieldOfView /= zoomFactor;
            sensitivity /= sensZoomMult;
        }
        if (Input.GetButtonUp("Zoom"))
        {
            _cam.fieldOfView *= zoomFactor;
            sensitivity *= sensZoomMult;
        }
        
        Vector3 mouseMov = (new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))) * (sensitivity * Time.deltaTime);

        transform.Rotate(Vector3.up * mouseMov.x);

        _xRot = Mathf.Clamp(_xRot - mouseMov.y, -90f, 90f);
        
        _camTr.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
    }
}
