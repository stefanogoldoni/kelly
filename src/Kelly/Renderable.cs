using Kelly.Materials;
using Kelly.Math;

namespace Kelly {
	public class Renderable : IIntersectable {
		public Renderable(IIntersectable geometry, IMaterial material) {
			Geometry = geometry;
			Material = material;
		}

		public IIntersectable Geometry { get; private set; }
		public IMaterial Material { get; private set; }

		public Intersection FindClosestIntersectionWith(Ray ray) {
			var intersection = Geometry.FindClosestIntersectionWith(ray);

			if (intersection == null)
				return null;

			return intersection.WithMaterial(Material);
		}

		public AxisAlignedBoundingBox GetBoundingBox() {
			return Geometry.GetBoundingBox();
		}
	}
}
