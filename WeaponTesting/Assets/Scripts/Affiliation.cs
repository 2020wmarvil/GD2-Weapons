using UnityEngine;

public enum FactionAffiliation {
    NEUTRAL,
    PLAYER,
    BASTION,
    REUNION,
    ASCENDANT, 
    MATRIOSHKA
}

public class Affiliation : MonoBehaviour {
	public FactionAffiliation affiliation;
}
