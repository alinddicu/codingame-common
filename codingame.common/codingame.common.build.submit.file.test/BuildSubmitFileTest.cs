﻿namespace codingame.common.build.submit.file.test
{
	using System.IO;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class BuildSubmitFileTest
	{
		[TestMethod]
		public void GivenBuildSubmitFileWhenBuildThenTargetEqualsReference()
		{
			var sourceFolder = new DirectoryInfo("../../");
			var targetFile = new FileInfo("../../codingame.common.build.submit.file.test.txt");
			var referenceFile = new DirectoryInfo("../../codingame.common.build.submit.file.test.reference.txt");
			new BuildSubmitFile().Build(sourceFolder, targetFile);

			var referenceContent = File.ReadAllText(referenceFile.FullName).Trim();
			var targetContent = File.ReadAllText(targetFile.FullName).Trim();

			Check.That(referenceContent).IsEqualTo(targetContent);
		}
	}
}
