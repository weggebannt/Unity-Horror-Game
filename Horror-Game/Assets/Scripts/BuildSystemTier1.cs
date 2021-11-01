using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystemTier1 : MonoBehaviour
{
    public GameObject spawner;
    public GameObject pre;

    public Transform reset;
    public float moveSpeed = 10;
    public float rotspeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        reset = spawner.transform;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.F)){
           spawner.transform.Translate(new Vector3(0,moveSpeed*Time.deltaTime, 0));
       }else if(Input.GetKey(KeyCode.C)){
            spawner.transform.Translate(new Vector3(0,-moveSpeed*Time.deltaTime, 0));
       }

       if(Input.GetKey(KeyCode.R)){
          spawner.transform.Rotate(new Vector3(0,rotspeed*Time.deltaTime, 0));
       }else if(Input.GetKey(KeyCode.E)){
           spawner.transform.Rotate(new Vector3(0,-rotspeed*Time.deltaTime, 0));
       }
       
       if(Input.GetButtonDown("Fire1")){
            GameObject g = Instantiate(pre, spawner.transform.position, spawner.transform.rotation);

            spawner.transform.position = reset.position;
            spawner.transform.rotation = reset.rotation;
       }
    }
}
