using System;
using System.IO;
using Kelly.Geometry.Ply;
using Xunit;

namespace Kelly.Specs.Geometry.PlyParserSpecs {
	public class When_parsing_a_ply_file_from_a_TextReader {
		[Fact]
		public void An_exception_is_thrown_if_the_file_does_not_begin_with_ply() {
			Assert.Throws<Exception>(
				() => Parse("this is not ply"));
		}

		[Fact]
		public void An_exception_is_thrown_if_the_file_does_not_have_a_format_line() {
			Assert.Throws<Exception>(
				() => Parse("ply\nthis is not a format line"));
		}

		[Fact]
		public void An_exception_is_thrown_if_the_file_does_not_specify_a_valid_format_type() {
			Assert.Throws<Exception>(
				() => Parse("ply\nformat invalid_format_type 1.0"));
		}

		[Fact]
		public void An_exception_is_thrown_if_the_file_does_not_specify_a_valid_format_version() {
			Assert.Throws<Exception>(
				() => Parse("ply\nformat ascii 1337"));
		}

		[Fact]
		public void An_exception_is_thrown_if_the_format_line_has_less_than_3_tokens() {
			Assert.Throws<Exception>(
				() => Parse("ply\nformat\nend_header"));

			Assert.Throws<Exception>(
				() => Parse("ply\nformat ascii\nend_header"));
		}

		[Fact]
		public void An_exception_is_thrown_if_the_format_line_has_more_than_3_tokens() {
			Assert.Throws<Exception>(
				() => Parse("ply\nformat ascii 1.0 an_extra_token\nend_header"));
		}

		[Fact]
		public void An_exception_is_thrown_if_there_is_no_end_header() {
			Assert.Throws<Exception>(
				() => Parse("ply\nformat ascii 1.0\nelement vertex 1\nproperty float x\nproperty float y\nproperty float z"));
		}

		[Fact]
		public void An_exception_is_not_thrown_if_there_is_a_valid_header() {
			Assert.DoesNotThrow(
				() => Parse("ply\nformat ascii 1.0\nend_header"));
		}

		[Fact]
		public void Comment_lines_do_not_cause_exceptions() {
			Assert.DoesNotThrow(()
				=> Parse("ply\ncomment this is a comment\nformat ascii 1.0\ncomment this is another comment\nend_header"));
		}
		
		[Fact]
		public void Format_line_is_parsed_correctly() {
			var ply = Parse("ply\nformat ascii 1.0\nend_header");

			Assert.Equal(PlyFormat.Ascii, ply.Header.Format);
		}

		[Fact]
		public void An_exception_is_thrown_if_an_invalid_line_is_encountered_in_header_after_format() {
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\ninvalid_line and stuffs"));
		}

		[Fact]
		public void An_exception_is_thrown_if_an_element_definition_contains_less_than_3_tokens() {
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement\nend_header"));
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement vertex\nend_header"));
		}

		[Fact]
		public void An_exception_is_thrown_if_an_element_definition_contains_more_than_3_tokens() {
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement vertex 10 an_extra_token\nend_header"));
		}

		[Fact]
		public void An_exception_is_thrown_if_an_element_definition_contains_an_invalid_element_count() {
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement vertex this_is_not_a_valid_element_count\nend_header"));
		}

		[Fact]
		public void An_exception_is_not_thrown_if_an_element_definition_contains_the_correct_number_of_tokens_and_a_valid_element_count() {
			Assert.DoesNotThrow(() => Parse("ply\nformat ascii 1.0\nelement vertex 1337\nend_header"));
		}

		[Fact]
		public void Element_types_are_correctly_parsed() {
			var ply = Parse("ply\nformat ascii 1.0\nelement vertex 10\nelement face 1337\nend_header");

			Assert.Equal(2, ply.Header.ElementTypes.Count);

			Assert.Equal("vertex", ply.Header.ElementTypes[0].Name);
			Assert.Equal(10, ply.Header.ElementTypes[0].Count);
	
			Assert.Equal("face", ply.Header.ElementTypes[1].Name);
			Assert.Equal(1337, ply.Header.ElementTypes[1].Count);
		}

