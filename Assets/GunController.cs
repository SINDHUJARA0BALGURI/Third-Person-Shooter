using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Range(0, 2)]
    public float FireRate = 1f;
    [SerializeField]
    [Range(0, 1)]
    int damage = 1;
    private float timer;
    [SerializeField]
    Transform firepoint;
    AudioClip audio;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= FireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0;
                FireGun();

            }
        }
    }
    private void FireGun()
    {
        // muzzleParticle.Play();
        //audio.Play();
        
       

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        Debug.DrawRay(ray.origin,ray.direction * 100, Color.red, 2f);
        
        
        //Ray ray = new Ray(firepoint.position, firepoint.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            var health = hit.collider.gameObject.GetComponent<Health>();
            
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}