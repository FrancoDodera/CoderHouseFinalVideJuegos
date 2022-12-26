using UnityEngine;
using UnityEngine.SceneManagement;

public class doorActivationlvl2 : MonoBehaviour
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
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene ("Lvl 3");
            }
		}
	}

}