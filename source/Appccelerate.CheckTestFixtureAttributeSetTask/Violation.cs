// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Violation.cs" company="Appccelerate">
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
    using Appccelerate.IO;

    public struct Violation
    {
        public Violation(string message, AbsoluteFilePath filename)
            : this()
        {
            this.Message = message;
            this.Filename = filename;
        }

        public string Message { get; private set; }

        public AbsoluteFilePath Filename { get; private set; }
    }
}