using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointer : MonoBehaviour
{

    // private GameObject[] enemies;
    List<GameObject> enemies = new List<GameObject>();
    private GameObject nearbyTarget;
    private Transform pointerTransform;
    private Transform player;
    private float nearbyDistance;
    private GameObject pointerArrow;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(LateStart());
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pointerArrow = GameObject.Find("Arrow");
        pointerArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(HelpVariables.doneNothing >=5f){
            Debug.Log(enemies.Count);
            findNearbyTarget();
        //     Vector3 dir = (nearbyTarget.transform.position - player.position).normalized;
        // float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
        // pointerArrow.localEulerAngles = new Vector3(0,0,angle);
        }
        else
        pointerArrow.SetActive(false);
    }

    void findNearbyTarget(){
        pointerArrow.SetActive(true);
        if(nearbyTarget == null){
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            nearbyDistance = float.MaxValue;
            foreach (GameObject enemy in enemies)
            {
                if(Vector3.Distance(player.position, enemy.transform.position)<nearbyDistance)
                {
                    nearbyDistance = Vector3.Distance(player.position, enemy.transform.position);
                    nearbyTarget = enemy;

                }
            }
            enemies.Clear();
        }
        else{
        Vector3 dir = (nearbyTarget.transform.position - transform.position);
        float angle = ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360  );
        // pointerArrow.localEulerAngles = new Vector3(0,0,angle);
        RaycastHit ray;
         Physics.Raycast(transform.position, dir,out ray);
        // transform.rotation = Quaternion.AngleAxis(angle,Vector3.left);
        // transform.localEulerAngles = new Vector3(0,0,angle);
        // transform.LookAt(dir);
        if(ray.collider!=null)
            pointerArrow.transform.position = ray.point;
        }
        
    }

    IEnumerator LateStart(){
        yield return new WaitForSeconds(3);
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }
}
