using UnityEngine;

public class StandardMissileLauncher : MonoBehaviour {
    [SerializeField] KeyCode key;

	[SerializeField] Transform missileSpawnTransform;
	[SerializeField] Transform missilePrefab;
	[SerializeField] float missileVelocity = 20f;

	Affiliation aff;

	void Awake() {
		aff = GetComponent<Affiliation>();
		aff.affiliation = transform.root.GetComponent<Affiliation>().affiliation;
	}

	void Update() {
        if (Input.GetKeyDown(key)) {
			FireMissile();
		}
	}

	void FireMissile() {
		Vector3 worldMousePos = Vector3.zero;

        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance)) {
            worldMousePos = ray.GetPoint(distance);
        }

        Vector3 direction = (worldMousePos - missileSpawnTransform.position).normalized;
		direction.y = 0f;

		StandardMissile missile = Instantiate(missilePrefab, missileSpawnTransform.position, Quaternion.identity).GetComponent<StandardMissile>();
		missile.GetComponent<Affiliation>().affiliation = aff.affiliation;
		float shipSpeed = transform.root.GetComponent<Rigidbody>().velocity.magnitude;
		missile.GetComponent<Rigidbody>().velocity = direction * (missileVelocity + shipSpeed);
		missile.transform.rotation = Quaternion.LookRotation(direction);
	}
}
