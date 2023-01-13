using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControlsForMovement : MonoBehaviour
{
    Vector2 facing = Vector2.zero;

    public string gameOverScene;
    public float speed;
    public float jumpSpeed;
    public SphereMovement controls;
    public Rigidbody rb;
    public GameObject Player;
    public GameObject text;
    public int secondTillRespawn;

    private InputAction directionalMovement;
    private InputAction jumpMovement;

    bool jumpable = true;

    private void Awake()
    {
        controls = new SphereMovement();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        textFollow();
        facing = directionalMovement.ReadValue<Vector2>();

        if (jumpMovement.triggered && jumpable == true)
        {
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(facing.x * speed, rb.velocity.y, facing.y * speed);
    }

    public void OnEnable()
    {
        //This controls the actual controls being used
        directionalMovement = controls.Player.Move;
        jumpMovement = controls.Player.Jump;
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Climbable")
        {
            rb.useGravity = false;
            jumpable = true;
        }
        else if (collision.transform.tag == "Ground")
        {
            rb.useGravity = true;
            jumpable = true;
        }
        else if (collision.transform.tag == "Damage")
        {
            Respawn();  
        }
    }

    public void textFollow()
    {
        text.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);
    }

    private async void Respawn()
    {
        Player.SetActive(false);
        controls.Disable();
        text.SetActive(true);
        await Task.Delay(secondTillRespawn * 60);
        SceneManager.LoadScene(gameOverScene);
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.useGravity = true;
        jumpable = false;
    }
}
