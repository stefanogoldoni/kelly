namespace Kelly.PlyConverter {
	public class PlyProperty {
		public string Name { get; set; }
		public string TypeName { get; set; }

		public bool IsList { get; set; }
		public string ListCountTypeName { get; set; }

		public int Index { get; set; }
	}
}