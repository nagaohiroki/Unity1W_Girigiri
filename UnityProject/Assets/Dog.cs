using UnityEngine;
using UnityEngine.UI;
// ------------------------------------------------------------------------
/// @brief 犬
// ------------------------------------------------------------------------
public class Dog : MonoBehaviour
{
	enum Arrow
	{
		None,
		Left,
		Right,
	}
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
		Arrow arrow = GetArrow();
		// 左回転
		if(arrow == Arrow.Left)
		{
			AddTorque(inPower);
		}
		// 右回転
		if(arrow == Arrow.Right)
		{
			AddTorque(-inPower);
		}
		// 再スタート
		if(Input.GetKeyDown(KeyCode.S))
		{
			Restart();
		}
	}
	Arrow GetArrow()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(0.0f > Input.mousePosition.x - Screen.width / 2.0f)
			{
				return Arrow.Left;
			}
			return Arrow.Right;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			return Arrow.Right;
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			return Arrow.Left;
		}
		return Arrow.None;
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
