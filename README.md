# FNunit
Force only marked tests to Run, like frontend libraries does. You can use `FTest` and `FTestCase` attributes to run only your marked test methods, based on NUnit. 

## How to use

Create a Global SetUp method (A method marked with `NUnit.Framework.SetUp` that will run before all tests. You can do it using Inheritance concepts). After that, call `FNunit.TestRunner.CheckIfShoudlRun()` as first action of SetUp method. With that you are able to mark test you like to force to run alone or together. There is a project with Samples what can be checked inside this repository.

**Take care to not commit your F-Tests! It is mainly to be used as development tool!**
