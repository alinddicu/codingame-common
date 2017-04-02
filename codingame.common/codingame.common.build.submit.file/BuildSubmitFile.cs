namespace codingame.common.build.submit.file
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;

	public class BuildSubmitFile
    {
		public void Build(DirectoryInfo sourceFolder, FileInfo targetFile)
		{
			var contents = new StringBuilder();
			AppendFilesContents(sourceFolder, contents);

			File.WriteAllText(targetFile.FullName, contents.ToString());
		}

		private static IEnumerable<string> GetReferencedProjectsPaths(DirectoryInfo sourceFolder)
		{
			throw new NotImplementedException();
		}

		private static void AppendFilesContents(FileSystemInfo sourceFolder, StringBuilder contents)
		{
			var sourceFolderPath = sourceFolder.FullName;
			var files = Directory
							.EnumerateFiles(sourceFolderPath, "*.cs")
							.Where(f => !f.EndsWith("AssemblyInfo.cs"));
			foreach (var file in files)
			{
				contents.AppendLine(File.ReadAllText(file));
				contents.AppendLine();
			}

			foreach (var d in Directory.GetDirectories(sourceFolderPath))
			{
				AppendFilesContents(new DirectoryInfo(d), contents);
			}
		}
	}
}
