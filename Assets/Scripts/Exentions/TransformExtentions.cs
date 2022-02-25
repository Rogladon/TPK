using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class TransformExtentions {
	public static IEnumerable<Transform> GetChildrens(this Transform t) {
		List<Transform> childrens = new List<Transform>();
		for(int i = 0; i < t.childCount; i++) {
			childrens.Add(t.GetChild(i));
		}
		return childrens;
	}
}
