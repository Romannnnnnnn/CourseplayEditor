﻿using System;
using System.Collections.Generic;
using System.IO;
using CourseplayEditor.Tools.FarmSimulator;

namespace Courseplay.Tests.Tools
{
    public static class TestDataHelper
    {
        public static readonly string TestDataPath = Path.Combine(Environment.CurrentDirectory, "TestData");

        public static readonly IDictionary<FarmSimulatorVersion, string> VersionToDictionaryTestData=new Dictionary<FarmSimulatorVersion, string>
        {
            {FarmSimulatorVersion.FarmingSimulator2019, "v2019" },
            {FarmSimulatorVersion.FarmingSimulator2017, "v2017" },
        };

        public static string GetTestDataPath(FarmSimulatorVersion version)
        {
            return Path.Combine(TestDataPath, VersionToDictionaryTestData[version]);
        }
    }
}
