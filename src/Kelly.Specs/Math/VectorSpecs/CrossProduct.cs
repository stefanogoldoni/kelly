using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class CrossProduct {
		[Fact]
		public void SatisfiesUnitVectorInvariants() {
			Assert.Equal(
				Vector.UnitX,
				Vector.CrossProduct(Vector.UnitY, Vector.UnitZ));

			Assert.Equal(
				Vector.UnitY,
				Vector.CrossProduct(Vector.UnitZ, Vector.UnitX));

			Assert.Equal(
				Vector.UnitZ,
				Vector.CrossProduct(Vector.UnitX, Vector.UnitY));
		}

		[Fact]
		public void IsAntiCommutative() {
			var a = new Vector(1, 2, 3);
			var b = new Vector(6, 4, 5);

			Assert.Equal(Vector.CrossProduct(a, b), -Vector.CrossProduct(b, a));
		}

		[Fact]
		public void ReturnsVectorThatHasADotProductOfZeroWithBothInputVectors() {
			var a = new Vector(2, 3, 4);
			var b = new Vector(4, 5, 6);

			var cross = Vector.CrossProduct(a, b);

			Assert.Equal(0f, Vector.DotProduct(a, cross));
			Assert.Equal(0f, Vector.DotProduct(cross, b));
		}

		[Fact]
		public void ReturnsZeroVectorWhenInputVectorsHaveSameDirection() {
			Assert.Equal(
				Vector.Zero,
				Vector.CrossProduct(Vector.UnitX, Vector.UnitX));

			Assert.Equal(
				Vector.Zero,
				Vector.CrossProduct(Vector.UnitY, Vector.UnitY));

			Assert.Equal(
				Vector.Zero,
				Vector.CrossProduct(Vector.UnitZ, Vector.UnitZ));
		}

		[Fact]
		public void ReturnsVectorWithLengthThatIsTheProductOfTheLengthsOfTheTwoInputVectors() {
			Assert.Equal(
				10f,
				Vector.CrossProduct(new Vector(2, 0, 0), new Vector(0, 5, 0)).Length);

			Assert.Equal(
				10f,
				Vector.CrossProduct(new Vector(2, 0, 0), new Vector(0, 0, 5)).Length);

			Assert.Equal(
				10f,
				Vector.CrossProduct(new Vector(0, 2, 0), new Vector(0, 0, 5)).Length);
		}		
	}
}