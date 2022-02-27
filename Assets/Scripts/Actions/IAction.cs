using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts {
	public interface IAction {
		public MonoBehaviour mono { get; }
		public UnityEvent sucess { get; }
		public UnityEvent error { get; }
		public UnityEvent reset { get; }

		public void ResetAction();
	}
}