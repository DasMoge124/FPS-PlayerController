using UnityEngine;

public class Gun : MonoBehaviour
{
	public float damage = 10f;
	public float range = 100f;
	public float ammo = 50f;
	
	public Camera fpsCam;
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0f)
		{
			Shoot();
			ammo --;
		}
		if (Input.GetKeyDown(KeyCode.R) && ammo <= 0)
		{
			ammo = 50f;
		}
    }
	void Shoot ()
	{
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
			
			Target target= hit.transform.GetComponent<Target>();
			if (target != null)
			{
				target.TakeDamage(damage);
			}
		}
	}
}
