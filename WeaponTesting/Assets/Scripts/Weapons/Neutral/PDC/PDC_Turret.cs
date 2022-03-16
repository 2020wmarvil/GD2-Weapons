using UnityEngine;

// TODO: burst firing (pew pew pew! pause pew pew pew! pause)
// TODO: random delay between each shot to feel more authentic

public class PDC_Turret : MonoBehaviour {
	[SerializeField] Transform pivot;
	[SerializeField] Transform bulletSpawnTransform;

	[SerializeField] Transform bulletPrefab;
	[SerializeField] float fireRate = 0.5f;
	[SerializeField] float bulletVelocity = 40f;
	float fireTimer = 0f;

	Affiliation aff;

	void Awake() {
		aff = GetComponent<Affiliation>();
		aff.affiliation = transform.root.GetComponent<Affiliation>().affiliation;
	}

	void Update() {
		fireTimer += Time.deltaTime * fireRate;
		if (fireTimer > 1f) {
			FirePDC();
			fireTimer = 0f;
		}
	}

	void FirePDC() {
		PDC_Bullet bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, pivot.rotation).GetComponent<PDC_Bullet>();
		bullet.GetComponent<Affiliation>().affiliation = aff.affiliation;
		float shipSpeed = Mathf.Max(1f, transform.root.GetComponent<Rigidbody>().velocity.magnitude);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * (bulletVelocity + shipSpeed);
	}
}
