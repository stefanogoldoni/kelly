using System.Collections.Generic;

namespace Kelly.PlyConverter {
	public class PlyElementType {
		public PlyElementType() {
			Properties = new Dictionary<string, PlyProperty>();
		}

		public string Name { get; set; }
		public int Count { get; set; }
		public IDictionary<string, PlyProperty> Properties { get; set; }

		public void AddProperty(PlyProperty property) {
			property.Index = Properties.Count;
			Properties.Add(property.Name, property);
		}
	}
}