using UnityEngine;

public class GuidedMissileLauncher : MonoBehaviour {
    [SerializeField] KeyCode key;

	[SerializeField] Transform missileSpawnTransform;
	[SerializeField] Transform missilePrefab;

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
		GuidedMissile missile = Instantiate(missilePrefab, missileSpawnTransform.position, Quaternion.identity).GetComponent<GuidedMissile>();
		missile.GetComponent<Affiliation>().affiliation = aff.affiliation;
		Vector3 direction = MathHelper.MouseDirectionOnWorldPlane(transform.position);
		missile.transform.rotation = Quaternion.LookRotation(direction);
	}
}
