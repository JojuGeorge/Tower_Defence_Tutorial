using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] private float _panSpeed = 10f;
    [SerializeField] private float _scrollSpeed = 5f;
    [SerializeField] private float _panBorderThickness = 10f;
    [SerializeField] private float  _minY, _maxY;

    private bool _doPanning = true;
 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _doPanning = !_doPanning;
        }

        if (!_doPanning)
            return;

        

        // If we click W or if mouse at top of the screen the move forward i.e in z
        if (Input.GetKey(KeyCode.W)) // || Input.mousePosition.y >= Screen.height - _panBorderThickness)
        {
            transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S)) //  || Input.mousePosition.y <= _panBorderThickness)
        {
            transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A)) // || Input.mousePosition.x >= Screen.width - _panBorderThickness)
        {
            transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D)) // || Input.mousePosition.x <=  _panBorderThickness)
        {
            transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
        }



        // For doing zooming on mouse scrolling
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 currentPos = transform.position;
        currentPos.y -= scroll * 1000 * _scrollSpeed * Time.deltaTime;
        currentPos.y = Mathf.Clamp(currentPos.y, _minY, _maxY);
        transform.position = currentPos;
    }
}
