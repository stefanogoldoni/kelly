using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_cloning_a_matrix {
		[Fact]
		public void The_clone_has_the_same_elements_as_the_original_matrix() {
			var clone = MatrixHelper.SequentialMatrix.Clone();

			for (var col = 0; col < 4; col++)
				for (var row = 0; row < 4; row++) {
					Assert.Equal(MatrixHelper.SequentialMatrix[row, col], clone[row, col]);
				}
		}
	}
}