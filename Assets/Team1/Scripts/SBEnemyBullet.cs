using UnityEngine;

namespace MatrixJam.Team1
{
    public class SBEnemyBullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 10f;
        
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
            }
            
            Destroy(gameObject);
        }
    }
}
