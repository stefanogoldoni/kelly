namespace Kelly {
	public interface IRenderer {
		void RenderScene(IRenderTarget target, ICamera camera, IIntersectable scene);
	}
}