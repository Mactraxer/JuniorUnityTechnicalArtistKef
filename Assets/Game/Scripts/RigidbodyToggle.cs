using Animators;
using System.Collections.Generic;
using UnityEngine;

namespace Physics
{
	public class RigidbodyToggle : MonoBehaviour
	{
		[SerializeField] private GameObject _target;
		[SerializeField] private ZombieAnimator _animator;

		private List<Rigidbody> _rigidbodies = new();
		private bool _isPhysicsEnable = false;

		private void Start()
		{
			FindRigidbodies(_target.transform);
		}

		private void FindRigidbodies(Transform target)
		{
			_rigidbodies.AddRange(target.GetComponentsInChildren<Rigidbody>());
			ToggleRigidbodyKinematic();
		}

		public void ToggleRigidbodyKinematic()
		{
			foreach(var rigidbody in _rigidbodies)
			{
				rigidbody.isKinematic = !_isPhysicsEnable;
			}

			_animator.ToggleActive(!_isPhysicsEnable);
			_isPhysicsEnable = !_isPhysicsEnable;
		}
	}
}