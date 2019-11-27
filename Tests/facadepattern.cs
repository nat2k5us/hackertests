using System.Reflection;
namespace hackertests.Tests
{
    // Facade pattern helps hide complexity of the system by providing an easy interface 
    // to access the system. Adds an simple interface to existing system to hide its complexities.
    
    // Players in this pattern 
    // 1. Complex system 
    // 2. Facade
    // 3. Client
    
   // 1. ################################# Complex System ##############################################
    public class ShoppingComplexShop
    {
        public ShoppingComplexShop()
        {
            System.Console.WriteLine($"ShoppingComplexShop constructor");
        }
        public void CreateShop()
        {
            System.Console.WriteLine("Created Shop");
        }
    }

     public class ShoppingComplexParking
    {
         public ShoppingComplexParking()
        {
            System.Console.WriteLine($"ShoppingComplexParking constructor");
        }

        public void AddParking()
        {
            System.Console.WriteLine("Added Parking");
        }
    }

     public class ShoppingComplexMaintaience
    {
        public ShoppingComplexMaintaience()
        {
            System.Console.WriteLine($"ShoppingComplexMaintaience constructor");
        }

        public void AddMaintainence()
        {
            System.Console.WriteLine("Added Maintainence");
        }
    }

    // 2. Facade 
    public class ShopComplexFacade
    {
     ShoppingComplexShop shoppingComplexShop {get; set;}
       ShoppingComplexParking shoppingComplexParking {get; set;}
       ShoppingComplexMaintaience shoppingComplexMaintaience {get; set;}

       public ShopComplexFacade()
       {
            shoppingComplexShop = new ShoppingComplexShop();
            shoppingComplexParking = new ShoppingComplexParking();
            shoppingComplexMaintaience = new ShoppingComplexMaintaience();
       }

       public void CreateCompleteShop()
       {
         shoppingComplexShop.CreateShop();
         shoppingComplexParking.AddParking();
         shoppingComplexMaintaience.AddMaintainence();
       }
    }

    // 3. client
    public class FacadeClient : ITestProgram
    {     
       ShopComplexFacade facade = new ShopComplexFacade();

        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.FacadeClient;
        }

        public void RunTests()
        {           
           facade.CreateCompleteShop();
        }
    }
}