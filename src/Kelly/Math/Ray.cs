using System;

namespace Kelly.Math {
	public class Ray {
		public Ray(Point origin, Vector direction) {
			if (!direction.IsUnit) {
				throw new ArgumentException("Rays can only be constructed with unit-vector directions.");
			}

			Origin = origin;
			Direction = direction;
		}

		public Point Origin { get; private set; }
		public Vector Direction { get; private set; }
	}
}
