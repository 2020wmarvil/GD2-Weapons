using UnityEngine;

public class GravityBomb : MonoBehaviour {
	[HideInInspector] public Vector3 initialPosition;
	[HideInInspector] public Vector3 targetPosition;

	float timeTilExplode = 5f;

	float progress = 0f;
	float speed = 0.1f;

	void Update() {
		timeTilExplode -= Time.deltaTime;
		if (timeTilExplode < 0f) Explode();

		progress += Time.deltaTime * speed;
		transform.position = Vector3.Lerp(initialPosition, targetPosition, MathHelper.QuinticEase(progress));
	}

	void Explode() {
		// TODO: gravity well thing
		Destroy(gameObject);
	}
}
