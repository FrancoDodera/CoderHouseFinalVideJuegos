using UnityEngine;
using UnityEngine.SceneManagement;

public class doorActivationlvl3 : MonoBehaviour
{   
    public GameObject textDetected;
	public GameObject winImg;
	void Start()
	{
	    textDetected.SetActive(false);
		winImg.SetActive(false);
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.CompareTag("Player"))
		{
			textDetected.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E))
            {
                winImg.SetActive(true);
            }
		}
	}

}
