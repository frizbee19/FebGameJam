using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRayHit : MonoBehaviour
{

    public RaycastHit2D hit;
    public Ray ray;
    private int counter;

    public GameObject followCam;
    public Camera staticCam;
    private bool cam = false;
    [Range(0.5f, 25f)] public float smoothSpeed = 1f;
    [Range(1, 10)] public float rayLength = 4f;
    private float angleStep = 4;

    public Transform target;
    public Rigidbody2D rb;
    private Vector3 offset;
    private LayerMask layerMask;
    private Vector3 save;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        layerMask = LayerMask.GetMask("Background");
        save = Vector3.zero;
    }

    void FixedUpdate()
    {
        offset = Vector3.zero;
        for (int i = 1; i <=angleStep; i++)
        {
            var rayAngle = Quaternion.AngleAxis((360f / angleStep) * i, target.forward) * target.up;
            hit = Physics2D.Raycast(target.position, rayAngle, rayLength, layerMask);
            
            if (hit)
            {
                offset += (rayAngle * rayLength) - (rayAngle * hit.distance);
                //Debug.Log(hit.point);
            }
            Vector3 smoothedPos = Vector3.Lerp(transform.position, new Vector3(((target.position.x - offset.x)*rayLength), (target.position.y - offset.y)*smoothSpeed/5, -65f), smoothSpeed * Time.fixedDeltaTime);

            float x = Mathf.Abs(target.position.x - smoothedPos.x);
            float y = Mathf.Abs(target.position.y - smoothedPos.y);
            
            if (x < 4 && y < 3)
            {
                save = smoothedPos;
                //followCam.transform.position = smoothedPos;
            }
            else if (x < 4)
            {
                //followCam.transform.position =new Vector3((save.x + target.position.x),smoothedPos.y, -1.3f);
            }else if (y < 3)
            {
                //followCam.transform.position = new Vector3((save.x + target.position.x), smoothedPos.y, -1.3f);
            }
            else
            {

            }

        }
    }
    //Vector3 smoothedPos = Vector3.Lerp(transform.position, new Vector3((target.position.x - offset.x)*rayLength, target.position.y - offset.y, -1.3f), smoothSpeed * Time.fixedDeltaTime);

    // Update is called once per frame
    void Update()
    {



        /*hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 4f);
        if (hit)
        {
            Debug.Log(" Hit a wall "+ hit.collider.name);
            Debug.Log(hit.distance);
            //staticCam.enabled = true;
            //followCam.enabled = false;
            counter = 0;
            //cam = true;
            
        }
        else if (cam && counter == 30)
        {
            staticCam.enabled = false;
            followCam.enabled = true;
            counter = 0;
            cam = false;
            Debug.Log("");
        }
        counter++;*/
    }
}
