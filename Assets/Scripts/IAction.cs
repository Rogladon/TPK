using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts {
	public interface IAction {
		public UnityEvent sucess { get; }
		public UnityEvent error { get; }

		public void ResetAction();
	}
}