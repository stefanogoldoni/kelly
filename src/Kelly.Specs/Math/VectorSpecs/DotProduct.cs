using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class DotProduct {
		[Fact]
		public void ReturnsDotProductOfTwoVectors() {
			Assert.Equal(0.0f,
			             Vector.DotProduct(new Vector(1, 2, 3), new Vector(0, 0, 0)));

			Assert.Equal(3.0f,
			             Vector.DotProduct(new Vector(1, 1, 1), new Vector(1, 1, 1)));

			Assert.Equal(84f,
			             Vector.DotProduct(new Vector(42, 0, 0), new Vector(2, 0, 0)));

			Assert.Equal(84f,
			             Vector.DotProduct(new Vector(0, 42, 0), new Vector(0, 2, 0)));

			Assert.Equal(84f,
			             Vector.DotProduct(new Vector(0, 0, 42), new Vector(0, 0, 2)));

			Assert.Equal(0,
			             Vector.DotProduct(new Vector(0, 0, 42), new Vector(2, 0, 0)));
		}

		[Fact]
		public void IsZeroForVectorsThatAreOrthogonal() {
			Assert.Equal(
				0f, Vector.DotProduct(Vector.UnitX, Vector.UnitY));
		
			Assert.Equal(
				0f, Vector.DotProduct(Vector.UnitY, Vector.UnitZ));
			
			Assert.Equal(
				0f, Vector.DotProduct(Vector.UnitX, Vector.UnitY));

			Assert.Equal(
				0f, Vector.DotProduct(new Vector(5, 0, 0), new Vector(0, 10, 0)));
		}

		[Fact]
		public void IsCommutative() {
			var a = new Vector(1, 2, 3);
			var b = new Vector(6, -7, -8);

			Assert.Equal(Vector.DotProduct(a, b), Vector.DotProduct(b, a));
		}

		[Fact]
		public void IsEqualToSquaredLengthWhenAppliedToTheSameVector() {
			var vector = new Vector(82408, 42, 1337);

			Assert.Equal(vector.SquaredLength, Vector.DotProduct(vector, vector));
		}
	}
}