using UnityEngine;

public class TimedNukeLauncher : MonoBehaviour {
    [SerializeField] KeyCode key;

	[SerializeField] Transform nukeSpawnTransform;
	[SerializeField] Transform nukePrefab;

	Affiliation aff;

	void Awake() {
		aff = GetComponent<Affiliation>();
		aff.affiliation = transform.root.GetComponent<Affiliation>().affiliation;
	}

	void Update() {
        if (Input.GetKeyDown(key)) {
			FireNuke();
		}
	}

	void FireNuke() {
		TimedNuke missile = Instantiate(nukePrefab, nukeSpawnTransform.position, Quaternion.identity).GetComponent<TimedNuke>();
		missile.GetComponent<Affiliation>().affiliation = aff.affiliation;
		missile.initialPosition = nukeSpawnTransform.position;
		missile.targetPosition = MathHelper.MousePositionOnWorldPlane();
	}
}
