using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSpaceIcons : MonoBehaviour
{
    public GameObject enter;

    public void enterMunch()
    {
        enter.SetActive(false);
        SceneManager.LoadScene("InMunch");
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
