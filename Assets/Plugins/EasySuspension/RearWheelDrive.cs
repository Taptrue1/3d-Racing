using UnityEngine;
using System.Collections.Generic;

public class RearWheelDrive : MonoBehaviour 
{
	[SerializeField] private float _maxAngle = 30;
	[SerializeField] private float _maxTorque = 300;
	[SerializeField] private GameObject _wheelShape;
	[SerializeField] private WheelCollider[] _rightWheels;
	[SerializeField] private WheelCollider[] _leftWheels;

	private List<WheelCollider> _allWheels;

	private void Start()
	{
		_allWheels = new List<WheelCollider>(_rightWheels.Length + _leftWheels.Length);
		var isNeedToCreateWheels = _wheelShape != null;

		foreach (var wheel in _rightWheels)
			_allWheels.Add(wheel);
		foreach (var wheel in _leftWheels)
			_allWheels.Add(wheel);

		if(isNeedToCreateWheels)
			foreach (var wheel in _allWheels)
				CreateWheel(wheel);
	}
	private void Update()
	{
		float angle = _maxAngle * Input.GetAxis("Horizontal");
		float torque = _maxTorque * Input.GetAxis("Vertical");

		foreach(var wheel in _allWheels)
        {
			var isRightWheel = IsRightWheel(wheel);
			UpdateWheel(wheel, angle, torque, isRightWheel);
		}
	}

	private void UpdateWheel(WheelCollider wheel, float angle, float torque, bool isRight)
    {
		SetWheelSteerAngle(wheel, angle, isRight);
		SetWheelTorque(wheel, torque, isRight);

		if (_wheelShape)
		{
			wheel.GetWorldPose(out Vector3 position, out Quaternion rotation);

			Transform shapeTransform = wheel.transform.GetChild(0);
			shapeTransform.position = position;
			shapeTransform.rotation = rotation;
			shapeTransform.localScale = new Vector3(1, 1, 1);
		}
	}
	private void SetWheelSteerAngle(WheelCollider wheel, float angle, bool isRight)
	{
		var isFrontWheel = wheel.transform.localPosition.z > 0;

		if (isRight)
			wheel.steerAngle = isFrontWheel ? 180 + angle : 180;
		else
			wheel.steerAngle = isFrontWheel ? angle : 0;
	}
	private void SetWheelTorque(WheelCollider wheel, float torque, bool isRight)
    {
		var isBackWheel = wheel.transform.localPosition.z < 0;

		if (isBackWheel)
			wheel.motorTorque = isRight ? -torque : torque;
    }
	private bool IsRightWheel(WheelCollider wheel)
	{
		foreach (var rightWheel in _rightWheels)
			if (wheel == rightWheel)
				return true;

		return false;
	}
	private void CreateWheel(WheelCollider wheel)
    {
		var ws = GameObject.Instantiate(_wheelShape);
		ws.transform.parent = wheel.transform;
	}
}