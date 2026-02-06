using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody characterRigidBody;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float distanceToMove = 2f;
    private bool isGrounded = true;
    private void Start()
    {
        characterRigidBody = GetComponent<Rigidbody>();
    }
    public void Jump()
    {
        if (isGrounded)
        {
            characterRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    public void MoveLeft()
    {
        transform.position += Vector3.left * distanceToMove;
    }
    public void MoveRight()
    {
        transform.position += Vector3.right * distanceToMove;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
