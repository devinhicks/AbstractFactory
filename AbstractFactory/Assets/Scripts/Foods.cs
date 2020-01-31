using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foods : MonoBehaviour
{
    float rot = 25.0f;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, rot * Time.deltaTime, 0);
    }
}
