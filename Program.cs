/*
* Main objective => need to create a math game that has 4 operations
? features should include:
! 1.) Users should be presented with a menu to choose a operation
! 2.) You should record previous games in a List and there should be an option in the menu for the 
!     user to visualize a history of previous games.
! 3.) No need for a database; the history should be deleted after the program is terminated.
*/

namespace CSharpMath;

/// <summary>
/// The current branch of our program.
/// </summary>
public enum ProgramBranch : int
{
    Addition = 1,
    Subtraction = 2,
    Multiplication = 3,
    Division = 4,
    History = 5,
}

public class ProgramState
{
    public float Answer { get; set; }
    public int First { get; set; }
    public int Second { get; set; }
    public int Guess { get; set; }
    public string? MathemathicalExpression { get; set; }
    public ProgramBranch Branch { get; set; }
    public List<string> ProgramHistory { get; set; } = new();
}
class Program
{
    public static void PrintWelcome()
    {
        Console.WriteLine("What operation would you like to start? Choose from the options below.");
        Console.WriteLine(@"
        Addition: [1]
        Subtraction: [2]
        Multiplication: [3]
        Division: [4]
        History: [5]
        ");
    }
    public static void Main()
    {
        ProgramState state = new();

        while (true) { ShadowMain(state); }
    }
    public static void ShadowMain(ProgramState state)
    {
        int choice;
        while (true)
        {
            PrintWelcome();

            string? input = Console.ReadLine();
            input ??= "Error: Invalid";

            if (!int.TryParse(input.Trim(), out choice))
            {
                Console.WriteLine("Please input a number from the selection, not letters.");
                Thread.Sleep(1000);
                Console.Clear();
                continue;
            }
            break;
        }

        switch (choice)
        {
            case (int)ProgramBranch.Addition:
                Add(state);
                break;
            case (int)ProgramBranch.Subtraction:
                Subtract(state);
                break;
            case (int)ProgramBranch.Multiplication:
                Multiply(state);
                break;
            case (int)ProgramBranch.Division:
                Divide(state);
                break;
            case (int)ProgramBranch.History:
                if (state.ProgramHistory.Count is 0)
                {
                    Console.WriteLine("No History Found.");
                    break;
                }

                foreach (string ProgramHistory in state.ProgramHistory)
                {
                    Console.WriteLine(ProgramHistory);
                }
                break;
            default:
                Console.WriteLine("Please select a number from the selection above.");
                Main();
                break;
        }
        AfterMathemathicalEquation(state);
    }
    private static void AfterMathemathicalEquation(ProgramState state)
    {
        //! Checking if the answer is correct or not.
        float response;
        while (true)
        {
            Console.Write($"{state.MathemathicalExpression} = ");
            string? input = Console.ReadLine();
            input ??= "Error: Invalid";

            if (!float.TryParse(input.Trim(), out response))
            {
                Console.WriteLine("Please input a valid number, not letters or spaces.");
                Thread.Sleep(333);
                // Console.Clear();
                continue;
            }
            break;
        }

        //! Add the response of the user to the history.
        state.ProgramHistory.Add(response.ToString());

        if (response != state.Answer)
        {
            Console.WriteLine("Incorrect Answer");
            Console.WriteLine("To quit please hit enter");
            return;
        }
        else if (response == state.Answer)
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("To quit please hit enter");
            return;
        }
        else
        {
            Console.WriteLine("Please Answer the question.");
            Console.WriteLine("To quit please hit enter");
            return;
        }
        /*/!Determines where to go back to.
        if (state.Branch == ProgramBranch.Addition)
        {
            Add(state);
        }
        if (state.Branch == ProgramBranch.Subtraction)
        {
            Subtract(state);
        }
        if (state.Branch == ProgramBranch.Multiplication)
        {
            Multiply(state);
        }
        if (state.Branch == ProgramBranch.Division)
        {
            Divide(state);
        }
        //!storing the data as a list and adding the current itteration to it.
        //!making history*/
    }

    //!All the operation methods
    static void Add(ProgramState state)
    {
        state.First = Random.Shared.Next(1, 100);
        state.Second = Random.Shared.Next(1, 100);
        state.Answer = state.First + state.Second;
        state.MathemathicalExpression = $"{state.First} + {state.Second}";
        state.Branch = ProgramBranch.Addition;
    }
    static void Subtract(ProgramState state)
    {
        state.First = Random.Shared.Next(1, 100);
        state.Second = Random.Shared.Next(1, 100);
        state.Answer = state.First - state.Second;
        state.MathemathicalExpression = $"{state.First} - {state.Second}";
        state.Branch = ProgramBranch.Subtraction;
    }
    static void Multiply(ProgramState state)
    {
        state.First = Random.Shared.Next(1, 12);
        state.Second = Random.Shared.Next(1, 12);
        state.Answer = state.First * state.Second;
        state.MathemathicalExpression = $"{state.First} x {state.Second}";
        state.Branch = ProgramBranch.Multiplication;
    }
    static void Divide(ProgramState state)
    {
        state.First = Random.Shared.Next(1, 144);
        state.Second = Random.Shared.Next(1, 12);
        state.Answer = state.First / state.Second;
        state.MathemathicalExpression = $"{state.First} ÷ {state.Second}";
        state.Branch = ProgramBranch.Division;
    }
}
//make a loop for instances of state