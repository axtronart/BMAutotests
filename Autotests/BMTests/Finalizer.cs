﻿using BMAutotests.AppLogic;
using NUnit.Framework;

namespace BMTests
{
    [SetUpFixture]
    public class Finalizer
    {
        [TearDown]
        public void RunInTheEndOfAll()
        {
            WebDriverFactory.DismissAll();
        }
    }
}
