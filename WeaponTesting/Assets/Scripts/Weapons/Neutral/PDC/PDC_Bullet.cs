using UnityEngine;

// TODO: pooling

public class PDC_Bullet : MonoBehaviour {
	float lifetime = 10f;
	float damage = 10f;

	void Update() {
		lifetime -= Time.deltaTime;
		if (lifetime < 0f) Destroy(gameObject);
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

		// spawn explosion and then die
		Destroy(gameObject);
	}
}
