using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawn;
    private float nextAttackTime;

    private void Start()
    {
        nextAttackTime = 0;
    }
    private void Update()
    {
        bullet.transform.localScale = new Vector3(0.8f * Upgrades.PierceCounter, 0.2f * Upgrades.DamageCounter, 1f);
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                FindObjectOfType<ScreenShaker>().shake = true;
                Shooting();
                nextAttackTime = Time.time + 1f / (Upgrades.FireRateCounter + 1f);
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 difference = -Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.position;
        difference.Normalize();
        float rotaionAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotaionAngle);

    }
    void Shooting()
    {
        GameObject projectile = (GameObject)Instantiate(bullet, spawn.transform.position, Quaternion.identity);
        projectile.transform.right = transform.right;
        if(Upgrades.ExtraBulletCounter >= 2)
        {
            GameObject projectile2 = (GameObject)Instantiate(bullet, spawn.transform.position, Quaternion.identity);
            projectile2.transform.right = transform.right + projectile2.transform.up / 10f;
        }
        if (Upgrades.ExtraBulletCounter >= 3)
        {
            GameObject projectile3 = (GameObject)Instantiate(bullet, spawn.transform.position, Quaternion.identity);
            projectile3.transform.right = transform.right - projectile3.transform.up / 10f;
        }
    }
}