using Kelly.Materials;

namespace Kelly {
	public class RenderableGeometry {
		public RenderableGeometry(IIntersectable geometry, IMaterial material) {
			Geometry = geometry;
			Material = material;
		}

		public IIntersectable Geometry { get; private set; }
		public IMaterial Material { get; private set; }
	}
}
