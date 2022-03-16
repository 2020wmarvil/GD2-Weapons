using UnityEngine;

public class RepairBot : MonoBehaviour {
    ShipHealth health;

	[SerializeField] float healthPerSecond = 10f;

	void Awake() {
		health = transform.root.GetComponent<ShipHealth>();
	}

	void Update() {
		health.AddHealth(healthPerSecond / Time.deltaTime);
    }
}
