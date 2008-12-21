using System.Collections.Generic;
using System.Linq;
using FrigginAwesome;
using Kelly.Math;

namespace Kelly {
	public class NaiveScene : IIntersectable {
		public NaiveScene() {
			_geometry = new List<IIntersectable>();
		}

		private readonly IList<IIntersectable> _geometry;

		public Intersection Intersects(Ray ray) {
			return _geometry
				.Select(g => g.Intersects(ray))
				.OrderBy(isec => isec == null? double.PositiveInfinity : isec.Distance)
				.FirstOrDefault();
		}

		public void AddGeometry(IIntersectable geometry) {
			Ensure.That("geometry", geometry).IsNotNull();

			_geometry.Add(geometry);
		}
	}
}
