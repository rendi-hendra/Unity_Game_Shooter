using UnityEngine;

public class DoorController : MonoBehaviour
{
    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        // Atur batas pintu biar maksimal 90 derajat
        JointLimits limits = hinge.limits;
        limits.min = 0;
        limits.max = 90;
        hinge.limits = limits;
        hinge.useLimits = true;
    }

    void Update()
    {
        // Tekan E untuk kasih "dorongan" biar pintu terbuka
        if (Input.GetKeyDown(KeyCode.E))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.right * 200f); // dorong pintu
        }
    }
}
