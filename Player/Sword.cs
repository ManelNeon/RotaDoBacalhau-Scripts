using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Sword : MonoBehaviour
{
    [SerializeField] private float range = 20f;
    [SerializeField] private float verticalRange = 20f;
    [SerializeField] private float horizontalRange = 20f;


    [SerializeField] private float damage;

    [SerializeField] private float gunRate;
    private float nextTimeToFire;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    public AudioSource slicing;
    public AudioSource sheathe;
    public AudioSource deathSound;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;
    public GameObject sword;
    public GameObject gun;
    public GameObject player;

    int maxAmmo ;

    public int ammo ;

    void Start()
    {
        sheathe.Stop();
        sheathe.Play();
        maxAmmo = gun.GetComponent<Gun>().maxAmmo;
        
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(horizontalRange, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
        CanvasManager.Instance.UpdateAmmo(ammo);
        CanvasManager.Instance.UpdateWeapon(2);
    }

    void Update()
    {
        gun.GetComponent<Gun>().ammo = ammo;
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sword.SetActive(false);
            ammo = gun.GetComponent<Gun>().ammo;
            gun.SetActive(true);
            CanvasManager.Instance.UpdateWeapon(1);
        }
    }

    private void Fire()
    {
        slicing.Stop();
        slicing.Play();

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
