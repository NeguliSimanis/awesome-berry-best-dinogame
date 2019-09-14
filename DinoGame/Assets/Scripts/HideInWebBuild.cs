using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInWebBuild : MonoBehaviour
{
    [SerializeField]
    bool showOnlyInWeb = false;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_WEBGL
        if (showOnlyInWeb)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

    #else
        if (showOnlyInWeb)
            gameObject.SetActive(true);
    #endif
    }

}
