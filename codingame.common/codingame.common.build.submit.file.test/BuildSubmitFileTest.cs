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
			const string sourceFolderPath = "../../";
			const string targetFilePath = "../../codingame.common.build.submit.file.test.txt";
			const string referenceFilePath = "../../codingame.common.build.submit.file.test.reference.txt";
			new BuildSubmitFile().Build(sourceFolderPath, targetFilePath);

			var referenceContent = File.ReadAllText(referenceFilePath).Trim();
			var targetContent = File.ReadAllText(targetFilePath).Trim();

			Check.That(referenceContent).IsEqualTo(targetContent);
		}
	}
}
