using UnityEngine;

public class BoatSteering : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed at which the boat moves forward\\
    [SerializeField] private float turnSpeed = 10f; // Speed at which the boat turns

    private Rigidbody rb;
    private bool isBeingControlled = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(!isBeingControlled) return;

       // float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down arrows
        //float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows

        /*Vector3 force = transform.forward * moveInput * moveSpeed;
        rb.AddForce(force, ForceMode.Acceleration);

        if(Mathf.Abs(moveInput) > 0.1f) // Only turn if there's significant forward/backward input
        {
            //may have to debug this section, not sure if it will work as intended
            float turnAmount = turnInput * turnSpeed * Time.fixedDeltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }*/

    }

    public void SetControl(bool control)
    {
        isBeingControlled = control;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
