using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class When_calculating_the_cross_product_of_two_vectors {
		[Fact]
		public void Unit_vector_invariants_are_satisfied() {
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
		public void Cross_product_is_anticommutative() {
			var a = new Vector(1, 2, 3);
			var b = new Vector(6, 4, 5);

			Assert.Equal(Vector.CrossProduct(a, b), -Vector.CrossProduct(b, a));
		}

		[Fact]
		public void The_resulting_vector_has_a_dot_product_of_zero_with_both_input_vectors() {
			var a = new Vector(2, 3, 4);
			var b = new Vector(4, 5, 6);

			var cross = Vector.CrossProduct(a, b);

			Assert.Equal(0f, Vector.DotProduct(a, cross));
			Assert.Equal(0f, Vector.DotProduct(cross, b));
		}

		[Fact]
		public void If_the_two_input_vectors_have_the_same_direction_the_result_is_the_zero_vector() {
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
		public void The_length_of_the_resulting_vectors_equals_the_product_of_the_lengths_of_the_two_input_vectors() {
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