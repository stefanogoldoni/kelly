namespace Kelly {
	public static class IntegerExtensions {
		public static bool IsEven(this uint value) {
			return value % 2 == 0;
		}

		public static bool IsOdd(this uint value) {
			return !IsEven(value);
		}
	}
}