using UnityEngine;

public class Grinder : MonoBehaviour {
    [SerializeField] float rotationSpeed = 10f; 

    void Update() {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.RotateAround(transform.position, transform.right, rotation);
    }
}
