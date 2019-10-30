using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
	}
	// ------------------------------------------------------------------------
	/// @brief 再スタート
	// ------------------------------------------------------------------------
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
