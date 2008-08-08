using System.Collections.Generic;
using FrigginAwesome;
using Kelly.Math;

namespace Kelly {
	public class NaiveScene : IScene {
		public NaiveScene() {
			_geometry = new List<RenderableGeometry>();
		}

		private IList<RenderableGeometry> _geometry;

		public Intersection IntersectWith(Ray ray) {
			float closestDistance = float.PositiveInfinity;
			RenderableGeometry closestGeometry = null;

			foreach (var renderable in _geometry) {
				float distance;

				if (renderable.Geometry.IntersectWith(ray, out distance)) {
					if (distance < closestDistance) {
						closestDistance = distance;
						closestGeometry = renderable;
					}
				}
			}

			return closestGeometry == null
			    ? null
				: new Intersection(ray, closestDistance, closestGeometry.Material);
		}

		public void AddGeometry(RenderableGeometry geometry) {
			Ensure.That("geometry", geometry).IsNotNull();

			_geometry.Add(geometry);
		}
	}
}
