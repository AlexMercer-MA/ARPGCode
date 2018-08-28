using MXX;
using PGW;
using CY;
using HYB;
using YNB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MXX
{
	public class DontDestroyOnLoad : MonoBehaviour 
	{
		void Awake () 
		{
			DontDestroyOnLoad(this.gameObject);
		}
	}
}
