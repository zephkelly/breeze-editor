using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Breeze
{
	public class SyntaxManager
	{
		public SyntaxManager() { }

		Color initialCharacterColour = Color.FromArgb(235, 235, 235);

		string keywords = @"\b(public|private|partial|static|void|class|namespace|interface|enum|using|foreach|in|if|else|do|while|internal|get|set|return)\b";
		string variables = @"\b(var|const|int|string|long|bool|float|char|this|null|false|true|value|new)\b";
		string referenceTypes = @"\b(Dictionary|List|Vector2|Vector3|StringBuilder|Vector2Int|GameObject|Bounds)\b";
		string comments = @"(/\*[^*]*\*+(?:[^/*][^*]*\*+)*/|\/\/.+?$)";
		string types = @"\b(Console)\b";
		string strings = "\".+?\"";

		public void HighlightSyntax(RichTextBox editorTextBox)
		{
			//Character collections
			MatchCollection keywordMatches = Regex.Matches(editorTextBox.Text, keywords);
			MatchCollection variableMatches = Regex.Matches(editorTextBox.Text, variables);
			MatchCollection referenceTypesMatches = Regex.Matches(editorTextBox.Text, referenceTypes);
			MatchCollection stringsMatches = Regex.Matches(editorTextBox.Text, strings);
			MatchCollection commentMatches = Regex.Matches(editorTextBox.Text, comments, RegexOptions.Multiline);
			MatchCollection typeMatches = Regex.Matches(editorTextBox.Text, types);

			int initialIndex = editorTextBox.SelectionStart;
			int initalLength = editorTextBox.SelectionLength;

			editorTextBox.SelectionStart = 0;
			editorTextBox.SelectionLength = editorTextBox.Text.Length;

			//Scan characters
			foreach (Match match in keywordMatches)
			{
				editorTextBox.SelectionStart = match.Index;
				editorTextBox.SelectionLength = match.Length;
				editorTextBox.SelectionColor = Color.Cyan;
			}

			foreach (Match match in variableMatches)
			{
				editorTextBox.SelectionStart = match.Index;
				editorTextBox.SelectionLength = match.Length;
				editorTextBox.SelectionColor = Color.LightCoral;
			}

			foreach (Match match in referenceTypesMatches)
			{
				editorTextBox.SelectionStart = match.Index;
				editorTextBox.SelectionLength = match.Length;
				editorTextBox.SelectionColor = Color.LightCoral;
			}

			foreach (Match match in commentMatches)
			{
				editorTextBox.SelectionStart = match.Index;
				editorTextBox.SelectionLength = match.Length;
				editorTextBox.SelectionColor = Color.Green;
			}

			foreach (Match match in typeMatches)
			{
				editorTextBox.SelectionStart = match.Index;
				editorTextBox.SelectionLength = match.Length;
				editorTextBox.SelectionColor = Color.Brown;
			}

			foreach (Match match in stringsMatches)
			{
				editorTextBox.SelectionStart = match.Index;
				editorTextBox.SelectionLength = match.Length;
				editorTextBox.SelectionColor = Color.Green;
			}

			editorTextBox.SelectionStart = initialIndex;
			editorTextBox.SelectionLength = initalLength;
			editorTextBox.SelectionColor = initialCharacterColour;
		}
	}
}
