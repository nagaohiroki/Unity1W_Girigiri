using UnityEngine;
public class Dog : MonoBehaviour
{
	[SerializeField]
	Rigidbody mRigidbody;
	[SerializeField]
	GameObject mCameraHandle;
	[SerializeField]
	GameObject mHead;
	[SerializeField]
	GameObject mTail;
	void Update()
	{
		const float power = 10.0f;
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			AddForce(mHead, power);
			AddForce(mTail, -power);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			AddForce(mHead, -power);
			AddForce(mTail, power);
		}
		mCameraHandle.transform.position = transform.position;
	}
	void AddForce(GameObject inGameObject, float inPower)
	{
		if(inGameObject == null || mRigidbody == null)
		{
			Debug.LogError("Dogのinspectorをよく見て");
			return;
		}
		var trans = inGameObject.transform;
		mRigidbody.AddForceAtPosition(trans.forward * inPower, trans.position, ForceMode.VelocityChange);
	}
}
