using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : Trigger
{
    [SerializeField] float despawnTimer = 10f;
    [SerializeField] GameObject entity;
    [SerializeField] Vector2 startPos;
    private GameObject clone;
    private bool spawned;
    [SerializeField] bool respawns = false;
    [SerializeField] float respawnTime = 3f;
    private float elapsed = 0f;

 
 
 //And function itself
     IEnumerator SpawnDespawn(){
        clone = Instantiate(entity, startPos, Quaternion.identity);
        clone.gameObject.SetActive(true);
        yield return new WaitForSeconds(despawnTimer); 
        Destroy(clone);
        this.gameObject.SetActive(false);
 }
    public override void Action() {
        if(!spawned && !respawns) {
            Debug.Log("spawn");
            StartCoroutine(SpawnDespawn());
        }
        else if(respawns) {
            if(elapsed < respawnTime) {
                elapsed = 0;
                
            StartCoroutine(SpawnDespawn());
            }
        }
    }
    // Start is called before the first frame update

}
