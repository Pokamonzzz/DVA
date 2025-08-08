using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSpaceIcons : MonoBehaviour
{
    public GameObject enter;
    public GameObject exit;

    public void EnterMunch()
    {
        enter.SetActive(false);
        SceneManager.LoadScene("InMunch");
    }

    public void ExitMunch()
    {
        exit.SetActive(false);
        SceneManager.LoadScene("OutMunch");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
