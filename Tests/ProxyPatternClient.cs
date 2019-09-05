namespace hackertests.Tests
{
    // Proxy Pattern
    // Players
    // 1. ISubject interface has operation on the Actual Subject as well as the proxy
    // 2. The actual subject and proxy are interchangeable
    // 

    public interface ISubject
    {
        void DoSomething();
    }

    // Actual subject implements ISubject
    public class ActualSubject : ISubject
    {
        public void DoSomething()
        {
            System.Console.WriteLine("ActualSubject: Handling the request (note this is NOT the proxy)");
        }
    }

    // 1. The Proxy implements the same interface as the Actual Subject
    // 2. The Proxy via constructor get the Actual Subject

    public class Proxy : ISubject
    {
        private ActualSubject _actualSubject;

        public Proxy(ActualSubject actualSubject)
        {
            this._actualSubject = actualSubject;
        }
        public void DoSomething()
        {
            System.Console.WriteLine("ActualSubject: Handling the request (note this is NOT the proxy)");
            _actualSubject.DoSomething();
        }
    }
    public class ProxyPatternClient : ITestProgram
    {
        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.ProxyPattern;
        }

        ISubject proxy {get;set;}
        public ProxyPatternClient()
        {
             // The client instantiates the actual subject and the proxy (the proxy takes the actual subject via
            // constructor. The client calls the underlying proxy method DoSomething, which in turn calls the 
            // actual subject method do something)
             ActualSubject realSubject = new ActualSubject();
            proxy = new Proxy(realSubject);
        }

        public void RunTests()
        {
            System.Console.WriteLine("Client calls the proxy's Method and Proxy in turn calls the underlying Actual Subject method");           
            proxy.DoSomething();
        }
    }
}