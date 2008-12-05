using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class When_calculating_the_dot_product_of_two_vectors {
		[Fact]
		public void The_result_equals_the_dot_product_of_the_two_vectors() {
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
		public void The_result_is_zero_when_the_two_vectors_are_orthogonal() {
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
		public void The_operation_is_commutative() {
			var a = new Vector(1, 2, 3);
			var b = new Vector(6, -7, -8);

			Assert.Equal(Vector.DotProduct(a, b), Vector.DotProduct(b, a));
		}

		[Fact]
		public void The_result_is_equal_to_the_SquaredLength_property_when_a_vector_is_dotted_with_itself() {
			var vector = new Vector(82408, 42, 1337);

			Assert.Equal(vector.SquaredLength, Vector.DotProduct(vector, vector));
		}
	}
}