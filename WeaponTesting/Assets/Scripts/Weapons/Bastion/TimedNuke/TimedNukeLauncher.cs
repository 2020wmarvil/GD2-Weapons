using UnityEngine;

// TODO: burst firing (pew pew pew! pause pew pew pew! pause)
// TODO: random delay between each shot to feel more authentic

public class TimedNukeLauncher : MonoBehaviour {
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
		Vector3 direction = MathHelper.MouseDirectionOnWorldPlane(missileSpawnTransform.position);

		TimedNuke missile = Instantiate(missilePrefab, missileSpawnTransform.position, Quaternion.identity).GetComponent<TimedNuke>();
		missile.GetComponent<Affiliation>().affiliation = aff.affiliation;
		float shipSpeed = Mathf.Max(1f, transform.root.GetComponent<Rigidbody>().velocity.magnitude);
		print(shipSpeed);
		missile.GetComponent<Rigidbody>().velocity = direction * (missileVelocity + shipSpeed);
		missile.transform.rotation = Quaternion.LookRotation(direction);
	}
}
