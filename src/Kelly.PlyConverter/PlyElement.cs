namespace Kelly.PlyConverter {
	public class PlyElement {
		public PlyElement(PlyElementType elementType, object[] propertyValues) {
			ElementType = elementType;
			_propertyValues = propertyValues;
		}

		private readonly object[] _propertyValues;

		public PlyElementType ElementType { get; private set; }

		public object GetValue(string property) {
			return _propertyValues[ElementType.Properties[property].Index];
		}
	}
}
