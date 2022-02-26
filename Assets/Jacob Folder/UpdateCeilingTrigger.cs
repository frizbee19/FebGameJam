using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedCeilingTrigger : MonoBehaviour
{
    public RaycastHit2D hit;
    public Ray ray;
    private LayerMask layerMask;
    private float angleStep = 8;
    public Transform target;
    [Range(1f, 10f)] public float rayLength = 10f;
    public BoxCollider2D box;
    public GameObject camMove;
    public GameObject catMove;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Player");

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= angleStep; i++)
        {
            var rayAngle = Quaternion.AngleAxis((360f / angleStep) * i, target.forward) * Vector3.left;
            hit = Physics2D.Raycast(target.position, rayAngle, rayLength, layerMask);
            float xe = Mathf.Abs(hit.point.x - target.localPosition.x);
            float ye = Mathf.Abs(hit.point.y - target.localPosition.y);
            float goalx = Mathf.Abs(target.position.x * box.size.x);
            float goaly = Mathf.Abs(target.position.y * box.size.y);
            if (hit && counter >= 150)
            {
                if (ye >=1)
                {
                    Debug.Log("Counter Up " + counter);
                    Debug.Log("YE " + ye);
                    Debug.Log("Goaly " + goaly);
                    Debug.Log(target.position.y * box.size.y);
                    camMove.transform.position = new Vector3(camMove.transform.position.x + 22f, camMove.transform.position.y, -1.3f);
                    catMove.transform.position = new Vector3(catMove.transform.position.x + 10f, catMove.transform.position.y + 1f, 0);
                    xe = 0;
                    ye = 0;
                    goalx = 0;
                    goaly = 0;
                    counter = 0;
                }
                else 

                {
                    Debug.Log("Counter Down " + counter);
                    Debug.Log("YE " + ye);
                    Debug.Log("Goaly " + goaly);
                    camMove.transform.position = new Vector3(camMove.transform.position.x - 22f, catMove.transform.position.y + 1.0f, -1.3f);
                    catMove.transform.position = new Vector3(catMove.transform.position.x - 10f, catMove.transform.position.y, 0);
                    counter = 0;
                    xe = 0;
                    ye = 0;
                    goalx = 0;
                    goaly = 0;
                }
            }
            counter++;
        }
    }
}