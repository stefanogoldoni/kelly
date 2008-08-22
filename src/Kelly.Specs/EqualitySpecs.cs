using Xunit;

namespace Kelly.Specs {
	/// <summary>
	/// These specs are based on http://msdn.microsoft.com/en-us/library/bsc2ak47.aspx
	/// </summary>
	public abstract class EqualitySpecs<T> {
		protected abstract T GetRandomInstance();
		protected abstract T[] GetRandomInstancesThatAreEqual(int count);

		[Fact]
		public void Equality_is_reflexive() {
			var x = GetRandomInstance();
			Assert.True(x.Equals(x));
		}

		[Fact]
		public void Equality_is_symmetric() {
			var instances = GetRandomInstancesThatAreEqual(2);
			var x = instances[0];
			var y = instances[1];

			Assert.True(x.Equals(y) && y.Equals(x));
		}

		[Fact]
		public void If_X_doesnt_equal_Y_then_Y_doesnt_equal_X() {
			var x = GetRandomInstance();
			var y = GetRandomInstance();

			Assert.True(!x.Equals(y) && !y.Equals(x));
		}

		[Fact]
		public void Equality_is_transitive() {
			var instances = GetRandomInstancesThatAreEqual(3);
			var x = instances[0];
			var y = instances[1];
			var z = instances[2];

			Assert.True(x.Equals(y) && y.Equals(z) && x.Equals(z));
		}

		[Fact]
		public void Equality_is_the_same_for_successive_checks() {
			var instances = GetRandomInstancesThatAreEqual(2);
			var x = instances[0];
			var y = instances[1];

			Assert.True(x.Equals(y) && x.Equals(y) && x.Equals(y) && x.Equals(y));
		}

		[Fact]
		public void Inequality_is_the_same_for_successive_checks() {
			var x = GetRandomInstance();
			var y = GetRandomInstance();

			Assert.True(!x.Equals(y) && !x.Equals(y) && !x.Equals(y) && !x.Equals(y));
		}

		[Fact]
		public void Equality_check_with_null_returns_false() {
			var x = GetRandomInstance();

			Assert.False(x.Equals(null));
		}
	}
}
