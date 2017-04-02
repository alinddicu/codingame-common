﻿namespace codingame.common.build.submit.file
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using Microsoft.Build.Evaluation;

	public class BuildSubmitFile
	{
		public void Build(DirectoryInfo sourceFolder, FileInfo targetFile)
		{
			var contents = new StringBuilder();
			var refProjects = GetReferencedProjectsFolders(sourceFolder);
			refProjects.Concat(new[] { sourceFolder })
			.ToList()
			.ForEach(sf => { AppendFilesContents(sf, contents); });

			File.WriteAllText(targetFile.FullName, contents.ToString());
		}

		private static IEnumerable<FileSystemInfo> GetReferencedProjectsFolders(FileSystemInfo currentProjectFolder)
		{
			var collection = new ProjectCollection();
			var csprojFileName = Path.Combine(currentProjectFolder.FullName, currentProjectFolder.Name + ".csproj");
			var project = collection.LoadProject(csprojFileName);
			return project
				.GetItems("ProjectReference")
				.Select(pr => Path.Combine(currentProjectFolder.FullName, pr.EvaluatedInclude))
				.Select(file => new FileInfo(file).Directory);
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
