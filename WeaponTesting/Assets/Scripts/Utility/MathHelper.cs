using UnityEngine;

public class MathHelper {
	public static float LinearEase(float t) {
		return t;
	}

	public static float QuinticEase(float t) {
		return t == 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
	}

	public static float EaseInBack(float t) {
		float c1 = 1.70158f;
		float c3 = c1 + 1;
		return c3 * t * t * t - c1 * t * t;
	}

	public static float EaseInOutBounce(float t) {
		return t < 0.5
		  ? (1 - EaseOutBounce(1 - 2 * t)) / 2
		  : (1 + EaseOutBounce(2 * t - 1)) / 2;
	}

	public static float EaseOutBounce(float t) { 
		float n1 = 7.5625f;
		float d1 = 2.75f;
		
		if (t < 1 / d1) {
		    return n1 * t * t;
		} else if (t < 2 / d1) {
			t -= 1.5f / d1;
		    return n1 * t * t + 0.75f;
		} else if (t < 2.5 / d1) {
			t -= 2.25f / d1;
		    return n1 * t * t + 0.9375f;
		} else {
			t -= 2.625f / d1;
		    return n1 * t * t + 0.984375f;
		}
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
