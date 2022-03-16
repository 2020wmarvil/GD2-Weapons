using UnityEngine;

public class BurstDrive : MonoBehaviour {
    [SerializeField] KeyCode key;

	[SerializeField] float speed = 6f;
	[SerializeField] float maxDistance = 20f;

	Vector3 initialPosition;
	Vector3 targetPosition;

	float progress;
	bool active = false;

	void Update() {
		if (!active) {
			if (Input.GetKeyDown(key)) {
				initialPosition = transform.root.position;
				Vector3 mousePosition = MathHelper.MousePositionOnWorldPlane();
				Vector3 displacement = mousePosition - transform.root.position;
				Vector3 clampedDisplacement = Vector3.ClampMagnitude(displacement, maxDistance);
				targetPosition = initialPosition + clampedDisplacement;

				progress = 0f;
				active = true;
			}
		} else {
			progress += Time.deltaTime * speed;

			transform.root.position = Vector3.Lerp(initialPosition, targetPosition, MathHelper.QuinticEase(progress));

			if (progress > 1f) {
				active = false;
			}
		}
	}
}
