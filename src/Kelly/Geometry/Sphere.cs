using System;
using System.Collections.Generic;
using Kelly.Math;

namespace Kelly.Geometry {
	public class Sphere : IIntersectable {
		public Sphere(Point position, float radius) {
			Position = position;
			Radius = radius;
		}

		public Point Position { get; private set; }
		public float Radius { get; private set; }

		public bool IntersectWith(Ray ray, out float distance) {
			var between = ray.Origin - this.Position;

			float b = Vector.DotProduct(between, ray.Direction);
			float c = between.SquaredLength - (Radius * Radius);
			float d = b * b - c;

			if (d <= 0) {
				distance = float.PositiveInfinity;
				return false;
			}

			distance = (b > 0) 
				? -b + (float)System.Math.Sqrt(d) 
				: -b - (float)System.Math.Sqrt(d);

			return true;
		}
	}
}
