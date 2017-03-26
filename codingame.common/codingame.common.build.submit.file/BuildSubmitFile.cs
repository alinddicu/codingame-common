namespace codingame.common.build.submit.file
{
	using System.IO;
	using System.Linq;
	using System.Text;

	public class BuildSubmitFile
    {
		public void Build(string sourceFolderPath, string targetFilePath)
		{
			var contents = new StringBuilder();
			AppendFilesContents(sourceFolderPath, contents);

			File.WriteAllText(targetFilePath, contents.ToString());
		}

		private static void AppendFilesContents(string root, StringBuilder contents)
		{
			foreach (var file in Directory.EnumerateFiles(root, "*.cs").Where(f => !f.EndsWith("AssemblyInfo.cs")))
			{
				contents.AppendLine(File.ReadAllText(file));
				contents.AppendLine();
			}

			foreach (var d in Directory.GetDirectories(root))
			{
				AppendFilesContents(d, contents);
			}
		}
	}
}
