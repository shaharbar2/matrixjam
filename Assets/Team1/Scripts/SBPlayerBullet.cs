using UnityEngine;

namespace MatrixJam.Team1
{
    public class SBPlayerBullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 10f;

        private void Update()
        {
            transform.position += transform.forward * (Time.deltaTime * bulletSpeed);
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
    }
}
