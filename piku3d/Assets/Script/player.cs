using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;
    public Transform cameraTransform;

    [SerializeField] private float speed = 5;
    private float horizontal, vertical;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Walking();
    }

    void Walking()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        anim.SetFloat("x", this.horizontal);
        anim.SetFloat("y", this.vertical);

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = camForward * vertical + camRight * horizontal;
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}
