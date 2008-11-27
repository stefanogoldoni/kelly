﻿using Kelly.Math;

namespace Kelly {
	public class DebugTracingAlgorithm : ITracingAlgorithm {
		public Color DetermineRayColor(Ray ray, IIntersectable scene) {
			var intersection = scene.Intersects(ray);

			return intersection == null ? Color.Black : intersection.Color;
		}
	}
}
