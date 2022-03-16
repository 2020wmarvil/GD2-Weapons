using UnityEngine;

public class ScannerLauncher : MonoBehaviour {
    [SerializeField] KeyCode key;

	[SerializeField] Transform scannerSpawnTransform;
	[SerializeField] Transform scannerPrefab;

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
		Scanner missile = Instantiate(scannerPrefab, scannerSpawnTransform.position, Quaternion.identity).GetComponent<Scanner>();
		missile.GetComponent<Affiliation>().affiliation = aff.affiliation;
		missile.initialPosition = scannerSpawnTransform.position;
		missile.targetPosition = MathHelper.MousePositionOnWorldPlane();
	}
}
