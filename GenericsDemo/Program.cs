using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> stringList = new List<string>();
            //List<int> intList = new List<int>();
            //intList.Add(1);
            //list does not defined what type goes in here<> list of t.
            // can put anytype in there, but once we declare what the type is that's the type, it is strongly type now. meainign you can't put what ever you want in there
            // there's language with a concept of changign ariables overtime like javascript
            // string into variabeanfd later put nubmer ott it.
            // not so in a strongly typed language like c#.

            //string test = 1.ToString(); //not storing a number.
            //List<T> design time list can be anytype,. but now when declared, you can;t


            //benefits, same 1 list i defined, store done once can work all different types.
            //string[] testArray = //multiple types of arrays.
            //object[] test //inefficent because it converts

            //boxing and uboxing  
            // allos to strongly tpye something and use same list declaration./samelistdefinition for differnt ypes.

            //create own generrics.
            // can also return type T.
            //string result = FizzBuzz("tests");
            //Console.WriteLine($"{ result}");

            //result = FizzBuzz(123);
            //Console.WriteLine($"{result}");

            //result = FizzBuzz(true);
            //Console.WriteLine($"true: {result}");

            //result = FizzBuzz(new PersonModel { FirstName = "Earl", LastName = "Hernandez" });
            //Console.WriteLine($"PersonModel: {result}");

            GenericHelper<PersonModel> peopleHelper = new GenericHelper<PersonModel>();

            peopleHelper.CheckItemAndAdd(new PersonModel { FirstName = "Earl", HasError = true });

            foreach (var item in peopleHelper.RejectedItems)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} was rejected");
            }

            Console.ReadLine();
        }

        //more indpeth issue?
        // not using everyday. once in a whyle.


        //simple, very little to do here.
        // we are just saying use T as a type  
        //  when when you call the fizzbuzz you never said the type w
        // reason because it infers it..   
        private static string FizzBuzz<T>(T item)
        {
            //fiz buzz is gonna use 1 generic item,1 generic type.
            //T is convention, firs generic item tpye T. can be other letters.
            int itemLength = item.ToString().Length; //everything is an object therefore we can call the to string method
            string output = "";
            if (itemLength % 3 == 0)
            {
                output += "Fizz";
            }

            if (itemLength % 5 == 0)
            {
                output += "Buzz";
            }

            return output;

        }


           // 3 - fizz, 5- buzz, 3 & 5 - FizzBuz
    }

    public class GenericHelper<T> where T: IErrorCheck/*, new() */// they will have an empty contructor
    {
        public List<T> Items { get; set; } = new List<T>();
        public List<T> RejectedItems { get; set; } = new List<T>();

        public void CheckItemAndAdd(T item)
        {
            //T test = new T(); 
            if (item.HasError == false)
            {
                Items.Add(item);
            }
            else
            {
                RejectedItems.Add(item);
            }
        }
    }

    public interface IErrorCheck
    {
         bool HasError { get; set; }
    }

    public class CarMode : IErrorCheck
    {
        public string Manufacturer { get; set; }
        public int YearManufactured { get; set; }
        public bool HasError { get;  set; }
    }

    public class PersonModel : IErrorCheck
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool HasError { get; set; }

        //not every class has an empty constrcutro unless you  don't specify it. 
        //public PersonModel(string lastName)
        //{
        //        // thos this class doesnt have an empty constructor
        //}

    }



}
