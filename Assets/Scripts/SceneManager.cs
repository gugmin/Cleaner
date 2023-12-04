using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EazySceneLoad()
    {
        SceneManager.LoadScene("GugminScene");
    }

    public void NormalSceneLoad()
    {
        SceneManager.LoadScene("Lsc_NormalScene");
    }

    public void HardSceneLoad()
    {
        SceneManager.LoadScene("Lsc_HardScene");
    }
}
