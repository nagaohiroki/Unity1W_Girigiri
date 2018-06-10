using UnityEngine;
public class ClearMessage : MonoBehaviour
{
	void OnTriggerEnter(Collider inColl)
	{
		var dog = inColl.gameObject.GetComponent<Dog>();
		if(dog == null)
		{
			return;
		}
		dog.Clear();
	}
}
