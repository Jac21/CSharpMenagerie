namespace Synchronizer.Interfaces
{
    public class MySharedClass : IReadFromShared, IWriteToShared
    {
        string _foo;

        public string GetValue()
        {
            return _foo;
        }

        public void SetValue(string value)
        {
            _foo = value;
        }
    }
}
