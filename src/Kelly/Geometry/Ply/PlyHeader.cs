using System.Collections.Generic;

namespace Kelly.Geometry.Ply {
	public class PlyHeader {
		public PlyHeader() {
			ElementTypes = new List<PlyElementType>();
		}

		public PlyFormat Format { get; set; }
		public IList<PlyElementType> ElementTypes { get; private set; }
	}
}