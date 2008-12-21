using Kelly.Materials;
using Kelly.Math;

namespace Kelly {
	public class RenderableGeometry : IIntersectable {
		public RenderableGeometry(IIntersectable geometry, IMaterial material) {
			Geometry = geometry;
			Material = material;
		}

		public IIntersectable Geometry { get; private set; }
		public IMaterial Material { get; private set; }

		public Intersection Intersects(Ray ray) {
			var intersection = Geometry.Intersects(ray);

			if (intersection == null)
				return null;

			return new Intersection(intersection.Ray, intersection.Distance, Material);
		}
	}
}
