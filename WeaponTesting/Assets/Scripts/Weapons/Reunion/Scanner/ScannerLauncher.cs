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
		Scanner scanner = Instantiate(scannerPrefab, scannerSpawnTransform.position, Quaternion.identity).GetComponent<Scanner>();
		scanner.GetComponent<Affiliation>().affiliation = aff.affiliation;
		scanner.initialPosition = scannerSpawnTransform.position;
		scanner.targetPosition = MathHelper.MousePositionOnWorldPlane();
	}
}
