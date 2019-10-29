using UnityEngine;
using UnityEngine.UI;
// ------------------------------------------------------------------------
/// @brief 犬
// ------------------------------------------------------------------------
public class Dog : MonoBehaviour
{
	// タイマー
	[SerializeField]
	Timer mTimer = null;
	// 剛体キャッシュ
	[SerializeField]
	Rigidbody mRigidbody = null;
	// クリアのメッセージ
	[SerializeField]
	Text mClearMessage = null;
	// スタート位置
	[SerializeField]
	GameObject mPlayerStart = null;
	// 今のステージ
	[SerializeField]
	int mCurrentStage = 0;
	// ステージ
	[SerializeField]
	GameObject[] mStages = null;
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
		// リセット
		if(Input.GetKeyDown(KeyCode.S))
		{
			Restart();
		}
		// 移動
		mRigidbody.AddTorque(Vector3.back * Input.GetAxis("Horizontal"), ForceMode.VelocityChange);
		// カメラ移動
		Camera.main.transform.parent.position = transform.position;
	}
}
