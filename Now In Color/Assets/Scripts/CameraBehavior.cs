using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject playerObj;
    public Transform target;
    public float cameraSpeed = 150;

    void Start()
    {
        playerObj = GameObject.Find("Player(Clone)");
        target = playerObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grab the position of the target
        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;

        // Move the camera to the target position at a set speed
        Vector3 camPos = Vector3.MoveTowards(transform.position, targetPosition
                                             , cameraSpeed);
        transform.position = camPos;
    }
}
