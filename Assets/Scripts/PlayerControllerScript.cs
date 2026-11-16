using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{
    private InputAction moveAction;
    private float horizontal, vertical;
    private Rigidbody rb;
    private Vector3 movement;
    private GameManager gameManager;
    private AudioSource audioPlayer;
    [SerializeField]private float speed;
    [SerializeField]private GameObject explodePickup;



    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioPlayer = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        horizontal = moveAction.ReadValue<Vector2>().x;
        vertical = moveAction.ReadValue<Vector2>().y;
        movement = new Vector3(horizontal, 0f, vertical);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.Count();
        audioPlayer.Play();
        Instantiate(explodePickup, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    } 

}
