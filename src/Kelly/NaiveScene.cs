using System.Collections.Generic;
using System.Linq;
using FrigginAwesome;
using Kelly.Math;
using Kelly.Geometry;

namespace Kelly {
	public class NaiveScene : IIntersectable {
		public NaiveScene() {
			_geometry = new List<RenderableGeometry>();
		}

		private readonly IList<RenderableGeometry> _geometry;

		public Intersection Intersects(Ray ray) {
			Intersection closestIntersection = null;

			foreach (var renderable in _geometry) {
				var intersection = renderable.Geometry.Intersects(ray);

				if (closestIntersection == null 
					|| (intersection != null && intersection.Distance < closestIntersection.Distance)) {

					closestIntersection = intersection;
				}
			}

			return closestIntersection;
		}

		public void AddGeometry(RenderableGeometry geometry) {
			Ensure.That("geometry", geometry).IsNotNull();

			_geometry.Add(geometry);
		}
	}
}
