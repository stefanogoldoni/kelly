using System;
using System.IO;
using System.Linq;

namespace Kelly.Geometry.Ply {
	public class PlyParser  {
		public PlyFile Parse(TextReader reader) {
			_reader = reader;

			_result = new PlyFile();

			ReadHeader();
			ReadBody();

			return _result;
		}

		private void ReadBody() {
			
		}

		private PlyFile _result;
		private TextReader _reader;
	
		private string CurrentLine { get; set; }

		private string NextLine() {
			return CurrentLine = _reader.ReadLine();
		}

		private bool AtEnd {
			get { return CurrentLine == null; }
		}

		private void ReadHeader() {
			if (NextLine() != "ply") {
				throw new Exception("Invalid PLY file. PLY files must start with the word \"ply\" on a single line.");
			}

			_result.Header = new PlyHeader();

			NextHeaderLine();
			_result.Header.Format = ReadFormat();

			while(CurrentLine != "end_header") {
				if (CurrentLine.StartsWith("element")) {
					_result.Header.ElementTypes.Add(ReadElementType());
				}
				else {
					throw new Exception(string.Format("Invalid line encountered in PLY header: \"{0}\".", CurrentLine));
				}
			}
		}

		private PlyElementType ReadElementType() {
			var tokens = CurrentLine.Split(' ');

			if (tokens.Length != 3)
				throw new Exception(
					string.Format(
						"Incorrect number of tokens in element type line: \"{0}\". " 
						+ "Element types should be in the format: \"element <element_type> <element_count>\".", CurrentLine));

			if (tokens[0] != "element")
				throw new Exception("Invalid element type line. Element types must start with the word \"element\".");

			int count;
			if (!int.TryParse(tokens[2], out count))
				throw new Exception(
					string.Format("Invalid element count: \"{0}\"", tokens[2]));

			var elementType = new PlyElementType {
				Name = tokens[1],
				Count = count
			};

			while(NextHeaderLine().StartsWith("property")) {
				elementType.AddProperty(ReadProperty());
			}

			return elementType;
		}

		private PlyProperty ReadProperty() {
			var tokens = CurrentLine.Split(' ');

			if (tokens.Length != 3 && tokens.Length != 5) {
				throw new Exception(string.Format("Invalid number of tokens in property line: \"{0}\".", CurrentLine));
			}

			if (tokens[0] != "property") {
				throw new Exception(string.Format("Invalid property line: \"{0}\".", CurrentLine));
			}

			var property = new PlyProperty {
				Name = tokens.Last(),
				IsList = tokens[1] == "list",
			};

			if (property.IsList) {
				property.ListCountTypeName = tokens[2];
				property.TypeName = tokens[3];
				property.Name = tokens[4];
			}
			else {
				property.TypeName = tokens[1];
				property.Name = tokens[2];
			}

			return property;
		}

		private string NextHeaderLine() {
			while (NextLine() != null && CurrentLine.StartsWith("comment")) {
			}

			if (AtEnd)
				throw new Exception("The end of the file was reached before the end of the header. PLY file headers must end with \"end_header\".");

			return CurrentLine;
		}

		private PlyFormat ReadFormat() {
			var tokens = CurrentLine.Split(' ');

			if (tokens.Length != 3) {
				throw new Exception(
					"Incorrect number of tokens in format line. Format lines should follow the format: \"format <format_type> <format_version>\".");
			}

			if (tokens[0] != "format")
				throw new Exception("Invalid format line in PLY file. PLY format lines must begin with the word \"format\".");

			PlyFormat format;

			if (tokens[1] == "ascii") {
				if (tokens[2] == "1.0") {
					format = PlyFormat.Ascii;
				}
				else {
					throw new Exception(
						string.Format("Invalid PLY format version: \"{0}\". Expected \"1.0\".", tokens[2]));
				}
			}else {
				throw new Exception(
					string.Format("Invalid PLY format: \"{0}\". Right now the PlyMeshLoader can only handle PLY files in the ascii format.", tokens[1]));				
			}

			NextHeaderLine();
			return format;
		}
	}
}