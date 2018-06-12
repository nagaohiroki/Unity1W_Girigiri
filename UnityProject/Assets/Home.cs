using UnityEngine;
public class Home : MonoBehaviour
{
	void OnTriggerEnter(Collider inColl)
	{
		var dog = inColl.gameObject.GetComponent<Dog>();
		if(dog == null)
		{
			return;
		}
		dog.StageClear();
	}
}
