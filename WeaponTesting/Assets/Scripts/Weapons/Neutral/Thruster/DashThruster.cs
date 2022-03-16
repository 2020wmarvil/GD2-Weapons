using UnityEngine;

// TODO: generalized cooldown system?
// TODO: generalized key system?

public class DashThruster : MonoBehaviour {
    [SerializeField] KeyCode key;
    [SerializeField] float dashForceStrength = 10f;

    void Update() {
        if (Input.GetKeyDown(key)) {
            DashThrust();
		}
    }

    void DashThrust() {
		Vector3 direction = -MathHelper.MouseDirectionOnWorldPlane(transform.position);
        Vector3 dashForce = direction * dashForceStrength;

        transform.root.GetComponent<Rigidbody>().AddForce(dashForce);
	}
}
