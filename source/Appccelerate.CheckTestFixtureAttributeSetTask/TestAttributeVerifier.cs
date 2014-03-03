// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestAttributeVerifier.cs" company="Appccelerate">
//   Copyright (c) 2008-2014
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Appccelerate.CheckTestFixtureAttributeSetTask
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class TestAttributeVerifier
    {
        public TestAttributeVerificationResult Verify(string sourceFolderPath, IEnumerable<string> sourceFileNames)
        {
            var violationMessages = new List<string>();

            foreach (var sourceFileName in sourceFileNames)
            {
                if (!sourceFileName.EndsWith("Test.cs", StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                string sourceFilePath = Path.Combine(sourceFolderPath, sourceFileName);
                if (!File.Exists(sourceFilePath))
                {
                    continue;
                }

                string fileContent = File.ReadAllText(sourceFilePath);
                var containsTextFixtureRegex = new Regex(@"\[.*TestFixture.*\][\n\s]");
                if (containsTextFixtureRegex.Match(fileContent).Success)
                {
                    continue;
                }

                string violationMessage = string.Concat("File `", sourceFileName, "` is missing [TestFixture] attribute.");
                violationMessages.Add(violationMessage);
            }

            return violationMessages.Any()
                ? TestAttributeVerificationResult.CreateFaulty(violationMessages)
                : TestAttributeVerificationResult.CreateSuccessful();
        }
    }
}