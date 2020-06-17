using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float nextFire = 1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    void Start()
    {

        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if(_spawnManager == null)
		{
            Debug.LogError("Spawn Manager is NULL");
		}
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
            PlayerAttack();
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.22f, 9.22f), Mathf.Clamp(transform.position.y, -1f, 8), 0);
    }
    void PlayerAttack()
    {
        nextFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, .735f, 0), Quaternion.identity);        
    }
    public void Damage()
	{
        _lives -= 1;
        
        if(_lives < 1)
		{
            //communicate with spawn manager
            _spawnManager.OnPlayerDeath();//find the GO and get component
            //let it know that player is dead
            Destroy(this.gameObject);
		}
	}
}
