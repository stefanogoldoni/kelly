using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class The_Length_property {
		[Fact]
		public void Equals_the_square_root_of_the_SquaredLength_property() {
			var a = new Vector(43, 29, -14);

			Assert.Equal(System.Math.Sqrt(a.SquaredLength), a.Length);
		}

		[Fact]
		public void Equals_the_length_of_the_vector() {
			Assert.Equal(
				1f,
				new Vector(1, 0, 0).Length);

			Assert.Equal(
				5f,
				new Vector(5, 0, 0).Length);

			Assert.Equal(
				5f,
				new Vector(0, 5, 0).Length);

			Assert.Equal(
				5f,
				new Vector(0, 0, 5).Length);
		}

	}
}