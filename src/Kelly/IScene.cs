using System.Collections.Generic;

namespace Kelly {
	public interface IScene : IIntersectable {
		IEnumerable<ILight> Lights { get; }
	}
}
