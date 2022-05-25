using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public WeaponObject weaponSetting; 

    [SerializeField]
    WeaponObject.weaponTypeList _weaponType;

    [SerializeField]
    Transform[] _firepoint;

    [SerializeField]
    GameObject _bulletPrefab;

    [SerializeField]
    float _bulletForce = 20f;

    [SerializeField]
    float _fireRate = 0.5f;

    float _canFire = 0f;

    [SerializeField]
    int _bulletDamage = 25;

    public int _ammo = 50;

    [SerializeField]
    GameObject _weaponCanvas;

    [SerializeField]
    Text _ammoText;

    void Start()
    {
        _canFire = 0f;
        _bulletPrefab = weaponSetting.bulletPrefab;
        _bulletForce = weaponSetting.bulletForce;
        _fireRate = weaponSetting.fireRate;
        _bulletDamage = weaponSetting.bulletDamage;
        if(_ammo == 0)
            _ammo = weaponSetting.ammo;
        if (_ammoText != null)
            _ammoText.text = _ammo.ToString();
    }

    public void AtemptoShot()
    {
        if ((Time.time > _canFire) && (_ammo > 0))
        {
            _canFire = Time.time + _fireRate;
            
            Shoot(_bulletPrefab, _firepoint, _bulletForce);

            if (_ammoText != null)
            {
                _ammo--;
                UpdateAmmoText();
            }
        }
    }

    void Shoot()
    {
        for (int i = 0; i < _firepoint.Length; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firepoint[i].position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firepoint[i].up * _bulletForce, ForceMode2D.Impulse);
        }
    }

    public void UpdateAmmoText()
    {
        _ammoText.text = _ammo.ToString();
    }

    protected void Shoot(GameObject bulletPrefab, Transform[] _firepoint, float bulletForce)
    {
        for (int i = 0; i < _firepoint.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, _firepoint[i].position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firepoint[i].up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
