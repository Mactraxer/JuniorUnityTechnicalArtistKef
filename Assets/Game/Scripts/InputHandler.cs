using System;
using UnityEngine;

namespace Inputs
{
	public class InputHandler : MonoBehaviour
	{
		public static event Action<float> OnInputForward;

		public static event Action<float> OnInputStopForward;
		public static event Action OnInputDie;

		public static event Action OnInputAttack;

		private void Update()
		{
			if(Input.GetKey(KeyCode.W))
			{
				OnInputForward?.Invoke(Input.GetAxis("Vertical"));
			}
			else
			{
				OnInputStopForward?.Invoke(Input.GetAxis("Vertical"));
			}

			if(Input.GetKeyDown(KeyCode.D))
			{
				OnInputDie?.Invoke();
			}

			if(Input.GetMouseButtonDown(0))
			{
				OnInputAttack?.Invoke();
			}
		}
	}
}