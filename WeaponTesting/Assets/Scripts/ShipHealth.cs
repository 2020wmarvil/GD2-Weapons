using System;
using UnityEngine;

/// <summary>
/// Use this function to give a ship a health system
/// </summary>
public class ShipHealth : MonoBehaviour {
	[SerializeField] float maxHealth = 100f;

	public float Health { get; private set; }

	void Awake() {
		Health = maxHealth;
	}

	/// <summary>
	/// When the ship is destroyed this will return true. Destruction happens when ship health is less than zero. 
	/// </summary>
	public bool Destroyed { get; private set; } = false;

	/// <summary>
	/// This event will be invoked when ship health drops below 0
	/// </summary>
	public event Action OnDestroyed;

	/// <summary>
	/// Call this function to deal damage to a ship. Returns true if the damage destroys the ship. 
	/// </summary>
	/// <param name="damage"></param>
	/// <returns></returns>
	public bool TakeDamage(float damage) {
		if (Destroyed) return false;

		Health -= damage;
		
		if (Health <= 0f) {
			OnDestroyed.Invoke();

			Destroyed = true;
			return true;
		}

		return false;
	}

	/// <summary>
	/// Give health to the ship. Use exceedMax to exceed max health (defaults to false). 
	/// </summary>
	/// <param name="toAdd"></param>
	/// <param name="exceedMax"></param>
	public void AddHealth(float toAdd, bool exceedMax=false) {
		Health += toAdd;

		if (!exceedMax) Mathf.Min(Health, maxHealth);
	}
}
