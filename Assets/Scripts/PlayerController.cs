using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

  public Rigidbody2D rb;
  public float thrusterSpeed = 5f;
  public InputAction PlayerControls;

  Vector2 moveDirection = Vector2.zero;

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

  }

  // Update is called once per frame
  void Update()
  {
    moveDirection = PlayerControls.ReadValue<Vector2>();
  }

  // Update is called once per physics update (50 times / s I believe)
  void FixedUpdate()
  {
    rb.linearVelocity = new Vector2(moveDirection.x * thrusterSpeed, moveDirection.y * thrusterSpeed);
  }
}
