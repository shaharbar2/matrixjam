using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatrixJam.Team1
{
    public class SBEnemySpawner : MonoBehaviour
    {
        [SerializeField] private SBEnemyController enemyController;
        
        [SerializeField] private float nextSpawnTime = 0;
        [SerializeField] private float timer;
        [SerializeField] private AnimationCurve animCurve;
        [SerializeField] private float totalTimer;
        [SerializeField] private float boardSize = 125f;

        
        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            totalTimer += Time.deltaTime;
            
            if (timer >= nextSpawnTime)
            {
                timer = 0;
                Instantiate(enemyController,new Vector3(Random.Range(-boardSize, boardSize), 0, Random.Range(-boardSize, boardSize)), Quaternion.identity);
                
                nextSpawnTime = animCurve.Evaluate(totalTimer);
            }
        }
    }
}
