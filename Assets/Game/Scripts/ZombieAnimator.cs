using UnityEngine;

namespace Animators
{
	[RequireComponent(typeof(Animator))]
	public class ZombieAnimator : MonoBehaviour
	{
		private static readonly int SpeedParameter = Animator.StringToHash("Speed");
		private static readonly int AttackClawTriggerParameter = Animator.StringToHash("AttackClawTrigger");
		private static readonly int AttackSpecialTriggerParameter = Animator.StringToHash("AttackSpecialTrigger");

		private Animator _animator;

		private void Start()
		{
			_animator = GetComponent<Animator>();
		}

		public void SetSpeed(float value)
		{
			_animator.SetFloat(SpeedParameter, value);
		}

		public void SetAttackClaw()
		{
			_animator.SetTrigger(AttackClawTriggerParameter);
		}

		public void SetAttackSpecial()
		{
			_animator.SetTrigger(AttackSpecialTriggerParameter);
		}

		public void ToggleActive(bool active)
		{
			_animator.enabled = active;
		}
	}
}