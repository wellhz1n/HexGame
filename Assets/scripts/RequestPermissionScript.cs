using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class RequestPermissionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite) && Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {

        }
        else
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            Permission.RequestUserPermission(Permission.ExternalStorageRead);




        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
