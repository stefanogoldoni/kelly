using Kelly.Math;

namespace Kelly {
	public interface IScene {
		Intersection IntersectWith(Ray ray);

		void AddGeometry(RenderableGeometry geometry);
	}
}
