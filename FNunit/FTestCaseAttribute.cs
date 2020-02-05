namespace NUnit.Framework
{
    public class FTestCaseAttribute : TestCaseAttribute
    {
        public FTestCaseAttribute(params object[] arguments)
            : base (arguments)
        { }

        public FTestCaseAttribute(object arg)
            : base(arg)
        { }

        public FTestCaseAttribute(object arg1, object arg2)
            : base(arg1, arg2)
        { }

        public FTestCaseAttribute(object arg1, object arg2, object arg3)
            : base(arg1, arg2, arg3)
        { }
    }
}
