using UnityEngine;

namespace MatrixJam.Team1
{
    public class SBEnemyBullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 10f;

        public int exit;
        
        private void Update()
        {
            transform.position += transform.forward * (Time.deltaTime * bulletSpeed);
        }

        private void OnCollisionEnter(Collision other)
        {
            var temp = other.gameObject.GetComponent<SBPlayerController>();
            if (temp != null)
            {
                temp.Kill();
                Invoke("DelayExit", 1.5f);
            }
            
            gameObject.SetActive(false);
        }

        private void DelayExit()
        {
            foreach (var exitObj in FindObjectsOfType<Exit>())
            {
                if (exitObj.id == exit)
                {
                    exitObj.EndLevel();
                    return;
                }
            }
        }
    }
}
