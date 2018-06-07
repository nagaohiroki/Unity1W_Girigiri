using UnityEngine;
public class Player : MonoBehaviour
{
	[SerializeField]
	GameObject mDog;
	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		transform.Translate(horizontal, 0, vertical);
		if(Input.GetKeyDown(KeyCode.Return))
		{
			var go = Instantiate(mDog);
			go.SetActive(true);
			var newRigid = go.GetComponent<Rigidbody>();
			newRigid.MovePosition(transform.position);
		}
	}
}
