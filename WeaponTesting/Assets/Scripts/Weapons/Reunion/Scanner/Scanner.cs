using UnityEngine;

public class Scanner : MonoBehaviour {
	[HideInInspector] public Vector3 initialPosition;
	[HideInInspector] public Vector3 targetPosition;

	float lifetime = 10f;

	float progress = 0f;
	float speed = 0.1f;

	void Update() {
		lifetime -= Time.deltaTime;
		if (lifetime < 0f) Explode();

		progress += Time.deltaTime * speed;
		transform.position = Vector3.Lerp(initialPosition, targetPosition, MathHelper.QuinticEase(progress));

		// TODO: set parameter of fog material
	}

	void Explode() {
		Destroy(gameObject);
	}
}
