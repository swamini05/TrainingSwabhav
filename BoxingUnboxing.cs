class BoxingUnboxing
{
    static void Main()
    {
        int i = 123;
        object o = i;  
        try
        {
            int j = (int)o;  

            System.Console.WriteLine("Unboxing OK.");
        }
        catch (System.InvalidCastException e)
        {
            System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
        }
    }
}