﻿using UnityEngine;
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
	// 頭質点位置
	[SerializeField]
	GameObject mHead;
	// お尻質点位置
	[SerializeField]
	GameObject mTail;
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
	void Restart()
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
	/// @brief オブジェクト正面にAddForce
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
		// 死亡判定
		if(transform.position.y < -50.0f)
		{
			Restart();
		}
	}
}
