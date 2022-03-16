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
        Vector3 worldMousePos = transform.root.position;

        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance)) {
            worldMousePos = ray.GetPoint(distance);
        }

        Vector3 dashDirection = (transform.root.position - worldMousePos).normalized;
        Vector3 dashForce = dashDirection * dashForceStrength;
        dashForce.y = 0f;

        transform.root.GetComponent<Rigidbody>().AddForce(dashForce);

	}
}
