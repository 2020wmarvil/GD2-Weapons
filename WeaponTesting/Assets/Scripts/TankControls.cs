using UnityEngine;

public class TankControls : MonoBehaviour {
    [SerializeField] float thrustForceConstant = 1f;
    [SerializeField] float turnForceConstant = 1f;

    [SerializeField] float maxSpeed;
    [SerializeField] float maxTurnSpeed;

    [SerializeField] float stoppingPower;
    [SerializeField] float angularStoppingPower;

    [SerializeField] float directionalForcePower;

    Rigidbody rb;

    float turningInput;
    float thrustInput;
    Vector3 torque, thrustForce;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

	void Update() {
        turningInput = Input.GetAxisRaw("Horizontal");
        thrustInput = Input.GetAxisRaw("Vertical");
    }

	void FixedUpdate(){
        // damp movement
        if (thrustInput >= 0f) {
            thrustForce = transform.forward * thrustInput * thrustForceConstant;
		} else {
            thrustForce = -rb.velocity * stoppingPower;
		}

        // damp rotation
        if (turningInput != 0f) {
            torque = Vector3.up * turningInput * turnForceConstant;
		} else {
            torque = -rb.angularVelocity * angularStoppingPower;
		}

        // lerp to new direction when moving opposite previous direction
        if(thrustForce.magnitude > 0.0f) {
            // a value between 0 and 1 for how much our thrust differs from our current velocity
            float thrustDirectionality = 1f - (Vector3.Dot(thrustForce.normalized, rb.velocity.normalized) * 0.5f + 0.5f);
            thrustForce += -rb.velocity * thrustDirectionality * directionalForcePower;
		}

        rb.AddForce(thrustForce);
        rb.AddTorque(torque);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        rb.maxAngularVelocity = maxTurnSpeed;
	}
}
