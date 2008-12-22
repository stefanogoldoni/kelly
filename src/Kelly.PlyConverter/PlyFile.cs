using System.Collections.Generic;

namespace Kelly.PlyConverter {
	public class PlyFile {
		public PlyFile() {
			ElementTypes = new Dictionary<string, PlyElementType>();
			Elements = new Dictionary<PlyElementType, PlyElement[]>();
		}

		public PlyFormat Format { get; set; }

		public IDictionary<string, PlyElementType> ElementTypes { get; private set; }
		public IDictionary<PlyElementType, PlyElement[]> Elements { get; private set; }

		public void AddElementType(PlyElementType elementType) {
			ElementTypes.Add(elementType.Name, elementType);
		}
	}
}