		[Fact]
		public void An_exception_is_thrown_if_a_property_definition_has_less_than_3_tokens() {
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement vertex 1\nproperty"));
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement vertex 1\nproperty int"));
		}

		[Fact]
		public void An_exception_is_thrown_if_a_property_definition_has_4_tokens() {
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement vertex 1\nproperty list uchar int"));
		}

		[Fact]
		public void An_exception_is_thrown_if_a_property_definition_has_more_than_5_tokens() {
			Assert.Throws<Exception>(() => Parse("ply\nformat ascii 1.0\nelement face 1\nproperty list uchar int vertex_indices an_extra_token"));
		}

		[Fact]
		public void No_exception_is_thrown_if_a_property_definition_has_3_tokens() {
			Assert.DoesNotThrow(() => Parse("ply\nformat ascii 1.0\nelement vertex 1\nproperty float x\nend_header"));
		}

		[Fact]
		public void No_exception_is_thrown_if_a_property_definition_has_5_tokens() {
			Assert.DoesNotThrow(() => Parse("ply\nformat ascii 1.0\nelement face 1\nproperty list uchar int vertex_indices\nend_header"));
		}

		[Fact]
		public void Simple_properties_are_parsed_correctly() {
			var ply = Parse("ply\nformat ascii 1.0\nelement vertex 1\nproperty float x\nproperty int y\nproperty uchar z\nend_header");

			Assert.Equal(3, ply.Header.ElementTypes[0].Properties.Count);
			Assert.True(ply.Header.ElementTypes[0].Properties.ContainsKey("x"));
			Assert.True(ply.Header.ElementTypes[0].Properties.ContainsKey("y"));
			Assert.True(ply.Header.ElementTypes[0].Properties.ContainsKey("z"));

			var x = ply.Header.ElementTypes[0].Properties["x"];
			Assert.Equal("float", x.TypeName);
			Assert.Equal("x", x.Name);
			Assert.False(x.IsList);
			Assert.Null(x.ListCountTypeName);

			var y = ply.Header.ElementTypes[0].Properties["y"];
			Assert.Equal("int", y.TypeName);
			Assert.Equal("y", y.Name);
			Assert.False(y.IsList);
			Assert.Null(y.ListCountTypeName);
			
			var z = ply.Header.ElementTypes[0].Properties["z"];
			Assert.Equal("uchar", z.TypeName);
			Assert.Equal("z", z.Name);
			Assert.False(z.IsList);
			Assert.Null(z.ListCountTypeName);
		}

		[Fact]
		public void List_properties_are_parsed_correctly() {
			var ply = Parse(
				"ply\nformat ascii 1.0\nelement face 1\nproperty list uchar int vertex_indices\nproperty list int int some_other_list_property\nend_header");

			Assert.Equal(2, ply.Header.ElementTypes[0].Properties.Count);
			Assert.True(ply.Header.ElementTypes[0].Properties.ContainsKey("vertex_indices"));
			Assert.True(ply.Header.ElementTypes[0].Properties.ContainsKey("some_other_list_property"));

			var indices = ply.Header.ElementTypes[0].Properties["vertex_indices"];
			Assert.Equal("int", indices.TypeName);
			Assert.Equal("vertex_indices", indices.Name);
			Assert.True(indices.IsList);
			Assert.Equal("uchar", indices.ListCountTypeName);

			var otherList = ply.Header.ElementTypes[0].Properties["some_other_list_property"];
			Assert.Equal("int", otherList.TypeName);
			Assert.Equal("some_other_list_property", otherList.Name);
			Assert.True(otherList.IsList);
			Assert.Equal("int", otherList.ListCountTypeName);
		}

		private static PlyFile Parse(string plyText) {
			return new PlyParser().Parse(new StringReader(plyText));
		}
	}
}
