using UnityEngine;
using UnityEngine.Events;
public class BoxTrigger : MonoBehaviour
{
	public UnityEvent mEvent;
	void OnTriggerEnter(Collider inColl)
	{
		if(mEvent != null)
		{
			mEvent.Invoke();
		}
	}
}
