using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedWallTrigger : MonoBehaviour
{
    public RaycastHit2D hit;
    public Ray ray;
    private LayerMask layerMask;
    private float angleStep = 8;
    public Transform target;
    [Range (1f,10f)]public float rayLength = 10f;
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
            float xe = Mathf.Abs(hit.point.x - target.position.x);
            float ye = hit.point.y;
            float goalx = Mathf.Abs(target.localPosition.x / box.size.x);
            if (hit && counter >=150)
            {
                if (xe >= goalx)
                {
                    Debug.Log("Counter Right "+counter);
                    Debug.Log(xe);
                    Debug.Log("XE " + xe);
                    Debug.Log("Goal " + goalx);
                    camMove.transform.position = new Vector3(camMove.transform.position.x - 22f, camMove.transform.position.y, -1.3f);
                    catMove.transform.position = new Vector3(catMove.transform.position.x - 10f, catMove.transform.position.y+1f, 0);
                    counter = 0;
                }
                else if (xe < goalx)
                {
                    Debug.Log("Counter Left " + counter);
                    Debug.Log("XE "+xe);
                    Debug.Log("Goal "+ goalx);
                    camMove.transform.position = new Vector3(camMove.transform.position.x + 22f, 0,-1.3f);
                    catMove.transform.position = new Vector3(catMove.transform.position.x + 10f, catMove.transform.position.y +1f,0);
                    counter = 0;
                }
            }
            counter++;
        }

        void OnTriggerEnter2D(Collider2D col)
        {

        }
    }
}
