using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = playerPos + offset;
    }
}
