using MXX;
using PGW;
using CY;
using HYB;
using YNB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MXX{
	public class SPBall : MonoBehaviour 
	{
		public GameObject dieParitcle;
		bool beenGet = false;
		float moveSpeed = 0.5f;
		float addMoveSpeed = 3f;
		Transform target;
		Vector3 targetPos;

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				beenGet = true;
				target = other.GetComponent<CharacterBehaviour>().hitPoint.transform;
			}
		}

		void Update()
		{
			if (beenGet)
			{
				targetPos = target.position;
				this.transform.LookAt (targetPos);
				moveSpeed += addMoveSpeed * Time.deltaTime;
				transform.Translate (moveSpeed*Vector3.forward*Time.deltaTime,Space.Self);
				if (Vector3.Distance(target.transform.position,this.transform.position)<0.05f)
				{
					ActorPropertiesFinal.GetInstance.ChangeSP(0.5f);
					Instantiate (dieParitcle,target.transform);
					Destroy (this.gameObject);
				}
			}
		}

	}
}
