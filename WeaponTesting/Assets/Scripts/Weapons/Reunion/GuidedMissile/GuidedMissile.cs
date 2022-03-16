using UnityEngine;

public class GuidedMissile : MonoBehaviour {
	float lifetime = 4.5f;
	float damage = 100f;

	float speed = 12f;
	float turnSpeed = 2f;

	Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		lifetime -= Time.deltaTime;
		if (lifetime < 0f) Explode();

		UpdateGuidance();
	}

	void UpdateGuidance() {
		Vector3 direction = MathHelper.MouseDirectionOnWorldPlane(transform.position);
		rb.velocity = transform.forward * speed;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
	}

	// collisions and deal damage
	void OnCollisionEnter(Collision collision) {
		Transform root = collision.transform.root;

		// has affiliation?
		Affiliation aff = root.GetComponent<Affiliation>();

		if (aff != null) {
			if (aff.affiliation != GetComponent<Affiliation>().affiliation) {
				// has ship health?
				ShipHealth sh = root.GetComponent<ShipHealth>();

				if (sh != null) sh.TakeDamage(damage);
			}
		}

		Explode();
	}

	void Explode() {
		// spawn explosion and then die
		Destroy(gameObject);
	}
}
