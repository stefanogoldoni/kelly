using System;
using System.IO;
using System.Text;
using Kelly.Geometry;
using Kelly.Resources;
using Xunit;

namespace Kelly.Specs.Resources.TrimeshLoaderSpecs {
	public class When_loading_a_mesh_from_a_stream {
		[Fact]
		public void An_exception_is_thrown_if_the_file_identifier_is_incorrect() {
			Assert.Throws<Exception>(() => Load(BuildTrimesh("12345678", 1, 0, 0)));
		}

		[Fact]
		public void An_exception_is_thrown_if_the_format_version_is_incorrect() {
			Assert.Throws<Exception>(() => Load(BuildTrimesh("TRIMESH\0", 0, 0, 0)));
			Assert.Throws<Exception>(() => Load(BuildTrimesh("TRIMESH\0", 2, 0, 0)));
			Assert.Throws<Exception>(() => Load(BuildTrimesh("TRIMESH\0", 1337, 0, 0)));
		}

		[Fact]
		public void An_exception_is_not_thrown_if_the_file_identifier_is_correct() {
			Assert.DoesNotThrow(() => Load(BuildTrimesh("TRIMESH\0", 1, 0, 0)));
		}

		private static byte[] BuildTrimesh(string identifier, int version, int vertexCount, int triangleCount) {
			using (var stream = new MemoryStream()) 
			using (var writer = new BinaryWriter(stream)) {
				writer.Write(Encoding.ASCII.GetBytes(identifier));
				writer.Write(version);
				writer.Write(vertexCount);
				writer.Write(triangleCount);
				writer.Flush();

				return stream.ToArray();
			}
		}

		private static Mesh Load(byte[] bytes) {
			using (var stream = new MemoryStream(bytes)) {
				return new TrimeshLoader().Load(stream);
			}
		}
	}
}
