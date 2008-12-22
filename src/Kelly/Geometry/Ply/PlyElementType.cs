using System.Collections.Generic;

namespace Kelly.Geometry.Ply {
	public class PlyElementType {
		public PlyElementType() {
			Properties = new Dictionary<string, PlyProperty>();
		}

		public string Name { get; set; }
		public int Count { get; set; }
		public IDictionary<string, PlyProperty> Properties { get; set; }

		public void AddProperty(PlyProperty property) {
			Properties.Add(property.Name, property);
		}
	}
}