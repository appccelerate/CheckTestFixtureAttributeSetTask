// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestAttributeVerificationResult.cs" company="Appccelerate">
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

    public class TestAttributeVerificationResult
    {
        private TestAttributeVerificationResult(bool successful, IReadOnlyList<string> violationMessages)
        {
            this.Successful = successful;
            this.ViolationMessages = violationMessages;
        }

        public IReadOnlyList<string> ViolationMessages { get; private set; }

        public bool Successful { get; private set; }

        public static TestAttributeVerificationResult CreateSuccessful()
        {
            return new TestAttributeVerificationResult(true, new List<string>());
        }

        public static TestAttributeVerificationResult CreateFaulty(IReadOnlyList<string> violationMessages)
        {
            return new TestAttributeVerificationResult(false, violationMessages);
        }
    }
}