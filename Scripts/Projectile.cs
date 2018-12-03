using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public int damageDefault;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().takeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
