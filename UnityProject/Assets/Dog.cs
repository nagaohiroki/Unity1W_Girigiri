using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Dog : MonoBehaviour
{
	[SerializeField]
	Text mClearMessage = null;
	float mSeconds = 0.0f;
	public void StageClear()
	{
		if(mClearMessage.gameObject.activeSelf)
		{
			return;
		}
		mClearMessage.text = "WELCOME BACK!!!!!\n";
		mClearMessage.text += System.TimeSpan.FromSeconds(Mathf.FloorToInt(mSeconds)).ToString();
		mClearMessage.gameObject.SetActive(true);
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	void Update()
	{
		mSeconds += Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.S))
		{
			Restart();
		}
		GetComponent<Rigidbody>().AddTorque(Vector3.back * Input.GetAxis("Horizontal"), ForceMode.VelocityChange);
		Camera.main.transform.parent.position = transform.position;
	}
}
