using Animators;
using Inputs;
using Physics;
using UnityEngine;

namespace Characters.Zombie
{
	public class Zombie : MonoBehaviour
	{
		[SerializeField] private RigidbodyToggle _rigidbodyToggle;
		[SerializeField] private ZombieAnimator _animator;
		[SerializeField] private ZombieMovement _zombieMovement;

		private void Start()
		{
			InputHandler.OnInputForward += InputHandlerOnInputForwardHandler;
			InputHandler.OnInputStopForward += InputHandlerOnInputStopForwardHandler;
			InputHandler.OnInputAttack += InputHandlerOnInputAttackHandler;
			InputHandler.OnInputDie += InputHandlerOnInputDieHandler;
		}


		private void OnDestroy()
		{
			InputHandler.OnInputForward -= InputHandlerOnInputForwardHandler;
			InputHandler.OnInputStopForward -= InputHandlerOnInputStopForwardHandler;
			InputHandler.OnInputAttack -= InputHandlerOnInputAttackHandler;
			InputHandler.OnInputDie -= InputHandlerOnInputDieHandler;
		}

		private void InputHandlerOnInputDieHandler()
		{
			_rigidbodyToggle.ToggleRigidbodyKinematic();
		}

		private void InputHandlerOnInputAttackHandler()
		{
			var attackNumber = Random.Range(0, 2);
			if (attackNumber == 0)
			{
				_animator.SetAttackClaw();
			}
			else
			{
				_animator.SetAttackSpecial();
			}
		}

		private void InputHandlerOnInputStopForwardHandler(float speed)
		{
			_animator.SetSpeed(speed);
		}

		private void InputHandlerOnInputForwardHandler(float speed)
		{
			_animator.SetSpeed(speed);
		}
	}
}