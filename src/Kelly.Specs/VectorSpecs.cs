using Xunit;
using Kelly.Math;

namespace Kelly.Specs {
	public class VectorSpecs {
		[Fact]
		public void DotProduct_ReturnsCorrectValues() {
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
		public void SquaredLength_ReturnsCorrectValues() {
			Assert.Equal(1.0f, new Vector(1, 0, 0).SquaredLength);
			Assert.Equal(2.0f, new Vector(1, 1, 0).SquaredLength);
			Assert.Equal(3.0f, new Vector(1, 1, 1).SquaredLength);
			Assert.Equal(14.0f, new Vector(3, 2, 1).SquaredLength);
		}

		[Fact]
		public void IsUnit_ReturnsCorrectValues() {
			Assert.True(new Vector(1, 0, 0).IsUnit);
			Assert.True(new Vector(0, 1, 0).IsUnit);
			Assert.True(new Vector(0, 0, 1).IsUnit);

			Assert.False(new Vector(1, 1, 0).IsUnit);
			Assert.False(new Vector(1, 0, 1).IsUnit);
			Assert.False(new Vector(0, 1, 1).IsUnit);
			
			Assert.False(new Vector(1.1f, 0, 0).IsUnit);
			Assert.False(new Vector(0, 1.1f, 0).IsUnit);
			Assert.False(new Vector(0, 0, 1.1f).IsUnit);

			Assert.False(new Vector(0.9f, 0, 0).IsUnit);
			Assert.False(new Vector(0, 0.9f, 0).IsUnit);
			Assert.False(new Vector(0, 0, 0.9f).IsUnit);
		}

		[Fact]
		public void Scale_ReturnsCorrectValues() {
			Assert.Equal(
				new Vector(2, 4, 6),
				new Vector(1, 2, 3).Scale(2));

			Assert.Equal(
				new Vector(2, 0, 0),
				new Vector(1, 0, 0).Scale(2));

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(2, 2, 2).Scale(0.5f));
		}
	}
}
