using UnityEngine;

public class GravityBombLauncher : MonoBehaviour {
    [SerializeField] KeyCode key;

	[SerializeField] Transform bombSpawnTransform;
	[SerializeField] Transform bombPrefab;

	Affiliation aff;

	void Awake() {
		aff = GetComponent<Affiliation>();
		aff.affiliation = transform.root.GetComponent<Affiliation>().affiliation;
	}

	void Update() {
        if (Input.GetKeyDown(key)) {
			FireBomb();
		}
	}

	void FireBomb() {
		GravityBomb bomb = Instantiate(bombPrefab, bombSpawnTransform.position, Quaternion.identity).GetComponent<GravityBomb>();
		bomb.GetComponent<Affiliation>().affiliation = aff.affiliation;
		bomb.initialPosition = bombSpawnTransform.position;
		bomb.targetPosition = MathHelper.MousePositionOnWorldPlane();
	}
}
