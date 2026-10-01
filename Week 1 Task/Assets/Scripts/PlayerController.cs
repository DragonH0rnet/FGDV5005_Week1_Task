using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Editor;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lookSpeed;
    [SerializeField] private float jumpSpeed;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction lookAction;

    [SerializeField] float lookTargetY;

    private Rigidbody rb;

    [SerializeField] private GameObject camera;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        Cursor.visible = false;
        
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction =  InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
        
        rb = GetComponent<Rigidbody>();

        lookTargetY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = moveAction.ReadValue<Vector2>();
        Vector2 look = lookAction.ReadValue<Vector2>();
        bool jump = jumpAction.IsPressed();
        
        //move x and z
        this.transform.Translate(movement.x * moveSpeed * Time.deltaTime,0, movement.y * moveSpeed * Time.deltaTime);
        
        //rotate horizontal
        this.transform.Rotate(0,look.x*lookSpeed,0); 
        //rotate vertical
        lookTargetY += -look.y * lookSpeed;
        if (lookTargetY > 89) {lookTargetY = 89;}
        else if  (lookTargetY < -89) {lookTargetY = -89;}
        camera.transform.localRotation = Quaternion.Euler(lookTargetY,0,0);

        if (jump)
        {
            //get if in contact with floor for jump
            RaycastHit hit;
            Physics.Raycast(this.transform.position, Vector3.down, out hit, 1.1f);
            if (hit.collider.tag == "Floor")
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
        }
    }
}
