namespace Kelly {
	public interface IRenderer {
		void RenderScene(IRenderingSurface surface, ICamera camera, IScene scene);
	}
}