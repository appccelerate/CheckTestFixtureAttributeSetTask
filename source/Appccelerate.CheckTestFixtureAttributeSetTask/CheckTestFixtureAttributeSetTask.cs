// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckTestFixtureAttributeSetTask.cs" company="Appccelerate">
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
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public class CheckTestFixtureAttributeSetTask : Task
    {
        [Required]
        public string SourceFolderPath { get; set; }

        [Required]
        public ITaskItem[] SourceFiles { get; set; }

        [Required]
        public bool TreatWarningsAsErrors { get; set; }

        public override bool Execute()
        {
            if (this.SourceFiles == null)
            {
                return true;
            }

            var testAttributeVerifier = new TestAttributeVerifier();
            IEnumerable<string> sourceFileNames = this.SourceFiles.Select(x => x.ItemSpec);

            TestAttributeVerificationResult result = testAttributeVerifier.Verify(this.SourceFolderPath, sourceFileNames);

            if (result.Successful)
            {
                return true;
            }

            foreach (string violationMessage in result.ViolationMessages)
            {
                this.LogViolation(violationMessage);
            }

            bool continueExecution = !this.TreatWarningsAsErrors;

            return continueExecution;
        }

        private void LogViolation(string violationMessage)
        {
            if (this.TreatWarningsAsErrors)
            {
                this.Log.LogError(violationMessage);
            }
            else
            {
                this.Log.LogWarning(violationMessage);
            }
        }
    }
}