using System.Collections.Generic;
using FrigginAwesome;
using Kelly.Math;

namespace Kelly {
	public class NaiveScene : IScene {
		public NaiveScene() {
			_geometry = new List<IIntersectable>();
			_lights = new List<ILight>();
		}

		private readonly ICollection<IIntersectable> _geometry;
		private readonly ICollection<ILight> _lights;

		public Intersection FindClosestIntersectionWith(Ray ray) {
			Intersection closest = null;

			foreach(var intersectable in _geometry) {
				var intersection = intersectable.FindClosestIntersectionWith(ray);

				if (closest == null || (intersection != null && intersection.Distance < closest.Distance)) {
					closest = intersection;
				}
			}

			return closest;
		}

		public void AddGeometry(IIntersectable geometry) {
			Ensure.That("geometry", geometry).IsNotNull();

			_geometry.Add(geometry);
		}

		public void AddLight(ILight light) {
			Ensure.That("light", light).IsNotNull();

			_lights.Add(light);
		}

		public IEnumerable<ILight> Lights {
			get { return _lights; }
		}
	}
}
