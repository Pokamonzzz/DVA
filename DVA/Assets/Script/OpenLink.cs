using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public string url = "https://www.np.edu.sg/about-np/facilities/eat"; // Set the default URL to Google

    public void OpenGoogleLink()
    {
        Application.OpenURL(url);
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
