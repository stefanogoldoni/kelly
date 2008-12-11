using System.Linq;
using Kelly.Math;

namespace Kelly.Specs.Math.VectorSpecs {
	public class When_comparing_two_vectors : EqualitySpecs<Vector> {
		private static readonly System.Random _rng = new System.Random();

		protected override Vector GetRandomInstance() {
			return new Vector((float) _rng.NextDouble(), (float) _rng.NextDouble(), (float) _rng.NextDouble());
		}

		protected override Vector[] GetRandomInstancesThatAreEqual(int count) {
			var instance = GetRandomInstance();

			return Enumerable
				.Range(0, count)
				.Select(i => new Vector(instance.X, instance.Y, instance.Z))
				.ToArray();
		}
	}
}
