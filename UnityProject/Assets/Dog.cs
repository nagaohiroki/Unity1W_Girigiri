using UnityEngine;
using UnityEngine.UI;
// ------------------------------------------------------------------------
/// @brief 犬
// ------------------------------------------------------------------------
public class Dog : MonoBehaviour
{
	// タイマー
	[SerializeField]
	Timer mTimer;
	// 剛体キャッシュ
	[SerializeField]
	Rigidbody mRigidbody;
	// カメラのハンドル
	[SerializeField]
	GameObject mCameraHandle;
	// クリアのメッセージ
	[SerializeField]
	Text mClearMessage;
	// スタート位置
	[SerializeField]
	GameObject mPlayerStart;
	// 今のステージ
	[SerializeField]
	int mCurrentStage;
	// ステージ
	[SerializeField]
	GameObject[] mStages;
	// ------------------------------------------------------------------------
	/// @brief ステージクリア
	///
	/// @return
	// ------------------------------------------------------------------------
	public void StageClear()
	{
		if(mClearMessage.gameObject.activeSelf)
		{
			return;
		}
		mClearMessage.gameObject.SetActive(true);
		mTimer.IsStop = true;
		++mCurrentStage;
	}
	// ------------------------------------------------------------------------
	/// @brief 再スタート
	// ------------------------------------------------------------------------
	public void Restart()
	{
		mClearMessage.gameObject.SetActive(false);
		mTimer.Reset();
		mRigidbody.Sleep();
		mRigidbody.MovePosition(mPlayerStart.transform.position);
		mRigidbody.MoveRotation(mPlayerStart.transform.rotation);
		UpdateStage();
	}
	// ------------------------------------------------------------------------
	/// @brief ステージを変える
	// ------------------------------------------------------------------------
	void UpdateStage()
	{
		if(mCurrentStage < 0 || mCurrentStage >= mStages.Length)
		{
			mCurrentStage = 0;
		}
		for(int i = 0; i < mStages.Length; ++i)
		{
			mStages[i].gameObject.SetActive(i == mCurrentStage);
		}
	}
	// ------------------------------------------------------------------------
	/// @brief 操作
	///
	/// @param inPower
	// ------------------------------------------------------------------------
	void Move(float inPower)
	{
		// 左回転
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			AddTorque(inPower);
		}
		// 右回転
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			AddTorque(-inPower);
		}
		// 再スタート
		if(Input.GetKeyDown(KeyCode.S))
		{
			Restart();
		}
	}
	// ------------------------------------------------------------------------
	/// @brief 回転
	///
	/// @param inPower
	// ------------------------------------------------------------------------
	void AddTorque(float inPower)
	{
		mRigidbody.AddTorque(Vector3.forward * inPower, ForceMode.VelocityChange);
	}
	// ------------------------------------------------------------------------
	/// @brief 初回更新
	// ------------------------------------------------------------------------
	void Start()
	{
		Restart();
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
	}
}
