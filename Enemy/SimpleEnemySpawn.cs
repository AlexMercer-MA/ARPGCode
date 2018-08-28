using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawn : MonoBehaviour {

	public GameObject portal;
	public GameObject simpleEnemy;
	public float spawnTimer;
	public float spawnCD = 20f;

	void Start()
	{
		spawnTimer = 15f;
	}

	void Update()
	{
		spawnTimer += Time.deltaTime;
		if (spawnTimer>spawnCD) 
		{
			StartCoroutine("Create");
			spawnTimer = 0f;
		}
	}

	IEnumerator Create ()
	{
		GameObject.Instantiate (portal, gameObject.transform);
		yield return new WaitForSeconds (1f);
		GameObject.Instantiate (simpleEnemy, gameObject.transform);
	}
}
