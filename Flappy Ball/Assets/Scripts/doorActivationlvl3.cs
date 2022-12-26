using UnityEngine;
using UnityEngine.SceneManagement;

public class doorActivationlvl3 : MonoBehaviour
{   
    public GameObject textDetected;
	void Start()
	{
	    textDetected.SetActive(false);
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.CompareTag("Player"))
		{
			textDetected.SetActive(true);
		}
	}

}
