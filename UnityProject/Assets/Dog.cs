using UnityEngine;
using UnityEngine.UI;
public class Dog : MonoBehaviour
{
	[SerializeField]
	Timer mTimer;
	[SerializeField]
	Rigidbody mRigidbody;
	[SerializeField]
	GameObject mCameraHandle;
	[SerializeField]
	GameObject mHead;
	[SerializeField]
	GameObject mTail;
	[SerializeField]
	Text mClearMessage;
	Vector3 mStartPos;
	Quaternion mStartRot;
	// ------------------------------------------------------------------------
	/// @brief
	///
	/// @return
	// ------------------------------------------------------------------------
	public void Clear()
	{
		mClearMessage.gameObject.SetActive(true);
		mTimer.IsStop = true;
	}
	// ------------------------------------------------------------------------
	/// @brief 再スタート
	// ------------------------------------------------------------------------
	void Restart()
	{
		mClearMessage.gameObject.SetActive(false);
		mTimer.Reset();
		mRigidbody.Sleep();
		mRigidbody.MovePosition(mStartPos);
		mRigidbody.MoveRotation(mStartRot);
	}
	// ------------------------------------------------------------------------
	/// @brief 回転
	///
	/// @param inPower
	// ------------------------------------------------------------------------
	void Move(float inPower)
	{
		// 左回転
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			AddForce(mHead, inPower);
			AddForce(mTail, -inPower);
		}
		// 右回転
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			AddForce(mHead, -inPower);
			AddForce(mTail, inPower);
		}
		// 再スタート
		if(Input.GetKeyDown(KeyCode.R))
		{
			Restart();
		}
	}
	// ------------------------------------------------------------------------
	/// @brief 移動
	///
	/// @param inGameObject
	/// @param inPower
	// ------------------------------------------------------------------------
	void AddForce(GameObject inGameObject, float inPower)
	{
		var trans = inGameObject.transform;
		mRigidbody.AddForceAtPosition(trans.forward * inPower, trans.position, ForceMode.VelocityChange);
	}
	// ------------------------------------------------------------------------
	/// @brief 初回更新
	// ------------------------------------------------------------------------
	void Start()
	{
		mClearMessage.gameObject.SetActive(false);
		mStartPos = transform.position;
		mStartRot = transform.localRotation;
	}
	// ------------------------------------------------------------------------
	/// @brief 更新
	// ------------------------------------------------------------------------
	void Update()
	{
		// 移動
		Move(10.0f);
		// カメラ移動
		mCameraHandle.transform.position = transform.position;
		// 死亡判定
		if(transform.position.y < -50.0f)
		{
			Restart();
		}
	}
}
