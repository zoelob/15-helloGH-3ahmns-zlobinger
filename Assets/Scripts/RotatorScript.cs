using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    private Vector3 rotation = new Vector3(5f,10f,30f);
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
