using UnityEngine;

public enum FactionAffiliation {
    NEUTRAL,
    PLAYER,
    BASTION,
    REUNION,
    ASCENDANT, 
    MATRIOSHKA
}

[ExecuteInEditMode]
public class Affiliation : MonoBehaviour {
	public FactionAffiliation affiliation;

	void Update() {
        // 6 is a magic number that corresponds to the physics layer value of NEUTRAL
        gameObject.layer = 6 + (int)affiliation;
	}
}
