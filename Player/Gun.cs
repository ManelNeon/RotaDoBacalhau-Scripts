using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float range = 20f;
    [SerializeField] private float verticalRange = 20f;

    [SerializeField] private float damage;

    [SerializeField] private float gunRate;
    private float nextTimeToFire;

    public int maxAmmo;
    public int ammo;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    public AudioSource fire;
    public AudioSource secondweapon;
    public AudioSource deathSound;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;
    public GameObject sword;
    public GameObject gun;
    public GameObject player;
    void Start()
    {
        secondweapon.Stop();
        secondweapon.Play();
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
        CanvasManager.Instance.UpdateAmmo(ammo);
        CanvasManager.Instance.UpdateWeapon(1);
    }

    void Update()
    {
        CanvasManager.Instance.UpdateAmmo(ammo);
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sword.SetActive(true);
            sword.GetComponent<Sword>().ammo = ammo;
            gun.SetActive(false);
            CanvasManager.Instance.UpdateWeapon(2);
        }
    }

    private void Fire()
    {
        fire.Stop();
        fire.Play();

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            if (enemy == null)
            {
                continue;
            }
            else
            {
                if ((enemy.enemyHealth - damage) <= 0)
                {
                    deathSound.Stop();
                    deathSound.Play();
                    player.GetComponent<PlayerHealth>().GiveArmor(10, null);
                }
                enemy.TakeDamage(damage);
            }         
        }

        nextTimeToFire = Time.time + gunRate;

        ammo--;
        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if (ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }
        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
            Destroy(pickup);
        }

        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
