namespace hackertests.Tests
{
    // Stragegy Pattern
    // Allows us to pick from a series of algorithms
    // Players in the Pattern
    // 1. Client - add the ICommutestrategy as interface and change to any of the stratagies
    // 2. Algorithm interface ( Commute to work - Personel car, uber, taxi, walk)
    // 3. Implementations of the Strategy
    // 
    public class StragegyDemo
    {

    }

    public interface ICommutestrategy
    {
        void CommuteToDestination();
    }

    public class Walk : ICommutestrategy
    {
        public void CommuteToDestination()
        {
            System.Console.WriteLine($"Commute by walking");
        }
    }

    public class PersonelCar : ICommutestrategy
    {
        public void CommuteToDestination()
        {
            System.Console.WriteLine($"Commute by My Car");
        }
    }

    public class UberCar : ICommutestrategy
    {
        public void CommuteToDestination()
        {
            System.Console.WriteLine($"Commute by Uber");
        }
    }

    public class LyftCar : ICommutestrategy
    {
        public void CommuteToDestination()
        {
            System.Console.WriteLine($"Commute by Lyft");
        }
    }

    public class StragetyClient
    {
        ICommutestrategy commutestrategy;

        public StragetyClient()
        {
            // default to commuting by personel car
            commutestrategy = new PersonelCar();
        }

        public void RunTests()
        {

            commutestrategy.CommuteToDestination(); // Personel Car default

            commutestrategy = new LyftCar();
            commutestrategy.CommuteToDestination();

            commutestrategy = new UberCar();
            commutestrategy.CommuteToDestination();

            commutestrategy = new Walk();
            commutestrategy.CommuteToDestination();
        }
    }
}