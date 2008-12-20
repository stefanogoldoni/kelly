using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.EpsilonComparerSpecs {
	public class When_comparing_two_vectors {
		[Fact]
		public void If_the_two_vectors_are_equal_the_result_is_0() {
			Assert.Equal(new Vector(1, 2, 3), new Vector(1, 2, 3));
		}

		[Fact]
		public void X_coordinates_are_more_significant_than_Y_coordinates() {
			Assert.True(
				EpsilonComparer.VectorComparer.Compare(
					new Vector(1, 0, 0),
					new Vector(0, 9, 0)) > 0);

			Assert.True(
				EpsilonComparer.VectorComparer.Compare(
					new Vector(0, 0, 0),
					new Vector(0, 9, 0)) < 0);
		}

		[Fact]
		public void Y_coordinates_are_more_significant_than_Z_coordinates() {
			Assert.True(
				EpsilonComparer.VectorComparer.Compare(
					new Vector(0, 1, 50),
					new Vector(0, 0, 999)) > 0);

			Assert.True(
				EpsilonComparer.VectorComparer.Compare(
					new Vector(0, 0, 50),
					new Vector(0, 0, 999)) < 0);
		}
	}
}
