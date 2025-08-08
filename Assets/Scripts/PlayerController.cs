using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

  // Transform transform;
  public float thrusterSpeed = 5f;
  public InputAction PlayerControls;

  public Vector2 currentVelocity = new(5.0f, -1.0f); // start velocity
  public Vector2 gravity = Vector2.down;

  public float rot = 0;
  public float rotationSpeed = 0.85f;

  public Vector2 moveDirection = Vector2.zero;

  private void OnEnable()
  {
    PlayerControls.Enable();
  }
  private void OnDisable()
  {
    PlayerControls.Enable();
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    // transform = 
  }

  // Update is called once per frame
  void Update()
  {
    moveDirection = PlayerControls.ReadValue<Vector2>();
  }

  // Update is called once per physics update (50 times / s I believe)
  void FixedUpdate()
  {
    // figure out if the player is pressing the 'w' key
    
    HandleRotation();
    HandleThruster();

    // currentVelocity += gravity;
    // rb.linearVelocity = new Vector2(moveDirection.x * thrusterSpeed, moveDirection.y * thrusterSpeed);
    // transform.position = currentVelocity;
  }

  void HandleRotation()
  {
    if (moveDirection.x + transform.eulerAngles.z >= 90.0f && transform.eulerAngles.z <= 180.0f)
    {
      rot = 90.1f - transform.eulerAngles.z;
    }
    else if (moveDirection.x + transform.eulerAngles.z <= -90.0f ||
            (moveDirection.x + transform.eulerAngles.z >= 180.0f &&
             moveDirection.x + transform.eulerAngles.z <= 270.0f)) // this is because eulerAngles can represent the same angle in different ways
    {
      rot = 270.1f - transform.eulerAngles.z;
    }
    else
    {
      rot = moveDirection.x * rotationSpeed;
    }
    transform.Rotate(new Vector3(0, 0, rot)); // * Time.deltaTime);
  }

  void HandleThruster()
  {
    if (moveDirection.y == 0)
      return;

    //transform.position
  }
}
