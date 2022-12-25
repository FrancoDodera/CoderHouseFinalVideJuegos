
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
  
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("Lvl 1");
    }

    public void Level()
    {
        SceneManager.LoadScene("Level");
    }

    public void niveles(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
}


