using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
	public class Tile : MonoBehaviour
	{
		[SerializeField] private GameObject _highlight;
		

		void OnMouseEnter()
        {
			_highlight.SetActive(true);
		}

		void OnMouseDown()
        {
			gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		}

		void OnMouseExit()
		{
			_highlight.SetActive(false);
		}
	}
}