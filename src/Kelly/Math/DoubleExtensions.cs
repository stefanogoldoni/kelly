namespace Kelly.Math {
	public static class DoubleExtensions {
		public static double ToRadians(this double value) {
			return value * System.Math.PI / 180f;
		}
	}
}
