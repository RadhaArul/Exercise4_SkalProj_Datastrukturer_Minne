// See https://aka.ms/new-console-template for more information
class Program
{

    /* 1.How do the stack and heap work? Feel free to explain with an example 
     * or sketch of its basic function. 
     * Stack and Heap are two types of memory structures.
     * The stack is used for static memory allocation and is a simple last in first out structure. 
     * Variables allocated on the stack are stored directly to the memory and its allocation is done 
     * when the program is compiled. When a method is invoked, the CLR bookmarks the top of the stack 
     * and the method then pushes data onto the stack as it executes. When the method completes, 
     * the CLR resets the stack to its previous bookmark, popping all the method’s memory allocations.
     * 
     * whereas  the heap is used for dynamic memory allocation; i.e. objects are allocated 
     * at run time and we have to  worry about garbage collection.
     * 
     * The value type variables are stored in a stack whereas object reference type is stored in a heap.
     * *************************************************************************************************
     * 
     * 2.What are Value Types and Reference Types respectively and what distinguishes them?
     * There are four types that fall to the reference type category: String, Arrays, Class, Delegate
     * 
     * The rest of the types fall to the value type category: Bool, Byte, Char, Decimal, etc.
     * 
     * A Value Type holds the data within its own memory allocation whereas a reference type 
     * doesn't store its value directly. Instead, it stores the address where the value is being stored. 
     * In other words, a reference type contains a pointer to another memory location that holds the data. 
     * 
     * ***************************************************************************************************
     * 
     * 3. The following methods (see picture below) generate different answers. The first returns 3, 
     * the others return 4, why?
     * From the first method x=3, y=x The value of x's content is allocated on the stack. 
     * A single space in memory based on the type is reserved in memory, and this variable directly holds
     * the value. If we were to copy this value to another variable like y=x via an assignment, 
     * the value would be copied to y so you would have the value of x reserved twice 
     * on the stack, one for each variable. Thatswhy x return 3 in first method.
     * 
     * whereas in the second method we treat x and y as objects which means reference variable,
     * When we assign a reference variable to another, we do not copy the data. 
     * We simply tell that the new variable also references the original address. 
     * This means if we were to modify either of them, the change would be reflected on both 
     * since they point to the same location in memory. The reference type variables are stored
     * in a designated space in memory called heap. Thatswhy they return 4 in the second method.
     * 
     * *************************************************************************************************
     */

    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParanthesis " 
                + "\n5. Calculate nth Even Number by Recursion "
                + "\n6. Fibonacci Recursion"
                + "\n7. Calculate nth Even Number by Iteration"
                + "\n8. Fibonacci Iteration"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (input)
            {
                case '1':
                    ExamineList();
                    Console.ReadKey();
                    break;
                case '2':
                    ExamineQueue();
                    Console.ReadKey();
                    break;
                case '3':
                    ExamineStack();
                    Console.ReadKey();
                    break;
                case '4':
                    CheckParanthesis();
                    Console.ReadKey();
                    break;
                case '5':
                    {
                     Console.WriteLine("Which nth even number would you like to find");
                     Console.WriteLine("Enter the value for n");
                     int num =int.Parse(Console.ReadLine());
                     int result = RecursiveEven(num);
                        Console.WriteLine($"{num}th Even number is {result}");
                        Console.ReadKey();
                    break;
                    }
                case '6':
                    {
                     Console.WriteLine("Enter the length of Fibonacci Series");
                     int length=int.Parse(Console.ReadLine());
                     for (int i = 0; i < length; i++)
                        {
                            Console.Write("{0} ", fibonaccisekvensen(i));
                        }
                     Console.ReadKey();
                     break;
                    }
                    
                case '7':
                    {
                        Console.WriteLine("Which nth even number would you like to find");
                        Console.WriteLine("Enter the value for n");
                        int num = int.Parse(Console.ReadLine());
                        int result = IterativeEven(num);
                        Console.WriteLine($"{num}th Even number is {result}");
                        Console.ReadKey();
                        break;
                    }
                case '8':
                    {
                        Console.WriteLine("Enter the length of Fibonacci Series");
                        int length = int.Parse(Console.ReadLine());
                        for (int i = 0; i < length; i++)
                        {
                            Console.Write("{0} ", fibonacciberäknaren(i));
                        }
                        Console.ReadKey();
                        break ;
                    }
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
        }
    }

    

    /// <summary>
    /// Examines the datastructure List
    /// </summary>
    static void ExamineList()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */
        Console.Clear();
        bool repeat=true;
        List<string> theList = new List<string>();
        while (repeat) // repeat until user stop adding or removing
        {
            
            Console.WriteLine("\nEnter any input to Add or Remove use +sign to add and -sign " +
                "to remove form the ExamineList " +
                "\nEnter q to Exit from the ExamineList \nEnter your Input :");
            string input = Console.ReadLine();
            char nav = input[0];
            string value = input.Substring(1, input.Length - 1);

            switch (nav)
            {
                case '+': // Adding to the list
                {
                    theList.Add(value);
                    Console.WriteLine("The current List Contents are :");
                    foreach(var str in theList)
                       Console.WriteLine(str);
                    Console.WriteLine("\nThe List Count is : "+theList.Count);
                    Console.WriteLine("The Capasity of the List is: "+theList.Capacity);
                    break;
                }
                case '-': //removing from the list
                {
                    theList.Remove(value);
                        Console.WriteLine("The current List Contents are:");
                        foreach (var str in theList)
                            Console.WriteLine(str);
                        Console.WriteLine("\nThe List Count is : " + theList.Count);
                        Console.WriteLine("The Capasity of the List is: " + theList.Capacity);
                        break;
                }
                case 'q':
                    {
                        repeat=false;
                        break ;
                    }
                default:
                {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("Please enter only + or - to add or remove the input");
                        break;
                }

            }
        }
        /* 2. When does the list's capacity increase? (So ​​the size of the underlying array)
         * If the Count becomes equals to Capacity then the capacity of the List increases 
         * automatically by reallocating the internal array. The existing elements will be copied
         * to the new array before the addition of the new element.
         * *****************************************************************************
         * 3. By how much does the capacity increase?
         * Default capacity is 4 and if we add the 5th item then its capacity is doubled and would be 8 
         * and this goes on.
         * *************************************************************************
         * 4. Why does the capacity of the list not increase at the same rate as elements are added?
         * Count is always less than the Capacity. While adding the elements, if Count exceeds Capacity 
         * then the Capacity will increase automatically.
         **************************************************************************** 
         *  5. Does the capacity decrease when elements are removed from the list?
         *  Capacity won't decrease automatically but the user can decrease capacity by either calling 
         *  the TrimExcess method or explicitly setting the Capacity to a lower value.
         **********************************************************************************  
         *  6. When is it then advantageous to use a custom array instead of a list?
         *  If memory is not a constraint and if we do addition and deletion frequently then list is better option
         *  if momory is a constraint then array is a better option
         */
    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */
        Queue<string> queue = new Queue<string>();//creating a queue variable
        Console.Clear();
        bool repeat = true;
        while (repeat)
        {
            Console.WriteLine("At ICA supermarket what do you want to do");
            Console.WriteLine("1.Enqueue \n2.Dequeue \n3.Display the Queue \n4.Exit the Queue");
            Console.WriteLine("Enter your option :");
            string input =Console.ReadLine();
            switch(input)
            {
                case "1":
                    {
                        Console.WriteLine("Enter your name to add in the Queue");
                        string Name = Console.ReadLine();
                        queue.Enqueue(Name);
                        break;
                    }
                case "2":
                    {
                        if (queue.Count > 0)
                        {
                            queue.Dequeue();
                            Console.WriteLine("One people left the Queue");
                        }
                        else
                            Console.WriteLine("Queue is Empty");
                        
                        break ;
                    }
                case "3":
                    {
                        Console.WriteLine("People in the Queue are:");
                        foreach(Object obj in queue)
                        {
                            Console.WriteLine(obj.ToString());
                        }
                        break ;
                    }
                case "4":
                    {
                        repeat = false;
                        break ;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Input! Try Again");
                        break ;
                    }
            }
        }
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    static void ExamineStack()
    {
        /*
         * Loop this method until the user inputs something to exit to main menue.
         * Create a switch with cases to push or pop items
         * Make sure to look at the stack after pushing and and poping to see how it behaves
        */

        Console.Clear ();   
        Stack<string> stack = new Stack<string>();//creating a stack
        bool repeat = true;
        while(repeat)
        {
            Console.WriteLine("1.Push\n2.Pop\n3.Display the Stack \n4.ReverseText \n5.Exit");
            string input=Console.ReadLine();    
            switch( input)
            {
                case"1":
                    {
                        Console.WriteLine("Enter your name to add in the Stack");
                        string Name = Console.ReadLine();
                        stack.Push(Name);
                        break;
                    }
                 case"2":
                    {
                        if(stack.Count > 0)
                        {
                            stack.Pop();
                            Console.WriteLine("One Item left the Stack");
                        }
                        else
                            Console.WriteLine("Stack is Empty");
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Item in the Stack are");
                        foreach(Object o in stack)
                            Console.WriteLine(o.ToString());
                        break;
                    }
                case"4": // Reverse a Text Using Stack
                    {
                        Console.WriteLine("Enter any text to Reverse");
                        string AnyText = Console.ReadLine();    
                        char[] chars = AnyText.ToCharArray();
                        int size = chars.Length;
                        //stack st = new Stack(size);
                        Stack<char> st = new Stack<char>();
                        for(int i = 0; i < size; i++)
                            st.Push(chars[i]);
                        foreach(object o in st)
                            Console.Write(o.ToString());

                        Console.WriteLine();
                        break;
                    }
                case"5":
                    {
                        repeat=false;
                        break ;
                    }
                default :
                    {
                        Console.WriteLine("Invalid Input! Try Again");
                        break;
                    }

            }
        }
    }

    static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */
        //What data structure do you use?
        // I am used Stack data structure to check the paranthesis

        string Par;
        Console.WriteLine("Enter paranthesis to check");
        Par = Console.ReadLine();

        Stack<char> stack = new Stack<char>(); 
        bool StackCheck=true;
        char Top;
        for(int i=0;i<Par.Length;i++)
        {
            if(Par[i] == '(' ||Par[i] == '{' || Par[i]=='[')
            {
                stack.Push(Par[i]);
            }
            if(stack.Count==0)
            {
                StackCheck = false;
                break ;
            }
             switch(Par[i])
            {
                case ')':
                    {
                        Top = stack.Peek();
                        stack.Pop();
                        if(Top == '{' || Top == '[')
                            StackCheck = false;
                        break;
                    }
                case '}':
                    {
                        Top = stack.Peek();
                        stack.Pop();
                        if (Top == '(' || Top == '[')
                            StackCheck = false;
                        break;
                    }
                case ']':
                    {
                        Top = stack.Peek();
                        stack.Pop();
                        if (Top == '{' || Top == '(')
                            StackCheck = false;
                        break;
                    }
            }
        }
        if (StackCheck == true)
            Console.WriteLine("Given String is well formed");
        else
            Console.WriteLine("Given String is not well formed");
    }

    //1: Define a stack to hold brackets
    //2: Traverse the expression from left to right
    //3: If the character is opening bracket(, or { Or[, then push
    //   it into stack
    //4. if stack is empty then it is not well formed.
    //5: If the character is closing bracket ), }
    //   or ] Then pop from stack, and if the popped character is
    //   matched with the closing bracket then it is well formed.
    //   otherwise they are not well formed.

    /// <summary>
    /// Calculate nth Even number by Recurssion
    /// </summary>
    static int RecursiveEven(int n)
    {
        if(n == 1)
            return 0;
        else
            return (RecursiveEven(n-1)+2);
        //Input:1,2,3,4,5 then Output: 0,2,4,6,,8
    }
    /// <summary>
    /// Calculate nth Even number by Iteration
    /// </summary>

    private static int IterativeEven(int n)
    {
     if(n==1)   
        return 0;
        int res = 0;
        for (int i = 1; i <n; i++)
            res += 2;
        return res;
        //Input:1,2,3,4,5 then Output: 0,2,4,6,,8
    }

    /// <summary>
    /// Fibonacci Series by Recurssion
    /// </summary>
    static int fibonaccisekvensen(int n)
    {
        int Fnumber = 0, Snumber = 1, result = 0;
        if (n == 0) return 0; //it will return the first number of the series
        if (n == 1) return 1; // it will return the second number of the series
        return fibonaccisekvensen(n - 1) + fibonaccisekvensen(n - 2);
    }
    /// <summary>
    /// Fibonacci Series by Iteration
    /// </summary>
    static int fibonacciberäknaren(int n)
    {
        int Fnumber = 0, Snumber = 1, result = 0;
        if (n == 0) return 0; //It will return the first number of the series
        if (n == 1) return 1; // it will return  the second number of the series
        for (int i = 2; i <= n; i++)  
        {
            result = Fnumber + Snumber;
            Fnumber = Snumber;
            Snumber = result;
        }
        return result;
    }


    //Fråga:
    //Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering.Vilken av
    //ovanstående funktioner är mest minnesvänlig och varför
    // Iteration is more Memory Friendly because recurssion use more memory and the recurssion function
    // has to add to the stack with each recursive call and keep the values there until the call is finished,
    // the memory allocation is greater than that of an iterative function. Recursion can be slow.
}
