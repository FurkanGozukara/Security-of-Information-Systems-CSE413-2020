using System;
using System.IO;

namespace lecture_8___salted_password_hashing
{
    class Program
    {
     

        static void Main(string[] args)
        {
            Console.WriteLine("enter your password to register");
            string srUserRawPassword = Console.ReadLine();

            string srHashedPw = srUserRawPassword.returnHashedPw();

            File.WriteAllText("saltedpw.txt",srHashedPw);

            while(true)
            {

            Console.WriteLine("enter your password to login");

            string srLoginPw =  Console.ReadLine();

                Console.WriteLine("your entered password is: " + srLoginPw);

                Console.WriteLine("the salted hash of your password is " + srLoginPw.returnHashedPw());

                string srSavedHashedPw = File.ReadAllText("saltedpw.txt");

                Console.WriteLine("saved password hash is " + srSavedHashedPw);

                if(srSavedHashedPw== srLoginPw.returnHashedPw())
                {
                    Console.WriteLine("login success both hashes match");
                }
                else
                    Console.WriteLine("login fail wrong password");


                Console.WriteLine("click a key to continue");

                Console.ReadKey();
            }

        }

     
    }
}
