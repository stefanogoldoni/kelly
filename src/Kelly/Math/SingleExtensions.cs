namespace Kelly.Math {
	public static class SingleExtensions {
		public static float ToRadians(this float value) {
			return value * (float) System.Math.PI / 180f;
		}
	}
}
