using UnityEngine;

public class StandardMissile : MonoBehaviour {
	float lifetime = 10f;
	float damage = 100f;

	void Update() {
		lifetime -= Time.deltaTime;
		if (lifetime < 0f) Explode();
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
		Destroy(gameObject);
	}
}
