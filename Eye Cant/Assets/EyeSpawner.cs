using System;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class EyeSpawner : MonoBehaviour
 {
     public GameObject eyePrefab;
 
     private void Start()
     {
         StartCoroutine(SpawnRoutine());

         for (int i = 0; i < 100; i++) {
             Spawn();
         }
     }
 
     IEnumerator SpawnRoutine()
     {
         while (true) {
             yield return new WaitForSeconds(0.1f);
            Spawn();
         }
     }

     private void Spawn()
     {
         var go = Instantiate(eyePrefab, transform.position, Quaternion.identity);
         go.transform.SetParent(this.transform);
     }
 }