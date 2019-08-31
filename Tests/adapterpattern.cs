using System.Reflection;
namespace hackertests.Tests
{
    // Adapter pattern helps two incompatible interfaces to
    // work together
    // Players in this pattern 
    // 1. ITarget 
    // 2. Client wants a specific interface
    // 3. Legacy system has an incompatible interface
    // 4. 
    public class adapterpattern
    {

    }

    public interface ITarget
    {
        void ClientRequiredMethod();
    }
    public class LegacySystem
    {
        public void legacyMethod()
        {
            System.Console.WriteLine($"legacy Method of legacy System called");
        }
    }
    // client want to call the legacy method but cannot do to legacy reasons
    public class AdapterClient : ITestProgram // new up the Adaptor
    {
        ITarget target;
        public AdapterClient()
        {
            target = new Adaptor();
        }
        public void RunTests()
        {
            System.Console.WriteLine($"Client calls the method on the ITarget or Adapter");
            target.ClientRequiredMethod();
        }
    }
    public class Adaptor : ITarget
    {
        public LegacySystem legacysystem;
        public Adaptor()
        {
            this.legacysystem = new LegacySystem();
        }
        public void ClientRequiredMethod()
        {
                  System.Console.WriteLine($"Adaptor implements the ITarget interface " + 
                  "and has access to the legacy system and able to make calls to it.");
            legacysystem.legacyMethod();
        }
    }
  
}