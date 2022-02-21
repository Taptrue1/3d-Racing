using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class EasySuspension : MonoBehaviour 
{
	[Range(0, 20)]
	[SerializeField] private float naturalFrequency = 10;
	[Range(0, 3)]
	[SerializeField] private float dampingRatio = 0.8f;
	[Range(-1, 1)]
	[SerializeField] private float forceShift = 0.03f;
	[SerializeField] private bool setSuspensionDistance = true;

	private WheelCollider[] wheels;

    private void Awake()
    {
        wheels = GetComponentsInChildren<WheelCollider>();
    }
    private void Update () {
		// work out the stiffness and damper parameters based on the better spring model
		foreach (WheelCollider wheel in wheels) {
			JointSpring spring = wheel.suspensionSpring;

			spring.spring = Mathf.Pow(Mathf.Sqrt(wheel.sprungMass) * naturalFrequency, 2);
			spring.damper = 2 * dampingRatio * Mathf.Sqrt(spring.spring * wheel.sprungMass);

			wheel.suspensionSpring = spring;

			Vector3 wheelRelativeBody = transform.InverseTransformPoint(wheel.transform.position);
			float distance = GetComponent<Rigidbody>().centerOfMass.y - wheelRelativeBody.y + wheel.radius;

			wheel.forceAppPointDistance = distance - forceShift;

			// the following line makes sure the spring force at maximum droop is exactly zero
			if (spring.targetPosition > 0 && setSuspensionDistance)
				wheel.suspensionDistance = wheel.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
		}
	}

// uncomment OnGUI to observe how parameters change

/*
	public void OnGUI()
	{
		foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>()) {
			GUILayout.Label (string.Format("{0} sprung: {1}, k: {2}, d: {3}", wc.name, wc.sprungMass, wc.suspensionSpring.spring, wc.suspensionSpring.damper));
		}

		var rb = GetComponent<Rigidbody> ();

		GUILayout.Label ("Inertia: " + rb.inertiaTensor);
		GUILayout.Label ("Mass: " + rb.mass);
		GUILayout.Label ("Center: " + rb.centerOfMass);
	}
*/

}
