using Kelly.Geometry;

namespace Kelly {
	public interface IRenderer {
		void RenderScene(IRenderingSurface surface, ICamera camera, IIntersectable scene);
	}
}