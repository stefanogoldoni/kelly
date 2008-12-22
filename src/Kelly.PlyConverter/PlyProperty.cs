using System;

namespace Kelly.PlyConverter {
	public class PlyProperty {
		public string Name { get; set; }
		public string TypeName { get; set; }

		public Type Type {
			get {
				switch (TypeName) {
					case "float":	return typeof(float);
					case "int":		return typeof(int);
					case "uchar":	return typeof(byte);
					default:
						throw new Exception(string.Format("Invalid property type: \"{0}\".", TypeName));
				}
			}
		}

		public bool IsList { get; set; }
		public string ListCountTypeName { get; set; }

		public int Index { get; set; }
	}
}