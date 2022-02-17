using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfLifeAndTests
{
    public sealed class GameController : MonoBehaviour
    {
        public delegate void OnStartButtonPressed();

        public event OnStartButtonPressed StartButtonPressed;
        public void Awake()
        {

        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartButtonPressed?.Invoke();
            }
        }
    }
}
