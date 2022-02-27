using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingWallTrigger : MonoBehaviour
{
    public GameObject cam;
    public GameObject cat;
    public BoxCollider2D box;
    private int counter = 0;
    [Range(-25f, 25f)] public float camOffset = 10f;
    [Range(-15f, 15f)] public float catOffset = 5f;
    [Range(5, 180)] public int countOffset = 10;
    private Vector3 moveCam;
    private Vector3 moveCat;
    private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        moveCam = new Vector3(camOffset, 0, 0);
        moveCat = new Vector3(catOffset, 0, 0);
        layerMask = LayerMask.GetMask("Player");
    }


    // Update is called once per frame
    void Update()
    {
        counter++;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        float xe = cat.transform.position.x;
        float goalx = box.transform.localPosition.x;
        if (xe < goalx && counter >= countOffset && (col.gameObject.tag == "Player"))
        {
            cam.transform.position += moveCam;
            cat.transform.position += moveCat;
            counter = 0;
        }
        else if (xe >= goalx && counter > countOffset && (col.gameObject.tag == "Player"))
        {
            cam.transform.position -= moveCam;
            cat.transform.position -= moveCat;

            counter = 0;
        }
    }
}
