using Xunit;
using Kelly.Math;

namespace Kelly.Specs {
	public class VectorSpecs {
		[Fact]
		public void DotProduct_ReturnsDotProductOfTwoVectors() {
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
		public void IsUnit_ReturnsTrueForUnitVectors() {
			Assert.True(new Vector(1, 0, 0).IsUnit);
			Assert.True(new Vector(0, 1, 0).IsUnit);
			Assert.True(new Vector(0, 0, 1).IsUnit);
		}

		[Fact]
		public void IsUnit_ReturnsFalseForNonUnitVectors() {
			Assert.False(new Vector(1, 1, 0).IsUnit);
			Assert.False(new Vector(1, 0, 1).IsUnit);
			Assert.False(new Vector(0, 1, 1).IsUnit);

			Assert.False(new Vector(1.1f, 0, 0).IsUnit);
			Assert.False(new Vector(0, 1.1f, 0).IsUnit);
			Assert.False(new Vector(0, 0, 1.1f).IsUnit);

			Assert.False(new Vector(.9f, 0, 0).IsUnit);
			Assert.False(new Vector(0, .9f, 0).IsUnit);
			Assert.False(new Vector(0, 0, .9f).IsUnit);			
		}

		[Fact]
		public void Length_ReturnsLengthOfVector() {
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

		[Fact]
		public void StaticUnitVectorsAllHaveUnitLength() {
			Assert.True(Vector.UnitX.IsUnit);
			Assert.True(Vector.UnitY.IsUnit);
			Assert.True(Vector.UnitZ.IsUnit);
		}

		[Fact]
		public void ZeroVectorHasLenghOfZero() {
			Assert.Equal(
				0f,
				Vector.Zero.Length);
		}

		[Fact]
		public void ToUnitVector_ReturnsUnitVector() {
			Assert.True(new Vector(7, 0, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 7, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 0, 7).ToUnitVector().IsUnit);

			Assert.True(new Vector(.1f, 0, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, .1f, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 0, .1f).ToUnitVector().IsUnit);

			Assert.True(new Vector(.1f, .02f, .3f).ToUnitVector().IsUnit);
		}

		[Fact]
		public void CrossProduct_SatisfiesUnitInvariants() {
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
		public void OperatorMultiplication_ReturnsVectorScaledBySpecifiedAmount() {
			Assert.Equal(
				new Vector(2, 4, 6),
				new Vector(1, 2, 3) * 2);

			Assert.Equal(
				new Vector(2, 0, 0),
				new Vector(1, 0, 0) * 2);

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(2, 2, 2) * .5f);
		}

		[Fact]
		public void OperatorAddition_ReturnsSumOfTwoVectors() {
			Assert.Equal(
				new Vector(1f, 1f, 0),
				Vector.UnitX + Vector.UnitY);

			Assert.Equal(
				new Vector(1, 2, 3),
				new Vector(1, 0, 3) + new Vector(0, 2, 0));

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(.5f, .3f, .2f) + new Vector(.5f, .7f, .8f));
		}

		[Fact]
		public void OperatorSubtraction_ReturnsDifferenceOfTwoVectors() {
			Assert.Equal(
				new Vector(1f, 0, -1f),
				Vector.UnitX - Vector.UnitZ);

			Assert.Equal(
				new Vector(0, 0, 0),
				new Vector(5, 6, 7) - new Vector(5, 6, 7));

			Assert.Equal(
				new Vector(3, -4, 12),
				new Vector(5, 7, 18) - new Vector(2, 11, 6));
		}

		[Fact]
		public void OperatorDivision_ReturnsVectorScaledByInverseOfSpecifiedAmount() {
			Assert.Equal(
				new Vector(1, 0, 0),
				new Vector(5, 0, 0) / 5);

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(5, 5, 5) / 5);

			Assert.Equal(
				new Vector(3, 2, 1),
				new Vector(39, 26, 13) / 13);
		}
	}
}
