using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoveUp : MonoBehaviour
{
    public GameObject cam;
     [Range(0f, 20f)] public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
            cam.transform.position = new Vector3(0, offset,-1.3f);
    }
}
