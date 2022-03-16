using UnityEngine;

public class TimedNuke : MonoBehaviour {
	[HideInInspector] public Vector3 initialPosition;
	[HideInInspector] public Vector3 targetPosition;

	float timeTilExplode = 5f;
	float damage = 100f;

	float progress = 0f;
	float speed = 0.1f;

	bool exploding = false;

	void Update() {
		if (exploding) return;

		timeTilExplode -= Time.deltaTime;
		if (timeTilExplode < 0f) Explode();

		progress += Time.deltaTime * speed;
		transform.position = Vector3.Lerp(initialPosition, targetPosition, MathHelper.QuinticEase(progress));
	}

	void Explode() {
		if (exploding) return;
		exploding = true;

		// sphere cast for casualties and deal damage

		Destroy(gameObject);
	}

	// collisions and deal damage
	void OnCollisionEnter(Collision collision) {
		Transform root = collision.transform.root;

		// has affiliation?
		Affiliation aff = root.GetComponent<Affiliation>();

		if (aff != null) {
			if (aff.affiliation != GetComponent<Affiliation>().affiliation) {
				Explode();
			}
		}
	}
}
