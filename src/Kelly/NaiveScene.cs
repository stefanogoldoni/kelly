using System.Collections.Generic;
using System.Linq;
using FrigginAwesome;
using Kelly.Math;

namespace Kelly {
	public class NaiveScene : IIntersectable {
		public NaiveScene() {
			_geometry = new List<RenderableGeometry>();
		}

		private readonly IList<RenderableGeometry> _geometry;

		public Intersection Intersects(Ray ray) {
			return _geometry
				.Select(g => g.Geometry.Intersects(ray))
				.Aggregate((left, right) => 
					left.Distance < right.Distance 
					? left 
					: right);
		}

		public void AddGeometry(RenderableGeometry geometry) {
			Ensure.That("geometry", geometry).IsNotNull();

			_geometry.Add(geometry);
		}
	}
}
