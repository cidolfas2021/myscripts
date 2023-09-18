using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightingfix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientLight = new Color32(255, 255, 255, (byte)(.4f * 255) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
