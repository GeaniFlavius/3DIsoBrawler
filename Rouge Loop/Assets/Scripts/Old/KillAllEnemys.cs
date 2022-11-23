using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllEnemys : MonoBehaviour
{

    // NUR FÜR TESTZWECKE 
    // Tötet alle enemys im SPiel, bool Wert sollte nur kurz angeklickt werden
    //  dann wieder aus
     public bool killed = false;
     int a =0;
    GameObject[] enemies ;
    List<DynamicEnemy> scripts = new List<DynamicEnemy>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart());

    }

    // Update is called once per frame
    void Update()
    {
//         if(enemies.Length>=scripts.Count){
// foreach(GameObject enemy in enemies){
//             a+=1;
//             Debug.Log(a);
//         scripts.Add(enemy.GetComponent<DynamicEnemy>());}
//         }
        if(killed)
            foreach( DynamicEnemy script in scripts){
                script.enemyDies();
                HelpVariables.enemies=0;
            }
    }

    IEnumerator LateStart(){
        yield return new WaitForSeconds(3);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        foreach(GameObject enemy in enemies){
            a+=1;
            Debug.Log(a);
        scripts.Add(enemy.GetComponent<DynamicEnemy>());}
    }

}
