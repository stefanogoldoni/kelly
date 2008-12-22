using System.Collections.Generic;
using System.Linq;
using FrigginAwesome;
using FrigginAwesome.Extensions;
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
			return _geometry
				.Select(g => g.FindClosestIntersectionWith(ray))
				.WhereNotNull()
				.OrderBy(isec => isec.Distance)
				.FirstOrDefault();
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
