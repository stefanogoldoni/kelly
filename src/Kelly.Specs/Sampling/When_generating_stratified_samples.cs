using System.Linq;
using Kelly.Sampling;
using Xunit;

namespace Kelly.Specs.Sampling {
	public class When_generating_stratified_samples {
		private static ISampleGenerator CreateGenerator() {
			return new StratifiedSampleGenerator();
		}

		[Fact]
		public void The_returned_number_of_samples_equals_the_largest_square_less_than_the_requested_number_of_samples() {
			Assert.Equal(100, CreateGenerator().GenerateSamples(101).Count());
			Assert.Equal(81, CreateGenerator().GenerateSamples(90).Count());
			Assert.Equal(4, CreateGenerator().GenerateSamples(7).Count());
		}

		[Fact]
		public void The_returned_number_of_samples_equals_the_requested_number_if_the_requested_number_is_a_square() {
			Assert.Equal(121, CreateGenerator().GenerateSamples(121).Count());
			Assert.Equal(100, CreateGenerator().GenerateSamples(100).Count());
			Assert.Equal(81, CreateGenerator().GenerateSamples(81).Count());
			Assert.Equal(9, CreateGenerator().GenerateSamples(9).Count());
		}
	}
}