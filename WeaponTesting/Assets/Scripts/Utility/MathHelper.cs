using UnityEngine;

public class MathHelper {
	public static float QuinticEase(float t) {
		return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
	}

	public static Vector3 MousePositionOnWorldPlane() {
		Vector3 worldMousePos = Vector3.zero;

        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance)) {
            worldMousePos = ray.GetPoint(distance);
        }

		worldMousePos.y = 0f;
		return worldMousePos;
	}

	public static Vector3 MouseDirectionOnWorldPlane(Vector3 origin) {
		Vector3 worldMousePos = Vector3.zero;

        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance)) {
            worldMousePos = ray.GetPoint(distance);
        }

		Vector3 direction = worldMousePos - origin;
		direction.y = 0f;
		direction.Normalize();

		return direction;
	}
}
